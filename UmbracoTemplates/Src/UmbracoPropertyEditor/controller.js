// https://our.umbraco.com/documentation/Tutorials/Creating-a-Property-Editor/

angular
  .module("umbraco")
  .controller("$safeitemname$.Controller", function($scope) {
    var vm = this;

    //your code here

    //how to use the configuration
    // https://our.umbraco.com/documentation/Tutorials/Creating-a-Property-Editor/part-2#using-the-configuration
    if ($scope.model.value === null || $scope.model.value === "") {
      $scope.model.value = $scope.model.config.defaultValue;
    }
  });
