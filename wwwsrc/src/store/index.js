import Vue from "vue";
import Vuex from "vuex";
import { api } from "../services/AxiosService.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    allKeeps: [],
    activeKeep: {}
  },
  mutations: {
    setProfile(state, profile) {
      state.profile = profile;
    },
    setAllKeeps(state, allKeeps) {
      state.allKeeps = allKeeps
    },
    setActiveKeep(state, activeKeep) {
      state.activeKeep = activeKeep
    }
  },
  actions: {
    async getProfile({ commit }) {
      try {
        let res = await api.get("profiles");
        commit("setProfile", res.data);
      } catch (error) {
        console.error(error);
      }
    },
     async getAllKeeps({ commit }) {
      try {
        console.log("get all keeps?");       
        let res = await api.get("keeps");
        console.log("get keeps", res);
        commit("setAllKeeps", res.data);
      } catch (error) {
        console.error("cannot get keeps - sorry");
      }
    },


      async getActiveKeep({ commit }, keepId) {
      try {
        console.log("get active keep?");       
        let res = await api.get("keeps/" + keepId);
        console.log("active keep", res);
        commit("setActiveKeep", res.data);
      } catch (error) {
        console.error("cannot get keep - sorry");
      }
    },
  },
});
