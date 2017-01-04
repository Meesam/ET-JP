jobPortal.directive('userSession', ['$rootScope','$cookies','$location', function ($rootScope, $cookies, $location) {
    return {
        restrict: 'AE',
        templateUrl: 'views/directives/user-session.html',
        link: function (scope, elm, attrs) {
            scope.UserName = $rootScope.mUser.Name;
            scope.signOut = function () {
                $rootScope.mUser = null;
                $rootScope.Token = null;
                $cookies.remove('UserToken');
                $location.path('/login');
            };
        }
    };
}]);