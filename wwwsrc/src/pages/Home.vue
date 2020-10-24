<template>
  <div class="home">
    <h1 class="active-keep-button" @click="returnAllKeeps">Welcome</h1>
    <div class="row" v-if="modalToggle != true">
      <all-keeps-component v-for="iKeep in keeps" :key="iKeep.id" :keepProp="iKeep"/>
    </div>
    <div class="row">
      
      <active-keep-component />
    </div>
  </div>
</template>

<script>
import allKeepsComponent from "../components/AllKeepsComponent";
import activeKeepComponent from "../components/ActiveKeepComponent"

export default {
  name: "home",
  components: {
    allKeepsComponent,
    activeKeepComponent
  },
  mounted() {
    this.$store.dispatch("getAllKeeps");
  },
  computed: {
    keeps() {
      return this.$store.state.allKeeps;
    }, activeKeep() {
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
