<template>
 <div class="row">
   <div class="card text-left">
     <img class="card-img-top" src="holder.js/100px180/" alt="">
     <div class="card-body">
       <h4 class="card-title">Title</h4>
       <p class="card-text">Body</p> 
       <p>{{creatorKeeps.length}} , {{creatorVaults.length}}</p>
   <p>{{creatorInfo.name}}</p>
   <img :src="creatorInfo.picture"/>
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
