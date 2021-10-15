import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex)

const state = {
    count:1
}

const mutations={
    add(state){
      state.count+=1
    },
    reduce(state){
      state.count-=1
    }
}

const getters={
    count:function(state){
        return state.count+=100
    }
}

const actions={
   addAction(context){
      context.commit('add')
   },
   reduceAction({commit}){
      commit('reduce');
   }
}

const moduleA={
    state,mutations,getters,actions
}
const store = new Vuex.Store({
    modules:{
      a:moduleA
    }
});

export default store