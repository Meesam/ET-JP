jobPortal.directive('clientList', function () {
    return {
        restrict: 'AE',
        templateUrl: 'views/directives/client-list.html',
        scope: {
            clientData: '='
        },
        link: function (scope,elm,attrs) {
            $(".paper-table").tablecloth({
                theme: "paper",
                striped: true,
                sortable: true,
                condensed: false
            });
        }
    };
});