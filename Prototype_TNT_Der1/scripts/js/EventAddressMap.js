var app;

//Module
(function () {
    app = angular.module("mapModule", ['ngMap']);
})();

//***************************************Start Gen Cont***************************************************
app.controller("FindEventID", function ($scope, FindAddressByID) {
    // debugger;
    var promiseGet = FindAddressByID.get();

    promiseGet.then(function (pl) {
        $scope.EventAddressInfo = pl.data
    },
              function (errorPl) {
                  $log.error('failure loading address', errorPl);
              });
});


//Event Address
app.service("FindAddressByID", function ($http) {
    //debugger;
    this.get = function () {
        return $http.get("http://localhost:53056/MappingService.svc/getAddressByEventId/eventID");
    };
});