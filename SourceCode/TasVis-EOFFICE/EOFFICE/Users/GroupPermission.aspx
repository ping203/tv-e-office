<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupPermission.aspx.cs"
    Inherits="EOFFICE.Users.GroupPermission" MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="ContentUser">
    <div class="list" id="list-congvieccanlam">
        <h2>
            <span class="icon">
                <asp:Image ImageUrl="~/Images/People.png" runat="server" /></span>Phân quyền
            cho nhóm :
            <asp:Label runat="server" ID="lblGroupName"></asp:Label></h2>
        <table class="tbl-list" width="100%" cellspacing="1" cellpadding="3">
            <tr>
                <td>
                    <asp:DropDownList runat="server" ID="ddlAction">
                        <asp:ListItem Text="Cập nhật quyền" Value="Update"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:LinkButton runat="server" ID="lnkAccept" CssClass="link-btn" OnClick="lnkAccept_Click"
                        OnClientClick="javascript:return ValidCheckedGroup();">Thực hiện</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lnkReturn" CssClass="link-btn" OnClick="lnkReturn_Click">Quay lại</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:GridView ID="grvPermisionDefinition" runat="server" AutoGenerateColumns="False"
                        CssClass="tbl-list" Width="100%" OnRowCommand="grvPermisionDefinition_RowCommand"
                        DataKeyNames="ID">
                        <Columns>
                            <asp:TemplateField HeaderText="Chọn quyền">
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" CssClass="chkGroupCheck" ID="chkCheckGroup" Checked='<%#CheckHasPermission(Eval("ID")) %>'/>
                                    <asp:HiddenField runat="server" ID="hdfGroupId" Value='<%#Eval("ID") %>' />
                                </ItemTemplate>
                                <ItemStyle Width="3%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mã quyền">
                                <ItemTemplate>
                                    <%#Eval("Code") %>
                                </ItemTemplate>
                                <ItemStyle Width="200px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tên quyền">
                                <ItemTemplate>
                                    <%#Eval("Name") %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle ForeColor="#0072BC" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <div class="pagenav">
        </div>
    </div>

    <script type="text/javascript">
     function ValidCheckedGroup() {
        if ($(".chkGroupCheck input:checked").length == 0) {
            alert("Vui lòng chọn nhóm người dùng cần thao tác");
            return false;
        }
        return confirm('Bạn chắc chắn muốn thực hiện thao tác này?');
    }
    $(document).ready(function() {
        $('#chkCheckGroupAll').bind('click', function() {
            if ($("#chkCheckGroupAll").attr('checked') == 'checked') {
                $(".chkGroupCheck").attr('checked', 'checked');
            }
            else {
                $(".chkGroupCheck").attr('checked', false);
            }
        });
    });
    </script>

</asp:Content>
