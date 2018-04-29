var alertController = function ( $scope, $state) {
    console.log($scope.$parent);
    $scope.ok = function () {
        $scope.$close();
        $state.go('^');
    };
};

alertController.$inject = ['$scope','$state'];