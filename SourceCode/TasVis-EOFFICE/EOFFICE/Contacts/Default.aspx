﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EOFFICE.Contacts.Default" MasterPageFile="~/MasterPages/Default.Master" %>
<%@ Register Assembly="EOFFICE" Namespace="EOFFICE.Common" TagPrefix="MyControl" %>
<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">    
    
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
                	<table width="100%" cellspacing="5">
                    	<tr>
                    	    <td class="style3" >Nhóm danh bạ:</td>
                    	    <td class="style4" >
                    	        <asp:DropDownList runat="server" ID="ddlContactGroup"></asp:DropDownList>
                    	    </td>
                    	    <td class="style1" >Giới tính:</td>
                    	    <td >
                    	        <asp:DropDownList runat="server" ID="ddlGender">
                    	            
                    	        </asp:DropDownList>
                    	    </td>
                    	    <td class="style2" >Tiêu chí tìm kiếm:</td>
                    	    <td>
                    	        <asp:DropDownList runat="server" ID="ddlTieuChi">
                    	            <asp:ListItem Text="-- Tất cả --" Value="All"></asp:ListItem>
                    	            <asp:ListItem Text="Tên" Value="Name"></asp:ListItem>
                    	            <asp:ListItem Text="Số điện thoại" Value="Phone"></asp:ListItem>
                    	            <asp:ListItem Text="Email" Value="Email"></asp:ListItem>
                    	            <asp:ListItem Text="Địa chỉ" Value="Address"></asp:ListItem>
                    	        </asp:DropDownList>
                    	    </td>
                    	</tr>
                    	<tr>
                    	    <td>Từ khóa:</td>
                    	    <td>
                    	        <asp:TextBox runat="server" ID="txtKeyWord"></asp:TextBox>
                    	    </td>
                    	</tr>
                    	<tr>
                    	    <td></td>
                    	    <td>
                    	        <asp:Button runat="server" ID="btnSearch" Text="Tìm kiếm" 
                                    ToolTip="Tìm kiếm danh bạ" CssClass="btn" onclick="btnSearch_Click" />
                    	    </td>
                    	</tr>                    	
                    </table>
                    <div class="list" id="list-congvieccanlam">
            	        <h2><span class="icon"><img src="../Images/Play.png" alt="Play.png" /></span>DANH SÁCH DANH BẠ</h2>
            	        
            	        <div style="margin-bottom:10px">
            	            <asp:LinkButton runat="server" ID="btnXoa" Text="Xóa" CssClass="link-btn" onclick="btnXoa_Click" 
                                ></asp:LinkButton> &nbsp &nbsp &nbsp &nbsp
            	            <asp:Label runat="server" ID="lblThongBao2" ForeColor="Red" Text=""></asp:Label>
            	        </div>
            	        <table width="100%">
                        <tr>
                            <td align="left">  
                                <span runat="server" id="spResultCount" style="float:left"></span>
                            </td>
                            <td align="right">
                                Hiển thị:
                                 <asp:DropDownList runat="server" ID="ddlPageSize" AutoPostBack="true" 
                                    onselectedindexchanged="ddlPageSize_SelectedIndexChanged">
                                    <asp:ListItem Text="5 kết quả" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="10 kết quả" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="20 kết quả" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="30 kết quả" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="50 kết quả" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="100 kết quả" Value="100"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
            	        
                        <asp:GridView ID="grvContact" runat="server" AutoGenerateColumns="False" 
                                    CssClass="tbl-list" Width="100%" 
                            DataKeyNames="ContactID" onrowcreated="grvContact_RowCreated" 
                                    onrowdatabound="grvContact_RowDataBound" 
                                    onrowcancelingedit="grvContact_RowCancelingEdit" 
                                    onrowdeleting="grvContact_RowDeleting" 
                                    onrowediting="grvContact_RowEditing" onrowupdating="grvContact_RowUpdating" >
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CheckAll" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="MyCheckBox" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Width="3%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="STT">
                                   <ItemTemplate>
                                          <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Width="3%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="FullName" HeaderText="Họ tên">
                                    
                                </asp:BoundField>
                                <asp:BoundField DataField="Phone" HeaderText="Di động" >    
                                    
                                </asp:BoundField>
                                <asp:BoundField DataField="Tel" HeaderText="Điện thoại nhà" >
                                    
                                </asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email" >
                                    
                                </asp:BoundField>
                                <asp:BoundField DataField="Address" HeaderText="Địa chỉ" >
                                    
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Thao tác</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" CommandName="Edit" CssClass="link-function edit"  runat="server" ToolTip="Sửa" />
                                        <asp:LinkButton ID="LinkButton4" CommandName="Delete" CssClass="link-function delete"  runat="server" ToolTip="Xóa" OnClientClick="javascript:return confirm('Bạn chắc chắn muốn xóa danh bạ?');"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton2" CommandName="Update" CssClass="link-function update" ToolTip="Cập nhật"   runat="server" />
                                        <asp:LinkButton ID="LinkButton3" CommandName="Cancel"  CssClass="link-function cancel" ToolTip="Hủy"  runat="server" />
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="7%" />                   
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle ForeColor="#0072BC" />
                        </asp:GridView>
                        <div class="pagenav">
                            <MyControl:PaggingControl runat="server" ID="ctlPagging" Mode="Url" PageSize="20"
                                PreviousClause="<img src='/images/Back.png'/>" NextClause="<img src='/images/Forward.png'/>" />
                        </div>
                        <br />
                       
                        
                    </div>
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
            width: 61px;
        }
        .style2
        {
            width: 147px;
        }
        .style3
        {
            width: 97px;
        }
        .style4
        {
            width: 321px;
        }
    </style>

</asp:Content>

