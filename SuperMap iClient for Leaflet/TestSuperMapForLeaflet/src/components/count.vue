<template>
  <div>
      <h2>{{msg}}</h2>
      <hr/>
      <h3>{{$store.state.a.count}}</h3>
      <div>
         <button @click="add">+</button>
         <button @click="reduce">-</button>
      </div>
      <div>
          <button @click="addAction">+</button>
          <button @click="reduceAction">-</button>
      </div>
  </div>
</template>

<script>
   import {mapState,mapMutations,mapGetters,mapActions} from 'vuex'
   export default {
       data(){
           return {
               msg:"hello world"
           }
       },
       computed:{
          ...mapGetters(["count"])
        },
      
        methods:{
            ...mapMutations(['add','reduce']),
            ...mapActions(['addAction','reduceAction'])
        }

   }
</script>