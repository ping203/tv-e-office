<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<link rel="Stylesheet" href="../css/style.css" />
<script language="javascript" type="text/javascript" src="../js/jquery.js"></script>
<script language="javascript" type="text/javascript" src="../js/script.js"></script>
<head id="Head1" runat="server">
    <title>Phần mềm quản lý công văn - Công ty cổ phần Ngân Sơn</title>    
</head>
<body>
<form id="form1" runat="server">
<div id="wrapper">
    <div id="wpfrmlogin">
        <div id="frmlogin">
            <h2>Đăng nhập hệ thống</h2>
            <table>
                <tr>
                    <td>Tên đăng nhập:</td>
                    <td><input type="text" class="txt" /></td>
                </tr>
                <tr>
                    <td>Mật khẩu:</td>
                    <td><input type="text" class="txt" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><input type="submit" value="Đăng nhập" class="btn" /></td>
                </tr>
            </table>
        </div>        
    </div>
</div><!-- end wrapprer -->
</form>
</body>
</html>
