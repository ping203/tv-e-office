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
                        	<td align="right">Nhóm công việc:<span class="rq">(*)</span></td>
                            <td>                            	
                                <asp:DropDownList runat="server" ID="ddlWorkGroup" AppendDataBoundItems="true" CssClass="required"></asp:DropDownList>
                                <asp:LinkButton CssClass="link-btn" Text="Thêm nhóm công việc" runat="server" ID="btnAddGroup" PostBackUrl="~/Works/WorkGroupCreat.aspx"></asp:LinkButton>                       
                            </td>
                        </tr>
                        <tr>
                        	<td align="right">Tên công việc:<span class="rq">(*)</span></td>
                            <td><asp:TextBox ID="txtWorkName" runat="server" CssClass="txt required"></asp:TextBox></td>                            
                        </tr>
                        <tr>
                        	<td align="right">Ngày bắt đầu: <span class="rq">(*)</span></td>
                            <td>
                                <asp:TextBox ID="txtStartDate" runat="server" CssClass="txt required datepicker"></asp:TextBox>(ngày/tháng/năm)                                
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtStartDate" ErrorMessage="Sai định dạng ngày tháng" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>                                                                
                            </td>                            
                        </tr>
                        <tr>
                            <td align="right">Ngày kết thúc: <span class="rq">(*)</span></td>
                            <td>                                
                                <asp:TextBox ID="txtEndDate" runat="server" CssClass="txt required datepicker"></asp:TextBox>(ngày/tháng/năm)                                
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEndDate" ErrorMessage="Sai định dạng ngày tháng" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtStartDate" ControlToValidate="txtEndDate" ErrorMessage="Ngày kết thúc phải lớn hơn ngày bắt đầu" Operator="GreaterThanEqual"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                        	<td align="right">Nội dung tóm tắt: </td>
                            <td><asp:TextBox ID="txtDescription" runat="server" CssClass="textarea" TextMode="multiline" Rows="5" Height="80" Width="500"></asp:TextBox></td>
                        </tr>
                        <tr>
                        	<td align="right">Nội dung công việc: </td>
                            <td><asp:TextBox ID="txtContent" runat="server" CssClass="textarea" Width="500" TextMode="multiline" Rows="10" Height="120"></asp:TextBox></td>
                        </tr>
                        <tr>
                        	<td align="right">File đính kèm: </td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" class="multi" />
                            </td>
                        </tr>
                        <tr>
                        	<td align="right">Mức độ ưu tiên: </td>
                            <td>
                                <asp:RadioButton ID="rdoPrior1" runat="server" GroupName="rdoPrior" Text="Rất quan trọng" Checked="true"/>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdoPrior2" runat="server" GroupName="rdoPrior" Text="Quan trọng" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdoPrior3" runat="server" GroupName="rdoPrior" Text="Bình thường" />
                            </td>
                        </tr>    
                        <tr>
                            <td align="right">Người nhận việc: </td>
                            <td>
                                <form name="orderform">
                                <asp:Repeater ID="rptDepartment" runat="server">
                                    <HeaderTemplate><table></HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <div class="link-department">
                                                    <a href='<%#Request.Url.Host %>' class="lbtDepartmentCreate" id='<%#Eval("DepartmentID") %>' style="font-weight:bold">
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
                                <asp:HiddenField ID="hdfUsers" runat="server" />
                            </form>
                            </td>
                        </tr>                    
                    </table>                                        
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
