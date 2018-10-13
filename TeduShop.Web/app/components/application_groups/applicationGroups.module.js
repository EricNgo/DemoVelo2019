/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('tedushop.application_groups', ['tedushop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('application_groups', {
            url: "/application_groups",
            templateUrl: "/app/components/application_groups/applicationGroupListView.html",
            controller: "applicationGroupListController",
                        parent: 'base'
        })
            .state('add_application_group', {
                url: "/add_application_group",
                 templateUrl: "/app/components/application_groups/applicationGroupAddView.html",
                controller: "applicationGroupAddController",
                parent: 'base'
            })
            .state('edit_application_group', {
                url: "/edit_application_group/:id",
                templateUrl: "/app/components/application_groups/applicationGroupEditView.html",
                controller: "applicationGroupEditController",
                parent: 'base'
            });
    }
})();