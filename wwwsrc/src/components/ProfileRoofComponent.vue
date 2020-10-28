<template>
 <div class="row p-3 d-flex justify-content-left">
   <div class="see-through p-2 rounded-card mx-2 d-flex align-items-center">
   
     <img :src="creatorInfo.picture" class="rounded-card"/>

     
     <div class="col-8 text-left">
       
   <h3 class="smaller-mobile">{{creatorInfo.name}}</h3>
       <h5 class="smaller-mobile-sub"> Vaults: {{creatorVaults.length}}</h5>
       <h5 class="smaller-mobile-sub" >Keeps: {{creatorKeeps.length}}</h5>
   
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
@media (max-width: 700px) {
.smaller-mobile{
  font-size: 1.1rem;
}
}

@media (max-width: 700px) {
.smaller-mobile-sub{
  font-size: 1rem;
}
}
</style>
