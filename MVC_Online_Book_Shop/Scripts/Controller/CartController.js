/// <reference path="../angular.min.js" />

var myapp = angular.module('CartApp', [/*'angularUtils.directives.dirPagination'*/]);

myapp.controller("CartController", function ($scope) {
    var orders = window.sessionStorage.getItem("orders");
    var data = JSON.parse(orders);
    $scope.orders = data;

    //Bug: chưa phân trang được bên giỏ hàng

    $scope.Delete = function (p) {
        var index = $scope.orders.indexOf(p);
        $scope.orders.splice(index, 1);
        window.sessionStorage.setItem("orders", JSON.stringify($scope.orders));
    }
    $scope.total = sessionStorage.getItem("total");
    //Lấy về tổng tiền các sản phẩm trong giỏ hàng
    $scope.minusTotal = function (price) {
        $scope.total = parseInt($scope.total) - price;
        window.sessionStorage.setItem("total", $scope.total);
    };
});

