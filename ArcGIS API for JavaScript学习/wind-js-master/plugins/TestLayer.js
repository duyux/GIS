
define([
  "dojo/_base/declare", "esri/layers/Layer",
  "esri/layers/GraphicsLayer","esri/layers/BaseDynamicLayer"
], function (
  declare,  Layer, GraphicsLayer,BaseDynamicLayer
) {
  return Layer.createSubclass({
    constructor: function() {
         console.log('jhello222')
    }
  });
});
