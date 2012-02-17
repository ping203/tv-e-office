<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkAssignmentDetail.aspx.cs" Inherits="EOFFICE.Works.WorkAssignmentDetail" MasterPageFile="~/MasterPages/Default.Master" %>


<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">  
    <asp:ScriptManager ID="TheScriptManager" runat="server"></asp:ScriptManager>      
    <div class="list wp-form" id="WorkAssignment">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Công việc giao</h2>
                
                	<div class="nav-function">
                    	<ul>
                    	    <li><asp:Button runat="server" ID="btnThemXuLy" CssClass="btn" Text="Thêm xử lý" onclick="btnThemXuLy_Click" 
                                     ></asp:Button></li>
                        	<li><input type="reset" value="Hủy bỏ" class="btn" /></li>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
                        </ul>
                    </div>
                    <div class="form">
                        <table width="100%" cellpadding="5">
                            <tr>
                                <td class="style1" colspan="3">
                                    <asp:Label runat="server" Text="Tên công việc: "></asp:Label>
                                    <asp:Label runat="server" ID="lblName"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="Ngào tạo: "></asp:Label>
                                    <asp:Label runat="server" ID="lblNgayTao"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text="Ngày bắt đầu: "></asp:Label>
                                    <asp:Label runat="server" ID="lblNgayBatDau"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text="Ngày kết thúc: "></asp:Label>
                                    <asp:Label runat="server" ID="lblNgayKetThuc"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label runat="server" Text="Yêu cầu xử lý: "></asp:Label>
                                    <asp:Label runat="server" ID="lblYeuCau"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1">
                                    <asp:Label runat="server" Text="File kèm theo: "></asp:Label>
                                    
                                </td>
                                <%--<td colspan="2">
                                    <asp:Panel ID="pnlDownloads" runat="server">
                                    </asp:Panel>                                    
                                </td>--%>
                                <td colspan="2">
                                    <asp:Repeater ID="rptFiles" runat="server" OnItemCommand="rptItemCommand">
                                        <ItemTemplate>
                                            <p><asp:LinkButton ID="lblFileName" CommandName="Download" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Path") %>' Text='<%#DataBinder.Eval(Container.DataItem,"Name") %>' runat="server" Font-Overline="False" Font-Underline="True"></asp:LinkButton>&nbsp
                                            <asp:LinkButton ID="lblDeleteFile" runat="server" CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"AttachID") %>' Text="(Xóa)" OnClientClick="javascript:return confirm('Bạn chắc chắn muốn xóa file đính kèm?');" ForeColor="Red"></asp:LinkButton></p>
                                            
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <asp:Label runat="server" ID="lblThongBao" CssClass="rq"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                    <h2><span class="icon"><img src="../Images/Play.png" alt="Play.png" /></span>Danh sách người thực hiện công việc</h2>
                    <br />
                    <table width="100%" cellpadding="5">
                        <tr>
                            <td style="width:20%;vertical-align:top">Danh sách người thực hiện<br />
                                <asp:Repeater ID="rptListUser" runat="server" onitemcommand="rptListUser_ItemCommand">
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
                                    </Triggers>
                                    <ContentTemplate>
                                        Nội dung xử lý:
                                        <br />
                                        <asp:TextBox ID="txtContentComment" runat="server" CssClass="textarea" TextMode="multiline" Rows="10" ReadOnly="true"></asp:TextBox>
                                        <br />
                                        File báo cáo:<asp:Repeater ID="rptFileAttachs" runat="server" >
                                                        <ItemTemplate>
                                                            <p><asp:LinkButton ID="lblFileName" CommandName="Download" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Path") %>' Text='<%#DataBinder.Eval(Container.DataItem,"Name") %>' runat="server" Font-Overline="False" Font-Underline="True"></asp:LinkButton>&nbsp
                                                            </p>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                        <br />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
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
                                <asp:TextBox ID="txtContent" runat="server" CssClass="textarea required" TextMode="multiline" Rows="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:20%">
                                Báo cáo kèm theo (nếu có):
                            </td>
                            <td style="width:80%">
                                <asp:FileUpload ID="FileUpload1" runat="server" class="multi" /> &nbsp
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="width:20%">
                                Trạng thái công việc:
                            </td>
                            <td style="width:80%">
                                 <asp:RadioButton runat="server" Checked="true" ID="rdoHoanThanh" Text="Hoàn thành" GroupName="rdoTrangThai"/>
                                &nbsp <asp:RadioButton runat="server" ID="rdoTamDung" Text="Tạm dừng" GroupName="rdoTrangThai"/>
                                &nbsp <asp:RadioButton runat="server" ID="rdoTiepTuc" Text="Tiếp tục xử lý" GroupName="rdoTrangThai"/>
                                &nbsp &nbsp <asp:LinkButton CssClass="link-btn" runat="server" 
                                     Text="Cập nhật trạng thái" ID="btnCapNhat" onclick="btnCapNhat_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    </div>
                    <div class="nav-function">
                    	<ul>
                    	    <li><asp:Button runat="server" ID="Button1" CssClass="btn" Text="Thêm xử lý" onclick="btnThemXuLy_Click" 
                                     ></asp:Button></li>
                        	<li><input type="reset" value="Hủy bỏ" class="btn" /></li>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
                        </ul>
                    </div>
                    
            </div>
 <script type="text/javascript">

     function SelectAll(id) {

         var frm = document.forms[0];

         for (i = 0; i < frm.elements.length; i++) {

             if (frm.elements[i].type == "checkbox") {

                 frm.elements[i].checked = document.getElementById(id).checked;
             }
         }
     } 
    </script>    
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style1
        {
            height: 28px;
        }
    </style>

</asp:Content>

