<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkReceived.aspx.cs" Inherits="EOFFICE.Works.WorkReceived" MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">        
    <div class="list wp-form" id="WorkAssignment">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Công việc nhận</h2>
                
                	<div class="nav-function">
                    	<ul>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
                        </ul>
                    </div>
                    <div class="form">
                	<table width="100%" cellspacing="5">
                    	<tr>
                    	    <td>Xem công việc:</td>
                    	    <td>
                    	        <asp:DropDownList runat="server" ID="ddlWork">
                    	            
                    	        </asp:DropDownList>
                    	    </td>
                    	    <td>Nhóm công việc:</td>
                    	    <td>
                    	        <asp:DropDownList runat="server" ID="ddlWorkGroup"></asp:DropDownList>
                    	    </td>
                    	</tr>
                    	<tr>
                    	    <td>Tên công việc:</td>
                    	    <td>
                    	        <asp:TextBox runat="server" ID="txtWorkName"></asp:TextBox>
                    	    </td>
                    	    <td>Người giao việc:</td>
                    	    <td>
                    	        <asp:TextBox runat="server" ID="txtUserCreate"></asp:TextBox>
                    	    </td>
                    	</tr>
                    	<tr>
                    	    <td></td>
                    	    <td>
                    	        <asp:Button ID="btnTim" Text="Tìm kiếm" runat="server" onclick="btnTim_Click" />
                    	</tr>
                    </table>
                    <br />
                    <h2><span class="icon"><img src="../Images/Play.png" alt="Play.png" /></span>DANH SÁCH CÔNG VIỆC NHẬN</h2>
                    <asp:Label runat="server" ID="lblThongBao" Text=""></asp:Label>
                    <br />
                        <asp:GridView ID="grvWork" runat="server" AutoGenerateColumns="False"  DataKeyNames="WorkID"
                            CssClass="tbl-list" Width="100%"  >
                            <Columns>
                                <asp:TemplateField HeaderText="STT">
                                   <ItemTemplate>
                                          <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle Width="3%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Name" HeaderText="Tên công việc">
                                </asp:BoundField>
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
