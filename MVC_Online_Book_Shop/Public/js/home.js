
$(function () {

    // START: Common function (áp dụng cho toàn bộ website)
        $(window).scroll(function () { 
            //đóng me-account-management khi cuộn
            $('.me-management-zone').css('display', 'none');
        });

        Search();

        OpenProductDetail();


        // Lấy về đường dẫn hiện tại trước khi thực hiện đăng nhập
        // Nếu đăng nhập thành công sẽ quay lại đường dẫn đó
        $('.nav-links .nav-login li:first-child').click(function () { 
            
            const pathname_login = window.location.pathname;

            window.sessionStorage.setItem('pathname_login', pathname_login);

        });

        // Đăng nhập
        LogIn();

    // END: Common function
    
    var pathname = window.location.pathname; //Kiểm tra đường dẫn. 
    // Nếu là '/' (trang home) thì chạy hàm scroll. 
    //Nếu khác không hoạt động.

    if (pathname === '/' || pathname === '/Home/Index') {


        // START: Common function
            Check_Login_Status();
            
            ShowAccountManagement();
            
            LogOut();
        // END: Common function

        $(window).scroll(function(){

            // when scroll up 
            ScrollTopUnder200();
    
            // When scroll down
            ScrollTopHigher200();
        });

    } else {

        // START: Common function
            Check_Login_Status();

            ShowAccountManagement();

            LogOut();
        // END: Common function

        $('.nav-container').removeClass('nav-container-visible');

    }
});



// Kiểm tra trạng thái đăng nhập
// Nếu đã đăng nhập thì hiện NavBar đăng nhập
// Nếu chưa đăng nhập thì hiện NavBar mặc định
function Check_Login_Status() {
    var username = sessionStorage.getItem('username');
    
    if (username === null || !username) {
        HideNavBar_Logged();
    } else {
        ShowNavBar_Logged();
    }

}

// Hiển thị Navbar_logged sau khi đăng nhập
function ShowNavBar_Logged() {

    $('.nav-links-logged').css('display', 'flex');
    $('.nav-links').css('display', 'none');

};

// Ẩn Navbar_logged sau khi đăng xuất
function HideNavBar_Logged() {

    $('.nav-links').css('display', 'flex');
    $('.nav-links-logged').css('display', 'none');

};

// Làm mờ NavBar khi cuộn lên 200px
function ScrollTopUnder200(){
    if($(this).scrollTop() < 200){
        $('.nav-brand a, .nav-content li a, .nav-login li a').css('color', '#ccc');
        $('.nav-container').css('background-color', 'rgba(204, 204, 204, 0)');
        $('.nav-container').css('box-shadow', '0 0 0 rgba(0, 0, 0, 0)');
        $('.nav-login').css('color', '#ccc');

        $('.nav-content li a').hover(function () {
            $(this).css('background-color', 'rgba(0, 0, 0, 0)');
            $(this).css('color', '#fff');
        }, function () {
            $(this).css('background-color', 'rgba(204, 204, 204, 0)');
            $(this).css('color', '#ccc');
        },

        $('.nav-brand a').hover(function () {
                $(this).css('color', '#fff');

            }, function () {
                $(this).css('color', '#ccc');
            }
        ),

        $('.nav-login a').hover(function () {
                $(this).css('color', '#fff');
                
            }, function () {
                $(this).css('color', '#ccc');
            }
        ),
    );
    }
};

// Hiện NavBar mặc định khi cuộn xuống 200px
function ScrollTopHigher200() {
    if($(this).scrollTop() >= 200){
        $('.nav-brand a, .nav-content li a, .nav-login li a').css('color', 'rgba(0, 0, 0, 0.7)');
        $('.nav-container').css('background-color', 'rgba(255, 255, 255, 0.8)');
        $('.nav-container').css('box-shadow', '0 0px 7px rgba(0, 0, 0, 0.7)');
        $('.nav-login').css('color', 'rgba(0, 0, 0, 0.7)');
        $('.nav-account-zone').css('background-color', '#ddd');

        $('.nav-content li a').hover(function () {
            $(this).css('background-color', '#ccc');
            $(this).css('color', '#000');
        }, function () {
            $(this).css('background-color', 'rgba(204, 204, 204, 0)');
            $(this).css('color', 'rgba(0, 0, 0, 0.7)');
        },

        $('.nav-brand a').hover(function () {
            $(this).css('color', '#000');

        }, function () {
            $(this).css('color', 'rgba(0, 0, 0, 0.7)');
            }
        ),

        $('.nav-login a').hover(function () {
            $(this).css('color', '#000');
            
        }, function () {
            $(this).css('color', 'rgba(0, 0, 0, 0.7)');
            }
        ),    
        );
    }
};

// Hiện bảng quản lý tài khoản, đăng xuất
function ShowAccountManagement() {
    $('.nav-login .nav-account-zone').click(function () { 
        
        if ($('.me-management-zone').css('display') == 'flex') {

            $('.me-management-zone').css('display', 'none');

        } else {
            
            $('.me-management-zone').css('display', 'flex');

        }

    });
};

// Thay đổi Navbar về mặc định khi đăng xuất
function LogOut() {
    $('.nav-links-logged .me-management-zone .logout').click(function () { 
        window.sessionStorage.setItem('username', '');
        Check_Login_Status();
    });
}

// validate form-login
function LogIn() {

    const username = 'tommy';
    const email = 'storebook.official@gmail.com';
    const password = '123456';
    
    //sửa chức năng đăng nhập

    $('.login-form .form-submit').click(function (e) {
        e.preventDefault();


        const pathname_login = sessionStorage.getItem('pathname_login');
        const i_email = $('.login-form #email').val();
        const i_password = $('.login-form #password').val(); 

        //if ((i_email == email) && (i_password == password)) {

        //    window.location = pathname_login;
        //    window.sessionStorage.setItem('username', username);
        //    Check_Login_Status();

        //} else if ((i_email == email) && (i_password != password)) {
        //     Trường hợp sai mật khẩu
        //    form_message = $('.login-container .form-message:last');
        //    form_message.text('Mật khẩu không chính xác!');

        //} else {
        //    Trường hợp sai tài khoản
        //    form_message = $('.login-container .form-message:first');
        //    form_message.text('Tài khoản không chính xác!');
        //}
        
    });

    // clear form-message khi nhập lại
    //$('.login-container input').keyup(function (e) { 
    //    form_message = $('.login-container .form-message');
    //    form_message.text('');
    //});
}

// hàm tìm kiếm
function Search() {
    $('.nav-links-logged #nav-logged-search').keyup(function () { 
        var input_value = $('.nav-links-logged #nav-logged-search').val();
        if (input_value != null && input_value != '') {

            $('.nav-links-logged .nav-search-result').css('display', 'block');
            $('.nav-links-logged .nav-search-result-more').text('Xem nhiều kết quả hơn về ' + input_value);

        } else if (input_value == ''){

            $('.nav-links-logged .nav-search-result').css('display', 'none');

        }
    });
}

// Mở trang chi tiết sản phẩm
function OpenProductDetail() {
    $('.content-container .card-product').click(function () { 
        window.location = '/product-detail';
    });
}
