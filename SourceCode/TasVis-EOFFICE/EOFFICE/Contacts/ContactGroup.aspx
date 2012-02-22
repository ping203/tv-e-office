<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactGroup.aspx.cs" Inherits="EOFFICE.Contacts.ContactGroup" MasterPageFile="~/MasterPages/Default.Master" %>
<%@ Register Assembly="EOFFICE" Namespace="EOFFICE.Common" TagPrefix="MyControl" %>
<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">    
    
    <div class="list wp-form" id="createWorkGroup">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Quản lý nhóm danh bạ</h2>
                
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
                        	<td>Tên nhóm danh bạ:<span class="rq">*</span></td>
                            <td><asp:TextBox ID="txtWorkGroupName" runat="server" CssClass="required"></asp:TextBox></td>                            
                        </tr>                        
                        <tr>
                        	<td>Mô tả: </td>
                            <td><asp:TextBox ID="txtContent" runat="server" CssClass="textarea" TextMode="multiline" Rows="5"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Thêm" ToolTip="Thêm nhóm danh bạ" 
                                    onclick="btnSubmit_Click" CssClass="btn"  /> &nbsp &nbsp
                               
                                <asp:Label runat="server" ID="lblThongBao"  ForeColor="Red"></asp:Label>
                            </td>
                        </tr>     
                    </table>
                    <div class="list" id="list-congvieccanlam">
            	        <h2><span class="icon"><img src="../Images/Play.png" alt="Play.png" /></span>CẬP NHẬT NHÓM DANH BẠ</h2>
            	        
            	        <div style="margin-bottom:10px">
            	            <asp:LinkButton runat="server" ID="btnXoa" Text="Xóa" CssClass="link-btn" 
                                onclick="btnXoa_Click"></asp:LinkButton> &nbsp &nbsp
            	            <asp:Label runat="server" ID="lblThongBao2" ForeColor="Red" Text=""></asp:Label>
            	        </div>
            	        
            	        
                        <asp:GridView ID="grvContactGroup" runat="server" AutoGenerateColumns="False" 
                                    CssClass="tbl-list" Width="100%" 
                            DataKeyNames="ContactGroupID" 
                                    onrowcancelingedit="grvContactGroup_RowCancelingEdit" 
                                    onrowcreated="grvContactGroup_RowCreated" 
                                    onrowdatabound="grvContactGroup_RowDataBound" 
                                    onrowediting="grvContactGroup_RowEditing" 
                                    onrowupdating="grvContactGroup_RowUpdating" 
                                    onrowdeleting="grvContactGroup_RowDeleting"  >
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
                                <asp:BoundField DataField="GroupName" HeaderText="Tên nhóm danh bạ">
                                </asp:BoundField>
                                <asp:BoundField DataField="Description" HeaderText="Mô tả" >
                                    
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Thao tác</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" CommandName="Edit" CssClass="link-function edit"  runat="server" ToolTip="Sửa" />
                                        <asp:LinkButton ID="LinkButton4" CommandName="Delete" CssClass="link-function delete"  runat="server" ToolTip="Xóa" OnClientClick="javascript:return confirm('Bạn chắc chắn muốn xóa nhóm danh bạ?');"></asp:LinkButton>
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
