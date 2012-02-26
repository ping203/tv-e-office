<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkReceivedDetail.aspx.cs" Inherits="EOFFICE.Works.WorkReceivedDetail" MasterPageFile="~/MasterPages/Default.Master" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">  
   <asp:ScriptManager ID="TheScriptManager" runat="server"></asp:ScriptManager>
   <telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanel1"></telerik:RadAjaxLoadingPanel>
   <div class="list wp-form" id="WorkAssignment">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Công việc nhận</h2>
                
                	<div class="nav-function">
                    	<ul>
                    	    <li><asp:Button runat="server" ID="btnCapNhat" CssClass="btn" Text="Cập nhật" OnClientClick='return get_check_value();'
                                    onclick="btnCapNhat_Click"></asp:Button></li>
                        	<li><input type="reset" value="Hủy bỏ" class="btn" /></li>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
                        </ul>
                    </div>
                    <div class="form">
                        <table width="100%" cellpadding="5">
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label1" runat="server" Text="Tên công việc: "></asp:Label>
                                    <asp:Label runat="server" ID="lblName"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label7" runat="server" Text="Người tạo việc: "></asp:Label>
                                    <asp:Label runat="server" ID="lblUserCreate"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Ngào tạo: "></asp:Label>
                                    <asp:Label runat="server" ID="lblNgayTao"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Ngày bắt đầu: "></asp:Label>
                                    <asp:Label runat="server" ID="lblNgayBatDau"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Ngày kết thúc: "></asp:Label>
                                    <asp:Label runat="server" ID="lblNgayKetThuc"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label5" runat="server" Text="Yêu cầu xử lý: "></asp:Label>
                                    <asp:Label runat="server" ID="lblYeuCau"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1">
                                    <asp:Label ID="Label6" runat="server" Text="File kèm theo: "></asp:Label>
                                    
                                </td>
                               
                                <td colspan="2">
                                    
                                    <asp:Repeater ID="rptFiles" runat="server" OnItemCommand="rptItemCommand" >
                                        <ItemTemplate>
                                            <p><asp:LinkButton ID="lblFileName" CommandName="Download" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Path") %>' Text='<%#DataBinder.Eval(Container.DataItem,"Name") %>' runat="server" Font-Overline="False" Font-Underline="True"></asp:LinkButton>&nbsp
                                            </p>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <asp:Label runat="server" ID="lblThongBao" CssClass="rq"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                    <h2><span class="icon"><img src="../Images/Play.png" alt="Play.png" /></span>Danh sách người cùng thực hiện</h2>
                    <br />
                    <table width="100%" cellpadding="5">
                        <tr>
                            <td style="width:20%;vertical-align:top">
                                Danh sách người thực hiện:<br />
                                <asp:HiddenField runat="server" ID="hdfUserJoin" />
                                <asp:Repeater ID="rptListUser" runat="server" 
                                    onitemcommand="rptListUser_ItemCommand">
                                    <ItemTemplate>
                                        <img src="../Images/user.png" alt="" />
                                        <asp:LinkButton ID="btnLoad" runat="server" Text='<%#Eval("FullName") %>' CommandName="trigger"></asp:LinkButton>
                                        <asp:HiddenField ID="hdfID" runat="server" Value='<%#Eval("UserName") %>' />
                                        <br />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                            <td style="width:80%">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="conditional">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="rptListUser" />
                                        <asp:PostBackTrigger ControlID="rptFileAttachs" />
                                    </Triggers>
                                    <ContentTemplate>
                                        Nội dung xử lý:
                                        <br />
                                        <div id="ContentCommentDiv" style="height:300px; overflow-y:auto;width:600px;border:solid 1px #0072BC;margin-bottom:20px;overflow-x: hidden;">
                                            <asp:Repeater runat="server" ID="rptComment">
                                                <HeaderTemplate>
                                                    <ul class="item_comment">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <li>
                                                        <p><img alt="img" style="vertical-align: middle;" src="../Images/arrow.png" /> Thời gian xử lý: <%#BindTime(DataBinder.Eval(Container.DataItem, "CommentID").ToString())%></p>
                                                        <p class="comment_content">
                                                            <%#DataBinder.Eval(Container.DataItem, "Content")%>
                                                        </p>
                                                        <br />
                                                    </li>
                                                </ItemTemplate>                                                
                                                <FooterTemplate></ul></FooterTemplate>
                                            </asp:Repeater>
                                        </div>      
                                        File báo cáo:<asp:Repeater ID="rptFileAttachs" runat="server" 
                                            onitemcommand="rptFileAttachs_ItemCommand"  >
                                                        <ItemTemplate>
                                                            <p><asp:LinkButton ID="lblFileName" CommandName="Download" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Path") %>' Text='<%#DataBinder.Eval(Container.DataItem,"Name") %>' runat="server" Font-Overline="False" Font-Underline="True"></asp:LinkButton>&nbsp
                                                            </p>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:Label runat="server" ID="lblTest"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <h2><span class="icon"><img src="../Images/Play.png" alt="Play.png" /></span>Thêm ý kiến xử lý của tôi</h2>    
                    <br />
                    <table cellpadding="5" width="100%">
                        <tr>
                            <td style="width:20%">
                                Nội dung:<span class="rq">*</span>
                            </td>
                            <td style="width:80%">
                                <asp:TextBox ID="txtContent" runat="server" TextMode="multiline" Rows="10" CssClass="textarea required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                Báo cáo kèm theo (nếu có):
                            </td>
                            <td colspan="4">
                                <asp:FileUpload ID="FileUpload1" runat="server" class="multi" /> 
                            </td>
                        </tr>
                        <tr>
                            <td><b>Chuyển tiếp:</b></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div>                                                                    
                                    <asp:Repeater ID="rptDepartment" runat="server">
                                        <HeaderTemplate><table></HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <div class="link-department">
                                                        <a href='<%#Request.Url.Host %>' class="lbtDepartmentAjax" id='<%#Eval("DepartmentID") %>' style="font-weight:bold">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/expand.png" ImageAlign="AbsMiddle" />
                                                            <%#Eval("Name") %>
                                                        </a>
                                                    </div>
                                                    <div class='result-<%#Eval("DepartmentID") %>' style="margin-left:30px;margin-top:5px"></div>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate></table></FooterTemplate>
                                    </asp:Repeater>                                                                    
                                </div>
                            </td>
                            
                        </tr>
                    </table>                  
                    <asp:HiddenField ID="hdfUsers" runat="server" />
                    </div>
                    <div class="nav-function">
                    	<ul>
                    	    <li><asp:Button runat="server" ID="btnCapNhat2" CssClass="btn" Text="Cập nhật" OnClientClick='return get_check_value();'
                                   onclick="btnCapNhat_Click"  ></asp:Button></li>
                        	<li><input type="reset" value="Hủy bỏ" class="btn" /></li>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
                        </ul>
                    </div>
                    
            </div>
   
<script type="text/javascript">
    $(document).ready(function() {
        $("#listUserProcess").hide();
        $("#btnHide").click(function() {
            $("#listUserProcess").slideToggle("slow");
        });
    });
</script>

</asp:Content>
