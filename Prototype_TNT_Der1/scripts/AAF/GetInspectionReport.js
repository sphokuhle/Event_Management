/// <reference path="../../Scripts/ui-bootstrap-tpls-1.3.3.js" />
/// <reference path="../../Scripts/angular-route.min.js" />
/// <reference path="dirPagination.js" />

//App variable
var app;


//**************Inspect Get All Complete ************//
//Module
(function () {
    app = angular.module("AccommoAppInspecModule", ['angularUtils.directives.dirPagination']);
})();
//controll
app.controller("AccommoAppInspecController", function ($scope, AccommoAppInspecService) {
    // debugger;
    $scope.AccommoAppInspec = [];
    var promiseGet = AccommoAppInspecService.get();

    promiseGet.then(function (pl) {
        $scope.AccommoAppInspec = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading Upcoming Inspections', errorPl);
              });
});
//Services
app.service("AccommoAppInspecService", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/InspectionSevices.svc/getInspecsByStatus/PENDING");
    };
});
//*****************End Inspect*********//
