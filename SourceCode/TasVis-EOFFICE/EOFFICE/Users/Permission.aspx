<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Permission.aspx.cs" Inherits="EOFFICE.Users.Permission"
    MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="ContentUser">
    <div class="list" id="list-congvieccanlam">
        <h2>
            <span class="icon">
                <asp:Image ImageUrl="~/Images/People.png" runat="server" /></span>Quản trị danh sách quyền: </h2>
        <table class="tbl-list" width="100%" cellspacing="1" cellpadding="3">
            <tr>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:GridView ID="grvListPermission" runat="server" AutoGenerateColumns="False" CssClass="tbl-list"
                        Width="100%" OnRowCommand="grvListGroups_RowCommand" DataKeyNames="GroupId">
                        <Columns>                          
                             <asp:TemplateField HeaderText="Chọn quyền">
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" CssClass="chkGroupCheck" ID="chkCheckGroup" Checked='<%#CheckHasRole(Eval("GroupId")) %>'/>
                                    <asp:HiddenField runat="server" ID="hdfGroupId" Value='<%#Eval("GroupId") %>' />
                                </ItemTemplate>
                                <ItemStyle Width="3%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quyền">
                                <ItemTemplate>
                                    <%#Eval("Name") %>
                                </ItemTemplate>
                                <ItemStyle Width="20%" HorizontalAlign="Center" />
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
