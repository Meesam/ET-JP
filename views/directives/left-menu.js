jobPortal.directive('leftMenu', ['appServices', '$rootScope', function (appServices, $rootScope) {
    return {
        restrict: 'AE',
        templateUrl: 'views/directives/left-menu.html',
        scope: {
            menuList: '='
        },
        link: function (scope, elm, attrs) {
            $(".left-primary-nav a").hover(function () {
                $(this).stop().animate({
                    fontSize: "30px"
                }, 200);
            }, function () {
                $(this).stop().animate({
                    fontSize: "24px"
                }, 100);
            });
            scope.isSubmenu = false;
            scope.showsubmenu = function (menuId) {
                appServices.doActionGet({}, 'RoleMenu/GetSubMenu?menuId=' + menuId).then(function (d) {
                    if (d.Status == 'success' && d.Count > 0) {
                        scope.subMenu = d.ObjData,
                        $rootScope.Token = d.Token;
                        scope.MenuName = d.ObjData[0].MenuName;
                        scope.isSubmenu = true;
                    } else scope.isSubmenu = false;
                })
            }
        }
    };
}]);