var mainApp = angular.module('mainApp', ['ngRoute']);

//Routing
mainApp.config(function ($routeProvider) {
    $routeProvider.when('/About', {
        controller: 'aboutCtrl',
        templateUrl: 'Partials/About.html'
    }).when('/Search', {
        controller: 'searchCtrl',
        templateUrl: 'Partials/Search.html'
    }).when('/Home',{
        controller:'homeCtrl',
        templateUrl:'Partials/Home.html'
    }).otherwise({
        controller:'homeCtrl',
        templateUrl:'Partials/Home.html'
    })
    
});


//Controllers

// 1.Home page.
mainApp.controller('homeCtrl', ['$scope', function ($scope) {
    $scope.title = "Welcome to home page.";
                        
}]);
// 2.Search page.
mainApp.controller('searchCtrl', ['$scope','$http', function ($scope,$http) {

    $scope.title="Search page."
    $scope.m = "";
    $scope.mClass="";
    $scope.term = "";
    $scope.data = new Array();
    $scope.validate = function () {

        if ($scope.term.length < 0) {
            $scope.m = "Search term should have more than 0 character.";
        }
        else {
            $scope.m = "Wait, searching for: " + $scope.term;
            $http.get("http://localhost:1102/api/search/find/" + $scope.term)
                .success(function (response) {
                    var len = response.length;
                    $scope.mClass = "glyphicon glyphicon-ok-sign";
                    var spell= " word found.";
                    if (len > 0) {
                        if(len >= 2 )
                        {
                            spell = " words found.";
                        }
                        $scope.data = response;                        
                        
                        $scope.m = response.length + spell;

                    }
                    else {
                        $scope.mClass = "glyphicon glyphicon-remove-sign";
                        $scope.m = "No result found!";
                        $scope.data = "";
                    }
                  
                });
        }
    };


}]);
// 3.About page.
mainApp.controller('aboutCtrl',['$scope',function($scope){
    $scope.title="About Page";
}]);


// Custom functions
//----------------

// 1) Log  - use to anything to console.
function log(text) {
    console.log(text);
}