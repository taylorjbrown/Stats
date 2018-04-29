var resultController = function ($scope, $stateParams) {
    $scope.stats = $stateParams.stats;
}

resultController.$inject = ['$scope','$stateParams'];