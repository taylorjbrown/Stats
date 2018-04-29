


//need to add validation of the user input
var statsCalcController = function ($scope, $state, $http) {
    $scope.input = "";
    $scope.$state = $state;
    var validation = function (input) {
        var nums = input.split(',').map(Number);
        return nums;
    }

    $scope.preventNewLine = function (event) {
        if (event.keyCode === 13) {
            event.preventDefault();
            $scope.calc();
        }
    }

    $scope.calc = function () {
        if ($scope.input.length > 0) {

            var nums = validation($scope.input);

            $http.post('Api/CalcStats', nums).then(function (response) {
                console.log(response);
                $scope.res = response.data;
                $state.go('Stats.result', { stats: $scope.res });
            }, function (error) {
                console.log(error);
            });
        }
    }


}

statsCalcController.$inject = ['$scope', '$state','$http'];