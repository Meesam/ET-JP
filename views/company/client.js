jobPortal.controller('clientController', ['$scope', '$http', '$location', '$cookies', 'appServices','$rootScope',
    function ($scope, $http, $location, $cookies, appServices, $rootScope) {
        $scope.ClientTable = {};
        $scope.getClient = function () {
            appServices.getTable($scope.ClientTable).then(function (d) {
                if (d.Status == 'success') {
                    $scope.ClientTable.setRows(d, $scope.ClientTable);
                }
                else
                    $rootScope.setMsg(d.Info);
            });
        };
        $scope.ClientTable = getTableObj('ClientMaster', $rootScope.Token, 'CompanyName', 'client/getClient', $scope.getClient);
        
        $scope.getClient();
}]);