<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="EOFFICE.Users.ChangePass" MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">  
          
    <div class="list wp-form" id="WorkAssignment">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Đổi mật khẩu</h2>
                
                	<div class="nav-function">
                    	<ul>
                    	    <li><asp:Button runat="server" ID="btnReset" Text="Đổi mật khẩu" CssClass="btn" 
                                    onclick="btnReset_Click" /></li>
                        	<li><input type="reset" value="Hủy bỏ" class="btn" /></li>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
                        </ul>
                    </div>
                    <div class="form">
                        <table class="tbl-list" width="100%" cellspacing="1" cellpadding="3">
                            <tr>
                                <td align="left">
                                    <table>
                                        <tr>
                                            <td align="right">Tên tài khoản:</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblUserName" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">Mật khẩu hiện tại:<span class="rq">*</span></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtPass" CssClass="required" 
                                                    TextMode="Password"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">Mật khẩu mới:<span class="rq">*</span></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtPassNew" CssClass="required" 
                                                    TextMode="Password"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">Nhắc lại mật khẩu mới:<span class="rq">*</span></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtPassRepeat" CssClass="required" 
                                                    TextMode="Password"></asp:TextBox>
                                            </td>
                                        </tr>                                        
                                    </table>
                                </td>
                            </tr>    
                        </table>
                        <br />
                        <asp:Label runat="server" ID="lblThongBao" CssClass="rq"></asp:Label>
                    </div>
                    
                    <div class="nav-function">
                    	<ul>
                    	    <li><asp:Button runat="server" ID="Button1" Text="Đổi mật khẩu" CssClass="btn" onclick="btnReset_Click" /></li>
                        	<li><input type="reset" value="Hủy bỏ" class="btn" /></li>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
                        </ul>
                    </div>
                    
            </div>

</asp:Content>
