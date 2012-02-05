using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DataAccess.Common;
using DataAccess.BusinessObject;
using DataAccess.DataObject;
using System.Collections.Generic;

namespace EOFFICE.Users
{
    public partial class GroupForUser : System.Web.UI.Page
    {
        #region "Propertys"
        /// <summary>
        /// Mã user
        /// </summary>
        public int UserId
        {
            get
            {
                if (ViewState["MyUserId"] != null)
                {
                    try
                    {
                        return int.Parse(ViewState["MyUserId"].ToString());
                    }
                    catch (Exception ex)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            set {
                ViewState["MyUserId"] = value;
            }
        }

        /// <summary>
        /// Tài khoản
        /// </summary>
        public string Username
        {
            get
            {
                if (Request.QueryString["username"] != null)
                {
                    try
                    {
                        return Request.QueryString["username"];
                    }
                    catch (Exception ex)
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
        }
        #endregion

        #region "Common Function"

        /// <summary>
        /// Bind danh sách người dùng theo nhóm
        /// </summary>
        private void BindData()
        {
            BGroup ctl = new BGroup();
            OGroup obj = new OGroup();
            grvListUserGroups.DataSource = ctl.Get("","Desc","GroupId");
            grvListUserGroups.DataBind();

        }

        /// <summary>
        /// Load thông tin người dùng
        /// </summary>
        private void BindUser()
        {
            if (Username != "")
            {
                BUser ctl = new BUser();
               IList< OUser> obj;
                obj = ctl.Get(Username);
                if (obj != null)
                {
                    lblUsername.Text = Username;
                    UserId = obj[0].UserID;
                }
            }
        }

        /// <summary>
        /// Kiểm tra xem User có thuộc nhóm hay không
        /// </summary>
        /// <param name="GroupId"></param>
        /// <returns></returns>
        public bool CheckHasRole(object GroupId)
        {
            BUserGroup ctl = new BUserGroup();
            OUserGroup obj=new OUserGroup();
            obj.IDUser = UserId;
            obj.IDGroup = int.Parse(GroupId.ToString());
            //--- Kiểm tra quyền
            IList<OUserGroup> lst;
            lst = ctl.Get(obj);
            return (lst != null && lst.Count>0);
        }

        #endregion

        #region "Events"


        /// <summary>
        /// Load data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //-- Load thông tin người dùng
                BindUser();
                //-- Load danh sách quyền
                BindData();
            }
        }


        /// <summary>
        /// Thực hiện thao tác
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkAccept_Click(object sender, EventArgs e)
        {
            switch (ddlAction.SelectedValue)
            {
                //-- Cập nhật quyền cho người dùng
                case "Update":
                    //-- Thực hiện xóa người dùng
                    BUserGroup ctl = new BUserGroup();
                    OUserGroup obj = new OUserGroup();
                    //obj.IDUser = UserId;
                    //obj.IDGroup = 0;
                    ////--- Kiểm tra quyền
                    //IList<OUserGroup> lst;
                    //lst = ctl.Get(obj);
                    Dictionary<int, int> dnr = new Dictionary<int, int>();
                    ArrayList arrNewPermission = new ArrayList();
                    foreach (GridViewRow r in grvListUserGroups.Rows)
                    {
                        CheckBox chk = (CheckBox)r.FindControl("chkCheckGroup");
                        HiddenField hdfGroupId = (HiddenField)r.FindControl("hdfGroupId");
                        if (chk.Checked)
                        {
                            obj = new OUserGroup();
                            obj.IDGroup = int.Parse(hdfGroupId.Value);
                            obj.IDUser = UserId;
                            IList<OUserGroup> lst;
                            lst = ctl.Get(obj);
                            dnr.Add(obj.IDGroup, obj.IDGroup);
                            if (lst.Count < 1)
                            {
                                ctl.Add(obj);
                            }
                        }
                    }
                    obj = new OUserGroup();
                    obj.IDGroup = 0;
                    obj.IDUser = UserId;
                    IList<OUserGroup> lstOfUser;
                    lstOfUser = ctl.Get(obj);
                    foreach (OUserGroup IObj in lstOfUser)
                    {
                        if (!dnr.ContainsKey(IObj.IDGroup))
                        {
                            ctl.Delete(IObj);
                        }
                    }
                    //-- Load lại người dùng
                    BindData();
                    break;
            }
        }

        /// <summary>
        /// Sự kiện xảy ra khi thực hiện các thao tác trên danh sách người dùng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvListGroups_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //-- Xóa nhóm người dùng
            if (e.CommandName.Equals("cmdDelete", StringComparison.OrdinalIgnoreCase))
            {
                BGroup ctl = new BGroup();
                try
                {
                    //-- THực hiện xóa nhóm người dùng
                    ctl.Delete(int.Parse((e.CommandArgument.ToString())));
                    //--Load lại danh sách nhóm người dùng
                    BindData();
                }
                catch (Exception ex)
                {
                    //--Load lại danh sách nhóm người dùng
                    BindData();
                }
            }
            //--Cập nhật nhóm người dùng
            else if (e.CommandName.Equals("cmdEdit", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("EditGroup.aspx?GroupId="+e.CommandArgument.ToString());
            }

        }
        #endregion


    }
}
