<template>
  <div class="hello"></div>
</template>

<script>
import L from "leaflet";
import { tiledMapLayer } from "@supermap/iclient-leaflet";

export default {
  name: "SuperMapForLeafLetTest",
  data() {
    return {
      msg: "learn supermap"
    };
  },
  methods: {},
  created() {
    // console.log('start')
    // var url =
    //   "https://iserver.supermap.io/iserver/services/map-world/rest/maps/World";
    // var map = L.map("app", {
    //   crs: L.CRS.EPSG4326,
    //   center: [0, 0],
    //   maxZoom: 18,
    //   zoom: 1
    // });
    // tiledMapLayer(url).addTo(map);
    var url =
      "http://59.215.189.122:8095/iserver/services/map-guizhou/rest/maps/guizhou";
    // 初始化地图信息
    var map = L.map("app", {
      // crs: L.CRS.NonEarthCRS({
      //   bounds: L.bounds([103.59830243397714, 24.62136102], [109.59269882156048, 29.22432804]),
      //   // origin: L.point(48.4, -55.58)
      // }),
      center: [106.59550062776881,26.92284453],
      maxZoom: 18,
      zoom:8
    });
    // 添加图层
    //L.supermap.tiledMapLayer(url, { noWrap: true }).addTo(map);
    L.supermap.tiledMapLayer(url, { noWrap: true }).addTo(map);
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1,
h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}
</style>
