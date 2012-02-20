<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EOFFICE.Works.Default" MasterPageFile="~/MasterPages/Default.Master" %>

<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">        
<div class="list wp-form" id="createWork">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Tạo công việc mới</h2>
                    
                	<div class="nav-function">
                    	<ul>
                        	<li><asp:Button ID="btnSave" runat="server" Text="Lưu" CssClass="btn" onclick="btnSave_Click" OnClientClick='return get_check_value();'></asp:Button></li>
                            <li><asp:LinkButton ID="btnForward" runat="server" Text="Giao việc" CssClass="btn" 
                                    onclick="btnForward_Click" ></asp:LinkButton></li>
                            <li><input type="reset" class="btn" value="Hủy bỏ" /></asp:Button></li>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
                        </ul>
                    </div>
                    <div class="form">
                    
                	<table width="100%" cellspacing="5">
                    	<tr>
                        	<td width="115px">Nhóm công việc:<span class="rq">*</span></td>
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
                            <td><asp:TextBox ID="txtStartDate" runat="server" CssClass="required datepicker"></asp:TextBox>
                                (ngày/tháng/năm)<asp:RegularExpressionValidator 
                                    ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="txtStartDate" ErrorMessage="Sai định dạng ngày tháng" 
                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator></td>
                            <td colspan="2">Ngày kết thúc: <span class="rq">*</span><asp:TextBox ID="txtEndDate" runat="server" CssClass="required datepicker"></asp:TextBox>(ngày/tháng/năm)<asp:RegularExpressionValidator 
                                    ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEndDate" 
                                    ErrorMessage="Sai định dạng ngày tháng" 
                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator><br />
                                <asp:CompareValidator 
                                    ID="CompareValidator1" runat="server" ControlToCompare="txtStartDate" 
                                    ControlToValidate="txtEndDate" 
                                    ErrorMessage="Ngày kết thúc phải lớn hơn ngày bắt đầu" 
                                    Operator="GreaterThanEqual"></asp:CompareValidator></td>                            
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
                            <td colspan="3">
                                <asp:FileUpload ID="FileUpload1" runat="server" class="multi" />
                            </td>
                        </tr>
                        <tr>
                        	<td>Mức độ ưu tiên: </td>
                            <td><asp:RadioButton ID="rdoPrior1" runat="server" GroupName="rdoPrior" Text="Rất quan trọng" Checked="true"/></td>
                            <td><asp:RadioButton ID="rdoPrior2" runat="server" GroupName="rdoPrior" Text="Quan trọng" /></td>
                            <td><asp:RadioButton ID="rdoPrior3" runat="server" GroupName="rdoPrior" Text="Bình thường" /></td>
                        </tr>
                        
                    </table>
                    <form name="orderform">
                        <table>
                            <tr>
                        	    <td>Người nhận việc: </td>
                                <td colspan="3">
                                    <div>                                                                    
                                        <asp:Repeater ID="rptDepartment" runat="server">
                                            <HeaderTemplate><table></HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <div class="link-department">
                                                            <a href='<%#Request.Url.Host %>' class="lbtDepartment" id='<%#Eval("DepartmentID") %>' style="font-weight:bold">
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/expand.png" ImageAlign="AbsMiddle" />
                                                                <%#Eval("Name") %>
                                                            </a>
                                                        </div>
                                                        <div class='result-<%#Eval("DepartmentID") %>' style="margin-left:30px;margin-top:5px"></div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate></table></FooterTemplate>
                                        </asp:Repeater>                                                                    
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdfUsers" runat="server" />
                    </form>
                    
                    </div>
                    <div class="nav-function">
                    	<ul>
                        	<li><asp:Button ID="btnSave2" runat="server" Text="Lưu" OnClick="btnSave_Click" CssClass="btn" OnClientClick='return get_check_value();'   
                                    ></asp:Button></li>
                            <li><asp:LinkButton ID="btnForward2" runat="server" Text="Giao việc" CssClass="btn" 
                                    onclick="btnForward_Click" ></asp:LinkButton></li>
                            <li><input type="reset" class="btn" value="Hủy bỏ" /></asp:Button></li>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
                            
                        </ul>
                    </div>
                    
            </div>
</asp:Content>
