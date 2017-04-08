angular.module("AnimateCss", [])
    .directive("ngAnimate", function () {
        "use strict";
        return {
            restrict: "A",
            scope: {
                ngAnimate: "@"
            },
            link: function (scope, element) {
                var animation, oldV, newV;
                scope.$watch("ngAnimate", function (newValue, oldValue) {
                    if (oldValue.charAt(0) === "@") {
                        oldV = "infinite " + oldValue.substring(1);
                    } else {
                        oldV = oldValue;
                    }
                    if (newValue.charAt(0) === "@") {
                        newV = "infinite " + newValue.substring(1);
                    } else {
                        newV = newValue;
                    }
                    element.removeClass(oldV);
                    scope.ngAnimate = newV;
                    if (scope.ngAnimate.charAt(0) === "@") {
                        animation = "infinite " + scope.ngAnimate.substring(1);
                    } else {
                        animation = scope.ngAnimate;
                    }
                    scope.inProggress = animation;
                    element.addClass("animated " + animation);
                });
            }
        };
    });