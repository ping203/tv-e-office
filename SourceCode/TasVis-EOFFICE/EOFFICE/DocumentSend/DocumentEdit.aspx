<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentEdit.aspx.cs" Inherits="EOFFICE.DocumentSend.DocumentEdit"
    MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="ContentUser">
    <div class="list wp-form" id="create-document">
        <h2>
            <span class="icon">
                <img src="../Images/New-document.png" /></span>Tạo công văn đi</h2>
        <form>
        <div class="nav-function">
            <ul>
                <li>
                    <asp:LinkButton runat="server" ID="lnkSave" CssClass="btn" OnClientClick="javascript:return $('form').valid();"  OnClick="lnkSave_Click"><img src="../Images/Save.png" />Lưu công văn đi</asp:LinkButton>
                </li>
                <li style="display:none">
                    <asp:LinkButton runat="server" ID="lnkSendDrap" CssClass="btn" 
                        onclick="lnkSendDrap_Click"><img src="../Images/Forward.png" />Gửi bản thảo</asp:LinkButton>
                </li>
                <li style="display:none">
                    <asp:LinkButton runat="server" ID="lnkCancel" CssClass="btn"><img src="../Images/Erase.png" />Hủy bỏ</asp:LinkButton></li>
                </li>
                <li>
                    <asp:LinkButton runat="server" ID="lnkReturn" CssClass="btn" 
                        onclick="lnkReturn_Click"><img src="../Images/Go-back.png" />Quay về</asp:LinkButton></li>
            </ul>
        </div>
        <div class="form">
            <table width="100%" cellspacing="5">
                <tr style="display:none">
                    <td>
                        Loại Công văn:<span class="required">*</span>
                    </td>
                    <td colspan="3">
                        <asp:DropDownList runat="server" DataTextField="Name" DataValueField="DocumentKindID" ID="ddlType">
                        </asp:DropDownList>
                        <a href="/Document/DocumentKindCreate.aspx" class="link-btn">Thêm loại Công văn</a>
                    </td>
                </tr>
                <tr style="display:none">
                    <td>
                        Văn phòng:<span class="required">*</span>
                    </td>
                    <td colspan="3">
                        <asp:DropDownList runat="server" DataTextField="Name" DataValueField="OfficalId" ID="ddlOffical">
                        </asp:DropDownList>
                        <a href="/Document/DocumentOffical.aspx" class="link-btn">Thêm văn phòng</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tên công văn:<span class="required">*</span>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtName" CssClass="required"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Ký hiệu:<span class="required">*</span>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCode" CssClass="required"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Ngày gửi: <span class="required">*</span>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtStartDate" CssClass="txt required datepicker"></asp:TextBox>(dd/mm/yy)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div style="display:none">Ngày
                        kết thúc: <span class="required">*</span><asp:TextBox runat="server" ID="txtEndDate"
                            CssClass="txt required datepicker"></asp:TextBox>(dd/mm/yy)</div>
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
                        File kèm theo:
                    </td>
                    <td>
                        <asp:FileUpload runat="server" ID="fuDrap" /><asp:LinkButton runat="server" 
                            ID="cmđUpload" onclick="cmđUpload_Click">Tải lên server</asp:LinkButton>
                            <br />
                            <asp:Label runat="server" ID="lblLink"></asp:Label>
                        <asp:LinkButton runat="server" Visible="false" ID="cmdDeleteFile" onclick="cmdDeleteFile_Click">Xóa</asp:LinkButton>
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
                        Địa chỉ nhận:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtAddress" TextMode="MultiLine" Height="50px" Width="300px" CssClass="required"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display:none">
                    <td valign="top">
                        Người xử lý:
                    </td>
                    <td colspan="3" valign="top" align="left">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="udp" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td valign="top">
                                            <asp:ListBox Height="150px" runat="server" ID="lsbUserProcess" DataTextField="FullName"
                                                DataValueField="UserId" Width="250px" AutoPostBack="false" SelectionMode="Multiple">
                                            </asp:ListBox>
                                        </td>
                                        <td valign="top">
                                            <asp:LinkButton Width="120px" runat="server" ID="lnkAddUserProcess" 
                                                CssClass="btn" onclick="lnkAddUserProcess_Click"><img src="../Images/Go-back.png" />Thêm người xử lý</asp:LinkButton>
                                                <br />
                                                  <br />
                                        <asp:LinkButton runat="server" ID="cmdDeleteUser" CssClass="btn" 
                                                onclick="cmdDeleteUser_Click"><img src="../Images/Erase.png" />Xóa</asp:LinkButton>
                                        </td>
                                        <td valign="top">
                                            <asp:TextBox runat="server" ID="txtKeySearch" Width="120px" Height="16px"></asp:TextBox>
                                            <asp:DropDownList runat="server" ID="ddlDepartment" Width="150px" Height="22px" DataValueField="DepartmentID"
                                                DataTextField="Name" AutoPostBack="true" 
                                                onselectedindexchanged="ddlDepartment_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:LinkButton runat="server" ID="btnSearchUserProcess" Text="Search" OnClick="btnSearchUserProcess_Click" OnClientClick="javascript:ShowLoading();"></asp:LinkButton>
                                            <br />
                                            <div align="center" id="SearchLoading" style="display:none">
                                                <img src="../Images/icon_loading.gif" />
                                            </div>
                                            <div id="SearchContent">
                                                <asp:ListBox runat="server" ID="lbsUserSearch" DataTextField="FullName" DataValueField="UserId" Visible="false" 
                                                    Width="350px" AutoPostBack="false"  Height="150px" SelectionMode="Multiple"></asp:ListBox>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div class="nav-function">
            <ul>
                <li>
                    <asp:LinkButton runat="server" ID="lnkSave1" CssClass="btn" 
                        onclick="lnkSave_Click" OnClientClick="javascript:return $('form').valid();" ><img src="../Images/Save.png" />Lưu công văn đi</asp:LinkButton>
                </li>
                <li style="display:none">
                    <asp:LinkButton runat="server" ID="lnkSendDrap1" CssClass="btn" 
                        onclick="lnkSendDrap_Click"><img src="../Images/Forward.png" />Gửi bản thảo</asp:LinkButton>
                </li>
                <li style="display:none">
                    <asp:LinkButton runat="server" ID="lnkCancel1" CssClass="btn"><img src="../Images/Erase.png" />Hủy bỏ</asp:LinkButton></li>
                </li>
                <li>
                    <asp:LinkButton runat="server" ID="lnkReturn1" CssClass="btn"><img src="../Images/Go-back.png" />Quay về</asp:LinkButton></li>
            </ul>
        </div>
        </form>
    </div>
    <script language="javascript" type="text/javascript">
    function ShowLoading()
    {
        document.getElementById("SearchLoading").style.display="block";
        document.getElementById("SearchContent").style.display="none";
    }
    </script>
</asp:Content>
