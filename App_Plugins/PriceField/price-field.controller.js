angular.module('umbraco').controller('PriceFieldPluginController', function ($scope) {
    $scope.model.config.isCurrencyEnabled = Boolean(Number($scope.model.config.isCurrencyEnabled));
    
});