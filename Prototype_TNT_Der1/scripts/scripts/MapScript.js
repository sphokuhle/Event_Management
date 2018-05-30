var app;

//Module
(function () {
    app = angular.module("mapModule", ['ngMap']);
})();

//***************************************Start Gen Cont***************************************************
app.controller("FindEventID", function ($scope, FindAddressByID) {
    // debugger;
    var promiseGet = FindAddressByID.get();
    $scope.EventAddressInfo = [];
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
        return $http.get("http://localhost:53056/MappingService.svc/getAddressByEventId/" + getUrlParameter('ev'));
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