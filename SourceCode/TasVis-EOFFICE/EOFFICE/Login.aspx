<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EOFFICE.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<link rel="Stylesheet" href="../css/style.css" />
<script language="javascript" type="text/javascript" src="../js/jquery.js"></script>
<script language="javascript" type="text/javascript" src="../js/script.js"></script>
<head id="Head1" runat="server">
    <title>Phần mềm quản lý công văn - Công ty cổ phần Ngân Sơn</title>    
</head>
<body>
<form id="form" runat="server">
<div id="wrapper">
    <div id="wpfrmlogin">
        <div id="frmlogin">
            <h2>Đăng nhập hệ thống</h2>
            <table>
                <tr>
                    <td>Tên đăng nhập:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtUsername" CssClass="txt required"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Mật khẩu:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="txt required"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:LinkButton runat="server" ID="btnLogin" CssClass="btn" 
                            onclick="btnLogin_Click" OnClientClick="javascript:return $('form').valid();" >Đăng nhập</asp:LinkButton>
                </tr>
            </table>
        </div>        
    </div>
</div><!-- end wrapprer -->
</form>
</body>
<script language="javascript" type="text/javascript" src="../js/jquery.js"></script>
<script language="javascript" type="text/javascript" src="../js/jquery.ui.core.js"></script>
<script language="javascript" type="text/javascript" src="../js/script.js"></script>
<script language="javascript" type="text/javascript" src="../js/jquery.validate.js"></script>
<script language="javascript" type="text/javascript" src="../js/ui.datetimepicker.js"></script>
<script type="text/javascript" src="../js/jquery.MultiFile.js"></script>
<script type="text/javascript">
        $(document).ready(function() {        
            $("#aspnetForm").validate();
            $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });
            
        });
 </script> 
</html>
