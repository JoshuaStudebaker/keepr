<template>
  <div>
     <button v-if="!keepForm" type="button" class="btn btn-secondary" @click="keepFormToggle">Add Keep</button>
     <button v-if="!vaultForm" type="button" class="btn btn-warning" @click="vaultFormToggle">Add Vault</button>
     <keeps-form-component v-if="keepForm"/>
     <vaults-form-component v-if="vaultForm"/>
     <profile-vaults-component v-for="iVault in creatorVaults" :key="iVault.id" :vaultProp="iVault"/>
     <profile-keeps-component v-for="iKeep in creatorKeeps" :key="iKeep.id" :keepProp="iKeep"/>
  </div>
</template>

<script>
  import profileKeepsComponent from "../components/ProfileKeepsComponent";
  import profileVaultsComponent from "../components/ProfileVaultsComponent";
  import keepsFormComponent from "../components/KeepsFormComponent";
  import vaultsFormComponent from "../components/VaultsFormComponent"
export default {
  name: "profile-page",
  components: {
    profileKeepsComponent,
    profileVaultsComponent,
    keepsFormComponent,
    vaultsFormComponent
  },
  mounted() {
    this.$store.dispatch("getProfile");
    this.$store.dispatch("getCreator", this.$route.params.profileId);
    
  },
  computed: {
    creatorKeeps() {
      return this.$store.state.creatorKeeps;
    }, 

    creatorVaults() {
      return this.$store.state.creatorVaults;
    }, 
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    modalToggle(){
      return this.$store.state.modalToggle
    },
    keepForm(){
      return this.$store.state.keepForm
    },
    vaultForm(){
      return this.$store.state.vaultForm
    }
    
  },
  methods: {   
    returnAllKeeps() {           
      this.$store.commit("returnAllKeeps");      
    },

    keepFormToggle(){
      this.$store.commit("keepFormToggle")
  },
  vaultFormToggle(){
      this.$store.commit("vaultFormToggle")
      }
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
