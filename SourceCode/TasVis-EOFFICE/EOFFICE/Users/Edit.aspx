<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="EOFFICE.Users.Edit"
    MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="ContentUser">
    <div class="list" id="list-congvieccanlam">
        <h2>
            <span class="icon">
                <asp:Image ImageUrl="~/Images/Modify.png" runat="server" /></span>Cập nhật người
            dùng</h2>
        <table class="tbl-list" width="100%" cellspacing="1" cellpadding="3">
            <tr>
                <td align="left">
                    <table>
                        <tr>
                            <td align="right">
                                Tài khoản:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtUsername" CssClass="required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Mật khẩu:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass=" required password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Xác nhận mật khẩu:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" CssClass="required confirm_password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Họ và tên:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtFullName" CssClass="required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Email:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="email required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Số di động:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtPhoneNumber" CssClass="required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Số máy bàn:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtTel" CssClass="required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Giới tính:
                            </td>
                            <td>
                                <asp:DropDownList runat="server" id="drdGender">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Ngày sinh:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtBirthDay" CssClass="required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Phòng ban:
                            </td>
                            <td>
                                <asp:DropDownList runat="server" id="drdDepartment" DataValueField="DepartmentID" DataTextField="Name">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Nhóm người dùng:
                            </td>
                            <td>
                                <asp:DropDownList runat="server" id="drdGroup" DataValueField="GroupID" DataTextField="Name">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:LinkButton runat="server" ID="lnkUpdate" CssClass="link-btn" 
                                    OnClientClick="javascript:return $('form').valid();" 
                                    onclick="lnkUpdate_Click">Cập nhật</asp:LinkButton>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <script language="javascript" type="text/javascript">
        	$(document).ready(function(){
		$("#<%=txtBirthDay.ClientID%>").datepicker();
	});
    </script>
</asp:Content>
