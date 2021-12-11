/// <reference path="../angular.min.js" />

var myapp = angular.module('CartApp', [/*'angularUtils.directives.dirPagination'*/]);

myapp.controller("CartController", function ($scope, $http) {
    $http({
        method: "get",
        url: "/Cart/GetCart"
    }).then(function (d) {
        $scope.orders1 = d.data;
        //alert("Lấy giỏ hàng thành công!");
    }, function (error) {
        alert("Lay gio hang loi");
    })
    //var orders = window.sessionStorage.getItem("orders");
    //var data = JSON.parse(orders);
    //$scope.orders = data;

    //Bug: chưa phân trang được bên giỏ hàng

    $scope.Delete = function (p) {
        $http({
            method: "get",
            url: '/Cart/DeleteCart',
            datatype: 'json',
            params: { product_id: p.Product_id }
        }).then(function (d) {
            ////alert('Xoa thanh cong');
            var index = $scope.orders1.indexOf(p);
            $scope.orders1.splice(index, 1);
        }, function (error) {
                alert('Xoa san pham khoi gio hang loi');
        })
        
        //window.sessionStorage.setItem("orders", JSON.stringify($scope.orders));
        
    }
    $scope.total = sessionStorage.getItem("total");
    //Lấy về tổng tiền các sản phẩm trong giỏ hàng
    $scope.minusTotal = function (price) {
        $scope.total = parseInt($scope.total) - price;
        window.sessionStorage.setItem("total", $scope.total);
    };
    //Bug: Chua thay doi tong tien theo gia ban vaf so luong
    
});

