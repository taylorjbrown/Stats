var alertController = function ($scope, $state, $stateParams) {
    console.log($stateParams);

    $scope.error = angular.copy($stateParams.error);

    $scope.ok = function () {
        $scope.$close();
        $state.go('^');
    };
};

alertController.$inject = ['$scope','$state','$stateParams'];