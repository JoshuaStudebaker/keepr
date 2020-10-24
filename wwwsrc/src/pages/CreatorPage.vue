<template>
  <div>
    
  </div>
</template>

<script>


export default {
  name: "creator-page",
  components: {
    
  },
  mounted() {
    this.$store.dispatch("getCreatorKeeps");
    this.$store.dispatch("getCreatorVaults")
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
