/* Copyright© 2000 - 2020 SuperMap Software Co.Ltd. All rights reserved.
 * This program are made available under the terms of the Apache License, Version 2.0
 * which accompanies this distribution and is available at http://www.apache.org/licenses/LICENSE-2.0.html.*/
(function () {
    var r = new RegExp("(^|(.*?\\/))(include-leaflet\.js)(\\?|$)"),
        s = document.getElementsByTagName('script'), targetScript;
    for (var i = 0; i < s.length; i++) {
        var src = s[i].getAttribute('src');
        if (src) {
            var m = src.match(r);
            if (m) {
                targetScript = s[i];
                break;
            }
        }
    }

    function inputScript(url) {
        var script = '<script type="text/javascript" src="' + url + '"><' + '/script>';
        document.writeln(script);
    }

    function inputCSS(url) {
        var css = '<link rel="stylesheet" href="' + url + '">';
        document.writeln(css);
    }

    function inArray(arr, item) {
        for (i in arr) {
            if (arr[i] == item) {
                return true;
            }
        }
        return false;
    }

    function supportES6() {
        var code = "'use strict'; class Foo {}; class Bar extends Foo {};";
        try {
            (new Function(code))();
        } catch (err) {
            return false;
        }
        if (!Array.from) {
            return false;
        }
        return true;
    }

    //加载类库资源文件
    function load() {
        var includes = (targetScript.getAttribute('include') || "").split(",");
        var excludes = (targetScript.getAttribute('exclude') || "").split(",");
        if (!inArray(excludes, 'leaflet')) {
            inputCSS('../../web/libs/leaflet/1.6.0/leaflet.css');
            inputScript('../../web/libs/leaflet/1.6.0/leaflet.js');
        }
        if (inArray(includes, 'mapv')) {
            inputScript('../../web/libs/mapv/2.0.43/mapv.min.js');
        }
        if (inArray(includes, 'turf')) {
            inputScript("../../web/libs/turf/5.1.6/turf.min.js");
        }
        if (inArray(includes, 'echarts')) {
            inputScript('../../web/libs/echarts/4.5.0/echarts.min.js');
        }
        if (inArray(includes, 'd3')) {
            inputScript('../../web/libs/d3/5.14.2/d3.min.js');
        }
        if (inArray(includes, 'd3-hexbin')) {
            inputScript("../../web/libs/d3/d3-hexbin.v0.2.min.js");
        }
        if (inArray(includes, 'd3Layer')) {
            inputScript("../../web/libs/leaflet/plugins/leaflet.d3Layer/leaflet-d3Layer.min.js");
        }
        if (inArray(includes, 'elasticsearch')) {
            inputScript('../../web/libs/elasticsearch/16.5.0/elasticsearch.min.js');
        }
        if (inArray(includes, 'deck')) {
            inputScript("../../web/libs/deck.gl/5.1.3/deck.gl.min.js");
        }
        if (inArray(includes, 'xlsx')) {
            inputScript('../../web/libs/xlsx/0.15.4/xlsx.core.min.js');
        }
        if (!inArray(excludes, 'iclient-leaflet')) {
            if (supportES6()) {
                inputScript("../../dist/leaflet/iclient-leaflet-es6.min.js");
            } else {
                inputScript("../../dist/leaflet/iclient-leaflet.min.js");
            }
        }
        if (inArray(includes, 'iclient-leaflet-css')) {
            inputCSS("../../dist/leaflet/iclient-leaflet.min.css");
        }
        if (inArray(includes, 'iclient-plot-leaflet')) {
            inputCSS("../../web/libs/plotting/leaflet/10.0.1/iclient-plot-leaflet.css");
            if (supportES6()) {
                inputScript("../../web/libs/plotting/leaflet/10.0.1/iclient-plot-leaflet-es6.min.js");
            } else {
                inputScript("../../web/libs/plotting/leaflet/10.0.1/iclient-plot-leaflet.min.js");
            }
        }
        if (inArray(includes, 'leaflet.heat')) {
            inputScript("../../web/libs/leaflet/plugins/leaflet.heat/leaflet-heat.js");
        }
        if (inArray(includes, 'osmbuildings')) {
            inputScript("../../web/libs/osmbuildings/OSMBuildings-Leaflet.js");
        }
        if (inArray(includes, 'leaflet.markercluster')) {
            inputCSS("../../web/libs/leaflet/plugins/leaflet.markercluster/1.4.1/MarkerCluster.Default.css");
            inputCSS("../../web/libs/leaflet/plugins/leaflet.markercluster/1.4.1/MarkerCluster.css");
            inputScript("../../web/libs/leaflet/plugins/leaflet.markercluster/1.4.1/leaflet.markercluster.js");
        }
        if (inArray(includes, 'leaflet-icon-pulse')) {
            inputCSS("../../web/libs/leaflet/plugins/leaflet-icon-pulse/L.Icon.Pulse.css");
            inputScript("../../web/libs/leaflet/plugins/leaflet-icon-pulse/L.Icon.Pulse.js");
        }
        if (inArray(includes, 'leaflet.draw')) {
            inputCSS("../../web/libs/leaflet/plugins/leaflet.draw/1.0.4/leaflet.draw.css");
            inputScript("../../web/libs/leaflet/plugins/leaflet.draw/1.0.4/leaflet.draw.js");
        }
        if (inArray(includes, 'leaflet-geoman')) {
            inputCSS('../../web/libs/leaflet/plugins/leaflet-geoman/2.3.0/leaflet-geoman.css');
            inputScript('../../web/libs/leaflet/plugins/leaflet-geoman/2.3.0/leaflet-geoman.min.js');
        }
        if (inArray(includes, 'leaflet.miniMap')) {
            inputCSS("../../web/libs/leaflet/plugins/leaflet-miniMap/3.6.1/dist/Control.MiniMap.min.css");
            inputScript("../../web/libs/leaflet/plugins/leaflet-miniMap/3.6.1/dist/Control.MiniMap.min.js");
        }
        if (inArray(includes, 'leaflet.sidebyside')) {
            inputScript("../../web/libs/leaflet/plugins/leaflet-side-by-side/leaflet-side-by-side.min.js");
        }
        if (inArray(includes, 'pixi')) {
          inputScript("../../web/libs/pixi/4.8.7/pixi.min.js");
          inputScript("../../web/libs/leaflet/plugins/Leaflet.PixiOverlay/1.8.1/L.PixiOverlay.min.js");
          inputScript("../../web/libs/leaflet/plugins/Leaflet.PixiOverlay/1.8.1/MarkerContainer.js");
          inputScript("../../web/libs/bezier-easing/2.1.0/bezier-easing.js");
        }
        if (inArray(includes, 'ant-design-vue')) {
            inputCSS("../../web/libs/ant-design-vue/1.3.9/antd.min.css");
            inputScript("../../web/libs/ant-design-vue/1.3.9/antd.min.js");
        }
        if (inArray(includes, 'echarts-vue')) {
            inputScript('../../web/libs/echarts/4.5.0/echarts.min.js');
            inputScript("../../web/libs/vue-echarts/4.0.4/vue-echarts.min.js");
            inputScript("../../web/libs/echarts-liquidfill/echarts-liquidfill.min.js");
            inputScript("../../web/libs/echartsLayer/EchartsLayer.min.js");
        }
        if (inArray(includes, 'iclient-leaflet-vue')) {
          	inputCSS("../../dist/leaflet/iclient-leaflet-vue.css");
          	inputScript("../../dist/leaflet/iclient-leaflet-vue.min.js");
        }
    }

    load();
    window.isLocal = true;
    window.server = document.location.toString().match(/file:\/\//) ? "http://localhost:8090" : document.location.protocol + "//" + document.location.host;
})();
