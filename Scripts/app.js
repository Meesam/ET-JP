var jobPortal = angular.module('jobPortal', ['ngRoute', 'ngCookies', 'cgNotify']);

jobPortal.config(function ($routeProvider, $controllerProvider, $locationProvider) {
    $routeProvider
        .when('/', {
            templateUrl: 'views/authentication/login.html?r=' + JPVer,
            controller: 'loginController'
         })
        .when('/clients', {
            templateUrl: 'views/company/client.html?r=' + JPVer,
            controller: 'clientController'
        })
        .when('/login', {
            templateUrl: 'views/authentication/login.html?r=' + JPVer,
            controller: 'loginController'
        })
        .when('/candidate', {
            templateUrl: 'views/candidates/candidate.html?r=' + JPVer,
            controller: 'candidateController'
        })
        .otherwise({ redirectTo: '/login' });
   $locationProvider.html5Mode(true);
});


jobPortal.controller('mainController', ['$scope', '$rootScope', '$location', '$cookies', 'notify', '$http', 'appServices',
    function ($scope, $rootScope, $location, $cookies, notify, $http, appServices) {
        $rootScope.mUser = null;
        $rootScope.attParam = null;
        $rootScope.isBusy = 0;
        $scope.loc = $location;
        $scope.mainMenu = {};
        $scope.addToken = function (str) { return { Search: str, Token: $rootScope.Token }; };
        $rootScope.setMsg = function (msg, succ) {
            notify.closeAll();
            notify({ message: msg, classes: (succ ? 'alert-success' : 'alert-danger'), duration: 5000 });
        };
        $rootScope.goSignin = function (url) {
            if (url && url.indexOf('login.html') < 0 && url.indexOf('login.html') < 0) {
                $rootScope.setMsg('Please sign-in to continue...');
                $location.path('/login');
            }
        };
        // to get menu
        $scope.getMenu = function () {
            appServices.doActionGet({ Token: $rootScope.Token }, '/RoleMenu/GetMenu').then(function (d) {
                if (d.Status == 'success' && d.Count > 0) {
                    $scope.mainModule = d.ObjData;
                } 
            });
        };

        $scope.isMenu = false;
        $scope.getModuleMenu = function (id) {
            appServices.doActionGet({ Token: $rootScope.Token }, 'modules/' + id + '').then(function (d) {
                if (d.Status == 'success') {
                    $scope.isMenu = true;
                    $scope.moduleMenu = d.objdata;
                }
            });
        };

        $rootScope.processForward = function () {
            $scope.getMenu();
        };

        
}]);



jobPortal.run(function ($rootScope, $location, $cookies, appServices) {
    var token = $cookies.get('UserToken');
    if (token) $rootScope.Token = token;
    $rootScope.$on("$routeChangeStart", function (event, next, current) {
        $rootScope.attParam = null;
        if (!navigator.onLine) $rootScope.setMsg('Network not connected! Please check internet connection.');
        // Get user if token is there but no user
        if ($rootScope.mUser === null) {
            if ($rootScope.Token) {
                var userToken = { UserName: token };
                appServices.getUserByToken(userToken).then(function (d) {
                    if (d.Status === 'success' && d.Count > 0) {
                        $rootScope.mUser = d.ObjData;
                        if ($rootScope.mUser !== null && next.templateUrl === 'views/authentication/login.html?r=0ab') {
                            $location.path('/clients');
                        }
                        $rootScope.$broadcast('userReady', null);
                        $rootScope.processForward();
                    } else $rootScope.goSignin(next.templateUrl);
                });
            } else $rootScope.goSignin(next.templateUrl);
        }
   });
});

function getTableObj(tableid, token, initSort, apipath, refreshTableFunc) {
    var itf = {};
    itf.id = tableid;
    itf.Rows = {};
    itf.api = apipath;
    itf.SortBy = appStor.gettext(tableid + 'sort', initSort);
    itf.Token = token;
    itf.SortDesc = false;
    itf.RPP = appStor.getnumber(tableid + 'rpp', 8);;
    itf.TotalRows = 0;
    itf.CurPage = 1;
    itf.NumPages = 1;
    itf.Params = [];
    itf.Filters = [];
    itf.FilBtnClass = function () {
        var cls = '';
        for (i = 0; i < this.Filters.length; i++) { if (this.Filters[i] > '') cls = 'btn-warning'; }
        return cls;
    }
    itf.clearFil = function () {
        for (i = 0; i < this.Filters.length; i++) { this.Filters[i] = ''; }
    }
    itf.setSort = function (newSort) {
        if (newSort == this.SortBy) this.SortDesc = !this.SortDesc; else this.SortDesc = false;
        this.SortBy = newSort;
        appStor.save(tableid + 'sort', newSort);
        refreshTableFunc();
    }
    itf.setRPP = function (nRPP) {
        this.RPP = nRPP;
        appStor.save(tableid + 'rpp', nRPP);
        refreshTableFunc();
    }
    itf.chPage = function (inc) {
        this.CurPage += inc;
        if (this.CurPage > this.NumPages) this.CurPage = this.NumPages;
        if (this.CurPage == 0) this.CurPage = 1;
        refreshTableFunc();
    }
    itf.setRows = function (aRes) {
        this.Rows = aRes.ObjData;
        this.TotalRows = aRes.Count;
        this.NumPages = Math.floor((this.TotalRows + this.RPP - 1) / this.RPP);
        if (this.CurPage > this.NumPages) this.CurPage = this.NumPages;
        if (this.CurPage == 0) this.CurPage = 1;
    }
    return itf;
}

// email validation
jobPortal.factory('validationService', function () {
    return {
        Email: function (email) {
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        }
    };
});

jobPortal.filter('UTC2Local', function () {
    return function (date) {
        if (date == null) { return date }
        return new Date(date + 'Z');
    };
});




var appStor = {
    save: function (key, value) { if (typeof (Storage) !== "undefined") { localStorage.setItem(key, value); } },
    gettext: function (key, def) { if (typeof (Storage) !== "undefined") { var val = localStorage.getItem(key); if (val) return val; else return def; } else return def; },
    getnumber: function (key, def) { if (typeof (Storage) !== "undefined") { var val = localStorage.getItem(key); if (val && !isNaN(val)) return parseInt(val); else return def; } else return def; }
}
