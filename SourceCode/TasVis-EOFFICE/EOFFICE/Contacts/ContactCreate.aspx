<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactCreate.aspx.cs" Inherits="EOFFICE.Contacts.ContactCreate" MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">    
    
    <div class="list wp-form" id="createWorkGroup">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Thêm thông tin danh mục cá nhân</h2>
                
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
                    	        <asp:DropDownList runat="server" ID="ddlContactGroup"></asp:DropDownList>
                    	    </td>
                    	</tr>
                    	<tr>
                    	    <td><p style="font-size: 14px; font-weight: bold; color: #0066FF">Thông tin cá nhân:</p></td>
                    	</tr>
                    	<tr>
                    	    <td>Họ và tên:<span class="rq">*</span></td>
                    	    <td colspan="2">
                    	        <asp:TextBox runat="server" ID="txtFullName" CssClass="required"></asp:TextBox>
                    	    </td>
                    	    <td>Giới tính:</td>
                    	    <td class="style1">
                    	        <asp:DropDownList runat="server" ID="ddlGender">
                    	            <asp:ListItem Text="Nam" Value="Nam"></asp:ListItem>
                    	            <asp:ListItem Text="Nữ" Value="Nữ"></asp:ListItem>
                    	        </asp:DropDownList>
                    	    </td>
                    	    <td>Xưng danh:</td>
                    	    <td>
                    	        <asp:DropDownList runat="server" ID="ddlXungDanh">
                    	            <asp:ListItem Text="Ông" Value="Ông"></asp:ListItem>
                    	            <asp:ListItem Text="Bà" Value="Bà"></asp:ListItem>
                    	            <asp:ListItem Text="Anh" Value="Anh"></asp:ListItem>
                    	            <asp:ListItem Text="Chị" Value="Chị"></asp:ListItem>
                    	            <asp:ListItem Text="Em" Value="Em"></asp:ListItem>
                    	            <asp:ListItem Text="Cháu" Value="Cháu"></asp:ListItem>
                    	        </asp:DropDownList>
                    	    </td>
                    	</tr>
                    	<tr>
                    	    <td>Ngày sinh:</td>
                    	    <td colspan="2">
                    	        <asp:TextBox runat="server" ID="txtBirthDay" CssClass="datepicker"></asp:TextBox>(dd/mm/yyyy)
                    	    </td>
                    	    <td>Địa chỉ:</td>
                    	    <td colspan="3">
                    	        <asp:TextBox runat="server" ID="txtAddress" Width="300px"></asp:TextBox>
                    	    </td>
                    	</tr>
                    	<tr>
                    	    <td>Nghề nghiệp:</td>
                    	    <td colspan="2">
                    	        <asp:TextBox runat="server" ID="txtJob"></asp:TextBox>
                    	    </td>
                    	    <td>Email:</td>
                    	    <td class="style1">
                    	        <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                    	    </td>
                    	</tr>
                    	<tr>
                    	    <td>Phone:</td>
                    	    <td colspan="2">
                    	        <asp:TextBox runat="server" ID="txtPhone"></asp:TextBox>
                    	    </td>
                    	    <td>Tel:</td>
                    	    <td class="style1">
                    	        <asp:TextBox runat="server" ID="txtTel"></asp:TextBox>
                    	    </td>
                    	</tr>
                    	<tr>
                    	    <td>Thông tin khác:</td>
                    	    <td colspan="6">
                    	        <asp:TextBox runat="server" ID="txtOther" TextMode="MultiLine" Rows="5" CssClass="textarea"></asp:TextBox>
                    	    </td>
                    	</tr>
                    	<tr>
                    	    <td></td>
                    	    <td>
                    	        <asp:Button runat="server" ID="btnSubmit" Text="Thêm danh bạ" CssClass="btn" 
                                    onclick="btnSubmit_Click" ToolTip="Thêm danh bạ" />
                            </td>                    	    
                    	    <td>
                                    <input type="reset" value="Hủy bỏ" title="Hủy bỏ" class="btn" /></td>                    	    
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
<script type="text/javascript">

    function SelectAll(id) {

        var frm = document.forms[0];

        for (i = 0; i < frm.elements.length; i++) {

            if (frm.elements[i].type == "checkbox") {

                frm.elements[i].checked = document.getElementById(id).checked;
            }
        }
    } 
    </script>    
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style1
        {
            width: 31px;
        }
    </style>

</asp:Content>

