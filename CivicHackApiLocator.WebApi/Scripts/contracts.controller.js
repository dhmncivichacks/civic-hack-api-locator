(function () {
    'use strict';

    angular
		.module('chal')
		.controller('ContractsController', ['$http', ContractsController]);

    /* @ngInject */
    function ContractsController($http) {
        var vm = this;
        vm.contracts = null;
        vm.selectedContract = null;
        vm.implementations = null;
        vm.contractJson = contractJson;
        vm.getContractImplementations = getContractImplementations;

        activate();

        ////////////////

        function activate() {
            $http.get('/api/contracts').then(function (result) {
                vm.contracts = result.data;
                vm.selectedContract = vm.contracts[0];
                getContractImplementations();
            });
        }

        function getContractImplementations() {
            vm.implementations = null;

            $http.get('/api/implementations/bycontract/' + vm.selectedContract.contractName).then(function (result) {
                vm.implementations = result.data;
            });
        }

        function contractJson() {
            if (vm.selectedContract)
                return JSON.parse(vm.selectedContract.responseJsonSchema);
        }

    }
})();
