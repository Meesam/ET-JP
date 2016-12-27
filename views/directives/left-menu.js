jobPortal.directive('leftMenu', function () {
    return {
        restrict: 'AE',
        templateUrl: 'views/directives/left-menu.html',
        scope: {
            projectList: '=',
            projectTitle: '@',
            plugin: '&'
        },
        controller: function ($scope, $element, $attrs) {
            $scope.removeProject = function (projectid) {
                console.log('projectid is ' + projectid);
            };
        }
    };
});