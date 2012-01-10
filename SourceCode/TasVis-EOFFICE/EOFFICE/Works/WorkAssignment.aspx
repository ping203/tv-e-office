<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkAssignment.aspx.cs" Inherits="EOFFICE.Works.WorkAssignment" MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">        
    <div class="list wp-form" id="WorkAssignment">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Công việc giao</h2>
                
                	<div class="nav-function">
                    	<ul>
                        	<li><asp:Button ID="btnDung" runat="server" Text="Dừng xử lý" CssClass="btn"></asp:Button></li>
                            <li><asp:Button ID="btnTiepTuc" runat="server" Text="Tiếp tục xử lý" CssClass="btn" 
                                     ></asp:Button></li>
                            <li><asp:Button ID="btnXoa" runat="server" Text="Xóa" CssClass="btn" 
                                     ></asp:Button></li>
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
                    	    <td>Người xử lý:</td>
                    	    <td>
                    	        <asp:TextBox runat="server" ID="txtUserProcess"></asp:TextBox>
                    	    </td>
                    	</tr>
                    	<tr>
                    	    <td></td>
                    	    <td>
                    	        <asp:Button ID="btnTim" Text="Tìm kiếm" runat="server" onclick="btnTim_Click" />
                    	</tr>
                    </table>
                    <br />
                    <h2><span class="icon"><img src="../Images/Play.png" alt="Play.png" /></span>DANH SÁCH CÔNG VIỆC GIAO</h2>
                    <asp:Label runat="server" ID="lblThongBao" Text=""></asp:Label>
                    <br />
                        <asp:GridView ID="grvWork" runat="server" AutoGenerateColumns="False"  DataKeyNames="WorkID"
                            CssClass="tbl-list" Width="100%" onrowcreated="grvWork_RowCreated" 
                            onrowdatabound="grvWork_RowDataBound" >
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
                                <asp:BoundField DataField="Name" HeaderText="Tên công việc">
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Người xử lý</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#BindNguoiXuLy(DataBinder.Eval(Container.DataItem,"IDUserProcess").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Ngày bắt đầu - Hạn kết thúc</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#BindThoiGian(DataBinder.Eval(Container.DataItem,"WorkID").ToString() ) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Trạng thái</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%#BindTrangThai(DataBinder.Eval(Container.DataItem,"WorkID").ToString() ) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>Ngày tạo</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%#BindNgayTao(DataBinder.Eval(Container.DataItem,"WorkID").ToString() ) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle ForeColor="#0072BC" />
                        </asp:GridView>
                        
                    </div>
                    <div class="nav-function">
                    	<ul>
                        	<li><asp:Button ID="Button1" runat="server" Text="Dừng xử lý" CssClass="btn"></asp:Button></li>
                            <li><asp:Button ID="Button2" runat="server" Text="Tiếp tục xử lý" CssClass="btn" 
                                     ></asp:Button></li>
                            <li><asp:Button ID="Button3" runat="server" Text="Xóa" CssClass="btn" 
                                     ></asp:Button></li>
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
