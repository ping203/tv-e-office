$(document).ready(function(){
	//menu-left		
	$(".a-parent").click(function(){
		if($(this).is('.parent-active')){
			$(this).removeClass("parent-active");
			$(this).parent().next().slideToggle("slow");	
		}else{
			$(this).addClass("parent-active");
			$(this).parent().next().slideToggle("slow");
		}	
	});
	$("#du-thao-cong-van .a-parent").parent().next().slideToggle("slow");
});