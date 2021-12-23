/// <reference path="angular.min.js" />

var admin = angular.module('Admin', ['angularUtils.directives.dirPagination']);

admin.controller("ProductController", function ($scope, $http) {

    $http({
        method: "get",
        url: '/Home/GetProducts'
    }).then(function success(d) {
        $scope.products = d.data;

    }, function (error) {
        //alert("failure");
    });


    $scope.sortcolumn = "Product_id";
    $scope.reverse = true;
    $scope.direct = "Ascending";

    $scope.Chon = function (d) {

        if ($scope.direct == "Ascending") {
            $scope.reverse = false;
            $scope.direct = "Decreasing";
        } else {
            $scope.reverse = true;
            $scope.direct = "Ascending";
        }
    }

    // Toast function
    $scope.showSuccessToast = function () {
        $scope.toast({
            title: "Thành công!",
            message: "Cập nhật dữ liệu thành công.",
            type: "success",
            duration: 5000
        });
    }

    $scope.showErrorToast = function () {
        $scope.toast({
            title: "Thất bại!",
            message: "Có lỗi xảy ra, vui lòng thử lại sau.",
            type: "error",
            duration: 5000
        });
    }

    $scope.toast = function ({ title = "", message = "", type = "info", duration = 3000 }) {
        const main = document.getElementById("toast");
        if (main) {
            const toast = document.createElement("div");

            // Auto remove toast
            const autoRemoveId = setTimeout(function () {
                main.removeChild(toast);
            }, duration + 1000);

            // Remove toast when clicked
            toast.onclick = function (e) {
                if (e.target.closest(".toast__close")) {
                    main.removeChild(toast);
                    clearTimeout(autoRemoveId);
                }
            };

            const icons = {
                success: "fas fa-check-circle",
                info: "fas fa-info-circle",
                warning: "fas fa-exclamation-circle",
                error: "fas fa-exclamation-circle"
            };
            const icon = icons[type];
            const delay = (duration / 1000).toFixed(2);

            toast.classList.add("toast", `toast--${type}`);
            toast.style.animation = `slideInLeft ease .3s, fadeOut linear 1s ${delay}s forwards`;

            toast.innerHTML = `
                    <div class="toast__icon">
                        <i class="${icon}"></i>
                    </div>
                    <div class="toast__body">
                        <h3 class="toast__title">${title}</h3>
                        <p class="toast__msg">${message}</p>
                    </div>
                    <div class="toast__close">
                        <i class="fas fa-times"></i>
                    </div>
                `;
            main.appendChild(toast);
        }
    }

    $http({
        method: "get",
        url: '/Admin/Category/GetCategories'
    }).then(function success(d) {
        $scope.categories = d.data;
    }, function (error) {
        alert('Lấy danh sách loại lỗi');
    });

    $scope.Delete = function (s) {

        $http({
            method: "POST",
            url: '/Admin/Product/Delete',
            params: { id: s.Product_id }
        }).then(function success(d) {
            var index = $scope.products.indexOf(s);
            $scope.products.splice(index, 1);
        }, function (error) {
            alert('Delete failure!');
        });
    }


    $scope.Add = function () {
        $scope.e_product = null;
    }

    $scope.Edit = function (product) {
        $scope.e_product = product;
    };

    

    $scope.SaveAdd = function () {

        var Product = {
            Product_id: $scope.Product_id,
            Product_title: $scope.Product_title,
            Category_id: $scope.Category_id,
            Publisher_id: $scope.Publisher_id,
            Author: $scope.Author,
            Quantity: $scope.Quantity,
            Price: $scope.Price,
            Image_url: $scope.Image_url,
            Big_image_url: $scope.Big_image_url,
            Description: $scope.Description,
            Active_flag: $scope.Active_flag
        }

        $http({
            method: "POST",
            url: "/Admin/Product/Add",
            dataType: "json",
            data: JSON.stringify(Product)
            //params: { product: Product }
        }).then(function success(d) {
            alert('Thêm sản phẩm thành công!');
            $scope.products.push(Product);
        }, function (error) {
            //alert('Add product failure');
        });
    }

    $scope.Update = function () {

        var Product = {
            Product_id: $scope.e_product.Product_id,
            Product_title: $scope.e_product.Product_title,
            Category_id: $scope.e_product.Category_id,
            Publisher_id: $scope.e_product.Publisher_id,
            Author: $scope.e_product.Author,
            Quantity: $scope.e_product.Quantity,
            Price: $scope.e_product.Price,
            Image_url: $scope.e_product.Image_url,
            Big_image_url: $scope.e_product.Big_image_url,
            Description: $scope.e_product.Description,
            Active_flag: $scope.e_product.Active_flag
        }

        $http({
            method: "POST",
            url: "/Admin/Product/Update",
            dataType: "json",
            data: JSON.stringify(Product)
            //params: { product: Product }
        }).then(function success(d) {
            //$scope.products.push(Product);
        }, function (error) {
            alert('Update product failure');
        });
    }

    $scope.Login = function () {
        alert('active')
        const pathname_login = window.location.pathname;
        window.sessionStorage.setItem('pathname_login', pathname_login);
    };

});

var app = angular.module('Login', []);

app.controller("LoginController", function ($scope, $http) {
    var user = { email: "", pass: "" };
    $scope.User = user;

    $scope.Login = function () {
        $http({
            method: 'Get',
            url: '/Admin/Login/CheckLogin',
            params: { us: $scope.User.email, pw: $scope.User.pass }
        }).then(function (d) {
            $scope.account = d.data;
            if (($scope.User.email == $scope.account.username) && ($scope.User.pass == $scope.account.password)) {
                window.location = '/admin';
            }
            else {
                alert("Tài khoản hoặc mật khẩu không chính xác!");
            }
        }, function (error) {
            alert('Đăng nhập lỗi')
        });

    }
})

var uploadapp = angular.module('UploadApp', ['ngFileUpload']);
uploadapp.controller('UploadImage', function ($scope, $http, Upload, $timeout, $document) {
    $scope.UploadFiles = function (file, kieu) {
        $scope.SelectedFiles = file;
        if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
            Upload.upload({
                url: 'admin/product/upload',
                data: { files: $scope.SelectedFiles, category_id: $scope.sp.Category_id }
            }).then(function (d) {
                if (kieu = 'Anh') {
                    $scope.sp.Image_url = d.data[0];
                }
                else {
                    $scope.sp.Big_image_url = d.data[0];
                }
            }, function (error) {
                    alert('Upload failure');
            });
        }
    }
});