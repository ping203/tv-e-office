﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="EOFFICE.Users.Edit"
    MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="ContentUser">
    <div class="list" id="list-createuser">
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
                                <asp:TextBox runat="server" ID="txtUsername" CssClass="txt required"></asp:TextBox>
                                <asp:Label Font-Bold="true" runat="server" ID="lblUsername" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_mk">
                            <td align="right">
                                Mật khẩu:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="txt required password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_cmk">
                            <td align="right">
                                Xác nhận mật khẩu:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" CssClass="txt required confirm_password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Họ và tên:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtFullName" CssClass="txt required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Email:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="txt email required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Số di động:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtPhoneNumber" CssClass="txt required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Số máy bàn:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtTel" CssClass="txt required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Giới tính:
                            </td>
                            <td>
                                <asp:DropDownList runat="server" id="ddlGender">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Ngày sinh:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtBirthDay" CssClass="txt required datepicker"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Địa chỉ:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtAddress" CssClass="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Vị trí:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtPossition" CssClass="txt required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Trạng thái:
                            </td>
                            <td>
                                <asp:DropDownList runat="server" id="ddlStatus">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Phòng ban:
                            </td>
                            <td>
                                <asp:DropDownList runat="server" id="ddlDepartment" DataValueField="DepartmentID" DataTextField="Name">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td align="right">
                                Nhóm người dùng:
                            </td>
                            <td>
                                <asp:DropDownList runat="server" id="ddlGroup" DataValueField="GroupID" DataTextField="Name">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:LinkButton runat="server" ID="lnkUpdate" CssClass="link-btn" 
                                    OnClientClick="javascript:return $('form').valid();" 
                                    onclick="lnkUpdate_Click">Cập nhật</asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lnkBack" CssClass="link-btn" 
                                    onclick="lnkBack_Click">Quay lại</asp:LinkButton>
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
