console.log("App was loaded");

angular
    .module("main", [])
    .controller("homeController", ["$scope", "$http", ($scope, $http) => {
        $scope.categories = [];
    }