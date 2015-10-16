(function () {
    'use strict';

    angular
		.module('chal')
		.config(routeConfig);

    function routeConfig($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('');

        $stateProvider
			.state('chal', {
			    url: '',
			    templateUrl: '/index.html'
			});
    }

})();
