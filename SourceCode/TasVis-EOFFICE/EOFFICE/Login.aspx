<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EOFFICE.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<link rel="Stylesheet" href="../css/login-style.css" />
<script language="javascript" type="text/javascript" src="../js/jquery.js"></script>
<script language="javascript" type="text/javascript" src="../js/script.js"></script>
<head id="Head1" runat="server">
    <title>Phần mềm quản lý công văn - Công ty cổ phần Ngân Sơn</title>    
</head>
<body>
<form id="form" runat="server">
    <div class="login">
            <h2>Đăng nhập hệ thống</h2>        
            <p><span>Tên đăng nhập:</span><asp:TextBox runat="server" ID="txtUsername" CssClass="txtlogin required"></asp:TextBox></p>        
            <p><span>Mật khẩu:</span><asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="txtlogin required"></asp:TextBox></asp:TextBox></p>
            <p><asp:LinkButton runat="server" ID="btnLogin" CssClass="btn" 
                            onclick="btnLogin_Click" OnClientClick="javascript:return $('form').valid();" >Đăng nhập</asp:LinkButton></p>        
    </div>                   
</form>
</body> 
</html>
