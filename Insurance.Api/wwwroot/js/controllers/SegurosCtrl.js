(function () {
    "use strict";

    angular.module("insurance").requires.push("ngMessages");
    angular.module("insurance").requires.push("angular.filter");
    angular.module("insurance").requires.push("mdColorMenu");
    angular
        .module("insurance")
        .controller("segurosCtrl", segurosCtrl);

    segurosCtrl.$inject = ["$scope", "$window", "$element", "$mdSelect", "toastr", "SeguroService"];

    function segurosCtrl($scope, $window, $element, $mdSelect, toastr, SeguroService) {
        $scope.seguros = null;
        $scope.seguro = {};
        $scope.pesquisa = null;

        $scope.loadSeguros = function () {
            if ($scope.seguros === null) {

                SeguroService.getAll(function (resp) {
                    $scope.seguros = resp.data;
                    console.log($scope.seguros);
                },
                    function (resp) {
                        console.log(resp);
                        toastr.error(resp.data.message, "Calma, houve um problema");
                    });


            }
        };

        $scope.searchId = function (id) {
            $scope.getSeguro(id);
        };

        $scope.searchPlaca = function (placa) {

            placa = placa.slice(0, 3) + '-' + placa.slice(3);
            SeguroService.searchPlaca(placa, function (resp) {
                if (resp.data === null) {
                    toastr.warning("Nada encontrado", "Placa: " + placa + " não encontrada");

                } else {
                    $scope.seguro = resp.data;
                    $('#modalEdit').modal('show');
                    //toastr.success("Placa encontrada!", "Placa: " + placa + " encontrada");
                }
            },
                function (resp) {
                    toastr.error(resp.data.message, "Calma, houve um problema");
                });
        };

        $scope.editSeguro = function () {
            window.location.href = "/wwwroot/seguro-cadastrar.html?id=" + $scope.seguro.id;
        };

        $scope.getSeguro = function (id,del) {

            var isDel = del | false; 
            SeguroService.get(id, function (resp) {
                $scope.seguro = resp.data;
                if (isDel) {
                    $('#modalDelete').modal('show');
                } else {
                    $('#modalEdit').modal('show');
                }
                
            },
                function (resp) {
                    toastr.error("Não foi encontrado esse seguro", "Calma, houve um problema");
                });
        };

        $scope.deleteSeguro = function () {

            if (isNaN($scope.seguro.id)) {
                toastr.error("O ID precisa ser um valor numérico", "Número inválido");
                $('.modal').modal('hide');
                return;
            }
            SeguroService.delete($scope.seguro.id, function (resp) {
                toastr.success("Seguro: #" + $scope.seguro.id, "deletado com sucesso");
                setTimeout(function () {
                    $window.location.reload();

                }, 500);


            },
                function (resp) {
                    toastr.error(resp.data.message, "Calma, houve um problema");
                });

            $('.modal').modal('hide');
        };


        $scope.loadSeguros();
    }

})();
