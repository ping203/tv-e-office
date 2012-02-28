<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentEdit.aspx.cs" Inherits="EOFFICE.DocumentEdit"
    MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="ContentUser">
    <div class="list" id="list-congvieccanlam">
        <h2>
            <span class="icon">
                <asp:Image ImageUrl="~/Images/Modify.png" runat="server" /></span>Cập nhật công văn</h2>
        <table class="tbl-list" width="100%" cellspacing="1" cellpadding="3">
            <tr>
                <td align="left">
                    <table>
                        <tr>
                            <td align="right">
                                Số văn bản:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtUsername" CssClass="required"></asp:TextBox>
                                <asp:Label Font-Bold="true" runat="server" ID="lblUsername" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_mk">
                            <td align="right">
                                Tên văn bản:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtPassword" TextMode="MultiLine" CssClass=" required password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr runat="server" id="tr_cmk">
                            <td align="right">
                               Nội dung: 
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtConfirmPassword"  TextMode="MultiLine"  TextMode="Password" CssClass="required confirm_password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Ngày xuất bản:
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
                            </td>ss
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
                                <asp:DropDownList runat="server" id="ddlGender">
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
                                Địa chỉ:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtAddress"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Vị trí:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtPossition" CssClass="required"></asp:TextBox>
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
                        <tr>
                            <td align="right">
                                Nhóm người dùng:
                            </td>
                            <td>
                                <asp:DropDownList runat="server" id="ddlGroup" DataValueField="GroupID" DataTextField="Name">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:LinkButton runat="server" ID="lnkUpdate" CssClass="link-btn" 
                                    OnClientClick="javascript:return $('form').valid();" 
                                    onclick="lnkUpdate_Click">Cập nhật</asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lnkBack" CssClass="link-btn" 
                                    onclick="lnkBack_Click">Quay lại</asp:LinkButton>
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
