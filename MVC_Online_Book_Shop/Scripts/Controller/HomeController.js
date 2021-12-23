/// <reference path="angular.min.js" />


var myapp = angular.module('MyApp', [/*'angularUtils.directives.dirPagination'*/]);

myapp.controller("ProductController", function ($scope, $http) {
    
    $http({
        method: "get",
        url: "/Home/GetDetail"
    }).then(function (d) {
        $scope.detail = d.data;
    }, function (error) {
        //alert('Failed');
    });

    $http({
        method: "get",
        url: "/Home/Get_Top_Product_By_Datetime"
    }).then(function (d) {
        $scope.Tproducts = d.data;
    }, function (error) {
        //alert('Failed');
    });

    $http({
        method: "get",
        url: '/Home/GetProducts'
    }).then(function success(d) {
        $scope.products = d.data;
        
    }, function (error) {
        //alert("failure");
    });

    $http({
        method: "get",
        url: '/Home/GetCategories'
    }).then(function success(d) {
        $scope.categories = d.data;
    }, function (error) {
        alert('failed');
    });

    $http({
        method: "get",
        url: '/BestSeller/get_5_product'
    }).then(function success(d) {
        $scope.product_bestseller = d.data;
    }, function (error) {
        alert('failed');
    });

    $scope.selectCategory = function (cat_id) {
        localStorage.setItem('cat_id', cat_id);
    }

    //Bug: Chưa thay đổi số lượng khi chọn sản phẩm đã có, chưa xoá khỏi giỏ hàng khi xoá
    $scope.AddCart = function (o) {
        var username = sessionStorage.getItem("username");
        if (username != null && username != "logout") {
            $http({
                method: "Post",
                dataType: "json",
                url: '/Cart/AddCart',
                data: JSON.stringify(o)
            }).then(function (d) {
                alert("Thêm sản phẩm vào giỏ hàng thành công!");
                //$scope.orders1 = d.data;
            }, function (error) {
                alert("Thêm sản phẩm vào giỏ hàng lỗi");
            });
        }
        else if (username == "logout" || username == null) {
            alert("Bạn cần đăng nhập để đặt mua!");
        }
    };

    $scope.total = sessionStorage.getItem("total");
    if ($scope.total == null || $scope.total == 0 ) {
        $scope.total = 0;
    }
    //Thêm biến tổng tiền
    $scope.plusTotal = function (price) {
        $scope.total = parseInt($scope.total) + price;
        window.sessionStorage.setItem("total", $scope.total);
    };

    
    

    $scope.Login = function () {
        const pathname_login = window.location.pathname;
        window.sessionStorage.setItem('pathname_login', pathname_login);
    };


    //Bug: Đăng xuất vẫn báo thêm sản phẩm vào giỏ hàng
    $scope.Logout = function () {
        sessionStorage.setItem('username', "logout");
    }

});


myapp.controller('CatgoryController', function ($scope, $http) {
    var cat_id = localStorage.getItem('cat_id');
    $http({
        method: "get",
        url: '/Home/GetProductCategory',
        params: { CatID: cat_id }
    }).then(function success(d) {
        $scope.product_category = d.data;
    }, function (error) {
        //alert('Lấy sản phẩm theo loại lỗi');
    });
});


myapp.controller('NewestController', function ($scope, $http) {
    $scope.pageindex = sessionStorage.getItem('currentPage');
    if (sessionStorage.getItem('currentPage') == null) {
        $scope.pageindex = 1;
        $http({
            method: "get",
            url: '/Newest/page/',
            params: { page: 1/*, pagesize: $scope.pagesize*/ }
        }).then(function success(d) {
            $scope.products_by_date = d.data;
            //sessionStorage.setItem('currentPage', $scope.pageindex);
            //window.location = "newest?page=" + $scope.pageindex + "";
        }, function (error) {
            alert("Lấy sản phẩm mới nhất lỗi");
        });
    } else {
        //$scope.pageindex = parseInt($scope.pageindex) + 1;
        $http({
            method: "get",
            url: '/Newest/page/',
            params: { page: $scope.pageindex/*, pagesize: $scope.pagesize*/ }
        }).then(function success(d) {
            $scope.products_by_date = d.data;
            //sessionStorage.setItem('currentPage', $scope.pageindex);
            //window.location = "newest?page=" + $scope.pageindex + "";
        }, function (error) {
            alert("Lấy sản phẩm mới nhất lỗi");
        });
    }

    

    $scope.GetSanPhamListP = function () {
        $scope.pageindex = parseInt($scope.pageindex) + 1;
        sessionStorage.setItem('currentPage', $scope.pageindex);
        window.location = "newest?page=" + $scope.pageindex + "";
    }


    $scope.GetSanPhamListM = function () {

        $scope.pageindex = parseInt($scope.pageindex) - 1;
        sessionStorage.setItem('currentPage', $scope.pageindex);
        window.location = "newest?page=" + $scope.pageindex + "";
    }
});

myapp.controller('BestSellerController', function ($scope, $http) {
    $scope.pageindex = sessionStorage.getItem('currentPageB');
    if (sessionStorage.getItem('currentPageB') == null) {
        $scope.pageindex = 1;
        $http({
            method: "get",
            url: '/BestSeller/page/',
            params: { page: 1 }
        }).then(function success(d) {
            $scope.products_bestseller = d.data;
        }, function (error) {
            alert("Lấy sản phẩm mới nhất lỗi");
        });
    } else {
        $http({
            method: "get",
            url: '/BestSeller/page/',
            params: { page: $scope.pageindex }
        }).then(function success(d) {
            $scope.products_bestseller = d.data;
        }, function (error) {
            alert("Lấy sản phẩm mới nhất lỗi");
        });
    }



    $scope.GetSanPhamListP = function () {
        $scope.pageindex = parseInt($scope.pageindex) + 1;
        sessionStorage.setItem('currentPageB', $scope.pageindex);
        window.location = "bestseller?page=" + $scope.pageindex + "";
    }


    $scope.GetSanPhamListM = function () {

        $scope.pageindex = parseInt($scope.pageindex) - 1;
        sessionStorage.setItem('currentPageB', $scope.pageindex);
        window.location = "bestseller?page=" + $scope.pageindex + "";
    }
});
