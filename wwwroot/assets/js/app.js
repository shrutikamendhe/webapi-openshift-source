/*
* Click2Cloud
* Copyright (c) 2015 All Rights Reserved
*/
(function () {
    'use strict';

    /* Common Validation function */

    function ValidateIndex(index) {
        if (index == "" || index == '' || index == undefined) {
            alert("Enter index");
            return false;
        }

        var regex = /^[0-9]+$/;
        if (!regex.test(index)) {
            alert("Only numeric value is allowed.")
            return false;
        }

        return true;
    }

    function ValidateTitle(title) {
        if (title == "" || title == '' || title == undefined) {
            alert("Title should not be left blank!");
            return false;
        }

        return true;
    }

    /*****************************/


    var app = angular.module('app', ['angular-loading-bar', "ngSanitize"]);

    app.controller("MyTodoController", function ($scope, $http) {
        var scope = $scope;

        scope.logs = "";
        scope.mytodoList = [];

        scope.$watchCollection('mytodoList', function (newToDo, oldToDo) {
            if (scope.mytodoList.length > 0) {
                for (var i = 0 ; i < scope.mytodoList.length; i++) {
                    scope.mytodoList[i].Index = i;
                }
            }
        });

        var localUrl = location.origin + "/api/todo";
        scope.logs += "<p>Sending request to <a href='" + localUrl + "' target='_blank'>" + localUrl + "</a></p>";
        $http.get("/api/todo")
        .success(function (data, status, header, config) {
            scope.logs += "<p>Response received from <a href='" + localUrl + "' target='_blank'>" + localUrl + "</a><br/>Data: <i>" + JSON.stringify(data) + "</i></p>";
            scope.mytodoList = data;
        })
        .error(function (data, status, header, config) {
            scope.logs += "<p style='color: #b94a48;'>Error received from <a href='" + localUrl + "' target='_blank'>" + localUrl + "</a><br/>Status Code: " + status + "</p>";
        });

        var elem = document.getElementById("dvAddNewItemForm");
        scope.showHideForm = function (state) {
            if(state)
                elem.style.display = "";
            else
                elem.style.display = "none";
        }

        scope.post = function (title, detail) {
            
            if (!ValidateTitle(title))
                return;

            if (detail == "" || detail == '' || detail == undefined) {
                detail = "";
            }

            var state = "ACTIVE";

            var localUrl = location.origin + "/api/todo?Title=" + title + "&Detail=" + detail + "&State=" + state;
            scope.logs += "<p>Sending request to <a href='" + localUrl + "' target='_blank'>" + localUrl + "</a></p>";
            $http.post("/api/todo?Title=" + title + "&Detail=" + detail + "&State=" + state)
                .success(function (data, status, header, config) {
                    scope.logs += "<p>Response received from <a href='" + localUrl + "' target='_blank'>" + localUrl + "</a><br/>Data: <i>" + JSON.stringify(data) + "</i></p>";
                    scope.mytodoList.push({
                        "Title": title,
                        "Detail": detail,
                        "State": state
                    });

                    scope.title = undefined;
                    scope.detail = undefined;
                    elem.style.display = "none";
                })
                .error(function (data, status, header, config) {
                    scope.logs += "<p style='color: #b94a48;'>Error received from <a href='" + localUrl + "' target='_blank'>" + localUrl + "</a><br/>Status Code: " + status + "</p>";
                });
        };

        scope.put = function (index, status) {
            var strStatus = "";

            if (status)
                strStatus = "Done";
            else
                strStatus = "Active";

            var localUrl = location.origin + "/api/todo/" + index + "?state=" + strStatus;
            scope.logs += "<p>Sending request to <a href='" + localUrl + "' target='_blank'>" + localUrl + "</a></p>";
            $http.put("/api/todo/" + index + "?state=" + strStatus)
                .success(function (data, status, header, config) {
                    scope.logs += "<p>Response received from <a href='" + localUrl + "' target='_blank'>" + localUrl + "</a><br/>Data: <i>" + JSON.stringify(data) + "</i></p>";
                    scope.mytodoList[index].State = strStatus;
                })
                .error(function (data, status, header, config) {
                    scope.logs += "<p style='color: #b94a48;'>Error received from <a href='" + localUrl + "' target='_blank'>" + localUrl + "</a><br/>Status Code: " + status + "</p>";
                });
        };

        scope.delete = function (index) {
            var localUrl = location.origin + "/api/todo/" + index;
            scope.logs += "<p>Sending request to <a href='" + localUrl + "' target='_blank'>" + localUrl + "</a></p>";

            $http.delete("/api/todo/" + index)
                .success(function (data, status, header, config) {
                    scope.logs += "<p>Response received from <a href='" + localUrl + "' target='_blank'>" + localUrl + "</a><br/>Data: <i>" + JSON.stringify(data) + "</i></p>";
                    scope.mytodoList.splice(index, 1);
                })
                .error(function (data, status, header, config) {
                    scope.logs += "<p style='color: #b94a48;'>Error received from <a href='" + localUrl + "' target='_blank'>" + localUrl + "</a><br/>Status Code: " + status + "</p>";
                });
        };

    });
})();