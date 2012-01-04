<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EOFFICE._Default" MasterPageFile="~/MasterPages/Default.Master" %>
<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">
    <div class="list" id="hot-function">
    	<h2><span class="icon"><img src="Images/Wrench.png" /></span>Truy cập nhanh các chức năng</h2>
        <ul>
        	<li><a href="file:///E:/TASVIS/PROJECT/NganSon/HTML/CreateDocument.html" class="a-hot-function create-doc-out"><span class="icon"><img src="Images/New-document.png" /></span>Tạo văn bản dự thảo</a><span class="icon-go"></span></li>
            <li><a href="#" class="a-hot-function create-doc-in"><span class="icon"><img src="Images/New-document.png" /></span>Nhập văn bản đến</a><span class="icon-go"></span></li>
            <li><a href="#" class="a-hot-function create-work"><span class="icon"><img src="Images/Create.png" /></span>Tạo mới công việc</a><span class="icon-go"></span></li>
            <li><a href="#" class="a-hot-function work-play"><span class="icon"><img src="Images/Play.png" /></span>Công việc cần hoàn thành</a><span class="icon-go"></span></li>
            <li><a href="#" class="a-hot-function search-doc"><span class="icon"><img src="Images/Text-preview.png" /></span>Tra cứu văn bản</a><span class="icon-go"></span></li>
        </ul>
    </div><!-- end hot-function -->
    <div class="list" id="list-congvieccanlam">
    	<h2><span class="icon"><img src="Images/Play.png" /></span>Danh sách công việc cần hoàn thành</h2>
    	<table class="tbl-list" width="100%" cellspacing="1" cellpadding="3">
    	    <tr>
    	        <td colspan="7">    	            
    	            <select class="select">
    	                <option>Xóa</option>
    	                <option>Duyệt</option>
    	            </select>
    	            <a href="#" class="link-btn">Thực hiện</a>
    	        </td>
    	    </tr>
        	<tr>
        	    <th><input type="checkbox" /></th>
            	<th>Stt</th>
                <th><a href="#" class="order-desc">Tên công việc</a></th>
                <th><a href="#">Ngày bắt đầu</a></th>
                <th><a href="#">Ngày hoàn thành</a></th>
                <th>Ghi chú</th>
                <th>Thao tác</th>
            </tr>            
            <tr>
                <td><input type="checkbox" /></td>
            	<td align="center">1</td>
                <td>Báo cáo công việc tuần từ 19/12 -> 24/12/2011</td>
                <td align="center">23/12/2011</td>
                <td align="center">24/12/2011</td>
                <td>Báo cáo tuần</td>
                <td><a href="#" class="link-function update" title="Cập nhật">Cập nhật</a><a href="#" class="link-function cancel" title="Hủy">Hủy</a><a href="#" class="link-function delete" title="Xóa">Xóa</a></td>
            </tr>
            <tr class="altenate">
                <td><input type="checkbox" /></td>
            	<td align="center">2</td>
                <td>Báo cáo công việc tuần từ 19/12 -> 24/12/2011</td>
                <td align="center">23/12/2011</td>
                <td align="center">24/12/2011</td>
                <td>Báo cáo tuần</td>
                <td><a href="#" class="link-function edit" title="Sửa">Sửa</a><a href="#" class="link-function delete" title="Xóa">Xóa</a></td>
            </tr>
            <tr>
                <td><input type="checkbox" /></td>
            	<td align="center">3</td>
                <td>Báo cáo công việc tuần từ 19/12 -> 24/12/2011</td>
                <td align="center">23/12/2011</td>
                <td align="center">24/12/2011</td>
                <td>Báo cáo tuần</td>
                <td><a href="#" class="link-function edit">Sửa</a><a href="#" class="link-function delete">Xóa</a></td>
            </tr>
            <tr class="altenate">
                <td><input type="checkbox" /></td>
            	<td align="center">4</td>
                <td>Báo cáo công việc tuần từ 19/12 -> 24/12/2011</td>
                <td align="center">23/12/2011</td>
                <td align="center">24/12/2011</td>
                <td>Báo cáo tuần</td>
                <td><a href="#" class="link-function edit" title="Sửa">Sửa</a><a href="#" class="link-function delete">Xóa</a></td>
            </tr>
            <tr>
                <td><input type="checkbox" /></td>
            	<td align="center">5</td>
                <td>Báo cáo công việc tuần từ 19/12 -> 24/12/2011</td>
                <td align="center">23/12/2011</td>
                <td align="center">24/12/2011</td>
                <td>Báo cáo tuần</td>
                <td><a href="#" class="link-function edit">Sửa</a><a href="#" class="link-function delete">Xóa</a></td>
            </tr>
            <tr class="altenate">
                <td><input type="checkbox" /></td>
            	<td align="center">6</td>
                <td>Báo cáo công việc tuần từ 19/12 -> 24/12/2011</td>
                <td align="center">23/12/2011</td>
                <td align="center">24/12/2011</td>
                <td>Báo cáo tuần</td>
                <td><a href="#" class="link-function edit">Sửa</a><a href="#" class="link-function delete">Xóa</a></td>
            </tr>
            <tr>
                <td><input type="checkbox" /></td>
            	<td align="center">7</td>
                <td>Báo cáo công việc tuần từ 19/12 -> 24/12/2011</td>
                <td align="center">23/12/2011</td>
                <td align="center">24/12/2011</td>
                <td>Báo cáo tuần</td>
                <td><a href="#" class="link-function edit">Sửa</a><a href="#" class="link-function delete">Xóa</a></td>
            </tr>
            <tr class="altenate">
                <td><input type="checkbox" /></td>
            	<td align="center">8</td>
                <td>Báo cáo công việc tuần từ 19/12 -> 24/12/2011</td>
                <td align="center">23/12/2011</td>
                <td align="center">24/12/2011</td>
                <td>Báo cáo tuần</td>
                <td><a href="#" class="link-function edit">Sửa</a><a href="#" class="link-function delete">Xóa</a></td>
            </tr>
            <tr>
                <td><input type="checkbox" /></td>
            	<td align="center">9</td>
                <td>Báo cáo công việc tuần từ 19/12 -> 24/12/2011</td>
                <td align="center">23/12/2011</td>
                <td align="center">24/12/2011</td>
                <td>Báo cáo tuần</td>
                <td><a href="#" class="link-function edit">Sửa</a><a href="#" class="link-function delete">Xóa</a></td>
            </tr>
            <tr class="altenate">
                <td><input type="checkbox" /></td>
            	<td align="center">10</td>
                <td>Báo cáo công việc tuần từ 19/12 -> 24/12/2011</td>
                <td align="center">23/12/2011</td>
                <td align="center">24/12/2011</td>
                <td>Báo cáo tuần</td>
                <td><a href="#" class="link-function edit">Sửa</a><a href="#" class="link-function delete">Xóa</a></td>
            </tr>
        </table>
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
    <div class="list" id="list-vanbanden">
    	<h2><span class="icon"><img src="Images/List-in.png" /></span>Danh sách văn bản đến</h2>
    	<table class="tbl-list" width="100%" cellspacing="1" cellpadding="3">
        	<tr>
            	<th>Stt</th>
                <th><a href="#" class="order-desc">Ngày nhận</a></th>
                <th><a href="#">Văn bản số</a></th>
                <th><a href="#">Nơi phát hành</a></th>
                <th>Trích yếu</th>
            </tr>
            <tr>
            	<td align="center">1</td>
                <td>Báo cáo công việc tuần từ 19/12 -> 24/12/2011</td>
                <td align="center">23/12/2011</td>
                <td align="center">24/12/2011</td>
                <td>Báo cáo tuần</td>
            </tr>
            <tr class="altenate">
            	<td align="center">2</td>
                <td>Báo cáo công việc tuần từ 19/12 -> 24/12/2011</td>
                <td align="center">23/12/2011</td>
                <td align="center">24/12/2011</td>
                <td>Báo cáo tuần</td>
            </tr>
            <tr>
            	<td align="center">3</td>
                <td>Báo cáo công việc tuần từ 19/12 -> 24/12/2011</td>
                <td align="center">23/12/2011</td>
                <td align="center">24/12/2011</td>
                <td>Báo cáo tuần</td>
            </tr>
            <tr class="altenate">
            	<td align="center">4</td>
                <td>Báo cáo công việc tuần từ 19/12 -> 24/12/2011</td>
                <td align="center">23/12/2011</td>
                <td align="center">24/12/2011</td>
                <td>Báo cáo tuần</td>
            </tr>
        </table>	
    </div>
</asp:Content>
