<template>  
    <!--  -->
       <div class="card rounded-card shadow" @click="setActiveKeep" style="display: inline-block">      
      <div class="card-body container-img p-0 justify-content-between">
        <img :src="keepProp.img" class="img-fluid rounded-card"> 
       <div class="bottom-left col-6 p-0 text-left rounded">{{keepProp.name}}</div>
        <!-- <router-link :to="{name: 'Profile', params: {profileId: keepProp.creatorId}}"> -->
          <i class="far fa-user-circle profile shadow bottom-right col-6 p-0 text-right" @click.stop="routerPush"></i> 
          <!-- </router-link> -->
      </div>      
    </div> 
    <!--  -->
</template>

<script>
export default {
  name: "all-keeps-component",
  props: ["keepProp"],
  components: {},
  
  mounted() {},

  computed: {},
  methods: {
   
    setActiveKeep() {           
      this.$store.dispatch("getActiveKeep", this.keepProp.id);  
      this.$store.dispatch("getUserVaults")    
    },

    routerPush(){
      console.log("routerPush")
      this.$router.push({name: 'Profile', params: {profileId: this.keepProp.creatorId}})
    }

    
    // creatorLink(){
    //   console.log("creatorId", this.keepProp.creatorId)
    //  this.$store.dispatch
    // },
  
  },
};
</script>

<style>
.red-font {
  color: red;
}

.green-font {
  color: green;
}

.see-through {
  background-color: hsla(218, 19%, 89%, 0.8);
}

.see-through-white {
  background-color: hsla(218, 19%, 98%, 0.8);
}

.active-keep-button {
  cursor: pointer
  }

  .active-keep-button:hover{
    box-shadow: 3px 3px black;
  }

  .profile{
    cursor: pointer;
  }

  .profile:hover {
    box-shadow: 0px 0px 2px grey;
  }

  .bottom-right {
  position: absolute;
  bottom: 8px;
  right: 16px;
}
.container-img {
  position: relative;
  text-align: center;
  color: white;
}.bottom-left {
  position: absolute;
  bottom: 8px;
  left: 16px;
}

.rounded-card{
  border-radius: 1rem;
  cursor: pointer;
}

.rounded-card-no-pointer{
  border-radius: 1rem;
 
}

.fa-user-circle{
  font-size: 1.2rem;
  color: hsl(148.28, 93.55%, 71.76%);
  background-color: hsla(218, 19%, 98%, 0.4);
  border-radius: 50%
}
.fa-user-circle:hover{
font-size: 1.4rem;
background-color: hsla(148.28, 93.55%, 71.76%, 0.4);
  color: hsla(218, 19%, 98%);
}

.see-through {
  background-color: hsla(218, 19%, 89%, 0.8);
}
.sea-green {
  color: hsl(148.28, 93.55%, 71.76%);
}

.see-through-white {
  background-color: hsla(218, 19%, 98%, 0.8);
}


</style>
