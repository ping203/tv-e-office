<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentEdit.aspx.cs" Inherits="EOFFICE.DocumentEdit"
    MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server" ID="ContentUser">
  <div class="list wp-form" id="create-document">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Tạo công văn dự thảo</h2>
                <form>
                	<div class="nav-function">
                    	<ul>
                        	<li><a href="#" class="btn"><span class="icon"><img src="../Images/Save.png" /></span>Lưu bản thảo</a></li>
                            <li><a href="#" class="btn"><span class="icon"><img src="../Images/Forward.png" /></span>Gửi bản thảo</a></li>
                            <li><a href="#" class="btn"><span class="icon"><img src="../Images/Erase.png" /></span>Hủy bỏ</a></li>
                            <li><a href="#" class="btn"><span class="icon"><img src="../Images/Go-back.png" /></span>Quay về</a></li>
                        </ul>
                    </div>
                    <div class="form">
                	<table width="100%" cellspacing="5">
                    	<tr>
                        	<td>Loại công văn:<span class="required">*</span></td>
                            <td colspan="3">
                            	<select class="select">
                                	<option>-- Chọn loại công văn --</option>
                                    <option value="1">Giấy mời</option>
                                    <option value="2">Thông báo</option>
                                    <option value="3">Quyết định</option>
                                    <option value="1">Nghị quyết</option>
                                </select>     
                                <a href="#" class="link-btn">Thêm loại công văn</a>                       
                            </td>
                        </tr>
                        <tr>
                        	<td>Tên bản thảo:<span class="required">*</span></td>
                            <td colspan="3"><input type="text" name="tenbanthao" class="txt" /></td>                            
                        </tr>
                        <tr>
                        	<td>Ngày bắt đầu: <span class="required">*</span></td>
                            <td><input type="text" class="txt" />(dd/mm/yy)</td>
                            <td colspan="2">Ngày kết thúc: <span class="required">*</span><input type="text" class="txt" />(dd/mm/yy)</td>                            
                        </tr>
                        <tr>
                        	<td>Nội dung tóm tắt: </td>
                            <td colspan="3"><textarea cols="5" rows="5" name="tomtat" class="textarea"></textarea></td>
                        </tr>
                        <tr>
                        	<td>Nội dung công văn: </td>
                            <td colspan="3"><textarea cols="10" rows="10" class="textarea"></textarea></td>
                        </tr>
                        <tr>
                        	<td>Bản thảo: </td>
                            <td colspan="3"><input type="file" /></td>
                        </tr>
                        <tr>
                        	<td>Mức độ ưu tiên: </td>
                            <td><input type="radio" name="rdoPrior" value="1" />Rất quan trọng </td>
                            <td><input type="radio" name="rdoPrior" value="2" />Quan trọng </td>
                            <td><input type="radio" name="rdoPrior" value="3" />Bình thường </td>
                            <select class="select">
                                	<option>-- Chọn loại công văn --</option>
                                    <option value="1">Giấy mời</option>
                                    <option value="2">Thông báo</option>
                                    <option value="3">Quyết định</option>
                                    <option value="1">Nghị quyết</option>
                                </select>  
                        </tr>
                        <tr>
                        	<td>Người xử lý/tham gia ý kiến: </td>
                            <td colspan="3"><textarea cols="5" rows="5" class="textarea"></textarea></td>
                        </tr>
                    </table>
                    </div>
                    <div class="nav-function">
                    	<ul>
                        	<li><a href="#" class="btn"><span class="icon"><img src="../Images/Save.png" /></span>Lưu bản thảo</a></li>
                            <li><a href="#" class="btn"><span class="icon"><img src="../Images/Forward.png" /></span>Gửi bản thảo</a></li>
                            <li><a href="#" class="btn"><span class="icon"><img src="../Images/Erase.png" /></span>Hủy bỏ</a></li>
                            <li><a href="#" class="btn"><span class="icon"><img src="../Images/Go-back.png" /></span>Quay về</a></li>
                        </ul>
                    </div>
                </form>
            </div>  
</asp:Content>
