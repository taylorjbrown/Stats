var App = angular.module("StatsCalc", ['ui.router', 'ui.bootstrap']);

App.controller("statsCalcController", statsCalcController);
App.controller("resultController", resultController);

var configFun = function ($stateProvider,$urlRouterProvider, $locationProvider) {
   

    $locationProvider.html5Mode(true);

    $stateProvider
        .state('Stats', {
            url: '/Stats',
            templateUrl: 'zApp/components/Stats/StatsCalcView.html',
            controller: 'statsCalcController'
        })
        .state('Stats.result', {
            params: {stats: ''},
            templateUrl: 'zApp/components/Stats/Result.html',
            controller: 'resultController'
        });

    $urlRouterProvider.otherwise('/Stats');
}

configFun.$inject = ['$stateProvider','$urlRouterProvider', '$locationProvider'];

App.config(configFun);

App.run(["$rootScope", "$state", function ($rootScope ,$state) {

}]);