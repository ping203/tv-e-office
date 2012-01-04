<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EOFFICE.Users.Default"
    MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="ContentUser">
    <div class="list" id="list-congvieccanlam">
        <h2>
            <span class="icon">
                <asp:Image ImageUrl="~/Images/People.png" runat="server" /></span>Quản lý người
            dùng</h2>
        <table class="tbl-list" width="100%" cellspacing="1" cellpadding="3">
            <tr>
                <td colspan="7">
                    <asp:DropDownList runat="server" ID="drdAction">
                        <asp:ListItem Text="Duyệt" Value="Approve"></asp:ListItem>
                        <asp:ListItem Text="Xóa" Value="Delete"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:LinkButton runat="server" ID="lnkAccept" CssClass="link-btn" OnClick="lnkAccept_Click">Thực hiện</asp:LinkButton>
                    <a class="link-btn" href="Edit.aspx"><span class="create">Thêm mới</span></a>
                </td>
            </tr>
            <tr>
                <th>
                    <input type="checkbox" />
                </th>
                <th>
                    Stt
                </th>
                <th>
                    <a href="#" class="order-desc">Tên công việc</a>
                </th>
                <th>
                    <a href="#">Ngày bắt đầu</a>
                </th>
                <th>
                    <a href="#">Ngày hoàn thành</a>
                </th>
                <th>
                    Ghi chú
                </th>
                <th>
                    Thao tác
                </th>
            </tr>
            <tr>
                <td>
                    <input type="checkbox" />
                </td>
                <td align="center">
                    1
                </td>
                <td>
                    Báo cáo công việc tuần từ 19/12 -> 24/12/2011
                </td>
                <td align="center">
                    23/12/2011
                </td>
                <td align="center">
                    24/12/2011
                </td>
                <td>
                    Báo cáo tuần
                </td>
                <td>
                    <a href="#" class="link-function update" title="Cập nhật">Cập nhật</a><a href="#"
                        class="link-function cancel" title="Hủy">Hủy</a><a href="#" class="link-function delete"
                            title="Xóa">Xóa</a>
                </td>
            </tr>
            <tr class="altenate">
                <td>
                    <input type="checkbox" />
                </td>
                <td align="center">
                    2
                </td>
                <td>
                    Báo cáo công việc tuần từ 19/12 -> 24/12/2011
                </td>
                <td align="center">
                    23/12/2011
                </td>
                <td align="center">
                    24/12/2011
                </td>
                <td>
                    Báo cáo tuần
                </td>
                <td>
                    <a href="#" class="link-function edit" title="Sửa">Sửa</a><a href="#" class="link-function delete"
                        title="Xóa">Xóa</a>
                </td>
            </tr>
            <tr>
                <td>
                    <input type="checkbox" />
                </td>
                <td align="center">
                    3
                </td>
                <td>
                    Báo cáo công việc tuần từ 19/12 -> 24/12/2011
                </td>
                <td align="center">
                    23/12/2011
                </td>
                <td align="center">
                    24/12/2011
                </td>
                <td>
                    Báo cáo tuần
                </td>
                <td>
                    <a href="#" class="link-function edit">Sửa</a><a href="#" class="link-function delete">Xóa</a>
                </td>
            </tr>
            <tr class="altenate">
                <td>
                    <input type="checkbox" />
                </td>
                <td align="center">
                    4
                </td>
                <td>
                    Báo cáo công việc tuần từ 19/12 -> 24/12/2011
                </td>
                <td align="center">
                    23/12/2011
                </td>
                <td align="center">
                    24/12/2011
                </td>
                <td>
                    Báo cáo tuần
                </td>
                <td>
                    <a href="#" class="link-function edit" title="Sửa">Sửa</a><a href="#" class="link-function delete">Xóa</a>
                </td>
            </tr>
            <tr>
                <td>
                    <input type="checkbox" />
                </td>
                <td align="center">
                    5
                </td>
                <td>
                    Báo cáo công việc tuần từ 19/12 -> 24/12/2011
                </td>
                <td align="center">
                    23/12/2011
                </td>
                <td align="center">
                    24/12/2011
                </td>
                <td>
                    Báo cáo tuần
                </td>
                <td>
                    <a href="#" class="link-function edit">Sửa</a><a href="#" class="link-function delete">Xóa</a>
                </td>
            </tr>
            <tr class="altenate">
                <td>
                    <input type="checkbox" />
                </td>
                <td align="center">
                    6
                </td>
                <td>
                    Báo cáo công việc tuần từ 19/12 -> 24/12/2011
                </td>
                <td align="center">
                    23/12/2011
                </td>
                <td align="center">
                    24/12/2011
                </td>
                <td>
                    Báo cáo tuần
                </td>
                <td>
                    <a href="#" class="link-function edit">Sửa</a><a href="#" class="link-function delete">Xóa</a>
                </td>
            </tr>
            <tr>
                <td>
                    <input type="checkbox" />
                </td>
                <td align="center">
                    7
                </td>
                <td>
                    Báo cáo công việc tuần từ 19/12 -> 24/12/2011
                </td>
                <td align="center">
                    23/12/2011
                </td>
                <td align="center">
                    24/12/2011
                </td>
                <td>
                    Báo cáo tuần
                </td>
                <td>
                    <a href="#" class="link-function edit">Sửa</a><a href="#" class="link-function delete">Xóa</a>
                </td>
            </tr>
            <tr class="altenate">
                <td>
                    <input type="checkbox" />
                </td>
                <td align="center">
                    8
                </td>
                <td>
                    Báo cáo công việc tuần từ 19/12 -> 24/12/2011
                </td>
                <td align="center">
                    23/12/2011
                </td>
                <td align="center">
                    24/12/2011
                </td>
                <td>
                    Báo cáo tuần
                </td>
                <td>
                    <a href="#" class="link-function edit">Sửa</a><a href="#" class="link-function delete">Xóa</a>
                </td>
            </tr>
            <tr>
                <td>
                    <input type="checkbox" />
                </td>
                <td align="center">
                    9
                </td>
                <td>
                    Báo cáo công việc tuần từ 19/12 -> 24/12/2011
                </td>
                <td align="center">
                    23/12/2011
                </td>
                <td align="center">
                    24/12/2011
                </td>
                <td>
                    Báo cáo tuần
                </td>
                <td>
                    <a href="#" class="link-function edit">Sửa</a><a href="#" class="link-function delete">Xóa</a>
                </td>
            </tr>
            <tr class="altenate">
                <td>
                    <input type="checkbox" />
                </td>
                <td align="center">
                    10
                </td>
                <td>
                    Báo cáo công việc tuần từ 19/12 -> 24/12/2011
                </td>
                <td align="center">
                    23/12/2011
                </td>
                <td align="center">
                    24/12/2011
                </td>
                <td>
                    Báo cáo tuần
                </td>
                <td>
                    <a href="#" class="link-function edit">Sửa</a><a href="#" class="link-function delete">Xóa</a>
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
</asp:Content>
