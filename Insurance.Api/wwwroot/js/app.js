angular.module("insurance", ["ngRoute", "ngCookies", "ngMaterial", "ngAnimate", "toastr", "ui.utils.masks", "idf.br-filters"])

    //.config(["$routeProvider", function ($routeProvider) {

    //    $routeProvider
    //        .when("/login", {
    //            controller: "LoginController",
    //            url: "modules/authentication/views/login.html"
    //        })

    //        .when("/", {
    //            controller: "HomeController",
    //            templateUrl: "/teste.html"
    //        })

    //        .otherwise({ redirectTo: "/login" });
    //}])
    .config([
        "$httpProvider", "$mdDateLocaleProvider", "toastrConfig", function ($httpProvider, $mdDateLocaleProvider, toastrConfig) {

            $mdDateLocaleProvider.months = [
                "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro",
                "Novembro", "Dezembro"
            ];
            $mdDateLocaleProvider.shortMonths = [
                "Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"
            ];
            $mdDateLocaleProvider.days = ["Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"];
            $mdDateLocaleProvider.shortDays = ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sáb"];

            angular.extend(toastrConfig, {
                allowHtml: false,
                closeButton: true,
                closeHtml: "<button>&times;KKKKK</button>",
                extendedTimeOut: 5000,
                iconClasses: {
                    error: "toast-error",
                    info: "toast-info",
                    success: "toast-success",
                    warning: "toast-warning"
                },
                messageClass: "toast-message",
                onHidden: null,
                onShown: null,
                onTap: null,
                progressBar: true,
                tapToDismiss: true,
                templates: {
                    toast: "directives/toast/toast.html",
                    progressbar: "directives/progressbar/progressbar.html"
                },
                timeOut: 8000,
                titleClass: "toast-title",
                toastClass: "toast"
            });
        }
    ]);
    //.factory("InterceptorService",
    //    [
    //        "$q", function($q) {
    //            var interceptorServiceFactory = {};

    //            var request = function(config) {
    //                //success logic here
    //                return config;
    //            }

    //            var responseError = function(rejection) {
    //                //error here. for example server respond with 401
    //                if (rejection.status === 401) {
    //                    window.location.href = "/wwwroot/SemAutorizacao.html";
    //                }
    //                return $q.reject(rejection);
    //            }

    //            interceptorServiceFactory.request = request;
    //            interceptorServiceFactory.responseError = responseError;
    //            return interceptorServiceFactory;

    //        }
    //    ])
    //.run([
    //    "$rootScope", "$location", "$cookies", "$http",
    //    function($rootScope, $location, $cookies, $http) {
    //        // keep user logged in after page refresh
    //        $rootScope.globals = $cookies.getObject("globals") || {};
    //        if ($rootScope.globals.currentUser) {
    //            $http.defaults.headers.common["Authorization"] =
    //                "Basic " + $rootScope.globals.currentUser.authdata; // jshint ignore:line
    //            $http.defaults.headers.common["Token"] = $rootScope.globals.currentUser.token;
    //        }

    //        $rootScope.$on("$locationChangeStart",
    //            function(event, next, current) {
    //                // redirect to login page if not logged in
    //                if (window.location.pathname.indexOf("/login") < 0 && !$rootScope.globals.currentUser) {
    //                    window.location.href = "/wwwroot/login.html";
    //                }
    //            });
    //    }
    //]);