<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkGroupCreat.aspx.cs" Inherits="EOFFICE.Works.WorkGroupCreat" MasterPageFile="~/MasterPages/Default.Master" %>
<%@ Register Assembly="EOFFICE" Namespace="EOFFICE.Common" TagPrefix="MyControl" %>
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
                    <div class="form-left">
                        <p class="label">Tên nhóm công việc:<span class="rq">(*)</span></p>
                        <p class="input"><asp:TextBox ID="txtWorkGroupName" runat="server" Width="300" CssClass="txt required"></asp:TextBox></p>
                        <p class="label">Mô tả:</p>
                        <p class="input"><asp:TextBox ID="txtContent" runat="server" CssClass="textarea" Width="295" TextMode="multiline" Rows="6"></asp:TextBox></p>
                        <p><asp:Button ID="btnSubmit" runat="server" Text="Cập nhật" CssClass="right link-btn" onclick="btnSubmit_Click" /></p>
                    </div>                	
                    <div class="list" id="list-congvieccanlam">            	        
            	        <div class="bunk-function">
            	            <asp:LinkButton ID="btnDelete" runat="server" Text="Xóa nhóm công việc" onclick="btnDelete_Click" CssClass="link-btn"></asp:LinkButton>	    
            	        </div>            	        
            	        <table width="100%">
            	            <tr>
            	                <td align="left"><span runat="server" id="spResultCount" style="float:left"></span></td>
            	                <td align="right">
            	                    Hiển thị:
                                     <asp:DropDownList runat="server" ID="ddlPageSize" AutoPostBack="true" 
                                        onselectedindexchanged="ddlPageSize_SelectedIndexChanged">
                                        <asp:ListItem Text="5 kết quả" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="10 kết quả" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="20 kết quả" Value="20"></asp:ListItem>                                        
                                        <asp:ListItem Text="50 kết quả" Value="50"></asp:ListItem>
                                        <asp:ListItem Text="100 kết quả" Value="100"></asp:ListItem>
                                    </asp:DropDownList>
            	                </td>
            	            </tr>
            	        </table>
                        <asp:GridView ID="grvWorkGroup" runat="server" AutoGenerateColumns="False" 
                                    CssClass="tbl-list" Width="100%" onrowcreated="grvWorkGroup_RowCreated" 
                                    onrowdatabound="grvWorkGroup_RowDataBound" 
                            DataKeyNames="WorkGroupID" onrowcancelingedit="grvWorkGroup_RowCancelingEdit" 
                            onrowediting="grvWorkGroup_RowEditing" 
                            onrowupdating="grvWorkGroup_RowUpdating">
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
                            <MyControl:PaggingControl runat="server" ID="ctlPagging" Mode="Url" PageSize="20"
                                PreviousClause="<img src='/images/Back.png'/>" NextClause="<img src='/images/Forward.png'/>" />
                        </div>
                        
                    </div>
                    </div>
                    <div class="nav-function">
                    	<ul>
                        	
                        	<li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
                        </ul>
                    </div>
                
            </div>
    
</asp:Content>
