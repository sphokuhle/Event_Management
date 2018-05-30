/// <reference path="../../scripts/AAF/angular.min.js" />
/// <reference path="../scripts/AAF/Chart.min.js" />
/// <reference path="../scripts/AAF/angular-chart.min.js" />

var BASE_URL = "http://localhost:53056/ReportingService.svc/";
var SURVEY_URL = "http://localhost:53056/SurveyService.svc/";
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
app.controller("lineCtrl_CheckedGuest", function ($scope, InterVal_One, InterVal_Two, InterVal_Three, InterVal_Four) {
    //GetNumberOfCheckedGuest(string ev)


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

    $scope.series = ['UncheckedGuest', 'CheckedGuest'];
});//G

//Overall Impression Controller
app.controller("RadarCtrl_OverallSatis", function ($scope, Overall_Satisfation) {
    $scope.labels = ["Very Dissatisfied", "Dissatisfied", "Neutral", "Satisfied", "Very Satisfied"];

    $scope.options = {
        title: {
            display: true,

        }
    };

    var promiseGet1 = Overall_Satisfation.get();
    $scope.Satisfaction_Data = [];

    promiseGet1.then(function (pl) {
        $scope.Satisfaction_Data = pl.data;
    },
             function (errorPl) {
                 $log.error('failure loading features', errorPl);
             });
});//N


//First time vs Returning attendees
app.controller("pieCtrl_GuestsVisits", function ($scope, GuestVisitsStatus) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = GuestVisitsStatus.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});

//Future ATTENDANCE posibility
app.controller("pieCtrl_FutureAttendance", function ($scope, gstFutureAttendance) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = gstFutureAttendance.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});//G
//Recommendations posibility
app.controller("pieCtrl_Recommend", function ($scope, gstRecommendation) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        }
    };

    // debugger;
    var promiseGet1 = gstRecommendation.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});//G

//Date Status from survey
app.controller("BarCtrl_Date", function ($scope, gstDate_Satisfation) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        },
        scales: {
            yAxes: [{
                ticks: {

                    min: 0,
                    //max: $scope.APK,
                    stepSize: 0
                }
            }]
        }
    };

    var promiseGet1 = gstDate_Satisfation.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});

//Date Status from survey
app.controller("BarCtrl_Location", function ($scope, gstLocation_Satisfation) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        },
        scales: {
            yAxes: [{
                ticks: {

                    min: 0,
                    //max: $scope.APK,
                    stepSize: 0
                }
            }]
        }
    };

    var promiseGet1 = gstLocation_Satisfation.get();

    $scope.res = [];

    promiseGet1.then(function (pl) {
        $scope.res = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
});

//Controllers for food and behaviour line graph
app.controller("lineCtrl_FoodvsVendor", function ($scope, gstFood_Satisfation, gstVendor_Satisfation) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        },
        scales: {
            yAxes: [{
                ticks: {

                    min: 0,
                    //max: $scope.APK,
                    stepSize: 0
                }
            }]
        }
    };
    //key-value pair
    // debugger;
    var promiseGet1 = gstFood_Satisfation.get();
    var promiseGet2 = gstVendor_Satisfation.get();

    $scope.var_Food = [];
    $scope.vendor = [];

    promiseGet1.then(function (pl) {
        $scope.var_Food = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });

    promiseGet2.then(function (pl) {
        $scope.vendor = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
    //StartTime------------------->EndTime
    //service to calc start date
    // $scope.data = [[food[0], food[1], food[2], food[3], food[4]], [vendor[0], vendor[1], vendor[2], vendor[3], vendor[4]]];
    $scope.labels = ['Very Dissatisfied', 'Dissatisfied', 'Neutral', 'Satisfied', 'Very Satisfied'];
    $scope.series = ['food', 'Vendor'];
});//G

//Controller for speaker and session impression
app.controller("lineCtrl_SessionvsSpeakers", function ($scope, gstSpeaker_Satisfation, gstSession_Satisfation) {

    $scope.options = {
        legend: { display: true },
        title: {
            display: true,

        },
        scales: {
            yAxes: [{
                ticks: {

                    min: 0,
                    //max: $scope.APK,
                    stepSize: 0
                }
            }]
        }
    };
    //key-value pair
    // debugger;
    var promiseGet1 = gstSpeaker_Satisfation.get();
    var promiseGet2 = gstSession_Satisfation.get();

    $scope.speaker = [];
    $scope.session = [];

    promiseGet1.then(function (pl) {
        $scope.speaker = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });

    promiseGet2.then(function (pl) {
        $scope.session = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading data', errorPl);
              });
    //StartTime------------------->EndTime
    //service to calc start date
    // $scope.data = [[food[0], food[1], food[2], food[3], food[4]], [vendor[0], vendor[1], vendor[2], vendor[3], vendor[4]]];
    $scope.labels = ['Very Dissatisfied', 'Dissatisfied', 'Neutral', 'Satisfied', 'Very Satisfied'];
    $scope.series = ['Session', 'Speaker'];
});//G

//SERVICE
//===----SURVEY---=========================
//Overall impression
app.service("Overall_Satisfation", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(SURVEY_URL + "GetAnswer/" + "Overal_Satis," + getUrlParameter('ev'));

    };
});

//First time vs non-first time guests
app.service("GuestVisitsStatus", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(SURVEY_URL + "GetAnswer/" + "First_Time," + getUrlParameter('ev'));

    };
});
//Possibility of future attendance
app.service("gstFutureAttendance", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(SURVEY_URL + "GetAnswer/" + "Future_Attendance," + getUrlParameter('ev'));
    };
});
//Possibility of recommending other friends
app.service("gstRecommendation", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(SURVEY_URL + "GetAnswer/" + "Recommendation," + getUrlParameter('ev'));
    };
});
//Date Satisfaction
app.service("gstDate_Satisfation", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(SURVEY_URL + "GetAnswer/" + "Date," + getUrlParameter('ev'));
    };
});
//Location Satisfaction
app.service("gstLocation_Satisfation", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(SURVEY_URL + "GetAnswer/" + "Location," + getUrlParameter('ev'));
    };
});
//Food Satisfaction
app.service("gstFood_Satisfation", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(SURVEY_URL + "GetAnswer/" + "Food," + getUrlParameter('ev'));
    };
});
//Vendors Satisfaction
app.service("gstVendor_Satisfation", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(SURVEY_URL + "GetAnswer/" + "Vendor," + getUrlParameter('ev'));
    };
});
//Session Satisfaction
app.service("gstSession_Satisfation", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(SURVEY_URL + "GetAnswer/" + "Session," + getUrlParameter('ev'));
    };
});
//Speakers Satisfaction
app.service("gstSpeaker_Satisfation", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(SURVEY_URL + "GetAnswer/" + "Speaker," + getUrlParameter('ev'));
    };
});



//Numebr of checked in stations
app.service("WorkStations", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "GetMostCheckedinEntrance/" + getUrlParameter('ev'));
        // GetMostCheckedinEntrance(string ev)
    };
});

//Checked In Guest In Range One || Service
app.service("InterVal_One", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "TicketInIntervals/" + getUrlParameter('ev') + "/one");
    };
});

//Checked In Guest In Range Two || Service
app.service("InterVal_Two", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "TicketInIntervals/" + getUrlParameter('ev') + "/two");
    };
});

//Checked In Guest In Range Three || Service
app.service("InterVal_Three", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "TicketInIntervals/" + getUrlParameter('ev') + "/three");
    };
});

//Checked In Guest In Range Four || Service
app.service("InterVal_Four", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get(BASE_URL + "TicketInIntervals/" + getUrlParameter('ev') + "/four");
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
        return $http.get(BASE_URL + "GetTicketCountPerEvent/" + getUrlParameter('ev'));
    };								//GetTicketCountPerEvent(string ev)
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

