<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Group.aspx.cs" Inherits="EOFFICE.Users.Group"
    MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="ContentUser">
    <div class="list" id="list-congvieccanlam">
        <h2>
            <span class="icon">
                <asp:Image ImageUrl="~/Images/People.png" runat="server" /></span>Quản lý nhóm người
            dùng</h2>
        <table class="tbl-list" width="100%" cellspacing="1" cellpadding="3">
            <tr>
                <td>
                    <asp:DropDownList runat="server" ID="drdAction">
                        <asp:ListItem Text="Xóa" Value="Delete"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:LinkButton runat="server" ID="lnkAccept" CssClass="link-btn" OnClick="lnkAccept_Click"
                        OnClientClick="javascript:return ValidCheckedGroup();">Thực hiện</asp:LinkButton>
                    <a class="link-btn" href="EditGroup.aspx"><span class="create">Thêm mới</span></a>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:GridView ID="grvListGroups" runat="server" AutoGenerateColumns="False" CssClass="tbl-list"
                        Width="100%" OnRowCommand="grvListGroups_RowCommand" DataKeyNames="GroupId">
                        <Columns>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <input type="checkbox" id="chkCheckGroupAll" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input type="checkbox" value="abc" class="chkGroupCheck" id="chkCheckGroup" runat="server" />
                                    
                                </ItemTemplate>
                                <ItemStyle Width="3%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="STT">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle Width="3%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" HeaderText="Tên nhóm"></asp:BoundField>
                            <asp:BoundField DataField="Description" HeaderText="Mô tả"></asp:BoundField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Thao tác</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" CommandName="cmdEdit" CommandArgument='<%#Eval("GroupId") %>' ToolTip="Sửa nhóm người dùng"
                                        CssClass="link-function edit" runat="server" />
                                    <asp:LinkButton ID="LinkButton4" CommandName="cmdDelete" CommandArgument='<%#Eval("GroupId") %>' ToolTip="Xóa nhóm người dùng"
                                        CssClass="link-function delete" runat="server" OnClientClick="javascript:return confirm('Bạn chắc chắn muốn xóa nhóm người dùng?');"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle ForeColor="#0072BC" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <div class="pagenav">
            <ul>
                <li><a href="#">Trang đầu</a></li>
                <li><a href="#" class="pagecurrent">1</a></li>
                <li><a href="#">2</a></li>
                <li><a href="#">3</a></li>
                <li><a href="#">4</a></li>
                <li><a href="#">5</a></li>
                <li><a href="#">...</a></li>
                <li><a href="#">Trang cuối</a></li>
            </ul>
        </div>
    </div>

    <script type="text/javascript">
     function ValidCheckedGroup() {
        if ($(".chkGroupCheck:checked").length == 0) {
            alert("Vui lòng chọn nhóm người dùng cần thao tác");
            return false;
        }
        return confirm('Bạn chắc chắn muốn thực hiện thao tác này?')
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
