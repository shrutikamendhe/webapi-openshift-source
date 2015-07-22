(function () {
    'use strict';

    var app = angular.module('app', []);

    app.controller("GetTodoAllController", function ($scope, $http) {
        $http.get("/api/todo").
            success(function (data, status, header, config) {
                $scope.todoList = data;
            }).
            error(function (data, status, header, config) {
                alert("Error occured:" + data);
            });
    });

    app.controller("GetTodoByIndexController", function ($scope, $http) {
        $scope.Go = function () {

            var index = document.getElementById("txtToDoIndexID").value;
            if (index == "" || index == '') {
                alert("Enter index");
                return;
            }

            $http.get("/api/todo/" + index).
                success(function (data, status, header, config) {
                    $scope.todo = data;
                }).
                error(function (data, status, header, config) {
                    alert("Error occured:" + data);
                });
        };

        
    });

})();