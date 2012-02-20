<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkGroupCreat.aspx.cs" Inherits="EOFFICE.Works.WorkGroupCreat" MasterPageFile="~/MasterPages/Default.Master" %>

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
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Tạo nhóm công việc mới</h2>
                
                	<div class="nav-function">
                    	<ul>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"/></li>
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
                                <asp:Button ID="btnSubmit" runat="server" Text="Cập nhật" onclick="btnSubmit_Click" />
                            </td>
                        </tr>     
                    </table>
                    <div class="list" id="list-congvieccanlam">
            	        <h2><span class="icon"><img src="../Images/Play.png" alt="Play.png" /></span>CẬP NHẬT NHÓM CÔNG VIỆC</h2>
            	        <asp:LinkButton ID="btnDelete" runat="server" Text="Xóa nhóm công việc" onclick="btnDelete_Click" CssClass="link-btn"></asp:LinkButton>	
            	        <br />
                        <asp:GridView ID="grvWorkGroup" runat="server" AutoGenerateColumns="False" 
                                    CssClass="tbl-list" Width="100%" onrowcreated="grvWorkGroup_RowCreated" 
                                    onrowdatabound="grvWorkGroup_RowDataBound" 
                            DataKeyNames="WorkGroupID" onrowcancelingedit="grvWorkGroup_RowCancelingEdit" 
                            onrowediting="grvWorkGroup_RowEditing" 
                            onrowupdating="grvWorkGroup_RowUpdating" >
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
                                        <asp:LinkButton ID="LinkButton1" CommandName="Edit" CssClass="link-function edit" ToolTip="Sửa"  runat="server" />
                                        <asp:LinkButton ID="LinkButton4" CommandName="Delete" CssClass="link-function delete" ToolTip="Xóa"  runat="server"></asp:LinkButton>
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
                        	
                        	<li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
                        </ul>
                    </div>
                
            </div>
    
</asp:Content>
