import Vue from "vue";
import Vuex from "vuex";
import { api } from "../services/AxiosService.js";
import SweetAlert from "../services/SweetAlert.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    allKeeps: [],
    activeKeep: {},
    modalToggle: false,
    creatorKeeps: [],
    creatorVaults: [],
    vaultKeeps: [],
    keepForm: false,
    vaultForm: false,
    userVaults: []
  },
  mutations: {
    setProfile(state, profile) {
      state.profile = profile;
    },
    setAllKeeps(state, allKeeps) {
      state.allKeeps = allKeeps
    },
    setVaultKeeps(state, vaultKeeps) {
      state.vaultKeeps = vaultKeeps
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
    },
    setProfileVaults(state, profileVaults) {
      state.creatorVaults = profileVaults
    },
    keepFormToggle(state) {
      state.keepForm = !state.keepForm
    },
     deleteKeep(state, keepId) {
      state.creatorKeeps = state.creatorKeeps.filter((k) => k.id != keepId);
    },
     vaultFormToggle(state) {
      state.vaultForm = !state.vaultForm
    },
     deleteVault(state, vaultId) {
      state.creatorVaults = state.creatorVaults.filter((v) => v.id != vaultId);
    },
     modalToggleFalse(state) {
       state.modalToggle = false
    },
    setUserVaults(state, userVaults) {
       state.userVaults = userVaults
     }
     
  },
  actions: {
    async getProfile({ commit, dispatch }) {
      try {
        let res = await api.get("profiles");
        commit("setProfile", res.data);
        dispatch("getUserVaults")
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
        commit("modalToggleFalse")
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
    async getProfileVaults({ commit }, creatorId) {
       
      try {
        console.log("get creator vaults?", creatorId);       
        let res = await api.get("profiles/" + creatorId +"/vaults");
        console.log("get profile vaults", res);
        commit("setProfileVaults", res.data);
      } catch (error) {
        console.error("cannot get profile vaults - sorry");
      }
    },

   async getVaultKeeps({ commit }, vaultId) {
       
      try {
        console.log("get vault keeps?", vaultId);       
        let res = await api.get("vaults/" + vaultId +"/keeps");
        console.log("get vault keeps", res);
        commit("setVaultKeeps", res.data);
      } catch (error) {
        console.error("cannot get vault keeps - sorry");
      }
    },
   
   
   async getUserVaults({ state, commit}) {
       
     try {
       
        let userId = state.profile.id
        console.log("user vaults??", userId);       
        let res = await api.get("profiles/" + userId +"/vaults");
        console.log("user vaults?", res);
        commit("setUserVaults", res.data);
      } catch (error) {
        console.error("cannot get user vaults - sorry");
      }
    },

    getCreator({ dispatch }, creatorId) {
      console.log("getcreator", creatorId)
      dispatch("getProfileVaults", creatorId)
      dispatch("getProfileKeeps", creatorId)
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
      
       async createKeep({ commit, state }, newKeep) {
      console.log("createKeep", newKeep);
      let res = await api.post("keeps/", newKeep);
      console.log("createKeep - res", res);
      commit("setProfileKeeps", [...state.creatorKeeps, res.data]);
      
    },

        async deleteKeep({ commit }, keepId) {
      if (
        await SweetAlert.sweetDelete(
         
        )
      ) {
        await api.delete("keeps/" + keepId);
        commit("deleteKeep", keepId);
      }
    },
    async createVault({ commit, state }, newVault) {
      if (newVault.isPrivate == "false") {
        newVault.isPrivate = false
      }
      if (newVault.isPrivate == "true") {
      newVault.isPrivate = true
    }
      console.log("createVault", newVault);
      let res = await api.post("vaults/", newVault);
      console.log("createVault - res", res);
      commit("setProfileVaults", [...state.creatorVaults, res.data]);
      
    },

        async deleteVault({ commit }, vaultId) {
      if (
        await SweetAlert.sweetDelete(
         
        )
      ) {
        await api.delete("vaults/" + vaultId);
        commit("deleteVault", vaultId);
      }
    },
        
  },
});
