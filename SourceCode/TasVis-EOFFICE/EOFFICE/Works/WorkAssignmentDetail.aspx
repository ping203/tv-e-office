<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkAssignmentDetail.aspx.cs" Inherits="EOFFICE.Works.WorkAssignmentDetail" MasterPageFile="~/MasterPages/Default.Master" %>


<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">        
    <div class="list wp-form" id="WorkAssignment">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Công việc giao</h2>
                
                	<div class="nav-function">
                    	<ul>
                    	    <li><asp:Button runat="server" ID="btnThemXuLy" CssClass="btn" Text="Thêm xử lý" 
                                     ></asp:Button></li>
                        	<li><input type="reset" value="Hủy bỏ" class="btn" /></li>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
                        </ul>
                    </div>
                    <div class="form">
                        <table width="100%" cellpadding="5">
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="Tên công việc: "></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="Ngào tạo: "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text="Ngày bắt đầu: "></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" Text="Ngày kết thúc: "></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="Yêu cầu xử lý: "></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text="File kèm theo: "></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                    <h2><span class="icon"><img src="../Images/Play.png" alt="Play.png" /></span>Danh sách người thực hiện công việc</h2>
                    <br />
                    <table width="100%" cellpadding="5">
                        <tr>
                            <td style="width:20%;vertical-align:top">Danh sách người thực hiện</td>
                            <td style="width:80%">
                                Nội dung xử lý:
                                <br />
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="textarea" TextMode="multiline" Rows="5" ReadOnly="true"></asp:TextBox>
                                <br />
                                File báo cáo:
                                <br />
                                Quyền: <asp:CheckBox runat="server" ID="chkChuyentiep" Text="Chuyển tiếp" /> &nbsp <asp:CheckBox runat="server" ID="chkXem" Text="Xem xử lý khác" />
                                <br />
                                Chọn: &nbsp <asp:RadioButton runat="server" ID="rdoNoiDung" Text="Xóa nội dung" GroupName="rdoXoa"/>
                                &nbsp <asp:RadioButton runat="server" ID="rdoFile" Text="Xóa các file" GroupName="rdoXoa"/>
                                &nbsp <asp:RadioButton runat="server" ID="rdoTatCa" Text="Xóa cả nội dung và file" GroupName="rdoXoa"/>
                                &nbsp &nbsp <asp:LinkButton CssClass="link-btn" runat="server" Text="    Xóa    " ID="btnXoa"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <h2><span class="icon"><img src="../Images/Play.png" alt="Play.png" /></span>Thêm ý kiến xử lý của tôi</h2>    
                    <br />
                    <table cellpadding="5" width="100%">
                        <tr>
                            <td style="width:20%">
                                Nội dung:<span class="rq">*</span>
                            </td>
                            <td style="width:80%">
                                <asp:TextBox ID="txtContent" runat="server" CssClass="textarea" TextMode="multiline" Rows="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:20%">
                                Báo cáo kèm theo (nếu có):
                            </td>
                            <td style="width:80%">
                                <asp:FileUpload ID="FileUpload1" runat="server" class="multi" /> &nbsp
                                <asp:LinkButton runat="server" Text="Upload" CssClass="link-btn"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:20%">
                                Trạng thái công việc:
                            </td>
                            <td style="width:80%">
                                 <asp:RadioButton runat="server" ID="RadioButton1" Text="Hoàn thành" GroupName="rdoTrangThai"/>
                                &nbsp <asp:RadioButton runat="server" ID="RadioButton2" Text="Tạm dừng" GroupName="rdoTrangThai"/>
                                &nbsp <asp:RadioButton runat="server" ID="RadioButton3" Text="Tiếp tục xử lý" GroupName="rdoTrangThai"/>
                                &nbsp &nbsp <asp:LinkButton CssClass="link-btn" runat="server" Text="Cập nhật trạng thái" ID="btnCapNhat"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    </div>
                    <div class="nav-function">
                    	<ul>
                    	    <li><asp:Button runat="server" ID="Button1" CssClass="btn" Text="Thêm xử lý" 
                                     ></asp:Button></li>
                        	<li><input type="reset" value="Hủy bỏ" class="btn" /></li>
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
