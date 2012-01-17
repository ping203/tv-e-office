<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactGroup.aspx.cs" Inherits="EOFFICE.Contacts.ContactGroup" MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">    
    <script type="text/javascript">

    function SelectAll(id) {

        var frm = document.forms[0];

        for (i=0;i<frm.elements.length;i++) {

            if (frm.elements[i].type == "checkbox") {

                frm.elements[i].checked = document.getElementById(id).checked;
            }
        }
    } 
    </script>
    <div class="list wp-form" id="createWorkGroup">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Quản lý nhóm danh bạ</h2>
                
                	<div class="nav-function">
                    	<ul>
                    	    <li><asp:Button ID="btnDanhSach" runat="server" Text="Danh sách liên hệ" CssClass="btn"  /></li>
                    	    <li><asp:Button ID="btnNhom" runat="server" Text="Quản lý nhóm" CssClass="btn" /></li>
                            <li><asp:Button ID="btnThem" runat="server" Text="Thêm liên hệ" CssClass="btn" /></li>
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
                                <asp:Button ID="btnSubmit" runat="server" Text="Thêm"  />
                            </td>
                        </tr>     
                    </table>
                    <div class="list" id="list-congvieccanlam">
            	        <h2><span class="icon"><img src="../Images/Play.png" alt="Play.png" /></span>CẬP NHẬT NHÓM DANH BẠ</h2>
            	        
            	        <br />
                        <asp:GridView ID="grvWorkGroup" runat="server" AutoGenerateColumns="False" 
                                    CssClass="tbl-list" Width="100%" 
                            DataKeyNames="WorkGroupID"  >
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
                                <asp:BoundField DataField="Name" HeaderText="Tên nhóm công việc">
                                </asp:BoundField>
                                <asp:BoundField DataField="Description" HeaderText="Mô tả" >
                                    <ItemStyle Width="45%"  />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Nhóm công việc cha</HeaderTemplate>                                    
                                    <ItemTemplate>                                        
                                        <asp:DropDownList ID="ddlGroupParent" runat="server" Width="200px"  Enabled="false"></asp:DropDownList>
                                    </ItemTemplate>                                    
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlGroupParent" runat="server" Width="200px"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>                                                                   
                                <asp:TemplateField>
                                    <HeaderTemplate>Thao tác</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" CommandName="Edit" CssClass="link-function edit"  runat="server" />
                                        <asp:LinkButton ID="LinkButton4" CommandName="Delete" CssClass="link-function delete"  runat="server"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton2" CommandName="Update" CssClass="link-function update"   runat="server" />
                                        <asp:LinkButton ID="LinkButton3" CommandName="Cancel"  CssClass="link-function cancel"  runat="server" />
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="7%" />                   
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle ForeColor="#0072BC" />
                        </asp:GridView>
                        <div class="pagenav">
                	        <ul>
                    	        <li><a href="#">Trang đầu</a></li>
                                <li><a href="#" class="pagecurrent">1</a></li>
                                <li><a href="#">2</a></li>
                                <li><a href="#">3</a></li>
                                <li><a href="#">4</a></li>
                                <li><a href="#">5</a></li>
                                <li><a href="#">...</a></li>
                                <li><a href="#">Trang cuối</a></li>
                            </ul>
                        </div>
                        <br />
                       
                        
                    </div>
                    </div>
                    <div class="nav-function">
                    	<ul>
                        	<li><asp:Button ID="Button1" runat="server" Text="Danh sách liên hệ" CssClass="btn"  /></li>
                    	    <li><asp:Button ID="Button2" runat="server" Text="Quản lý nhóm" CssClass="btn" /></li>
                            <li><asp:Button ID="Button3" runat="server" Text="Thêm liên hệ" CssClass="btn" /></li>
                        </ul>
                    </div>
                
            </div>
    
</asp:Content>
