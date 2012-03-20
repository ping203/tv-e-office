<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EOFFICE._Default" MasterPageFile="~/MasterPages/Default.Master" %>
<%@ Register Assembly="EOFFICE" Namespace="EOFFICE.Common" TagPrefix="MyControl" %>
<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">
    <div class="list" id="hot-function">
    	<h2><span class="icon"><img src="Images/Wrench.png" /></span>Truy cập nhanh các chức năng</h2>
        <ul>
        	<li><a href="/Document/Default.aspx" class="a-hot-function create-doc-out"><span class="icon"><img src="Images/New-document.png" /></span>Tạo văn bản dự thảo</a><span class="icon-go"></span></li>
            <li><a href="/DocumentReceived/DocumentEdit.aspx" class="a-hot-function create-doc-in"><span class="icon"><img src="Images/New-document.png" /></span>Nhập văn bản đến</a><span class="icon-go"></span></li>
            <li><a href="/Works/Default.aspx" class="a-hot-function create-work"><span class="icon"><img src="Images/Create.png" /></span>Tạo mới công việc</a><span class="icon-go"></span></li>
            <li><a href="/Works/WorkReceived.aspx" class="a-hot-function work-play"><span class="icon"><img src="Images/Play.png" /></span>Công việc cần hoàn thành</a><span class="icon-go"></span></li>
            <li><a href="#" class="a-hot-function search-doc"><span class="icon"><img src="Images/Text-preview.png" /></span>Tra cứu văn bản</a><span class="icon-go"></span></li>
        </ul>
    </div><!-- end hot-function -->
    <div class="list" id="list-congvieccanlam">
    	<h2><span class="icon"><img src="Images/Play.png" /></span>Danh sách công việc cần hoàn thành</h2>    	
    	<table width="80%" cellspacing="1">
        	<tr>
        	    <td align="right">Xem công việc:</td>
        	    <td>
        	        <asp:DropDownList runat="server" ID="ddlWork" onselectedindexchanged="ddlWork_SelectedIndexChanged" Width="255" AutoPostBack="true"></asp:DropDownList>
        	    </td>
        	    <td align="right">Nhóm công việc:</td>
        	    <td>
        	        <asp:DropDownList runat="server" ID="ddlWorkGroup" 
                        onselectedindexchanged="ddlWorkGroup_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        	    </td>
        	</tr>
        	<tr>
        	    <td align="right">Từ khóa:</td>
        	    <td>
        	        <asp:TextBox runat="server" ID="txtKeyword" CssClass="txt" Width="250"></asp:TextBox>
        	    </td>
        	    <td align="right">
        	        Tìm kiếm theo:                    	        
        	    </td>
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
                            <a href="/Works/WorkReceivedDetail.aspx?WorkID=<%# DataBinder.Eval(Container.DataItem,"WorkID")%>"><%# DataBinder.Eval(Container.DataItem,"Name") %></a>
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
</asp:Content>
