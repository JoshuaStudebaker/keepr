<template>
 <div class="row">
   <p>{{creatorCount.keepCount}} , {{creatorCount.vaultCount}}</p>
 </div>
</template>

<script>
export default {
  name: "profile-roof-component",
  props: [],
  components: {},
  
  mounted() {
     this.$store.dispatch("getProfile");
     this.$store.dispatch("getProfileInfo");
  },

  computed: {
    creatorCount(){
      return this.$store.state.creatorCount
    },
    // creator(){
    //   return 
    // }
  },
  methods: {
   
  //  profile() {           
  //     this.$store.dispatch("getProfileInfo");      
  //   },
    
  
  },
};
</script>

<style>


</style>
