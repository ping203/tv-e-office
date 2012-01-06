<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EOFFICE.Works.Default" MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">    
    
    <div class="list wp-form" id="createWork">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Tạo công việc mới</h2>
                
                	<div class="nav-function">
                    	<ul>
                        	<li><asp:Button ID="btnSave" runat="server" Text="Lưu công việc" CssClass="btn" onclick="btnSave_Click"></asp:Button></li>
                            <li><asp:Button ID="btnForward" runat="server" Text="Giao việc" CssClass="btn" ></asp:Button></li>
                            <li><asp:Button ID="btnCancel" runat="server" Text="Hủy bỏ" CssClass="btn" ></asp:Button></li>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
                        </ul>
                    </div>
                    <div class="form">
                	<table width="100%" cellspacing="5">
                    	<tr>
                        	<td>Nhóm công việc:<span class="rq">*</span></td>
                            <td colspan="3">                            	
                                <asp:DropDownList runat="server" ID="ddlWorkGroup" AppendDataBoundItems="true" CssClass="required">
                                    
                                </asp:DropDownList>
                                <asp:LinkButton CssClass="link-btn" Text="Thêm nhóm công việc" runat="server" ID="btnAddGroup" PostBackUrl="~/Works/WorkGroupCreat.aspx"></asp:LinkButton>                       
                            </td>
                        </tr>
                        <tr>
                        	<td>Tên công việc:<span class="rq">*</span></td>
                            <td colspan="3"><asp:TextBox ID="txtWorkName" runat="server" CssClass="required"></asp:TextBox></td>                            
                        </tr>
                        <tr>
                        	<td>Ngày bắt đầu: <span class="rq">*</span></td>
                            <td><asp:TextBox ID="txtStartDate" runat="server" CssClass="required"></asp:TextBox>(dd/mm/yy)</td>
                            <td colspan="2">Ngày kết thúc: <span class="rq">*</span><asp:TextBox ID="txtEndDate" runat="server" CssClass="required"></asp:TextBox>(dd/mm/yy)</td>                            
                        </tr>
                        <tr>
                        	<td>Nội dung tóm tắt: </td>
                            <td colspan="3"><asp:TextBox ID="txtDescription" runat="server" CssClass="textarea" TextMode="multiline" Rows="5"></asp:TextBox></td>
                        </tr>
                        <tr>
                        	<td>Nội dung công việc: </td>
                            <td colspan="3"><asp:TextBox ID="txtContent" runat="server" CssClass="textarea" TextMode="multiline" Rows="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                        	<td>File đính kèm: </td>
                            <td colspan="3"><asp:FileUpload ID="AttachsFile" runat="server" /></td>
                        </tr>
                        <tr>
                        	<td>Mức độ ưu tiên: </td>
                            <td><asp:RadioButton ID="rdoPrior1" runat="server" GroupName="rdoPrior" Text="Rất quan trọng"  /></td>
                            <td><asp:RadioButton ID="rdoPrior2" runat="server" GroupName="rdoPrior" Text="Quan trọng" /></td>
                            <td><asp:RadioButton ID="rdoPrior3" runat="server" GroupName="rdoPrior" Text="Bình thường" /></td>
                        </tr>
                        <tr>
                        	<td>Người nhận việc: </td>
                            <td colspan="3"><asp:TextBox ID="txtUserProcess" runat="server" CssClass="textarea" TextMode="multiline" Rows="5"></asp:TextBox></td>
                        </tr>
                    </table>
                    </div>
                    <div class="nav-function">
                    	<ul>
                        	<li><asp:Button ID="btnSave2" runat="server" Text="Lưu công việc" CssClass="btn" ></asp:Button></li>
                            <li><asp:Button ID="btnForward2" runat="server" Text="Giao việc" CssClass="btn" ></asp:Button></li>
                            <li><asp:Button ID="btnCancel2" runat="server" Text="Hủy bỏ" CssClass="btn" ></asp:Button></li>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
                        </ul>
                    </div>
                
            </div>
    
</asp:Content>
