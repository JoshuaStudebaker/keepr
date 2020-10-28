<template>
 <div class="row p-3 d-flex justify-content-left">
   <div class="see-through p-2 rounded mx-2 col-8 d-flex align-items-center">
   <div class="col-3 text-center">
     <img :src="creatorInfo.picture" class="img-fluid"/></div>

     
     <div class="col-8">
       
   <h3>{{creatorInfo.name}}</h3>
       <h5> Vaults: {{creatorVaults.length}}</h5>
       <h5>Keeps: {{creatorKeeps.length}}</h5>
   
     </div>
   </div>
  </div>
 </div>
</template>

<script>
export default {
  name: "profile-roof-component",
  props: [],
  components: {},
  
  mounted() {
     this.$store.dispatch("getProfile");
      // this.$store.dispatch("getCreator", this.$route.params.profileId);
  },

  computed: {
    creatorKeeps() {
      return this.$store.state.creatorKeeps;
    }, 

    creatorVaults() {
      return this.$store.state.creatorVaults;
    }, 

    creatorInfo(){
      return this.$store.state.creatorInfo
    }
    // creatorCount(){
    //   return this.$store.state.creatorCount
    // },
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
