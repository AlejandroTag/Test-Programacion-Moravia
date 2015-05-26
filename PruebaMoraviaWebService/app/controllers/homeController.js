'use strict';

app.controller('homeController', ['$scope', '$http', 'GlobalUrlWebApi', 'authService', '$window', function ($scope, $http, GlobalUrlWebApi, authService, $window) {
    
    $scope.comments = [];

    $scope.user = authService.authentication.userName;

    $scope.submitted = false;

    var hub = $.connection.myHub; // create a proxy to signalr hub on web server

    // Create a function that the hub can call back to display messages.

    hub.client.addNewMessageToPage = function (name, message) {
       
        var nuevo =
            {
                userName: name,

                commentDescription: message
            }
        
        //$scope.comments.push(nuevo);
        //$scope.$apply(); // this is outside of angularjs, so need to apply
        
        ShowComments();//pongo asi para que me muestre el tiempo que paso, porque eso se hace en el back-end.
    };

    $scope.mailTo = function () {

        $window.location = "mailto:alejandrotaglioni@gmail.com";
    }

    function ShowComments() {

        $http.get(GlobalUrlWebApi.serviceBase + '/api/Comments')
       
            .success(function (data, status) {
                
                $scope.comments = data; // show current complaints

            })
            .error(function (data, status) {
                $scope.comments = [];
                $scope.errorToSearch = errorMessage(data, status);
            })
    };

    $scope.toShow = function () {
        return $scope.comments && $scope.comments.length > 0;
    };
    
    $scope.mailTo = function () {

        var link = "mailto:" + authService.authentication.userName;

        $window.location.href = link;
    }
    
    $.connection.hub.start().done(function () {

        ShowComments();

        $scope.postOne = function () {

            $scope.submitted = true;

            if ($scope.frmComment.$valid)
            {
                $http.post(GlobalUrlWebApi.serviceBase + "/api/Comments", {

                    UserName: $scope.user,

                    CommentDescription: $scope.descToAdd
                })
                .success(function (data, status) {
                    
                    hub.server.send($scope.user, $scope.descToAdd);

                    $scope.errorToAdd = null;
                    $scope.descToAdd = null;

                    ClearForm();
                })
                .error(function (data, status) {
                    $scope.errorToAdd = errorMessage(data, status);
                })

            }
            
        };
        
    }); // connect to signalr hub


    function ClearForm() {

        $scope.frmComment.$setPristine(); //here f1 our form name
        $scope.submitted = false;
    }

}]);