/// <reference path="../../scripts/AAF/angular.min.js" />
/// <reference path="../scripts/AAF/Chart.min.js" />
/// <reference path="../scripts/AAF/angular-chart.min.js" />

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
        chartColors: ["#455C73", "#9B59B6","#BDC3C7", "#26B99A"],
        responsive: true,
        scales: { yAxes: [{ ticks: { min: 0, stepSize: 1 }}]}
      
    });
}]);

app.controller("pieCtrl_AccPerCampus", function ($scope, countPerCampus) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = countPerCampus.get();

    $scope.NumCampData = [];

    promiseGet1.then(function (pl) {
        $scope.NumCampData = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});//G

//Controllers
// Guest Checkins
app.controller("lineCtrl_CheckedGuest", function ($scope, InterVal_One, InterVal_Two, InterVal_Three, InterVal_Four, Hourly_Intervals) {
//GetNumberOfCheckedGuest(string eventID)


    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        },
    };
	
    // debugger;
    var promiseGet1 = InterVal_One.get();
    var promiseGet2 = InterVal_Two.get();
    var promiseGet3 = InterVal_Three.get();
    var promiseGet4 = InterVal_Four.get();
	var promiseGet5 = Hourly_Intervals.get();
	
    $scope.Int_One = [];
    $scope.Int_Two = [];
    $scope.Int_Three = [];
    $scope.Int_Four = [];
	$scope.Hourly = [];
	
    promiseGet1.then(function (pl) {
        $scope.Int_One = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });

    promiseGet2.then(function (pl) {
        $scope.Int_Two = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
    promiseGet3.then(function (pl) {
        $scope.Int_Three = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
    promiseGet4.then(function (pl) {
        $scope.Int_Four = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
			  
	    promiseGet5.then(function (pl) {
        $scope.Hourly = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
			  
    $scope.series = ['CheckedGuest', 'UncheckedGuest'];
});//G


//Track most checked in entrance
app.controller("lineCtrl_MostCheckedEntrance", function ($scope, WorkStations) {
//GetNumberOfCheckedGuest(string eventID)

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        },
    };
	
    // debugger;
    var promiseGet1 = WorkStations.get();
    $scope.NumScans = [];
	
    promiseGet1.then(function (pl) {
        $scope.NumScans = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
//	$scope.NumScans.length;
	$scope.data = [4,6, 10];
	$scope.labels = ['Station 1','Station 2','Station 3','Station 4'];
	
    $scope.series = ['Entrance'];
});//G


//SERVICE

//Numebr of checked in stations
app.service("WorkStations", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "GetMostCheckedinEntrance/" + getUrlParameter('eventID'));
		// GetMostCheckedinEntrance(string eventID)
    };
});

//Checked In Guest In Range One || Service
app.service("InterVal_One", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "TicketInIntervals/" + getUrlParameter('eventID') + "/one");
    };
});

//Checked In Guest In Range Two || Service
app.service("InterVal_Two", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "TicketInIntervals/" + getUrlParameter('eventID') + "/two");
    };
});

//Checked In Guest In Range Three || Service
app.service("InterVal_Three", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "TicketInIntervals/" + getUrlParameter('eventID') + "/three");
    };
});

//Checked In Guest In Range Four || Service
app.service("InterVal_Four", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "TicketInIntervals/" + getUrlParameter('eventID') + "/four");
    };
});

//Event Hourly Intervals || Service
app.service("Hourly_Intervals", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "HourlyInterVals/" + getUrlParameter('id'));
    };
});


//CountAccPerCampus
app.service("countPerCampus", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "GetTicketCountPerEvent/" + getUrlParameter('eventID'));
    };								//GetTicketCountPerEvent(string eventID)
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

