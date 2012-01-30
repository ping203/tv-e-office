<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="EOFFICE.Users.UserInfo" MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">  
          
    <div class="list wp-form" id="WorkAssignment">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Thông tin cá nhân</h2>
                
                	<div class="nav-function">
                    	<ul>
                    	    <li><asp:Button runat="server" ID="btnCapNhat" CssClass="btn" Text="Cập nhật" onclick="btnCapNhat_Click" 
                                    ></asp:Button></li>
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
                                            <td align="right">Họ và tên:<span class="rq">*</span></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtFullName" CssClass="required"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">Ngày sinh:<span class="rq">*</span></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtDate" CssClass="required date datepicker"></asp:TextBox>(ngày/tháng/năm)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">Email:<span class="rq">*</span></td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtEmail" CssClass="required email"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">Số di động:</td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtPhone"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">Số máy bàn:</td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtTel"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">Giới tính:</td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlGender"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">Địa chỉ:</td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtAddress"></asp:TextBox>
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
                    	    <li><asp:Button runat="server" ID="btnCapNhat2" CssClass="btn" Text="Cập nhật" onclick="btnCapNhat_Click" 
                                    ></asp:Button></li>
                        	<li><input type="reset" value="Hủy bỏ" class="btn" /></li>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
                        </ul>
                    </div>
                    
            </div>

</asp:Content>
