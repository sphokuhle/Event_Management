BASE_URL = "http://localhost:53056/EventService.svc/";

var app;

//Module  
(function () {
    app = angular.module("GuestEventList_App",[]);
})();

 

app.controller("cntrl_GuestEventList", function ($scope, GuestEventList) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,
        }
    };

    // debugger;
    var promiseGet1 = GuestEventList.get();
    var promiseGet2 = GuestEventList.get();
    var promiseGet3 = GuestEventList.get();
    $scope.EventDetails = [];
    $scope.Tickets = [];
    $scope.Images;
    promiseGet1.then(function (pl) {
        $scope.EventDetails = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });

    promiseGet2.then(function (pl) {
        $scope.Tickets = pl.data;
    },
          function (errorPl) {
              $log.error('failure loading data', errorPl);
          });

    promiseGet3.then(function (pl) {
        $scope.Images = pl.data;
    },
          function (errorPl) {
              $log.error('failure loading data', errorPl);
          });
   // document.getElementById("imageDiv").innerHTML = "<a href='#'><img class='media-object' src=" + $scope.Images.ImageLocation + " alt=''></a>";
});//G

//SERVICE
//Find Event By ID
app.service("GuestEventList", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "GuestEventTicketList/" + getUrlParameter('hostID'));
    };
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