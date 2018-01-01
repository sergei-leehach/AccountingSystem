angular.module('App', [])
    .controller('Ctrl', function ($scope, $http) {
        $scope.clientList = null;
        $scope.filter = null;
        $scope.clientCard = null;

        $scope.getAllClients = function () {
            $scope.filter = null;
            $http({
                method: 'GET',
                url: '/api/Clients'
            }).then(function (success) {
                $scope.clientList = success.data;
            }, function (error) {
            });
        };

        $scope.getAllClients();

        $scope.getFiltered = function () {
            $http({
                method: 'GET',
                url: '/api/Clients/' + $scope.filter
            }).then(function (success) {
                $scope.clientList = success.data;
            }, function (error) {
            });
        };

        $scope.getClientCard = function (id) {
            $http({
                method: 'GET',
                url: '/api/Client/' + id
            }).then(function (success) {
                $scope.clientCard = success.data;
            }, function (error) {
            });
        };
    });