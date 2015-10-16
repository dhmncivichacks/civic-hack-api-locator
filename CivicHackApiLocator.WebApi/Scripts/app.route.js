(function () {
    'use strict';

    angular
		.module('chal')
		.config(routeConfig);

    function routeConfig($stateProvider, $urlRouterProvider) {
        $stateProvider
			.state('index', {
			    url: '/',
			    templateUrl: '/index.html'
			})
            .state('contracts', {
                url: '/contracts',
                templateUrl: '/contracts.html',
                controller: 'ContractsController',
                controllerAs: 'vm'
            });

        $urlRouterProvider.otherwise('/');
    }

})();
