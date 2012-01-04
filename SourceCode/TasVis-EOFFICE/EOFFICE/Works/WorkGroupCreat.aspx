<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkGroupCreat.aspx.cs" Inherits="EOFFICE.Works.WorkGroupCreat" MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">    
    
    <div class="list wp-form" id="createWorkGroup">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Tạo nhóm công việc mới</h2>
                
                	<div class="nav-function">
                    	<ul>
                            <li><asp:LinkButton ID="btnBack" runat="server" Text="Quay về" CssClass="btn" onclick="btnBack_Click"></asp:LinkButton></li>
                        </ul>
                    </div>
                    <div class="form">
                	<table width="100%" cellspacing="5">
                    	<tr>
                        	<td>Tên nhóm công việc:<span class="rq">*</span></td>
                            <td><asp:TextBox ID="txtWorkGroupName" runat="server" CssClass="required"></asp:TextBox></td>                            
                        </tr>                        
                        <tr>
                        	<td>Mô tả: </td>
                            <td><asp:TextBox ID="txtContent" runat="server" CssClass="textarea" TextMode="multiline" Rows="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Cập nhật" />
                            </td>
                        </tr>     
                    </table>
                    <div class="list" id="list-congvieccanlam">
            	        <h2><span class="icon"><img src="Images/Play.png" /></span>THÊM NHÓM CÔNG VIỆC</h2>
            	        <asp:DataGrid ID="grvWorkGroup" runat="server" AllowCustomPaging="True" 
                                AllowSorting="True" AutoGenerateColumns="False" Width="100%">
                                <Columns>
                                    <asp:TemplateColumn >
                                        <ItemTemplate>
                                            <asp:CheckBox ID="myCheckBox" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="Name" HeaderText="Nhóm công việc"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Description" HeaderText="Mô tả"></asp:BoundColumn>
                                    
                                    <asp:TemplateColumn HeaderText="Thao tác" >
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Sửa" CommandName="Edit"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" Text="Xóa" CommandName="Delete"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                
                            </asp:DataGrid>
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
                    </div>
                    </div>
                    <div class="nav-function">
                    	<ul>
                        	<li><asp:LinkButton CausesValidation="false"  ID="btnBack2" runat="server" 
                                    Text="Quay về" CssClass="btn" onclick="btnBack2_Click" ></asp:LinkButton></li>
                        </ul>
                    </div>
                
            </div>
    
</asp:Content>
