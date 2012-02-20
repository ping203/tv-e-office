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
        url = "http://" + url + ":85/Ajax/ajLoadUserByDepartment.aspx";
        $('.result-' + id).html('<img src="/images/icon_loading.gif" />');
        $.post(url, { DepartmentID: '' + id + '' }, function(data) {
            $('.result-' + id).html(data);
        });
        return false;
    });
    $("#du-thao-cong-van .a-parent").parent().next().slideToggle("slow");
    $("#listUserProcess").hide();
    $("#btnHide").click(function() {
        $("#listUserProcess").slideToggle("slow");
    });

});
/* check box */
function get_check_value() {
    var c_value = "";

    $(".cbxUser:checked").each
        (
            function() {
                c_value += $(this).val();
            }
        );
            $("#ctl00_cphContent_hdfUsers").val(c_value);                 
} 
