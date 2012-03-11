<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS.aspx.cs" Inherits="EOFFICE.Calendar.SMS" MasterPageFile="../MasterPages/Default.Master" %>

<asp:Content ID="ctnSMS" ContentPlaceHolderID="cphContent" runat="server">
    <div class="list wp-form" id="WorkAssignment">
        <h2><span class="icon"><img src="../Images/icon-sms.png" /></span>Gửi tin nhắn nhắc việc</h2>
        <div class="form">
            <table>
                <tr>
                    <td>Nội dung:</td>
                    <td>
                        <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" MaxLength="146" CssClass="txtcontentsms textarea required" Width="300" Height="100" ></asp:TextBox>
                        Ký tự còn lại: <label id="lblChar">146</label>
                    </td>
                </tr>
                <tr>
                    <td>Người thực hiện:</td>
                    <td>
                        <form name="orderform">
                            <asp:Repeater ID="rptDepartment" runat="server">
                                <HeaderTemplate><table></HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <div class="link-department">
                                                <a href='<%#Request.Url.Host %>' class="lbtDepartmentCreate" id='<%#Eval("DepartmentID") %>' style="font-weight:bold">
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
                            <asp:HiddenField ID="hdfUsers" runat="server" />
                        </form>
                    </td>
                </tr>                    
                <tr><td></td><td><asp:Button ID="btnSend" runat="server" Text="Gửi SMS" OnClientClick='return get_check_value();' CssClass="link-btn" OnClick="btnSend_Click" /></td></tr>
            </table>
            
        </div>
    </div>
</asp:Content>