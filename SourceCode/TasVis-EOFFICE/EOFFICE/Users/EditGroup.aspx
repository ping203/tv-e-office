<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditGroup.aspx.cs" Inherits="EOFFICE.Users.EditGroup"
    MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="ContentUser">
    <div class="list" id="list-congvieccanlam">
        <h2>
            <span class="icon">
                <asp:Image ImageUrl="~/Images/Modify.png" runat="server" /></span>Cập nhật nhóm người
            dùng</h2>
        <table class="tbl-list" width="100%" cellspacing="1" cellpadding="3">
            <tr>
                <td align="left">
                    <table>
                        <tr>
                            <td align="right">
                                Tên nhóm:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtName" CssClass="required"></asp:TextBox>
                                <asp:Label Font-Bold="true" runat="server" ID="lblName" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Mô tả:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" CssClass="required"></asp:TextBox>
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
</asp:Content>
