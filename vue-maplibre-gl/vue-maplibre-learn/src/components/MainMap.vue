<template>
  <div class="map-container">
    <MglMap
      ref="mglMapRef"
      :map-style="mapStyle"
      :center="center"
      :zoom="zoom"
    >
      <!-- 标记点，等地图正常后再打开 -->
      <!-- <MglMarker v-if="validPos" :lnglat="validPos">
        <div>标记点</div>
      </MglMarker> -->
      <mgl-navigation-control position="top-left" />

     <mgl-marker :coordinates="coordinates">
      <mgl-popup ref="popup">
        <h1>Hello</h1>
        <p>HTML content</p>
        <a href="#" @click.prevent="closePopup">Close popup</a>
      </mgl-popup>
    </mgl-marker>


   
    </MglMap>
  </div>
</template>

<script setup>
import { ref, computed, watch, nextTick ,useTemplateRef} from 'vue'
import { MglMap, MglMarker,MglPopup} from '@indoorequal/vue-maplibre-gl'

const rawPoint = ref(null)
const validPos = computed(() => {
  if (!rawPoint.value) return null
  const lng = Number(rawPoint.value.lng)
  const lat = Number(rawPoint.value.lat)
  if (!isNaN(lng) && !isNaN(lat)) {
    return [lng, lat]
  }
  return null
})

const mapStyle = ref('https://tiles.openfreemap.org/styles/liberty')
const center = ref([106.63, 26.65])
const zoom = ref(10)
const coordinates = [106.63, 26.65];



// 模板ref，绑定MglMap组件
const mglMapRef = ref(null)
// 保存地图原生实例
const map = ref(null)

const popupRef = useTemplateRef('popup')
const closePopup = () => {
  popupRef.value.remove()
};

// 监听组件ref变化
watch(
  mglMapRef,
  async (comp) => {
    if (!comp) return
    await nextTick()
    // 等待地图内部初始化完成
    const waitMapReady = () => {
      return new Promise((resolve) => {
        const timer = setInterval(() => {
          if (comp.map) {
            clearInterval(timer)
            resolve(comp.map)
          }
        }, 100)
      })
    }
    const nativeMap = await waitMapReady()
    map.value = nativeMap
    console.log('✅地图原生实例', nativeMap)

    // 监听地图错误
    nativeMap.on('error', (e) => {
      console.error('❌地图错误：', e)
    })
    // 地图加载完成事件
    nativeMap.on('load', () => {
      console.log('🎉地图瓦片全部加载完毕')
    })
  },
  { once: true }
)
</script>

<style scoped>
.map-container {
  width: 100%;
  height: 600px;
}
</style>
