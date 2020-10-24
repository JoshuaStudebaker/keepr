import Vue from "vue";
import Vuex from "vuex";
import { api } from "../services/AxiosService.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    allKeeps: [],
    activeKeep: {},
    modalToggle: false,
    creatorKeeps: [],
    creatorVaults: []
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
      state.modalToggle = true
    },
    returnAllKeeps(state) {
      state.modalToggle = false
    },
    setProfileKeeps(state, profileKeeps) {
      state.creatorKeeps = profileKeeps
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
     
    async getProfileKeeps({ commit }, creatorId) {
       
      try {
        console.log("get creator keeps?", creatorId);       
        let res = await api.get("profiles/" + creatorId +"/keeps");
        console.log("get profile keeps", res);
        commit("setProfileKeeps", res.data);
      } catch (error) {
        console.error("cannot get profile keeps - sorry");
      }
    },
    async getCreatorVaults({ commit }) {
       console.log("creatorVaults")
      // try {
      //   console.log("get all keeps?");       
      //   let res = await api.get("keeps");
      //   console.log("get keeps", res);
      //   commit("setAllKeeps", res.data);
      // } catch (error) {
      //   console.error("cannot get keeps - sorry");
      // }
    },

   

    getCreator({ dispatch }, creatorId) {
  console.log("getcreator", creatorId)
      dispatch("getProfileKeeps", creatorId)
    },

//       async getActiveKeep({ commit }, keepId) {
//       try {
//         console.log("get active keep?");       
//         let res = await api.get("keeps/" + keepId);
//         console.log("active keep", res);
//         commit("setActiveKeep", res.data);
//       } catch (error) {
//         console.error("cannot get keep - sorry");
//       }
//     },
  },
});
