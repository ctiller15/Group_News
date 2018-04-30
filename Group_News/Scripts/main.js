console.log("App was loaded");

angular
    .module("main", [])
    .controller("StoryController", ["$scope", "$http", ($scope, $http) => {
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