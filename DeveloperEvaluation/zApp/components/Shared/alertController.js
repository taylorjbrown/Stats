var alertController = function ( $scope, $state) {

    $scope.ok = function () {
        $scope.$close();
        $state.go('^');
    };
};

alertController.$inject = ['$scope','$state'];