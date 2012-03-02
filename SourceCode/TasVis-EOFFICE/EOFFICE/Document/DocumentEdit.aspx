<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentEdit.aspx.cs" Inherits="EOFFICE.DocumentEdit"
    MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="ContentUser">
    <div class="list wp-form" id="create-document">
        <h2>
            <span class="icon">
                <img src="../Images/New-document.png" /></span>Tạo công văn dự thảo</h2>
        <form>
        <div class="nav-function">
            <ul>
                <li><a href="#" class="btn"><span class="icon">
                    <img src="../Images/Save.png" /></span>Lưu bản thảo</a></li>
                <li><a href="#" class="btn"><span class="icon">
                    <img src="../Images/Forward.png" /></span>Gửi bản thảo</a></li>
                <li>
                    <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn"><img src="../Images/Erase.png" /></span>Hủy bỏ</asp:LinkButton></li>
                    </li>
                <li>                    <asp:LinkButton runat="server" ID="lnkUpdate" CssClass="btn"><img src="../Images/Go-back.png" /></span>Quay về</asp:LinkButton></li>
                    
            </ul>
        </div>
        <div class="form">
            <table width="100%" cellspacing="5">
                <tr>
                    <td>
                        Loại công văn:<span class="required">*</span>
                    </td>
                    <td colspan="3">
                        <asp:DropDownList runat="server" DataTextField="Name" ID="ddlType">
                        </asp:DropDownList>
                        <a href="/Document/DocumentKindCreate.aspx" class="link-btn">Thêm loại công văn</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tên bản thảo:<span class="required">*</span>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Ngày bắt đầu: <span class="required">*</span>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtStartDate" CssClass="txt required datepicker"></asp:TextBox>(dd/mm/yy)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ngày
                        kết thúc: <span class="required">*</span><asp:TextBox runat="server" ID="txtEndDate"
                            CssClass="txt required datepicker"></asp:TextBox>(dd/mm/yy)
                    </td>
                </tr>
                <tr>
                    <td>
                        Nội dung tóm tắt:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtSubContent" TextMode="MultiLine" Height="50px"
                            Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nội dung công văn:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtContent" TextMode="MultiLine" Height="50px" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Bản thảo:
                    </td>
                    <td>
                        <asp:FileUpload runat="server" ID="fuDrap" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Mức độ ưu tiên:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlLevel">
                            <asp:ListItem Text="Rất quan trọng" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Quan trọng" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Bình thường" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Người xử lý/tham gia ý kiến:
                    </td>
                    <td colspan="3">
                        <textarea cols="5" rows="5" class="textarea"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <div class="nav-function">
            <ul>
                <li><a href="#" class="btn"><span class="icon">
                    <img src="../Images/Save.png" /></span>Lưu bản thảo</a></li>
                <li><a href="#" class="btn"><span class="icon">
                    <img src="../Images/Forward.png" /></span>Gửi bản thảo</a></li>
                <li><a href="#" class="btn"><span class="icon">
                    <img src="../Images/Erase.png" /></span>Hủy bỏ</a></li>
                <li><a href="#" class="btn"><span class="icon">
                    <img src="../Images/Go-back.png" /></span>Quay về</a></li>
            </ul>
        </div>
        </form>
    </div>
</asp:Content>
