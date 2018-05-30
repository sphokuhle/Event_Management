BASE_URL = "http://localhost:53056/EventService.svc/";

var app;

//Module  
(function () {
    app = angular.module("EventList_App", []);
})();



app.controller("cntrl_EventList", function ($scope, EventList) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,
        }
    };

    // debugger;
    var promiseGet1 = EventList.get();
    $scope.EventDetails = [];
    promiseGet1.then(function (pl) {
        $scope.EventDetails = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});

//Guest Event List
app.controller("cntrl_GuestList", function ($scope, GuestList) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,
        }
    };

    // debugger;
    var promiseGet1 = GuestList.get();
    $scope.EventDetails = [];
    promiseGet1.then(function (pl) {
        $scope.EventDetails = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});

//Event Host's Event List
app.controller("cntrl_HostList", function ($scope, HostList) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,
        }
    };

    // debugger;
    var promiseGet1 = HostList.get();
    $scope.EventDetails = [];
    promiseGet1.then(function (pl) {
        $scope.EventDetails = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});

//Event Home List
app.controller("cntrl_HomeEvents", function ($scope, HomeEvents) {

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
//Home list 
app.service("HomeEvents", function ($http) {
    //debugger;

    this.get = function () {
        return $http.get(BASE_URL + "getHomeEvent/" + getUrlParameter('LoggedID') + "," + getUrlParameter('Type'));
    };
});




//Find all Event
app.service("EventList", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "getAllEvents");
    };
});
//Find Guest Event List
//GuestLiveEvent(string Guest_ID)
app.service("GuestList", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "GuestLiveEvent/" + getUrlParameter('GuestID'));
    };
});
//Find Host's event list
app.service("HostList", function ($http) {
    //debugger;
    
    this.get = function () {
        return $http.get(BASE_URL + "getAllEventsByHostID/" + getUrlParameter('HostID') + ",0");
    };
});

//BASE_URL + "getAllEventsByHostID/" + hostID + "," + GuestID

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