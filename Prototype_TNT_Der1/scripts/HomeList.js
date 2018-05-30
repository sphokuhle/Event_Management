
BASE_URL = "http://localhost:53056/EventService.svc/";

var app;

//Module  
(function () {
    app = angular.module("HomeEventList_App", []);
})();

//Event Host's Event List
app.controller("cntrl_IndexList", function ($scope, HomeEvents) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,
        }
    };

    // debugger;
    var promiseGet1 = HomeEvents.get();
    $scope.EventDetails = [];
    promiseGet1.then(function (pl) {
        $scope.EventDetails = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});

//SERVICE================================================================
//Find Host's event list
app.service("HomeEvents", function ($http) {
    //debugger;

    this.get = function () {
        return $http.get(BASE_URL + "getHomeEvent/" + getUrlParameter('LoggedID') + "," + getUrlParameter('Type'));
    };
});

//helper functions=====================================================
function getUrlParameter(param, dummyPath) {
    var sPageURL = dummyPath || window.location.search.substring(1),
        sURLVariables = sPageURL.split(/[&||?]/),
        res;
    for (var i = 0; i < sURLVariables.length; i += 1) {
        var paramName = sURLVariables[i],
            sParameterName = (paramName || '').split('=');

        if (sParameterName[0] === param) {
            res = sParameterName[1];
        }
    }
    return res;
}