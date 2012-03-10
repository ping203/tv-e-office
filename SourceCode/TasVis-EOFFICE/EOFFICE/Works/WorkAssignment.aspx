<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkAssignment.aspx.cs" Inherits="EOFFICE.Works.WorkAssignment" MasterPageFile="~/MasterPages/Default.Master" %>
<%@ Register Assembly="EOFFICE" Namespace="EOFFICE.Common" TagPrefix="MyControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">        
    <div class="list wp-form" id="WorkAssignment">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Công việc giao</h2>
                
                	<div class="nav-function">
                    	<ul>
                    	    <li><asp:Button runat="server" ID="btnGiaoViec" CssClass="btn" Text="Giao Việc" 
                                    onclick="btnGiaoViec_Click" ></asp:Button></li>
                        	<li><asp:Button ID="btnDung" runat="server" Text="Dừng xử lý" CssClass="btn" 
                                    onclick="btnDung_Click"></asp:Button></li>
                            <li><asp:Button ID="btnTiepTuc" runat="server" Text="Tiếp tục xử lý" CssClass="btn" onclick="btnTiepTuc_Click" 
                                     ></asp:Button></li>
                            <li><asp:Button ID="btnXoa" runat="server" Text="Xóa" CssClass="btn" onclick="btnXoa_Click" 
                                     ></asp:Button></li>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
                        </ul>
                    </div>
                    <div class="form">
                	<table width="80%" cellspacing="1">
                    	<tr>
                    	    <td align="right">Xem công việc:</td>
                    	    <td>
                    	        <asp:DropDownList runat="server" ID="ddlWork" Width="255" 
                                    onselectedindexchanged="ddlWork_SelectedIndexChanged" AutoPostBack="true">                    	            
                    	        </asp:DropDownList>
                    	    </td>
                    	    <td align="right">Nhóm công việc:</td>
                    	    <td>
                    	        <asp:DropDownList runat="server" ID="ddlWorkGroup" Width="255"
                                    onselectedindexchanged="ddlWorkGroup_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    	    </td>
                    	</tr>
                    	<tr>
                    	    <td align="right">Từ khóa:</td>
                    	    <td>
                    	        <asp:TextBox runat="server" ID="txtKeyword" CssClass="txt" Width="250"></asp:TextBox>                    	        
                    	    </td>
                    	    <td align="right">Tiêu chí tìm kiếm:</td>
                    	    <td>
                    	        <asp:DropDownList runat="server" ID="ddlTieuChi">
                    	            <asp:ListItem Text="Tên công việc" Value="WorkName"></asp:ListItem>
                    	            <asp:ListItem Text="Người xử lý" Value="User"></asp:ListItem>
                    	        </asp:DropDownList>
                    	        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnTim" Text="Tìm kiếm" runat="server" CssClass="link-btn" onclick="btnTim_Click" />
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
                                <asp:TemplateField>
                                    <HeaderTemplate>Tên công việc</HeaderTemplate>
                                    <ItemTemplate>
                                        <%--<a href="WorkAssignmentDetail.aspx?WorkID=<%# DataBinder.Eval(Container.DataItem,"WorkID")%>"><%# DataBinder.Eval(Container.DataItem,"Name") %></a>--%>
                                        <asp:LinkButton runat="server" ID="lbtnForward" Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"WorkID")%>' OnClick="lbtnForward_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                    
                                </asp:TemplateField>
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
                        <div class="pagenav">
                            <MyControl:PaggingControl runat="server" ID="ctlPagging" Mode="Url" PageSize="20"
                                PreviousClause="<img src='/images/Back.png'/>" NextClause="<img src='/images/Forward.png'/>" />
                        </div>
                    </div>
                    <div class="nav-function">
                    	<ul>
                    	    <li><asp:Button runat="server" ID="btnGiaoViec2" CssClass="btn" Text="Giao Việc" onclick="btnGiaoViec_Click"></asp:Button></li>
                        	<li><asp:Button ID="btnDung2" runat="server" Text="Dừng xử lý" CssClass="btn" 
                                    onclick="btnDung_Click" ></asp:Button></li>
                            <li><asp:Button ID="btnTiepTuc2" runat="server" Text="Tiếp tục xử lý" CssClass="btn" onclick="btnTiepTuc_Click"
                                     ></asp:Button></li>
                            <li><asp:Button ID="btnXoa2" runat="server" Text="Xóa" CssClass="btn" onclick="btnXoa_Click" 
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
