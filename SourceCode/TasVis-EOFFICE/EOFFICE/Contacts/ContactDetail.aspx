<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactDetail.aspx.cs" Inherits="EOFFICE.Contacts.ContactDetail" MasterPageFile="~/MasterPages/Default.Master" %>
<asp:Content ContentPlaceHolderID="cphContent" runat="server">
    <div class="list wp-form" id="createWorkGroup">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Danh sách liên hệ</h2>
                
                	<div class="nav-function">
                    	<ul>
                    	    <li><asp:LinkButton ID="btnDanhSach" runat="server" Text="Danh sách liên hệ" 
                                    CssClass="btn" onclick="btnDanhSach_Click"></asp:LinkButton></li>
                    	    <li><asp:LinkButton ID="btnNhom" runat="server" Text="Quản lý nhóm" CssClass="btn" 
                                    onclick="btnNhom_Click"></asp:LinkButton></li>
                            <li><asp:LinkButton ID="btnThem" runat="server" Text="Thêm liên hệ" CssClass="btn" 
                                    onclick="btnThem_Click" ></asp:LinkButton></li>
                        </ul>
                    </div>
                    <div class="form">
                        <table width="100%" cellspacing="6">
                    	<tr>
                    	    <td><p style="font-size: 14px; font-weight: bold; color: #0066FF">Liên hệ thuộc nhóm:</p></td>
                    	    <td colspan="6">
                    	        <asp:DropDownList runat="server" ID="ddlContactGroup" Width="300"></asp:DropDownList>
                    	    </td>
                    	</tr>
                    	<tr>
                    	    <td><p style="font-size: 14px; font-weight: bold; color: #0066FF">Thông tin cá nhân:</p></td>
                    	</tr>
                    	<tr>
                    	    <td align="right">Họ và tên:<span class="rq">(*)</span></td>
                    	    <td colspan="2">
                    	        <asp:TextBox runat="server" ID="txtFullName" CssClass="txt required"></asp:TextBox>
                    	    </td>
                    	    <td align="right">Giới tính:</td>
                    	    <td>
                    	        <asp:DropDownList runat="server" ID="ddlGender"></asp:DropDownList>
                    	        &nbsp;&nbsp;&nbsp;&nbsp;Xưng danh:
                    	        <asp:DropDownList runat="server" ID="ddlXungDanh">
                    	            <asp:ListItem Text="Ông" Value="Ông"></asp:ListItem>
                    	            <asp:ListItem Text="Bà" Value="Bà"></asp:ListItem>
                    	            <asp:ListItem Text="Bác" Value="Bác"></asp:ListItem>
                    	            <asp:ListItem Text="Chú" Value="Chú"></asp:ListItem>
                    	            <asp:ListItem Text="Cô" Value="Cô"></asp:ListItem>
                    	            <asp:ListItem Text="Anh" Value="Anh"></asp:ListItem>
                    	            <asp:ListItem Text="Chị" Value="Chị"></asp:ListItem>
                    	            <asp:ListItem Text="Em" Value="Em"></asp:ListItem>
                    	            <asp:ListItem Text="Cháu" Value="Cháu"></asp:ListItem>
                    	        </asp:DropDownList>
                    	    </td>
                    	</tr>
                    	<tr>
                    	    <td align="right">Ngày sinh:</td>
                    	    <td colspan="2">
                    	        <asp:TextBox runat="server" ID="txtBirthDay" CssClass="txt datepicker"></asp:TextBox>(ngày/tháng/năm)
                    	    </td>
                    	    <td align="right">Địa chỉ:</td>
                    	    <td colspan="3">
                    	        <asp:TextBox runat="server" ID="txtAddress" Width="300px" CssClass="txt"></asp:TextBox>
                    	    </td>
                    	</tr>
                    	<tr>
                    	    <td align="right">Nghề nghiệp:</td>
                    	    <td colspan="2"><asp:TextBox runat="server" ID="txtJob" CssClass="txt"></asp:TextBox></td>
                    	    <td align="right">Email:</td>
                    	    <td><asp:TextBox runat="server" ID="txtEmail" CssClass="txt email"></asp:TextBox></td>
                    	</tr>
                    	<tr>
                    	    <td align="right">Phone:</td>
                    	    <td colspan="2"><asp:TextBox runat="server" ID="txtPhone" CssClass="txt"></asp:TextBox></td>
                    	    <td align="right">Tel:</td>
                    	    <td><asp:TextBox runat="server" ID="txtTel" CssClass="txt"></asp:TextBox></td>
                    	</tr>
                    	<tr>
                    	    <td align="right">Thông tin khác:</td>
                    	    <td colspan="6"><asp:TextBox runat="server" ID="txtOther" TextMode="MultiLine" Rows="5" Width="295" CssClass="textarea"></asp:TextBox></td>
                    	</tr>
                    	<tr>
                    	    <td></td>
                    	    <td>
                    	        <asp:Button runat="server" ID="btnSubmit" Text="Sửa danh bạ" CssClass="link-btn" 
                                    onclick="btnSubmit_Click" ToolTip="Thêm danh bạ" />
                                <input type="reset" value="Hủy bỏ" title="Hủy bỏ" class="link-btn" />
                            </td>                    	    
                        </tr>
                    	<tr>
                    	    <td></td>
                    	    <td colspan="6">
                    	        <asp:Label runat="server" ID="lblThongBao" ForeColor="Red" Text=""></asp:Label>
                    	    </td>
                    	</tr>
                    </table>
                    </div>
                    <div class="nav-function">
                    	<ul>
                        	<li><asp:LinkButton ID="LinkButton5" runat="server" Text="Danh sách liên hệ" 
                                    CssClass="btn" onclick="btnDanhSach_Click"></asp:LinkButton></li>
                    	    <li><asp:LinkButton ID="LinkButton6" runat="server" Text="Quản lý nhóm" 
                                    CssClass="btn" onclick="btnNhom_Click"></asp:LinkButton></li>
                            <li><asp:LinkButton ID="LinkButton7" runat="server" Text="Thêm liên hệ" 
                                    CssClass="btn" onclick="btnThem_Click" ></asp:LinkButton></li>
                        </ul>
                    </div>
                
            </div>
</asp:Content>