/// <reference path="../../scripts/AAF/angular.min.js" />

var Event_BASE_URL = "http://localhost:53056/EventService.svc/";
var Image_BASE_URL = "http://localhost:53056/FileUpload.svc/";
var Ticket_BASE_URL = "http://localhost:53056/TicketService.svc/";
var app;

//Module  
(function () {
    app = angular.module("myTicketModule", []);
})();

//Controllers
//$scope.Events = [];
app.controller("myEventController", function ($scope, $http) {
    $http.get(Event_BASE_URL + "getAllEventsByHostID/0," + getUrlParameter('hostID'))
    .then(function (response) {
        $scope.Events = response.data;
    });
});

app.controller("myImageController", function ($scope, $http) {
    $http.get(Image_BASE_URL + "getImageById/" + $scope.Events.EventID)
    .then(function (response) {
        $scope.Images = response.data;
    });
});

app.controller("myTicketController", function ($scope, $http) {
    $http.get(Ticket_BASE_URL + "GetGuestTicketForEvent/" + $scope.Events.EventID)
    .then(function (response) {
        $scope.Tickets = response.data;
    });
});

//SERVICE


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

