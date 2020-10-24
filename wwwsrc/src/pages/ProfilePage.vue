<template>
  <div>
     <profile-vaults-component v-for="iVault in creatorVaults" :key="iVault.id" :vaultProp="iVault"/>
     <profile-keeps-component v-for="iKeep in creatorKeeps" :key="iKeep.id" :keepProp="iKeep"/>
  </div>
</template>

<script>


  import profileKeepsComponent from "../components/ProfileKeepsComponent";
  import profileVaultsComponent from "../components/ProfileVaultsComponent";
export default {
  name: "profile-page",
  components: {
    profileKeepsComponent,
    profileVaultsComponent
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
    }
    
  },methods: {
   
    returnAllKeeps() {           
      this.$store.commit("returnAllKeeps");      
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
