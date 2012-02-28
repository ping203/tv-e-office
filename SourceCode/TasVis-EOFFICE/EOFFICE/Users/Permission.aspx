<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Permission.aspx.cs" Inherits="EOFFICE.Users.Permission"
    MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="ContentUser">
    <div class="list" id="list-congvieccanlam">
        <h2>
            <span class="icon">
                <asp:Image ImageUrl="~/Images/People.png" runat="server" /></span>Quản trị danh
            sách quyền
        </h2>
        <table class="tbl-list" width="100%" cellspacing="1" cellpadding="3">
            <tr>
                <td>
                    Mã quyền:
                    <asp:TextBox runat="server" ID="txtCode"></asp:TextBox>
                    Tên quyền
                    <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                    <asp:LinkButton runat="server" ID="cmdUpdateP" CssClass="link-btn" 
                        onclick="cmdUpdateP_Click">Cập nhật</asp:LinkButton>
                        <asp:HiddenField runat="server" ID="hdfId" Value="-1" />
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:GridView ID="grvListPermission" runat="server" AutoGenerateColumns="False" CssClass="tbl-list"
                        Width="100%" DataKeyNames="ID" onrowcommand="grvListPermission_RowCommand">
                        <Columns>
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
                            <asp:TemplateField HeaderText="Sửa">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="cmdEdit" CssClass="link-function edit" CommandName="cmdEdit" CommandArgument='<%#Eval("ID") %>'>
                                   
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="50px" HorizontalAlign="Center" />
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
