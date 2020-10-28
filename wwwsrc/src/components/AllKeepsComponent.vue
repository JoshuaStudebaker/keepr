<template>  
    <div class="card rounded-card shadow">      
      <div class="card-body container-img p-0">
        <img :src="keepProp.img" class="img-fluid rounded-card"> 
        <div class="bottom-left active-keep-buttom" @click="setActiveKeep()">{{keepProp.name}}</div>
        <router-link :to="{name: 'Profile', params: {profileId: keepProp.creatorId}}"><i class="far fa-user profile shadow bottom-right"></i></router-link> 
      </div>      
    </div> 
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
}

</style>
