var App = angular.module("StatsCalc", ['ui.router','ngResource','ui.bootstrap']);

App.controller("statsCalcController", statsCalcController);
App.controller("resultController", resultController);
App.controller("alertController", alertController);

var configFun = function ($stateProvider, $urlRouterProvider, $locationProvider) {


    $locationProvider.html5Mode(true);

    $stateProvider
        .state('Stats', {
            url: '/Stats',
            templateUrl: 'zApp/components/Stats/StatsCalcView.html',
            controller: 'statsCalcController'
        })
        .state('Stats.Result', {
            params: {
                stats: {}
            },
            templateUrl: 'zApp/components/Stats/Result.html',
            controller: 'resultController'
        })
        .state('Stats.Alert', {
            url: '/Alert',
            params: {
                error: null
            },
            onEnter: function ($stateParams, $state, $uibModal, $resource) {
                $uibModal.open({
                    templateUrl: 'zApp/components/Shared/Alert.html',
                    controller: alertController
                }).result.then(function () { },
                    function (res) {
                        $state.go('^');
                });
            }
        });

    $urlRouterProvider.otherwise('/Stats');
};

configFun.$inject = ['$stateProvider','$urlRouterProvider', '$locationProvider'];

App.config(configFun);

App.run(["$rootScope", "$state", function ($rootScope ,$state) {

}]);