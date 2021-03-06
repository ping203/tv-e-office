﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentProcessedUser.aspx.cs" Inherits="EOFFICE.Document.SendDocumentProcessedUser"
    MasterPageFile="~/MasterPages/Default.Master" %>

<%@ Register Assembly="EOFFICE" Namespace="EOFFICE.Common" TagPrefix="MyControl" %>
<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="ContentDocument">
    <div class="list" id="list-congvieccanlam">
        <h2>
            <span class="icon">
                <asp:Image ImageUrl="~/Images/People.png" runat="server" /></span>Công văn đi đã duyệt</h2>
        <table class="tbl-list" width="100%" cellspacing="1" cellpadding="3">
            <tr>
                <td>
                <asp:HiddenField runat="server" ID="hdfCurrentPage" Value="1" />
                    <asp:DropDownList runat="server" ID="ddlAction" Visible="false">
                        <asp:ListItem Text="Duyệt" Value="Approve"></asp:ListItem>
                        <asp:ListItem Text="Khóa" Value="UnApprove"></asp:ListItem>
                        <asp:ListItem Text="Xóa" Value="Delete"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:LinkButton runat="server" ID="lbtAccept" CssClass="link-btn" OnClick="lbtAccept_Click"
                        OnClientClick="javascript:return ValidCheckedDocument();" Visible="false">Thực hiện</asp:LinkButton>
                   <%-- <a class="link-btn" href="/DocumentSend/DocumentEdit.aspx"><span class="create">Thêm mới</span></a>--%>
                </td>
                <td>
                    Từ ngày:<asp:TextBox runat="server" Width="80px" ID="txtStartDate" CssClass="txt required datepicker"></asp:TextBox>
                    Đến ngày:<asp:TextBox runat="server"  Width="80px" ID="txtEndDate" CssClass="txt required datepicker"></asp:TextBox>
                    Tên<asp:TextBox runat="server" ID="txtKey" CssClass="txt" Width="170px"></asp:TextBox>
                    <asp:DropDownList runat="server" ID="ddlColumnName" Visible="false">
                        <asp:ListItem Text="Tên Công văn đi" Value="Name"></asp:ListItem>
                        <asp:ListItem Text="Người xử lý" Value="Fullname"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:LinkButton runat="server" ID="lbtSearch" CssClass="link-btn" 
                        onclick="lbtSearch_Click1">Tìm kiếm</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <div align="right">
                        <span runat="server" id="spResultCount" style="float:left"></span>
                        Loại Công văn đi: <asp:DropDownList AutoPostBack="true" runat="server" 
                            DataTextField="Name" DataValueField="DocumentKindID" ID="ddlDocumentType" 
                            onselectedindexchanged="ddlDocumentType_SelectedIndexChanged">
                        </asp:DropDownList>
                        Hiển thị:
                         <asp:DropDownList runat="server" ID="ddlPageSize" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                            <asp:ListItem Text="2 kết quả" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3 kết quả" Value="3"></asp:ListItem>
                            <asp:ListItem Text="10 kết quả" Value="10"></asp:ListItem>
                            <asp:ListItem Text="20 kết quả" Value="20"></asp:ListItem>
                            <asp:ListItem Text="50 kết quả" Value="50"></asp:ListItem>
                            <asp:ListItem Text="100 kết quả" Value="100"></asp:ListItem>
                        </asp:DropDownList>
                        
                    </div>
                    <asp:GridView ID="grvListDocument" runat="server" AutoGenerateColumns="False" CssClass="tbl-list"
                        Width="100%" OnRowCommand="grvListDocument_RowCommand" DataKeyNames="Name">
                        <Columns>
                            <asp:TemplateField HeaderText="STT">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle Width="3%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" HeaderText="Tên  Công văn đi"></asp:BoundField>
                            <asp:TemplateField HeaderText="Người tham gia duyệt">
                                <ItemTemplate>
                                    <%#BindUserProcess(Eval("UserProcess"))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Phát hành</HeaderTemplate>
                                <ItemTemplate>
                                <asp:LinkButton runat="server" ID="cmdSendPublish" CommandName="Publish" CommandArgument='<%# Eval("DocumentID") %>'>Phát hành</asp:LinkButton>
                                </ItemTemplate>
                               <ItemStyle HorizontalAlign="Center"/>
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
     function ValidCheckedDocument() {
        if ($(".chkDocumentCheck:checked").length == 0) {
            alert("Vui lòng chọn người dùng cần thao tác");
            return false;
        }
        return confirm('Bạn chắc chắn muốn thực hiện thao tác này?');
    }
    $(document).ready(function() {
        $('#chkCheckDocumentAll').bind('click', function() {
            if ($("#chkCheckDocumentAll").attr('checked') == 'checked') {
                $(".chkDocumentCheck").attr('checked', 'checked');
            }
            else {
                $(".chkDocumentCheck").attr('checked', false);
            }
        });

    });
    </script>

</asp:Content>
