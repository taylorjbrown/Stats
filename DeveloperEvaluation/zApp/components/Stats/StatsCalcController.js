


//need to add validation of the user input
var statsCalcController = function ($scope, $state, $http) {
    $scope.input = "";

    var validation = function (input) {
        var nums = input.split(',').map(Number);
        return nums;
    }

    $scope.calc = function () {
        if ($scope.input.length > 0) {

            var nums = validation($scope.input);

            $http.post('Api/CalcStats', nums).then(function (response) {
                console.log(response);
                $state.go('Stats.resultModal');
            }, function (error) {
                console.log(error);
            });
        }
    }


}

statsCalcController.$inject = ['$scope', '$state','$http'];