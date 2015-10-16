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
            .state('faqs', {
                url: '/faqs',
                templateUrl: '/faqs.html'
            })
            .state('swagger', {
                url: '/swagger',
                templateUrl: '/swagger.html'
            })
            .state('apps', {
                url: '/apps',
                templateUrl: '/apps.html'
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
