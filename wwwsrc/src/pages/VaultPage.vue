<template>
  <div class="container-fluid">
    <div class="row align-items-center d-flex px-2"><h1>{{activeVault.name}}</h1> <span class="pl-3"><i class="fas fa-trash" v-if="profile.id == activeVault.creatorId" @click="deleteVault(activeVault.id)"></i></span> </div>
    <div class="row px-2">Keeps: {{vaultKeeps.length}}</div>
    <div class="row">
      <div class="card-columns p-md-4 p-3 justify-content-center">
      <vault-keeps-component v-for="iKeep in vaultKeeps" :key="iKeep.id" :keepProp="iKeep"/></div>
    </div>    
  </div>
</template>

<script>
import vaultKeepsComponent from "../components/VaultKeepsComponent";
export default {
  name: "home",
  components: {
    vaultKeepsComponent,
   
  },
  mounted() {
    this.$store.dispatch("getProfile");
    this.$store.dispatch("getVaultKeeps", this.$route.params.vaultId);
    this.$store.dispatch("getActiveVault", this.$route.params.vaultId);
  },
  computed: {
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
    }, 
    activeKeep() {
      return this.$store.state.activeKeep;
    },

    activeVault() {
      return this.$store.state.activeVault;
    },
    modalToggle(){
      return this.$store.state.modalToggle
    },
    profile(){
      return this.$store.state.profile
    }
    
  },methods: {
   
    returnAllKeeps() {           
      this.$store.commit("returnAllKeeps");      
    },
  deleteVault(id){
      this.$store.dispatch("deleteVault", this.activeVault)     
    },
  },
};
</script>
<style>


.active-keep-button {
  cursor: pointer;}
  .active-keep-button:hover{
    box-shadow: 3px 3px black;
  }

</style>
