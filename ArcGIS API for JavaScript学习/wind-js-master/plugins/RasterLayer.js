
define([
  "dojo/_base/declare", "dojo/_base/connect", "dojo/_base/array",
  "dojo/dom-construct", "dojo/dom-style", "dojo/number",
  "esri/core/lang",
  "esri/geometry/SpatialReference", "esri/geometry/Point", "esri/layers/Layer",
  "esri/layers/GraphicsLayer"
], function (
  declare, connect, arrayUtils,
  domConstruct, domStyle, number,
  esriLang,
  SpatialReference, Point, Layer, GraphicsLayer
) {
    return Layer.createSubclass({
      constructor: function (map, mapview, options) {
        
        // Manually call superclass constructor with required arguments
        //this.inherited(arguments, ["http://some.server.com/path", options]);
  
        this.mapview = mapview;
        this.map = map;
        this.loaded = true;
     
        this._initialize(mapview, mapview.container);
 
  
      },
      
      /******************************
       * esri.layers.Layer Interface
       ******************************/
      _initialize: function (mapview, container) {
        
        this._mapview = mapview;
        //console.log('containers',container)
      
       
        var element = this._element = domConstruct.create("canvas", {
          id: "canvas",
          width: mapview.width + "px",
          height: mapview.height + "px",
          style: "position: absolute; left: 500px; top: 500px;"
        // }, mapview);
        }, container);
  
  
      
        // if (esriLang.isDefined(this.opacity)) {
        //   domStyle.set(element, "opacity", this.opacity);
        // }
  
        this._context = element.getContext("2d");
  
        if (!this._context) {
          console.error("This browser does not support <canvas> elements.");
        }
         
        /////////?????????????????????
        // console.log('start text', this._context)
        // this._context.font="72px Sans-Serif";
       
        // this._context.textBaseline="top";

        // this._context.globalAlpha=0.9;
        // this._context.fillStyle="#FFFFFF";
        // this._context.fillText("hello",150,200);
        // console.log('start text3')
        //???????????????????????????

        // this._mapviewWidth = mapview.width;
        // this._mapviewHeight = mapview.height;
  
        // Event connections
        // this._connects = [];
        // this._connects.push(connect.connect(mapview, "onPan", this, this._panHandler));
        // this._connects.push(connect.connect(mapview, "onExtentChange", this, this._extentChangeHandler));
        // this._connects.push(connect.connect(mapview, "onZoomStart", this, this.clear));
        // this._connects.push(connect.connect(this, "onVisibilityChange", this, this._visibilityChangeHandler));
        //console.log('element',element)
        this._element=element;
        return element;
      },
  
      _unsetMap: function (map, container) {
        arrayUtils.forEach(this._connects, connect.disconnect, this);
        if (this._element) {
          container.removeChild(this._element);
        }
        this._mapview = this._element = this._context = this.data = this._connects = null;
      },
  
      /*****************
       * Public Methods
       *****************/
  
      refresh: function () {
        if (!this._canDraw()) {
          return;
        }
      },
  
      clear: function () {
        if (!this._canDraw()) {
          return;
        }
  
        this._context.clearRect(0, 0, this._mapWidth, this._mapHeight);
      },
  
      /*******************
       * Internal Methods
       *******************/
  
      _canDraw: function () {
        return (this._map && this._element && this._context) ? true : false;
      },
  
      _panHandler: function (extent, delta) {
        domStyle.set(this._element, { left: delta.x + "px", top: delta.y + "px" });
      },
  
      _extentChangeHandler: function (extent, delta, levelChange, lod) {
        if (!levelChange) {
          domStyle.set(this._element, { left: "0px", top: "0px" });
          this.clear();
        }
      },
  
      /****************
       * Miscellaneous
       ****************/
  
      // _visibilityChangeHandler: function(visible) {
      //   if (visible) {
      //     domUtils.show(this._element);
      //   }
      //   else { 
      //     domUtils.hide(this._element);
      //   }
      // }
  
      _visibilityChangeHandler: function (visible) {
        if (visible) {
          //domUtils.show(this._element);
          this._element.visible = true;
        }
        else {
          //domUtils.hide(this._element);
          this._element.visible = false;
        }
      }
    });
  });
  
