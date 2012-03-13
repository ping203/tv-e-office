<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="EOFFICE.Calender.Calendar" MasterPageFile="~/MasterPages/Default.Master" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ContentPlaceHolderID="cphContent" ID="ContentDefault" runat="server">       
    
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Panel1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Panel1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div class="list wp-form" id="WorkAssignment">
            	<h2><span class="icon"><img src="../Images/New-document.png" /></span>Lịch công tác cá nhân</h2>
                
                	<div class="nav-function">
                    	<ul>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>
                        </ul>
                    </div>
                    <div class="form">
                	   <telerik:RadScheduler ID="RadScheduler1" runat="server"
                            DataKeyField="CalendarID"
                            DataSubjectField="Name"
                            DataStartField="StartDate"
                            DataEndField="EndDate"
                            DataDescriptionField="Content"
                            Skin="Outlook" Culture="Vietnamese (Vietnam)" 
                            SelectedView="MonthView" DayEndTime="23:59:59" DayStartTime="00:00:00" 
                            Height="" style="margin-bottom: 25" EditFormDateFormat="dd/MM/yyyy" 
                            EnableTheming="True" MonthView-GroupingDirection="Vertical" onformcreated="RadScheduler1_FormCreated" 
                             
                            
                            
                            OnAppointmentCommand="RadScheduler1_AppointmentCommand" 
                             OnClientTimeSlotClick="OnClientTimeSlotClick" 
                            onappointmentcreated="RadScheduler1_AppointmentCreated" onappointmentdelete="RadScheduler1_AppointmentDelete"
                            >                                             
                            <WeekView GroupingDirection="Horizontal" />
                            <Localization AdvancedAllDayEvent="Cả ngày" AdvancedCalendarCancel="Hủy" 
                                AdvancedCalendarOK="Đồng ý" AdvancedCalendarToday="Hôm nay" 
                                AdvancedClose="Đóng" AdvancedDaily="Hàng ngày" AdvancedDay="Ngày" 
                                AdvancedDescription="Mô tả" AdvancedEditAppointment="Sửa lịch làm việc" 
                                AllDay="Cả ngày" Cancel="Hủy" ConfirmCancel="Hủy" 
                                ConfirmDeleteText="Bạn chắc chắn muốn xóa lịch làm việc này?" 
                                ConfirmDeleteTitle="Xác nhận xóa" ConfirmOK="Đồng ý" 
                                ContextMenuAddAppointment="Thêm lịch công tác" ContextMenuDelete="Xóa" 
                                ContextMenuEdit="Sửa" HeaderDay="Ngày" HeaderMonth="Tháng" 
                                HeaderNextDay="Ngày kế tiếp" HeaderPrevDay="Ngày trước" 
                                HeaderTimeline="Dòng thời gian" HeaderToday="Hôm nay" HeaderWeek="Tuần" 
                                Save="Lưu" ShowAdvancedForm="Lựa chọn" AdvancedDone="Xong" 
                                AdvancedNewAppointment="Thêm lịch làm việc" 
                                ContextMenuGoToToday="Tới ngày hôm nay" Show24Hours="Xem theo 24 giờ..." 
                                ShowBusinessHours="Xem theo giờ làm việc..." ShowMore="Xem thêm..." />
                            <AdvancedForm DateFormat="dd/MM/yyyy" />
                            <TimeSlotContextMenuSettings EnableDefault="true" />
                            <AppointmentContextMenuSettings EnableDefault="true" />
                            <MonthView GroupingDirection="Vertical" />
                            
                            <AdvancedEditTemplate>
                                <div class="rsAdvancedEdit">
                                    <div class="rsAdvTitle">
                                        <div class="rsAdvInnerTitle"> Sửa lịch công tác </div>
                                    </div>
                                    <div class="rsAdvContentWrapper">
                                        <div class="rsAdvOptionsScroll">
                                            <div class="rsAdvOptions">
                                                <div class="rsAdvBasicControls">
                                                    <div class="rsAdvOptionsPanel">
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="right" width="135px">Tên lịch công tác:</td>
                                                                <td>
                                                                    <asp:HiddenField runat="server" ID="hdfID" />
                                                                    <asp:TextBox runat="server" ID="SubjectTextBox" Width="100%" CssClass="txt"></asp:TextBox>
                                                                    <br />
                                                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="SubjectTextBox" ErrorMessage="Thông tin cần nhập"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">Thời gian bắt đầu:</td>
                                                                <td>
                                                                    <telerik:RadDateTimePicker ID="StartInput" Runat="server" Culture="Vietnamese (Vietnam)" Skin="Web20">
                                                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Web20"></Calendar>
                                                                        <TimeView CellSpacing="-1" Culture="Vietnamese (Vietnam)" Columns="2" RenderDirection="Vertical"></TimeView>
                                                                        <TimePopupButton ImageUrl="" HoverImageUrl=""></TimePopupButton>
                                                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                                        <DateInput DisplayDateFormat="dd/MM/yyyy HH:mm:ss" DateFormat="dd/MM/yyyy HH:mm:ss"></DateInput>
                                                                    </telerik:RadDateTimePicker>
                                                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="StartInput" ErrorMessage="Thông tin cần nhập"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">Thời gian kết thúc:</td>
                                                                <td>
                                                                    <telerik:RadDateTimePicker ID="EndInput" Runat="server" Culture="Vietnamese (Vietnam)" Skin="Web20">
                                                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Web20"></Calendar>
                                                                        <TimeView CellSpacing="-1" Culture="Vietnamese (Vietnam)" Columns="2" RenderDirection="Vertical"></TimeView>
                                                                        <TimePopupButton ImageUrl="" HoverImageUrl=""></TimePopupButton>
                                                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                                        <DateInput DisplayDateFormat="dd/MM/yyyy HH:mm:ss" DateFormat="dd/MM/yyyy HH:mm:ss" runat="server" ID="dateStart"></DateInput>
                                                                    </telerik:RadDateTimePicker>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="EndInput" ErrorMessage="Thông tin cần nhập"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Thời gian kết thúc phải lớn hơn thời gian bắt đầu" ControlToCompare="StartInput" ControlToValidate="EndInput"
                                                                    Operator="GreaterThanEqual"></asp:CompareValidator>
                                                                    
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">Mô tả:</td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="txtDescription" CssClass="riTextBox riFocused" BorderColor="#C3D9F9" BorderStyle="Solid" BorderWidth="1px" Columns="50" Rows="10" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">Thành phần tham gia:</td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblUserJoin"></asp:Label>
                                                                    <asp:HiddenField runat="server" ID="hdfUserJoin" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">Địa điểm:</td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="txtAddress" Width="100%" CssClass="txt"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                <asp:Panel runat="server" ID="panelUser">
                                                                    <br />
                                                                    <p style="font-size:12pt">Thay đổi thành phần tham gia:<p>                                                               
                                                                    <div>
                                                                        
                                                                            <asp:Repeater ID="rptDepartment" runat="server"  DataSource="<%#BindDepartment() %>">
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
                                                                     </asp:Panel>      
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td></td>
                                                                <td align="right">
                                                                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Cập nhật">
                                                                    </asp:Button>&nbsp &nbsp
                                                                    <asp:Button ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Hủy bỏ">
                                                                    </asp:Button>
                                                                </td>
                                                            </tr>      
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </AdvancedEditTemplate>
                                
                            <AdvancedInsertTemplate>
                                <div class="rsAdvancedEdit">
                                    <div class="rsAdvTitle">
                                        <div class="rsAdvInnerTitle"> Thêm lịch công tác </div>
                                    </div>
                                    <div class="rsAdvContentWrapper">
                                        <div class="rsAdvOptionsScroll">
                                            <div class="rsAdvOptions">
                                                <div class="rsAdvBasicControls">
                                                    <div class="rsAdvOptionsPanel">
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="right" width="135px">Tên lịch công tác:</td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="SubjectTextBox" Width="100%" CssClass="txt"></asp:TextBox>
                                                                    <br />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="SubjectTextBox" ErrorMessage="Thông tin cần nhập"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">Thời gian bắt đầu:</td>
                                                                <td>
                                                                    <telerik:RadDateTimePicker ID="StartInput" Runat="server" Culture="Vietnamese (Vietnam)" Skin="Web20">
                                                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Web20"></Calendar>
                                                                        <TimeView CellSpacing="-1" Culture="Vietnamese (Vietnam)" Columns="2" RenderDirection="Vertical"></TimeView>
                                                                        <TimePopupButton ImageUrl="" HoverImageUrl=""></TimePopupButton>
                                                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                                        <DateInput DisplayDateFormat="dd/MM/yyyy HH:mm:ss" DateFormat="dd/MM/yyyy HH:mm:ss"></DateInput>
                                                                    </telerik:RadDateTimePicker>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="StartInput" ErrorMessage="Thông tin cần nhập"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">Thời gian kết thúc:</td>
                                                                <td>
                                                                    <telerik:RadDateTimePicker ID="EndInput" Runat="server" Culture="Vietnamese (Vietnam)" Skin="Web20">
                                                                        <Calendar runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Web20"></Calendar>
                                                                        <TimeView runat="server" CellSpacing="-1" Culture="Vietnamese (Vietnam)" Columns="2" RenderDirection="Vertical"></TimeView>
                                                                        <TimePopupButton ImageUrl="" HoverImageUrl=""></TimePopupButton>
                                                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                                        <DateInput DisplayDateFormat="dd/MM/yyyy HH:mm:ss" DateFormat="dd/MM/yyyy HH:mm:ss" runat="server" ID="dateStart"></DateInput>
                                                                    </telerik:RadDateTimePicker>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="EndInput" ErrorMessage="Thông tin cần nhập"></asp:RequiredFieldValidator>
                                                                    <br />
                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Thời gian kết thúc phải lớn hơn thời gian bắt đầu" ControlToCompare="StartInput" ControlToValidate="EndInput"
                                                                    Operator="GreaterThanEqual"></asp:CompareValidator>
                                                                    
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">Mô tả:</td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="txtDescription" CssClass="riTextBox riFocused" BorderColor="#C3D9F9" BorderStyle="Solid" BorderWidth="1px" Columns="50" Rows="10" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">Địa điểm:</td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="txtAddress" Width="100%" CssClass="txt"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                <asp:Panel runat="server" ID="panelUser">
                                                                    <p>Chọn thành phần tham gia:</p>                                                                    
                                                                    <div>                                                                    
                                                                        <asp:Repeater ID="rptDepartment" runat="server" DataSource="<%#BindDepartment() %>">
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
                                                                    </div>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td></td>
                                                                <td align="right">
                                                                    <asp:Button ID="UpdateButton" runat="server" CssClass="link-btn" CommandName="Insert" Text="Thêm lịch công tác">
                                                                    </asp:Button>&nbsp &nbsp
                                                                    <asp:Button ID="UpdateCancelButton" runat="server" CssClass="link-btn" CausesValidation="False" CommandName="Cancel" Text="Hủy bỏ">
                                                                    </asp:Button>
                                                                </td>
                                                            </tr>      
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </AdvancedInsertTemplate>
                            
                            <InlineInsertTemplate>
                               <div>
                                    <table>
                                        <tr>
                                            <td>
                                                <telerik:RadTextBox ID="txtName" runat="server" 
                                                    TextMode="MultiLine" Rows="4" EmptyMessage="Tên lịch công tác" Columns="30"
                                                    Skin="Windows7" ClientEvents-OnValueChanged="OnValueChanged">
                                                </telerik:RadTextBox>
                                                                                        
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="rsEditOptions">
                                                    <asp:LinkButton ID="btnSave" runat="server" CommandName="Insert" Text="Thêm" class="rsAptEditConfirm" />
                                                    <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Hủy bỏ"
                                                        class="rsAptEditCancel" />
                                                    <asp:LinkButton ID="btnOptions" runat="server" CommandName="More" Text="Lựa chọn" class="rsAptEditMore" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </InlineInsertTemplate>
                        </telerik:RadScheduler>
                         
                    <asp:HiddenField ID="HiddenField1" runat="server" /> 
                    <script type="text/javascript">
                        function OnValueChanged(sender) {
                            var txbValue = document.getElementById("HiddenField1");
                            txbValue.value = sender.get_editValue();
                        }  
                        </script> 
                    </div>
                    <div class="nav-function">
                    	<ul>
                            <li><INPUT TYPE="button" class="btn" VALUE="Quay về" onClick="history.go(-1);"></li>                            
                        </ul>                        
                    </div>
            </div>           
            
            <asp:HiddenField runat="server" ID="hdf" />
             <script type="text/javascript">
                 function OnClientTimeSlotClick(sender, eventArgs) {
                     
                     var Messages = $get('<%=hdf.ClientID%>');
                     Messages.value = eventArgs.get_time().format('yyyy/MM/dd hh:mm:ss');
                 }
            </script>
</asp:Content>

