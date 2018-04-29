


//need to add validation of the user input
var statsCalcController = function ($rootScope,$scope, $uibModal, $state, $http) {

    $scope.input = "";

    var validation = function (input) {
        var check = /^[-]?[0-9]+.[0-9]+(,[-]?[0-9]+.[0-9]+)*$/.test(input);
        var nums = [];
        if (check) {
            nums = input.split(',').map(Number);
        }
        else {
            $rootScope.err = 'Badly formated input <br\> Needs to be a commad seperated arrray of numbers <br\>Ex: -1.444,2.222,-3.22222';
            $state.go('Stats.Alert');
        }
        return nums;
    }

    $scope.preventNewLine = function (event) {
        if (event.keyCode === 13) {
            event.preventDefault();
            //need to stop newline when enter is hit
            $scope.calc();
        }
    }

    $scope.calc = function () {
        if ($scope.input.length > 0) {
            var nums = validation($scope.input);

            if (nums.length > 0) {
                $http.post('Api/CalcStats', nums).then(function (response) {
                    $scope.res = response.data;
                    console.log($scope.res);
                    $state.go('Stats.Result', { stats: $scope.res });
                }, function (errResponse) {
                    console.log(err);
                    $rootScope.err = 'Issue with server: <br\>' + errResponse;
                    $state.go('Stats.Alert');
                });
            }
        }
        else {
            $rootScope.err = 'Empty input submission <br\> Need to input an array of numbers seperated by \',\' for calculations to run';
            $state.go('Stats.Alert');
        }
    }


}

    statsCalcController.$inject = ['$rootScope','$scope','$uibModal', '$state', '$http'];