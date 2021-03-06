﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentOffical.aspx.cs"
    Inherits="EOFFICE.SendDocumentOffical" MasterPageFile="~/MasterPages/Default.Master" %>
<%@ Register Assembly="EOFFICE" Namespace="EOFFICE.Common" TagPrefix="MyControl" %>
<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">

    <script type="text/javascript">

    function SelectAll(id) {

        var frm = document.forms[0];

        for (i=0;i<frm.elements.length;i++) {

            if (frm.elements[i].type == "checkbox") {

                frm.elements[i].checked = document.getElementById(id).checked;
            }
        }
    } 
    </script>

    <div class="list wp-form" id="createWorkGroup">
        <h2>
            <span class="icon">
                <img src="../Images/New-document.png" /></span>Tạo loại Công văn đi</h2>
        <div  class="nav-function">
            <ul>
                <li><a href="/DocumentSend/DocumentEdit.aspx" class="btn">
                    <img src="../Images/Go-back.png" />Quay lại</a> </li>
            </ul>
        </div>
        <asp:HiddenField runat="server" ID="hdfId" Value="0" />
        <div class="form">
            <table width="100%" cellspacing="5">
                <tr>
                    <td style="width:150px">
                        Loại cha<span class="rq">*</span>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" DataTextField="Name" DataValueField="OfficalID"
                            ID="ddlParent" Width="250px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tên văn phòng:<span class="rq">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" autocomplete="off" runat="server" CssClass="required" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Mô tả:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="textarea" TextMode="multiline"
                            Rows="3" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Địa chỉ:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="textarea" TextMode="multiline"
                            Rows="3" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tel:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTel" runat="server" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Fax:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFax" runat="server" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Cập nhật" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
            <div class="list" id="list-congvieccanlam">
                <asp:GridView ID="grvDocumentKind" runat="server" AutoGenerateColumns="False" CssClass="tbl-list"
                    Width="100%" OnRowCommand="grvDocumentKind_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle Width="3%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Loại Công văn đi"></asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="Mô tả">
                            <ItemStyle Width="45%" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Loại Công văn đi cha</HeaderTemplate>
                            <ItemTemplate>
                                <%#GetName(Eval("OfficalID"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Thao tác</HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" CommandName="cmdEdit" CommandArgument='<%#Eval("OfficalID")%>'
                                    CssClass="link-function edit" ToolTip="Sửa" runat="server" />
                                <asp:LinkButton ID="LinkButton4" OnClientClick="javascript:return confirm('Bạn chắc chắn muốn xóa?');"
                                    CommandName="cmdDelete" CommandArgument='<%#Eval("OfficalID")%>' CssClass="link-function delete"
                                    ToolTip="Xóa" runat="server"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle ForeColor="#0072BC" />
                </asp:GridView>
                <div class="pagenav" style="display: none">
                    <MyControl:PaggingControl runat="server" ID="ctlPagging" Mode="Url" PageSize="20"
                        PreviousClause="<img src='/images/Back.png'/>" NextClause="<img src='/images/Forward.png'/>" />
                </div>
            </div>
        </div>
        <div class="nav-function">
            <ul>
                <li>
                    <input type="button" class="btn" value="Quay về" onclick="history.go(-1);"></li>
            </ul>
        </div>
    </div>
</asp:Content>
