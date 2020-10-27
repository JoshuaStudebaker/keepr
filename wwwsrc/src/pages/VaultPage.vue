<template>
  <div>
    <h1 class="active-keep-button" @click="returnAllKeeps">Welcome</h1>
    <div class="row">
      <vault-keeps-component v-for="iKeep in vaultKeeps" :key="iKeep.id" :keepProp="iKeep"/>
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
  },
  computed: {
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
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
