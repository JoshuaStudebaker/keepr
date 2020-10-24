<template>
  <div class="col-4">
    <div class="card see-through rounded">
      <div class="card-header see-through-white">
        <h5 class="card-title active-keep-button" @click="setActiveVault()">{{ vaultProp.name }}</h5>
      <h1 class="mt-2"></h1>
        <h6 class="card-subtitle text-muted"><router-link :to="{name: 'Profile', params: {profileId: vaultProp.creatorId}}"><i class="far fa-user profile"></i></router-link> {{ vaultProp.creator.name }}</h6>
      </div>
      <div class="card-body">
        <img :src="vaultProp.img" class="img-fluid" alt="Responsive image">
      </div>
      <div class="card-footer see-through-white py-1">
        <p class="card-text">{{ vaultProp.description }}</p>        
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "profile-vaults-component",
  props: ["vaultProp"],
  components: {},
  
  mounted() {},

  computed: {},
  methods: {
   
    setActiveVault() {           
      this.$store.dispatch("getActiveVault", this.vaultProp.id);      
    },

    
    // creatorLink(){
    //   console.log("creatorId", this.vaultProp.creatorId)
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


</style>
