var resultController = function ($scope, $stateParams) {
    console.log($stateParams.stats);
    if ($stateParams.stats.mode.length === 0) {
        $scope.EmptyMode = true;
        $scope.stats = {};
        $scope.stats.mean = $stateParams.stats.mean;
        $scope.stats.median = $stateParams.stats.median;
        $scope.stats.mode = "All values appear the same amount in the Set";
    }
    else {
        $scope.EmptyMode = false;
        $scope.stats = $stateParams.stats;
    }

}

resultController.$inject = ['$scope','$stateParams'];