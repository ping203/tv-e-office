<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkReceived.aspx.cs" Inherits="EOFFICE.Works.WorkReceived" MasterPageFile="~/MasterPages/Default.Master" %>
<%@ Register Assembly="EOFFICE" Namespace="EOFFICE.Common" TagPrefix="MyControl" %>
<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">        
    <div class="list wp-form" id="WorkAssignment">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Công việc nhận</h2>
                
                	<div class="nav-function">
                    	<ul>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
                        </ul>
                    </div>
                    <div class="form">
                	<table width="80%" cellspacing="1">
                    	<tr>
                    	    <td>Xem công việc:</td>
                    	    <td>
                    	        <asp:DropDownList runat="server" ID="ddlWork" 
                                    onselectedindexchanged="ddlWork_SelectedIndexChanged" AutoPostBack="true">
                    	            
                    	        </asp:DropDownList>
                    	    </td>
                    	    <td>Nhóm công việc:</td>
                    	    <td>
                    	        <asp:DropDownList runat="server" ID="ddlWorkGroup" 
                                    onselectedindexchanged="ddlWorkGroup_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    	    </td>
                    	</tr>
                    	<tr>
                    	    <td>Từ khóa:</td>
                    	    <td>
                    	        <asp:TextBox runat="server" ID="txtKeyword"></asp:TextBox>
                    	        <asp:DropDownList runat="server" ID="ddlTieuChi">
                    	            <asp:ListItem Text="Tên công việc" Value="WorkName"></asp:ListItem>
                    	            <asp:ListItem Text="Người xử lý" Value="User"></asp:ListItem>
                    	        </asp:DropDownList>
                    	        <asp:Button ID="btnTim" Text="Tìm kiếm" runat="server" onclick="btnTim_Click" />
                    	    </td>
                    	</tr>
                    </table>
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
                        <asp:GridView ID="grvWork" runat="server" AutoGenerateColumns="False"  DataKeyNames="WorkID"
                            CssClass="tbl-list" Width="100%" onrowcreated="grvWork_RowCreated"  >
                            <Columns>
                                <asp:TemplateField HeaderText="STT">
                                   <ItemTemplate>
                                          <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Width="3%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Tên công việc</HeaderTemplate>
                                    <ItemTemplate>
                                        <a href="WorkReceivedDetail.aspx?WorkID=<%# DataBinder.Eval(Container.DataItem,"WorkID")%>"><%# DataBinder.Eval(Container.DataItem,"Name") %></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Người tạo việc</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%#BindTaoViec(DataBinder.Eval(Container.DataItem,"IDUserCreate").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Người chuyển việc</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%#BindChuyenViec(DataBinder.Eval(Container.DataItem,"IDUserProcess").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                    
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Hạn kết thúc</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%#BindHanKetThuc(DataBinder.Eval(Container.DataItem,"WorkID").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Trạng thái</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%#BindTrangThai(DataBinder.Eval(Container.DataItem,"WorkID").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Ngày giao</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%#BindNgayGiao(DataBinder.Eval(Container.DataItem,"WorkID").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle ForeColor="#0072BC" />
                        </asp:GridView>
                        <div class="pagenav">
                            <MyControl:PaggingControl runat="server" ID="ctlPagging" Mode="Url" PageSize="20"
                                PreviousClause="<img src='/images/Back.png'/>" NextClause="<img src='/images/Forward.png'/>" />
                        </div>
                    </div>
                    <div class="nav-function">
                    	<ul>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
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
