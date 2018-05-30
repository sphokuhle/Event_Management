/// <reference path="chartApp.js" />

//Services
app.service("countSWC", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/ReportingServices.svc/accommodationCounts/swc");
    };
});

app.service("countAPK", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/ReportingServices.svc/accommodationCounts/apk");
    };
});

app.service("countAPB", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/ReportingServices.svc/accommodationCounts/apb");
    };
});
app.service("countDFC", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:50706/ReportingServices.svc/accommodationCounts/dfc");
    };
});
