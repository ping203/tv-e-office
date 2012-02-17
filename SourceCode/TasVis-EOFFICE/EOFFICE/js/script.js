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
        id=($(this).attr("id"));
        url = $(this).attr("href");
        $.post(url,{ DepartmentID: ''+id+'' }, function(data) {
            $('.result-'+id).html(data);
        });
        return false;
    });
    $("#du-thao-cong-van .a-parent").parent().next().slideToggle("slow");
    $("#listUserProcess").hide();
    $("#btnHide").click(function() {
        $("#listUserProcess").slideToggle("slow");
    });
});
