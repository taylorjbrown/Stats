var statsCalcController = function ($rootScope, $scope, $uibModal, $state, $http) {

    $scope.input = "";

    var validation = function (input) {

        var removeNewLine = input.replace(/\r?\n|\r/g, ',');

        var check = /[\s\S][-]?[0-9]+.[0-9]+(,[-]?[0-9]+.[0-9]+)*$/g.test(removeNewLine);

        var nums = [];
        if (check) {
            nums = removeNewLine.split(',').map(Number);
        }
        else {
            $rootScope.errTitle = 'Badly formated input';
            $rootScope.err = 'Needs to be a comma seperated arrray of numbers\nEach new line should not start with a comma \nNor should any line end with a comma \nEx: \n-1.444,2.222,-3.22222\n1,2,-4';
            $state.go('Stats.Alert');
        }
        return nums;
    };

    $scope.sendToCalc = function (event) {
        if (event.keyCode === 13) {
            //event.preventDefault(); (use if don't want newlines on enter)
            $scope.calc();
        }
    };

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
            $rootScope.errTitle = 'Empty input submission';
            $rootScope.err = 'Need to input an array of numbers seperated by \',\' for calculations to run';
            $state.go('Stats.Alert');
        }
    };


};

    statsCalcController.$inject = ['$rootScope','$scope','$uibModal', '$state', '$http'];