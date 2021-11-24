/// <reference path="angular.min.js" />


var app = angular.module("LoginApp", []);

app.controller("LoginController", function ($http, $scope) {

    //$http.get('/Login/GetAccount').then(function success(d) {
    //    $scope.accounts = d.data;
    //}, function (error) {
    //    //alert("faile");
    //});

    var username = 'tommy';
    var user = { email: "", pass: "" };
    $scope.User = user;

    
    
    $scope.Login = function () {
        $http({
            method: 'Get',
            url: '/Login/CheckLogin',
            params: { us: $scope.User.email, pw: $scope.User.pass }
        }).then(function (d) {
            //alert('login active!');
            $scope.account = d.data;
            //alert($scope.account.username);
            if (($scope.User.email == $scope.account.username) && ($scope.User.pass == $scope.account.password)) {
                var pathname_login = sessionStorage.getItem('pathname_login');
                window.location = pathname_login;
                window.sessionStorage.setItem('username', $scope.account.username);
            }
            else {
                alert("Tài khoản hoặc mật khẩu không chính xác!");
            }
        }, function (error) {
            alert('Đăng nhập lỗi')
        });

    }

    var new_user = { email: "", pass: "" };
    $scope.New_user = new_user;

    $scope.Register = function () {
        $http({
            method: "POST",
            url: '/Register/Register',
            params: { us: $scope.New_user.email, pw: $scope.New_user.pass }
        }).then(function (d) {
            alert('Đăng ký thành công!');
        }, function (error) {
                alert('Đăng ký tài khoản lỗi');
        });
    }

});