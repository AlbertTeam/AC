;(function($) {


// 菜单展示
$('.J_head_menu').on('click',function(){
    var $HBContent = $('.HBContent');
    $HBContent.hasClass('isShow') ? $HBContent.fadeOut("slow").removeClass('isShow') : $HBContent.fadeIn("slow").addClass('isShow')

});




// $('input').iCheck('check');   //将输入框的状态设置为checked 
// ifClicked 	 用户点击了自定义的输入框或与其相关联的label
 // 美化选择框
  $('input').iCheck({
    checkboxClass: 'icheckbox_square-yellow',
    radioClass: 'iradio_square-yellow',
    increaseArea: '20%' // optional
  });


})(jQuery);
