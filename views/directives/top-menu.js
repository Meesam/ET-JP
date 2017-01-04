jobPortal.directive('topMenu', ['appServices', '$rootScope', function (appServices, $rootScope) {
    return {
        restrict: 'AE',
        templateUrl: 'views/directives/top-menu.html',
        scope: {
            menuList: '='
        },
        link: function (scope,elm,attrs) {
            scope.isSubmenu = false;
            scope.showsubmenu = function (menuId) {
                appServices.doActionGet({}, 'RoleMenu/GetSubMenu?menuId=' + menuId).then(function (d) {
                    if (d.Status == 'success' && d.Count > 0) {
                        scope.subMenu = d.ObjData,
                        $rootScope.Token = d.Token;
                        scope.isSubmenu = true;
                    } else scope.isSubmenu = false;
                })   
            }
        }
    };
}]);