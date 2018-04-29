var resultController = function ($scope, $stateParams) {
    console.log($stateParams.stats);
    $scope.stats = $stateParams.stats;
}

resultController.$inject = ['$scope','$stateParams'];