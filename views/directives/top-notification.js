jobPortal.directive('topNotification', function () {
    return {
        restrict: 'AE',
        templateUrl: 'views/directives/top-notification.html',
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