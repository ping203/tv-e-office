<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="permission-fail.aspx.cs" Inherits="EOFFICE.permission_fail" MasterPageFile="MasterPages/Default.Master" %>

<asp:Content ID="tblPermissionFail" runat="server" ContentPlaceHolderID="cphContent">
    <div class="list" id="list-congvieccanlam">
        <br />
    	<h1>&nbsp;&nbsp;Bạn không đủ quyền truy cập vào chức năng này !</h1>
    	<br />
    	<br />
    	&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lbtHome" runat="server" Text="Quay về trang chủ" CssClass="link-btn" PostBackUrl="~/Default.aspx"></asp:LinkButton>
    </div>
</asp:Content>