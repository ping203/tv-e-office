<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EOFFICE._Default" MasterPageFile="~/MasterPages/Default.Master" %>
<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">
    <div>        
        <asp:GridView ID="grvTest" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None">
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>        
    </div>
</asp:Content>
