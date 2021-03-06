﻿console.log("App was loaded");

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

    $routeProvider.when("/Stories/:storyID", {
        templateUrl: "/Scripts/app/views/story.html",
        controller: "StoryController"
    })

    $routeProvider.otherwise({ redirectTo: "/Dashboard" });

})

app.controller("SubmitController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    $scope.body = {
        UserName: "",
        Body: "",
        Category: "",
        Headline: ""
    };

    $scope.postBody = () => {
        postBody();
    };
        
    const postBody = () => {
        console.log($scope.body);
        let temp = $scope.body;
        $http({
            method: "POST",
            url: "/api/stories",
            //data: $scope.body
            data: {
                UserName: temp.UserName,
                Body: temp.Body,
                Category: temp.Category,
                Headline: temp.Headline
            }
        }).then(resp => {
            //console.log(resp.data);
            //console.log(resp.data.id);
            $location.path(`/Stories/${resp.data.ID}`);
        });
    }
}]);

app.controller("DashController", ["$scope", "$http", function ($scope, $http) {
    $scope.categories = [];
    $scope.stories = [];

    const getCategories = () => {
        let catURL = "/api/categories"
        $http({
            method: "GET",
            url: catURL
        }).then(resp => {
            $scope.categories = resp.data;
            //console.log("The response is:", resp.data);
        })
    }

    const getStories = () => {
        let storiesURL = "/api/stories"
        $http({
            method: "GET",
            url: storiesURL
        }).then(resp => {
            $scope.stories = resp.data;
            //console.log("The stories response is:", resp.data);
        })
    }
    getCategories();
    getStories();
}]);

app.controller("StoryController", ["$scope", "$routeParams", "$http", function ($scope, $routeParams, $http) {
    console.log("On the individual story controller!");

    const getStory = () => {
        $http({
            method: "GET",
            url: `/api/stories/${$routeParams.storyID}`
        }).then(res => {
            $scope.storyData = res.data;
            //console.log(res.data);

        });
    }

    getStory();
}]);