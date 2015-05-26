(function () { 
    var app = angular.module('MoraviaApp', ['ngRoute', 'LocalStorageModule']),
        uri = 'api/Comments',
        errorMessage = function (data, status) {
            return 'Error: ' + status +
                (data.Message !== undefined ? (' ' + data.Message) : '');
        };
        

    app.config(function ($routeProvider, $httpProvider) {

        $routeProvider.when("/home", {
            controller: "homeController",
            templateUrl: "/app/views/home.html"
        });

        $routeProvider.when("/login", {
            controller: "loginController",
            templateUrl: "/app/views/login.html"
        });

        $routeProvider.when("/signup", {
            controller: "signupController",
            templateUrl: "/app/views/signup.html"
        });

        $routeProvider.when("/docs", {
            controller: "docsController",
            templateUrl: "/app/views/docs.html"
        });

        $routeProvider.otherwise({ redirectTo: "/login" });

        $httpProvider.interceptors.push('authInterceptorService');
    });

    app.run(['authService', function (authService) {
        authService.fillAuthData();
    }]);

    app.factory('GlobalUrlWebApi', function () {
        return {

            serviceBase: 'http://localhost:1642/',//Poner la URI donde vaya a correr el web service.

        };
    });

    app.factory('UserService', function () {

        var savedData = {}

        function set(data) {
            savedData = data;
        }
        function get() {
            return savedData;
        }

        return {
            set: set,
            get: get
        }

    });

    app.directive('loading', ['$http', function ($http) {
        return {

            restrict: 'A',

            link: function (scope, elm, attrs) {
                scope.isLoading = function () {

                    return $http.pendingRequests.length > 0;

                };
               
                scope.$watch(scope.isLoading, function (v) {
                    if (v) {
                        elm.show();
                    } else {
                        elm.hide();
                    }
                });
            }
        };

    }]);


})();