$(document).ready(function() {    
    //menu-left		
    $(".a-parent").click(function() {
        if ($(this).is('.parent-active')) {
            $(this).removeClass("parent-active");
            $(this).parent().next().slideToggle("slow");
        } else {
            $(this).addClass("parent-active");
            $(this).parent().next().slideToggle("slow");
        }
    });
    /* ajax load user by department */
    $(".lbtDepartment").click(function() {
        id = ($(this).attr("id"));
        url = $(this).attr("href");
        user = $('#ctl00_cphContent_RadScheduler1_Form_hdfUserJoin').attr("value");        
        url = "http://" + url + ":85/Ajax/ajLoadUserByDepartment.aspx";
        $('.result-' + id).html('<img src="/images/icon_loading.gif" />');
        $.post(url, { DepartmentID: '' + id + '' , UserJoin: user}, function(data) {
            $('.result-' + id).html(data);
        });
        return false;
    });
    $("#du-thao-cong-van .a-parent").parent().next().slideToggle("slow");
    $("#listUserProcess").hide();
    $("#btnHide").click(function() {
        $("#listUserProcess").slideToggle("slow");
    });
    $(".txtcontentsms").keydown(function(){
        var value=$(this).val();
        var length=value.length;
        
        if(length > 146){
            $(this).val(value.substring(0,146));
        }else{
            var character=146-length;
            $("#lblChar").html(character);
        }
    });     
    //check/uncheck all checkbox
	$(".cbxAll input").change(function(){
        if($(this).is(':checked'))
        {
            $(".cbxItem input").attr("checked",true);   
        }else{
            $(".cbxItem input").attr("checked",false);   
        }
    });
});
/* ajax load user by department work */
$(".lbtDepartmentAjax").click(function() {
        id = ($(this).attr("id"));
        url = $(this).attr("href");
        user = $('#ctl00_cphContent_hdfUserJoin').attr("value");        
        url = "http://" + url + ":85/Ajax/ajLoadUserByDepartment.aspx";
        $('.result-' + id).html('<img src="/images/icon_loading.gif" />');
        $.post(url, { DepartmentID: '' + id + '' , UserJoin: user}, function(data) {
            $('.result-' + id).html(data);
        });
        return false;
    });

    /* ajax load user by department work */
    $(".lbtDepartmentCreate").click(function() {
        id = ($(this).attr("id"));
        url = $(this).attr("href");
        url = "http://" + url + ":85/Ajax/ajLoadUser.aspx";
        $('.result-' + id).html('<img src="/images/icon_loading.gif" />');
        $.post(url, { DepartmentID: '' + id + ''}, function(data) {
            $('.result-' + id).html(data);
        });
        return false;
    });      
/* check box */
function get_check_value() {
    var c_value = "";

    $(".cbxUser:checked").each
        (
            function() {
                c_value += $(this).val()+",";
            }
        );
            $("#ctl00_cphContent_hdfUsers").val(c_value);             
} 
/* check char sms */
function textCounter(field,cntfield,maxlimit) {
    if (field.value.length > maxlimit) // if too long...trim it!
        field.value = field.value.substring(0, maxlimit);
    // otherwise, update 'characters left' counter
    else
    cntfield.value = maxlimit - field.value.length;
}
