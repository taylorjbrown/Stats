var App = angular.module("StatsCalc",["ui.router"]);

//App.service("stackTraceService", stackTraceService);

App.controller("statsCalcController", statsCalcController);

var configFun = function ($stateProvider, $urlProvider, $locationProvider) {
    $locationProvider.html5mode(true);
    $stateProvider
        .state("StatCalcView", {
            url: "/Stats",
            templateUrl: "zApp/components/Stats/StatsCalcView.html",
            controller: statsCalcController
        }
    )
}

configFun.$inject = ['$stateProvider', '$urlProvider', '$locationProvider'];

App.run(["$rootScope", "$state", function ($rootScope, $state) {
    $rootScope.$state = $state;
    if ($rootScope.$state !== "StatCalcView") {
        $state.go("StatCalcView");
    }
}]);