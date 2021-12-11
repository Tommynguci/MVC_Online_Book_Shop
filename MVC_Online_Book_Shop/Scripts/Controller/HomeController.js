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
    //var data = window.sessionStorage.getItem("orders");
    //var orders = JSON.parse(data);
    //var data_product = new Array();
    //data_product.concat(orders);
    //data_product.splice(0, 1);
    ////$scope.orders = window.sessionStorage.getItem("orders");
    //console.log(data_product);
    //$scope.addToCart = function (product) {
    //    //Lay ve san pham dat mua them vao gio hang

    //    var username = sessionStorage.getItem("username");
    //    if (username != null && username != "logout") {
    //        data_product.push(product);
    //        window.sessionStorage.setItem("orders", JSON.stringify(data_product));
    //        alert('Sản phẩm đã thêm vào giỏ hàng');
    //    }
    //    else if (username == "logout" || username == null) {
    //        alert("Bạn cần đăng nhập để đặt mua!");
    //    }

    //};

    $scope.total = sessionStorage.getItem("total");
    //var total = parseInt($scope.total);
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

