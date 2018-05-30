/// <reference path="AAF/angular.js" />

var Event_BASE_URL = "http://localhost:53056/EventService.svc/";
var FileUpload_Base_URL = "http://localhost:53056/FileUpload.svc/";
var Ticket_BASE_URL = "http://localhost:53056/TicketService.svc/";
var app;
(function () {
    app = module("myTicketModule", []);
})();



app.controller("myTicketController", function ($scope, $http) {
        $http.get(Event_BASE_URL + "getAllEventsByHostID/0," + getUrlParameter('Guest_ID'))
        .then(function(response){
            $scope.Events = response.data;
        });
    });




//helper functions
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