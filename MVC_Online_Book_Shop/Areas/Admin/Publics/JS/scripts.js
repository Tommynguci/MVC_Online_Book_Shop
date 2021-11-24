$(document).ready(function () {
    $('.nav-bar img').click(function () { 
        if($('.dashboard').css('width') == '200px'){
            $('.dashboard').css('width', '64px');
            $('.content').css('width', 'calc(100% - 64px)');
            $('.nav-bar').css('left', '64px');
            $('.title').css('display', 'none');
            $('.icon-down').css('display', 'none');
            $('.shop-info').css('height', '70px');  
            $('.shop-info img').css('width', '40px');
            $('.shop-info img').css('height', '40px');
            $('.shop-info img').css('margin', '32px');
            $('.shop-name').css('display', 'none');
            $('.nav-bar ul').css('right', '100px');
        }
        else if($('.dashboard').css('width') == '64px'){
            $('.dashboard').css('width', '200px');
            $('.content').css('width', 'calc(100% - 200px)');
            $('.nav-bar').css('left', '200px');
            $('.title').css('display', 'block');
            $('.icon-down').css('display', 'block');
            $('.shop-info').css('height', '130px');
            $('.shop-info img').css('width', '80px');
            $('.shop-info img').css('height', '80px');
            $('.shop-info img').css('margin', '25% 50%');
            $('.shop-name').css('display', 'block');
            $('.nav-bar ul').css('right', '237px');
        }
    });
    $('.sub-menu').click(function () { 
        var sub_menu = $(this);
        var icon_down = sub_menu.find('.icon-down');
        $(icon_down).toggleClass('fa-angle-up');

        var sub_menu_down = $(sub_menu).next('.dropdown-container');
        $(sub_menu_down).slideToggle(200);
    });
    $('.btn').click(function () { 
        var sub_menu_down = $(this).next('.dropdown-container');
        $(sub_menu_down).slideToggle(200);
    });
    // set số thứ tự tự động cho full menu
    var stt = $('.statistic-item3 .stt');
    var rows = $('table tr').length;
    for(var i = 0; i < rows; i++){
        $(stt[i]).html(i+1);
    }
    $('.btn-del').click(function () { 
        var product = $(this).closest('.products');
        $(product).remove();
        var stt = $('.statistic-item3 .stt');
        var rows = $('table tr').length;
        for(var i = 0; i < rows; i++){
            $(stt[i]).html(i+1);
        }
    });
    var today = new Date();
    var date = today.getDate() + '-' + (today.getMonth()+1)+ '-' + today.getFullYear();
    // var date = today.getHours() +':'+ today.getUTCMinutes() +':'+ today.getSeconds()+' '+ today.getDate() + '-' + (today.getMonth()+1)+ '-' + today.getFullYear();
    $('#currentDate').text(date.toString());

});




