'use strict';
app.controller('loginController', ['$scope', '$location', 'authService', '$routeParams', function ($scope, $location, authService, $routeParams) {

    //Model to send
    $scope.loginData = {
        userName: "",
        password: "",
        returnUrl: $routeParams.returnUrl
    };
    
    if (authService.authentication.isAuth) {
        $location.path('/home');
    }

    $scope.errorLogin = false;

    $scope.submitted = false;

    $scope.message = "";

    //------------------------------------------------

    $scope.login = function () {

        $scope.submitted = true;

        if ($scope.loginForm.$valid) {

            authService.login($scope.loginData).then(function (response) {

                if ($scope.loginData.returnUrl !== undefined) {
                    $location.path('/home');
                } else {
                    $location.path('/home');
                }

                
            },
        function (err) {

            $scope.errorLogin = true;
            $scope.message = err.error_description;
        });
        }

       
    };

}]);