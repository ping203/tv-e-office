<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Person.aspx.cs" Inherits="EOFFICE.Users.Person"
    MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="ContentUser">
    <div class="list" id="list-congvieccanlam">
        <h2>
            <span class="icon">
                <asp:Image ImageUrl="~/Images/People.png" runat="server" /></span>Quản lý người
            thông tin người dùng</h2>
        <table class="tbl-list" width="100%" cellspacing="1" cellpadding="3">
            <tr>
                <td align="left">
                    <div style="border-bottom: 3px solid #06C; height: 19px">
                        <asp:LinkButton runat="server" ID="lbtChangedInfo" CssClass="link-btn">Cập nhật thông tin</asp:LinkButton>
                        <asp:LinkButton runat="server" ID="lbtChangedPassword" CssClass="link-btn">Thay đổi mật khẩu</asp:LinkButton>
                    </div>
                    <!--Cập nhật password-->
                    <asp:Panel runat="server" ID="pnUpdatePassword">
                        <table>
                        <tr>
                            <td>
                                Nhập mật khẩu hiện tại:
                            </td>
                            <td>
                            <asp:TextBox runat="server" ID="txtCurrentPassword" Width="150px" MaxLength="30" CssClass="required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nhập mật khẩu mới:
                            </td>
                            <td>
                            <asp:TextBox runat="server" ID="txtNewPassword" Width="150px" MaxLength="30" CssClass="required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Xác nhận mật khẩu mới:
                            </td>
                            <td>
                            <asp:TextBox runat="server" ID="txtConfirmNewPassword" Width="150px" MaxLength="30" CssClass="required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:LinkButton runat="server" ID="LinkButton1" CssClass="link-btn" OnClientClick="javascript:return $('form').valid();">Thay đổi mật khẩu</asp:LinkButton>
                            </td>
                        </tr>
                        </table>
                    </asp:Panel>
                    <!--Cập nhật Info-->
                    <asp:Panel runat="server" ID="pnUpdateInfo">
                    
                    </asp:Panel>
                </td>
            </tr>
        </table>
        
    </div>
</asp:Content>
