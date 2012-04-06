<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EOFFICE.Users.Default"
    MasterPageFile="~/MasterPages/Default.Master" %>

<%@ Register Assembly="EOFFICE" Namespace="EOFFICE.Common" TagPrefix="MyControl" %>
<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="ContentUser">
    <div class="list" id="list-congvieccanlam">
        <h2>
            <span class="icon">
                <asp:Image ImageUrl="~/Images/People.png" runat="server" /></span>Quản lý người
            dùng</h2>
        <table class="tbl-list" width="100%" cellspacing="1" cellpadding="3">
            <tr>
                <td>
                    <asp:DropDownList runat="server" ID="ddlAction">
                        <asp:ListItem Text="Duyệt" Value="Approve"></asp:ListItem>
                        <asp:ListItem Text="Khóa" Value="UnApprove"></asp:ListItem>
                        <asp:ListItem Text="Xóa" Value="Delete"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:LinkButton runat="server" ID="lbtAccept" CssClass="link-btn" OnClick="lbtAccept_Click"
                        OnClientClick="javascript:return ValidCheckedUser();">Thực hiện</asp:LinkButton>
                    <a class="link-btn" href="Edit.aspx"><span class="create">Thêm mới</span></a>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtKey" CssClass="txt" Width="200px"></asp:TextBox>
                    <asp:DropDownList runat="server" ID="ddlColumnName">
                        <asp:ListItem Text="Tài khoản" Value="Username"></asp:ListItem>
                        <asp:ListItem Text="Họ và tên" Value="Fullname"></asp:ListItem>
                        <asp:ListItem Text="Email" Value="Email"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:LinkButton runat="server" ID="lbtSearch" CssClass="link-btn" onclick="lbtSearch_Click" 
                      >Tìm kiếm</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <div align="right">
                        <span runat="server" id="spResultCount" style="float:left"></span>
                        Phòng ban:<asp:DropDownList runat="server" AutoPostBack="true" ID="ddlDepartment"  
                            DataValueField="DepartmentID" DataTextField="Name" 
                            onselectedindexchanged="ddlDepartment_SelectedIndexChanged">
                        </asp:DropDownList>
                        Trạng thái:<asp:DropDownList runat="server" AutoPostBack="true" ID="ddlStatus" 
                            onselectedindexchanged="ddlStatus_SelectedIndexChanged">
                        </asp:DropDownList>
                        Hiển thị:
                         <asp:DropDownList runat="server" ID="ddlPageSize" AutoPostBack="true" 
                            onselectedindexchanged="ddlPageSize_SelectedIndexChanged">
                            <asp:ListItem Text="2 kết quả" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3 kết quả" Value="3"></asp:ListItem>
                            <asp:ListItem Text="10 kết quả" Value="10"></asp:ListItem>
                            <asp:ListItem Text="20 kết quả" Value="20"></asp:ListItem>
                            <asp:ListItem Text="50 kết quả" Value="50"></asp:ListItem>
                            <asp:ListItem Text="100 kết quả" Value="100"></asp:ListItem>
                        </asp:DropDownList>
                        
                    </div>
                    <asp:GridView ID="grvListUsers" runat="server" AutoGenerateColumns="False" CssClass="tbl-list"
                        Width="100%" OnRowCommand="grvListUsers_RowCommand" DataKeyNames="Username">
                        <Columns>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <input type="checkbox" id="chkCheckUserAll" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input type="checkbox" value="abc" class="chkUserCheck" id="chkCheckUser" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="3%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="STT">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle Width="3%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Username" HeaderText="Tên đăng nhập"></asp:BoundField>
                            <asp:BoundField DataField="FullName" HeaderText="Họ và tên"></asp:BoundField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Thao tác</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" CommandName="cmdApprove" CommandArgument='<%#Eval("Username") %>'
                                        ToolTip="Duyệt" Visible='<%#VisibleUnApp(Eval("Status")) %>' CssClass="link-function"
                                        runat="server">
                                        <asp:Image CssClass="link-function" runat="server" ID="Image1" ImageUrl="~/images/unchecked.gif" />
                                    </asp:LinkButton>
                                     <asp:LinkButton ID="LinkButton6" CommandName="cmdResetPass" CommandArgument='<%#Eval("Username") %>'
                                        ToolTip="Reset mật khẩu mặc định" CssClass="link-function"
                                        runat="server">
                                        Reset mật khẩu
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" CommandName="cmdUnApprove" CommandArgument='<%#Eval("Username") %>'
                                        ToolTip="Khóa" Visible='<%#VisibleApp(Eval("Status")) %>' CssClass="link-function"
                                        runat="server">
                                        <asp:Image CssClass="link-function" runat="server" ID="imgApprove" ImageUrl="~/images/checked.gif" />
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton5" CommandName="cmdUserGroup" CommandArgument='<%#Eval("Username") %>'
                                        ToolTip="Thuộc nhóm" CssClass="link-function" runat="server">
                                        <asp:Image CssClass="link-function" runat="server" ID="Image2" ImageUrl="~/images/User-group.png" />
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton1" CommandName="cmdEdit" CommandArgument='<%#Eval("Username") %>'
                                        ToolTip="Sửa người dùng" CssClass="link-function edit" runat="server" />
                                    <asp:LinkButton ID="LinkButton4" CommandName="cmdDelete" CommandArgument='<%#Eval("Username") %>'
                                        ToolTip="Xóa người dùng" CssClass="link-function delete" runat="server" OnClientClick="javascript:return confirm('Bạn chắc chắn muốn xóa người dùng?');"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle ForeColor="#0072BC" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <div class="pagenav">
            <MyControl:PaggingControl runat="server" ID="ctlPagging" Mode="Url" PageSize="20"
                PreviousClause="<img src='/images/Back.png'/>" NextClause="<img src='/images/Forward.png'/>" />
        </div>
    </div>

    <script type="text/javascript">
     function ValidCheckedUser() {
        if ($(".chkUserCheck:checked").length == 0) {
            alert("Vui lòng chọn người dùng cần thao tác");
            return false;
        }
        return confirm('Bạn chắc chắn muốn thực hiện thao tác này?');
    }
    $(document).ready(function() {
        $('#chkCheckUserAll').bind('click', function() {
            if ($("#chkCheckUserAll").attr('checked') == 'checked') {
                $(".chkUserCheck").attr('checked', 'checked');
            }
            else {
                $(".chkUserCheck").attr('checked', false);
            }
        });

    });
    </script>

</asp:Content>
