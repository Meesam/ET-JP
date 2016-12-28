jobPortal.controller('loginController', ['$scope', '$rootScope', '$http', '$location', 'appServices', '$cookies', 'validationService',
    function ($scope, $rootScope, $http, $location, appServices, $cookies, validationService) {
        $scope.loginInfo = { UserName: '', Password: '' };
        $scope.doLogin = function () {
            if ($scope.loginInfo.UserName == '') { $rootScope.setMsg('UserName is required'); return }
            else if ($scope.loginInfo.Password == '') { $rootScope.setMsg('Password is required'); return }
            appServices.doLogin($scope.loginInfo).then(function (d) {
                console.log(JSON.stringify(d));
                if (d.Status == 'success') { // Login Success
                    $rootScope.mUser = d.ObjData;
                    $rootScope.token = d.Token;
                    if ($scope.loginInfo.Remember) {
                        var expireDate = new Date();
                        expireDate.setDate(expireDate.getDate() + 90);
                        $cookies.put('UserToken', d.token, { 'expires': expireDate });
                    } else $cookies.put('UserToken', d.token);
                    $rootScope.processForward();
                    $location.path('/client');
                } else {  // Login error
                    $rootScope.setMsg('Login Failed ! UserName or Password is incorrect ');
                }

            });
        }
}]);