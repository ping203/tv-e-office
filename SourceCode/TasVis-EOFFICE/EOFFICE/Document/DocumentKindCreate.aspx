﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentKindCreate.aspx.cs"
    Inherits="EOFFICE.DocumentKindCreate" MasterPageFile="~/MasterPages/Default.Master" %>

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
                <img src="../Images/New-document.png" /></span>Tạo loại văn bản</h2>
        <div class="nav-function">
            <ul>
                <li>
                    <input type="button" class="btn" value="Quay về" onclick="history.go(-1);" /></li>
            </ul>
        </div>
        <div class="form">
            <table width="100%" cellspacing="5">
            <tr>
                    <td>
                        Loại cha<span class="rq">*</span>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" DataTextField="Name" DataValueField="DocumentKindID" ID="ddlParent" Width="250px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tên loại văn bản:<span class="rq">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" CssClass="required"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Mô tả:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="textarea" TextMode="multiline"
                            Rows="10"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Cập nhật" 
                            onclick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
            <div class="list" id="list-congvieccanlam">
                <asp:GridView ID="grvDocumentKind" runat="server" AutoGenerateColumns="False" CssClass="tbl-list"
                    Width="100%" onrowcommand="grvDocumentKind_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle Width="3%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Tên nhóm công việc"></asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="Mô tả">
                            <ItemStyle Width="45%" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Loại văn bản cha</HeaderTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlGroupParent" runat="server" Width="200px" Enabled="false">
                                </asp:DropDownList>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlGroupParent" runat="server" Width="200px">
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Thao tác</HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" CommandName="cmdEdit" CommandArgument='<%#Eval("DocumentKindID")%>' CssClass="link-function edit"
                                    ToolTip="Sửa" runat="server" />
                                <asp:LinkButton ID="LinkButton4" CommandName="cmdDelete" CommandArgument='<%#Eval("DocumentKindID")%>' CssClass="link-function delete"
                                    ToolTip="Xóa" runat="server"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle ForeColor="#0072BC" />
                </asp:GridView>
                <div class="pagenav">
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
