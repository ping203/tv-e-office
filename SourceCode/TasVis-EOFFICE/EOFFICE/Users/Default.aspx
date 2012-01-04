<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EOFFICE.Users.Default"
    MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="ContentUser">
    <div class="list" id="list-congvieccanlam">
        <h2>
            <span class="icon">
                <asp:Image ImageUrl="~/Images/People.png" runat="server" /></span>Quản trị người
            dùng</h2>
        <asp:GridView CssClass="tbl-list" runat="server" ID="gvListUser" AutoGenerateColumns="false"
            GridLines="None">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                    
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <table class="tbl-list" width="100%" cellspacing="1" cellpadding="3">
            <tr>
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
            </tr>
            <tr>
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
            </tr>
            <tr class="altenate">
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
            </tr>
            <tr>
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
            </tr>
            <tr class="altenate">
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
            </tr>
            <tr>
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
            </tr>
            <tr class="altenate">
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
            </tr>
            <tr>
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
            </tr>
            <tr class="altenate">
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
            </tr>
            <tr>
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
            </tr>
            <tr class="altenate">
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
