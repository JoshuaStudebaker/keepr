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
    userVaults: [],
    creatorCount: {},
    creatorInfo: {}
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

    setCreatorCount(state, creatorCount) {
      state.creatorCount = creatorCount
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
    },
     removeFromVault(state, vaultKeepId) {
      state.vaultKeeps = state.vaultKeeps.filter((k) => k.vaultKeepId != vaultKeepId);
    },
     setCreatorInfo(state, creator) {
       state.creatorInfo.name = creator.name;
       state.creatorInfo.picture = creator.picture;
      //  state.creatorInfo.keepCount = state.creatorKeeps.length;
      //  state.creatorInfo.vaultCount - state.creatorVaults.length;
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
    async getProfileInfo({ commit, dispatch, state }) {
   let creatorCount = {}
    creatorCount.keepCount = state.creatorKeeps.length;
   creatorCount.vaultCount = state.creatorVaults.length;
  commit("setCreatorCounts", creatorCount)
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
      dispatch("getCreatorInfo", creatorId)
    },

    async getCreatorInfo({ commit }, creatorId) {
      try {
        let res = await api.get("profiles/" + creatorId)
        console.log("creator?", res.data)
        commit("setCreatorInfo", res.data)
      } catch (error) {
        console.error("Failed to get creator")
        
      }
    },

      async getActiveKeep({ commit }, keepId) {
      try {
        console.log("get active keep?");       
        let res = await api.get("keeps/" + keepId);
        console.log("active keep", res);
        commit("setActiveKeep", res.data);
        this.dispatch("addViews", keepId)
      } catch (error) {
        console.error("cannot get keep - sorry");
      }
    },
      
       async addViews({ commit, state }, keepId) {
      try {
        console.log("add view?", keepId); 
        let keepPatch = {};
        keepPatch.views = state.activeKeep.views + 1
        keepPatch.keeps = state.activeKeep.keeps    
        let res = await api.patch("keeps/" + keepId, keepPatch);
        console.log("addView", res);
        commit("setActiveKeep", res.data);        
      } catch (error) {
        console.error("cannot get keep - sorry");
      }
    },
       
      async addKeepCount({ commit, state }, keepId) {
      try {
        console.log("add view?", keepId); 
        let keepPatch = {};
        keepPatch.views = state.activeKeep.views
        keepPatch.keeps = state.activeKeep.keeps + 1 
        let res = await api.patch("keeps/" + keepId, keepPatch);
        console.log("addView", res);
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

       async deleteKeepFromActive({ commit, dispatch }, keepId) {
      if (
        await SweetAlert.sweetDelete(
         
        )
      ) {
        await api.delete("keeps/" + keepId);
        commit("deleteKeep", keepId);
        dispatch("getAllKeeps")
        commit("returnAllKeeps")
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

    async addKeepToVault({ dispatch}, vaultKeep) {
      console.log("addKeepToVault", vaultKeep)
      let res = await api.post("vaultkeeps", vaultKeep)
      console.log("vaultkeep store", res.data)
      dispatch("addKeepCount", vaultKeep.keepId)
    },

    async removeFromVault({ commit}, vaultKeepId) {
      if (
        await SweetAlert.sweetDelete()
      )
      console.log("DeleteKeepFromVault", vaultKeepId)
      let res = await api.delete("vaultkeeps/" + vaultKeepId)
      commit("removeFromVault", vaultKeepId)     
     
    },

        async deleteVault({ commit }, vaultId) {
      if (
        await SweetAlert.sweetDelete()
      ) {
        await api.delete("vaults/" + vaultId);
        commit("deleteVault", vaultId);
      }
    },
        
  },
});
