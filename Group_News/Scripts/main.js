console.log("App was loaded");

const app = angular.module("main", ["ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider.when("/Dashboard", {
        templateUrl: "/Scripts/app/views/dashboard.html",
        controller: "DashController"
    })

    $routeProvider.when("/Submit", {
        templateUrl: "/Scripts/app/views/submit.html",
        controller: "SubmitController"
    })
})


app.controller("DashController", ["$scope", "$http", function ($scope, $http) {
        $scope.categories = [];
        $scope.stories = [];

        const getCategories = () => {
            let catURL = "/api/categories"
            $http({
                method: "GET",
                url: catURL
            }).then(resp => {
                $scope.categories = resp.data
            })
        }

        const getStories = () => {
            let storiesURL = "/api/stories"
            $http({
                method: "GET",
                url: storiesURL
            }).then(resp => {
                $scope.stories = resp.data;
            })
        }
    }]);