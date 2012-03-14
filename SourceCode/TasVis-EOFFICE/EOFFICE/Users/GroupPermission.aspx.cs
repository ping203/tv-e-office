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
    public partial class GroupPermission : System.Web.UI.Page
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
        /// Nhóm người dùng
        /// </summary>
        public int GroupId
        {
            get
            {
                if (Request.QueryString["GroupId"] != null)
                {
                    try
                    {
                        return int.Parse( Request.QueryString["GroupId"]);
                    }
                    catch (Exception ex)
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion

        #region "Common Function"


        /// <summary>
        /// Bind danh sách quyền trên hệ thống
        /// </summary>
        private void BindData()
        {
            BUser ctlUP = new BUser();
            if (!Global.IsAdmin())
                Response.Redirect("/permission-fail.aspx");
            BPermisionDefinition ctl = new BPermisionDefinition();
            grvPermisionDefinition.DataSource = ctl.Get(0,"","");
            grvPermisionDefinition.DataBind();

        }

        /// <summary>
        /// Load thông tin nhóm người dùng
        /// </summary>
        private void BindGroup()
        {
            if (GroupId>0)
            {
                BGroup ctl = new BGroup();
               IList< OGroup> obj;
                obj = ctl.Get(GroupId);
                if (obj != null)
                {
                    lblGroupName.Text = obj[0].Name;
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


        /// <summary>
        /// Kiểm tra quyền của nhóm người dùng
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool CheckHasPermission(object ID)
        {
            BGroupPermission ctl = new BGroupPermission();
            OGroupPermission obj = new OGroupPermission();
            obj.GroupId = GroupId;
            obj.PermissionDefinitionId = int.Parse(ID.ToString());
            //--- Kiểm tra quyền
            IList<OGroupPermission> lst;
            lst = ctl.Get(obj);
            return (lst != null && lst.Count > 0);
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
                BindGroup();
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
                //-- Cập nhật quyền cho nhóm người dùng
                case "Update":
                    BGroupPermission ctl = new BGroupPermission();
                    OGroupPermission obj = new OGroupPermission();

                    Dictionary<int, int> dnr = new Dictionary<int, int>();
                    ArrayList arrNewPermission = new ArrayList();
                    foreach (GridViewRow r in grvPermisionDefinition.Rows)
                    {
                        CheckBox chk = (CheckBox)r.FindControl("chkCheckGroup");
                        HiddenField hdfGroupId = (HiddenField)r.FindControl("hdfGroupId");
                        if (chk.Checked)
                        {
                            obj = new OGroupPermission();
                            obj.PermissionDefinitionId = int.Parse(hdfGroupId.Value);
                            obj.GroupId = GroupId;
                            IList<OGroupPermission> lst;
                            lst = ctl.Get(obj);
                            if (lst.Count < 1)
                            {
                                ctl.Add(obj);
                            }
                        }
                        else
                        {
                            obj = new OGroupPermission();
                            obj.PermissionDefinitionId = int.Parse(hdfGroupId.Value);
                            obj.GroupId = GroupId;
                            IList<OGroupPermission> lst;
                            lst = ctl.Get(obj);
                            if (lst.Count >0)
                            {
                                ctl.Delete(obj);
                            }
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
        protected void grvPermisionDefinition_RowCommand(object sender, GridViewCommandEventArgs e)
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

        /// <summary>
        /// Quay về trang quản trị người dùng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Users/Group.aspx");
        }
        #endregion



    }
}
