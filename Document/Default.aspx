<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EOFFICE.Contacts.Default" MasterPageFile="~/MasterPages/Default.Master" %>
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
                    <div class="filter">
                	    <table width="100%" cellspacing="5">
                    	    <tr>
                    	        <td>Từ khóa:<asp:TextBox runat="server" ID="txtKeyWord" Width="200" CssClass="txt"></asp:TextBox></td>
                    	        <td>Nhóm danh bạ:<asp:DropDownList runat="server" ID="ddlContactGroup" CssClass="select"></asp:DropDownList></td>                    	    
                    	        <td>Giới tính:<asp:DropDownList runat="server" ID="ddlGender"></asp:DropDownList></td>                    	    
                    	        <td>Tiêu chí tìm kiếm:
                    	            <asp:DropDownList runat="server" ID="ddlTieuChi">                    	                
                    	                <asp:ListItem Text="Tên" Value="Name"></asp:ListItem>
                    	                <asp:ListItem Text="Số điện thoại" Value="Phone"></asp:ListItem>
                    	                <asp:ListItem Text="Email" Value="Email"></asp:ListItem>
                    	                <asp:ListItem Text="Địa chỉ" Value="Address"></asp:ListItem>
                    	            </asp:DropDownList>
                    	        </td>                    	                        	    
                    	        <td><asp:Button runat="server" ID="btnSearch" Text="Tìm kiếm" ToolTip="Tìm kiếm danh bạ" CssClass="link-btn" onclick="btnSearch_Click" /></td>
                    	    </tr>                    	
                        </table>
                    </div>
                    <div id="list-contact">            	                    	        
                        <asp:Label runat="server" ID="lblThongBao2" ForeColor="Red" Text=""></asp:Label>
            	        <div class="bunk-function">
            	            <asp:LinkButton runat="server" ID="btnXoa" Text="Xóa" CssClass="link-btn" onclick="btnXoa_Click"></asp:LinkButton> &nbsp &nbsp &nbsp &nbsp            	            
            	            
            	            <p style="float:right;"><span runat="server" id="spResultCount"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            Hiển thị:
                           <asp:DropDownList runat="server" ID="ddlPageSize" AutoPostBack="true" 
                                onselectedindexchanged="ddlPageSize_SelectedIndexChanged">
                                <asp:ListItem Text="5 kết quả" Value="5"></asp:ListItem>
                                <asp:ListItem Text="10 kết quả" Value="10"></asp:ListItem>
                                <asp:ListItem Text="20 kết quả" Value="20"></asp:ListItem>
                                <asp:ListItem Text="30 kết quả" Value="30"></asp:ListItem>
                                <asp:ListItem Text="50 kết quả" Value="50"></asp:ListItem>
                                <asp:ListItem Text="100 kết quả" Value="100"></asp:ListItem>
                            </asp:DropDownList></p>
            	        </div>            	                    	        
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
                                <asp:BoundField DataField="FullName" HeaderText="Họ tên"></asp:BoundField>
                                <asp:BoundField DataField="Phone" HeaderText="Di động" ></asp:BoundField>
                                <asp:BoundField DataField="Tel" HeaderText="Điện thoại nhà" ></asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email" ></asp:BoundField>
                                <asp:BoundField DataField="Address" HeaderText="Địa chỉ" ></asp:BoundField>
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