<template>
  
     <div class="card see-through rounded-card" @click="setActiveVault">
      <div class="card-header see-through-white">
       <h5 class="card-title active-keep-button">{{ vaultProp.name }}</h5>
      <h1 class="mt-2"></h1>
        <h6 class="card-subtitle text-muted"><i class="far fa-user profile"></i> {{ vaultProp.creator.name }}</h6>
      </div>
      <div class="card-body">
        <p class="card-text">{{ vaultProp.description }}</p> 
         <p>   <i class="far fa-times-circle" @click.stop="deleteVault"></i></p>
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
      this.$router.push({name: 'Vault', params: {vaultId: this.vaultProp.id}})
    },

    deleteVault(){
      this.$store.dispatch("deleteVault", this.vaultProp.id)
    },
    
  
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
