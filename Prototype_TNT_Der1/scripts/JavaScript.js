/// <reference path="../../Scripts/angular.min.js" />
/// <reference path="../Scripts/Chart.min.js" />
/// <reference path="../Scripts/angular-chart.min.js" />

var BASE_URL = "http://localhost:53056/ReportingService.svc/";
var app;

//Module  
(function () {
    app = angular.module("reportsModule", ['chart.js']);
})();

//Config
app.config(['ChartJsProvider', function (ChartJsProvider) {
    // Configure all charts 
    ChartJsProvider.setOptions({
        chartColors: ["#455C73", "#9B59B6", "#BDC3C7", "#26B99A"],
        responsive: true,
        scales: { yAxes: [{ ticks: { min: 0, stepSize: 1 } }] }

    });
}]);

app.controller("pieCtrl_CountPerTicket", function ($scope, countPerTicket) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = countPerTicket.get();

    $scope.NumCampData = [];

    promiseGet1.then(function (pl) {
        $scope.NumCampData = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});//G

//CountAccPerCampus
app.service("countPerTicket", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "GetTicketCountPerEvent/" + getUrlParameter('eventID'));
    };
});

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
