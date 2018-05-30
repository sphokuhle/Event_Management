/// <reference path="chartApp.js" />
/// <reference path="chartServices.js" />

app.controller("pieChartController", function ($scope, countAPK /*, countSWC, countAPB, countDFC*/) {
    // debugger;
    //var promiseGet1 = countSWC.get();
    var promiseGet2 = countAPK.get();
    //var promiseGet3 = countAPB.get();
    //var promiseGet4 = countDFC.get();

    $scope.NumAPK = 0;
    //$scope.NumAPB = 0;
    //$scope.NumDFC = 0;
    //$scope.NumSWC = 0;

    promiseGet1.then(function (pl) {
        $scope.NumAPK = pl.data;
    },
              function (errorPl) {
                  $log.error('failure loading APK', errorPl);
              });
    //promiseGet2.then(function (pl) {
    //    $scope.NumAPB = pl.data;
    //},
    //          function (errorPl) {
    //              $log.error('failure loading APB', errorPl);
    //          });
    //promiseGet3.then(function (pl) {
    //    $scope.NumDFC = pl.data;
    //},
    //          function (errorPl) {
    //              $log.error('failure loading DFC', errorPl);
    //          });
    //promiseGet4.then(function (pl) {
    //    $scope.NumSWC = pl.data;
    //},
    //          function (errorPl) {
    //              $log.error('failure loading SWC', errorPl);
      //        });
    //$scope.totalNum = $scope.NumAPB + $scope.NumAPK + $scope.NumDFC + $scope.NumSWC;

    //$scope.chartData = [$scope.NumAPK / $scope.totalNum, $scope.NumAPB / $scope.totalNum, $scope.NumDFC / $scope.totalNum, $scope.NumSWC / $scope.totalNum];
});
