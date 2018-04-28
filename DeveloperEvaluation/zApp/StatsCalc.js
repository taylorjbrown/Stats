var App = angular.module("StatsCalc", ['ui.router', 'ui.bootstrap']);

App.provider("modalState", modalState);
App.controller("statsCalcController", statsCalcController);

var configFun = function ($stateProvider, modalStateProvider,$urlRouterProvider, $locationProvider) {
   

    $locationProvider.html5Mode(true);

    $stateProvider
        .state('Stats', {
            url: '/Stats',
            templateUrl: 'zApp/components/Stats/StatsCalcView.html',
            controller: 'statsCalcController'
        });

    $urlRouterProvider.otherwise('/Stats');

    modalStateProvider.state("Stats.resultModal", {
        url: '/result',
        templateUrl: 'zApp/components/Stats/ResultModal.html'
    });
}

configFun.$inject = ['$stateProvider', 'modalStateProvider','$urlRouterProvider', '$locationProvider'];

App.config(configFun);

App.run(["$rootScope", "$state", function ($rootScope ,$state) {
   
}]);