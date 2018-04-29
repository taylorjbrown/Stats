var statsCalcController = function ($rootScope,$scope, $uibModal, $state, $http) {

    $scope.input = "";

    var validation = function (input) {

        var check = /[\s\S][-]?[0-9]+.[0-9]+(,[-]?[0-9]+.[0-9]+)*$/g.test(input);

        var nums = [];
        if (check) {
            nums = input.split(',').map(Number);
        }
        else {
            $rootScope.err = 'Badly formated input \nNeeds to be a commad seperated arrray of numbers\nEach new line should not start with a comma \nNor should any line end with a comma \nEx: \n-1.444,2.222,-3.22222\n1,2,-4';
            $state.go('Stats.Alert');
        }
        return nums;
    }

    $scope.preventNewLine = function (event) {
        if (event.keyCode === 13) {
            //event.preventDefault(); (use if don't want newlines on enter)
            $scope.calc();
        }
    }

    $scope.calc = function () {
        if ($scope.input.length > 0) {
            var nums = validation($scope.input);

            if (nums.length > 0) {
                $http.post('Api/CalcStats', nums).then(function (response) {
                    $scope.res = response.data;
 
                    $state.go('Stats.Result', { stats: $scope.res });
                }, function (errResponse) {
                    console.error(err);
                    $rootScope.err = 'Issue with server: \n' + errResponse;
                    $state.go('Stats.Alert');
                });
            }
        }
        else {
            $rootScope.err = 'Empty input submission \nNeed to input an array of numbers seperated by \',\' for calculations to run';
            $state.go('Stats.Alert');
        }
    }


}

    statsCalcController.$inject = ['$rootScope','$scope','$uibModal', '$state', '$http'];