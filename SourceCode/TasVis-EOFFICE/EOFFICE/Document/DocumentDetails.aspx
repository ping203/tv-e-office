<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentDetails.aspx.cs"
    Inherits="EOFFICE.DocumentDetails" MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="ContentUser">
    <div class="list wp-form" id="create-document">
        <h2>
            <span class="icon">
                <img src="../Images/New-document.png" /></span>Xử lý văn bản</h2>
        <div class="nav-function">
            <ul>
                <li>
                    <asp:LinkButton runat="server" ID="lnkSave" CssClass="btn" OnClick="lnkSave_Click"><img src="../Images/Save.png" />Duyệt</asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton runat="server" ID="lnkSendDrap" CssClass="btn" OnClick="lnkSendDrap_Click"><img src="../Images/Forward.png" />Trả lại</asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton runat="server" ID="lnkReturn" CssClass="btn" OnClick="lnkReturn_Click"><img src="../Images/Go-back.png" />Quay về</asp:LinkButton></li>
            </ul>
        </div>
        <div class="form">
            <table width="100%" cellspacing="5">
                <tr>
                    <td style="width: 110px">
                        Tên văn bản:
                    </td>
                    <td colspan="3">
                        <asp:Label runat="server" ID="lblName" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Người dự thảo:
                    </td>
                    <td colspan="3">
                        <asp:Label runat="server" ID="lblUserDrap" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nội dung tóm tắt:
                    </td>
                    <td colspan="3">
                        <asp:Label runat="server" ID="lblSubContent" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Bản thảo:
                    </td>
                    <td colspan="3">
                        <asp:LinkButton runat="server" ID="cmdDownAttachs" OnClick="cmdDownAttachs_Click">
                            <asp:Label runat="server" ID="lblAttach" Font-Bold="true"></asp:Label>
                        </asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
                        <h2 style="background-color: White; color: Blue; font-weight: normal; border-bottom: 1px solid">
                            <span class="icon">
                                <img src="../Images/Play.png" alt="Play.png" /></span>Thêm ý kiến xử lý</h2>
                        <table cellpadding="5" width="100%">
                            <tr>
                                <td style="width: 20%" valign="top">
                                    Nội dung:<span class="rq">*</span>
                                </td>
                                <td style="width: 80%">
                                    <asp:TextBox ID="txtContent" Width="200px" runat="server" CssClass="textarea required"
                                        TextMode="multiline" Rows="5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 20%">
                                    Báo cáo kèm theo (nếu có):
                                </td>
                                <td style="width: 80%">
                                    <asp:FileUpload ID="FileUpload1" runat="server" class="multi" />
                                    &nbsp
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div class="nav-function">
            <ul>
                <li>
                    <asp:LinkButton runat="server" ID="lnkSave1" CssClass="btn" OnClick="lnkSave_Click"><img src="../Images/Save.png" />Duyệt</asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton runat="server" ID="lnkSendDrap1" CssClass="btn" OnClick="lnkSendDrap_Click"><img src="../Images/Forward.png" />Trả lại</asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton runat="server" ID="lnkReturn1" CssClass="btn"><img src="../Images/Go-back.png" />Quay về</asp:LinkButton></li>
            </ul>
        </div>
        <br />
        <h2 style="background-color: White; color: Blue; font-weight: normal; border-bottom: 1px solid">
            <span class="icon">
                <img src="../Images/Play.png" alt="Play.png" /></span>Ý kiến xử lý khác</h2>
        <div id="ContentCommentDiv" style="height: 300px; overflow-y: auto; width: 600px;
            margin-bottom: 20px; overflow-x: hidden;">
            <asp:Repeater runat="server" ID="rptComment">
                <HeaderTemplate>
                    <ul class="item_comment">
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <p>
                            <img alt="img" style="vertical-align: middle;" src="../Images/arrow.png" />
                            Thời gian xử lý:
                            <%#DateTime.Parse(Eval("CreateDate").ToString()).ToString("dd/MM/yyyy")%></p>
                        <p class="comment_content">
                            <%#DataBinder.Eval(Container.DataItem, "Content")%>
                        </p>
                        <br />
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul></FooterTemplate>
            </asp:Repeater>
            File báo cáo:<asp:Repeater ID="rptFileAttachs" runat="server" onitemcommand="rptFileAttachs_ItemCommand" >
                                                        <ItemTemplate>
                                                            <p><asp:LinkButton ID="lblFileName" CommandName="Download" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Path") %>' Text='<%#DataBinder.Eval(Container.DataItem,"Name") %>' runat="server" Font-Overline="False" Font-Underline="True"></asp:LinkButton>&nbsp
                                                            </p>
                                                        </ItemTemplate>
                                                    </asp:Repeater>  
            <br />
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
    </div>

    <script language="javascript" type="text/javascript">
    function ShowLoading()
    {
        document.getElementById("SearchLoading").style.display="block";
        document.getElementById("SearchContent").style.display="none";
    }
    </script>

</asp:Content>
