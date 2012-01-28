<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="EOFFICE.Users.UserInfo" MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">  
          
    <div class="list wp-form" id="WorkAssignment">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Thông tin cá nhân</h2>
                
                	<div class="nav-function">
                    	<ul>
                    	    <li><asp:Button runat="server" ID="btnCapNhat" CssClass="btn" Text="Cập nhật" 
                                    ></asp:Button></li>
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
                                
                            </tr>
                        </table>
                        <br />
                    </div>
                    <div class="nav-function">
                    	<ul>
                    	    <li><asp:Button runat="server" ID="btnCapNhat2" CssClass="btn" Text="Cập nhật" 
                                    ></asp:Button></li>
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
