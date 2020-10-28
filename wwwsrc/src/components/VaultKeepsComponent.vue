<template>
  
     <div class="card rounded-card shadow" @click="setActiveKeep" style="display: inline-block">      
      <div class="card-body container-img p-0 justify-content-between">
        <img :src="keepProp.img" class="img-fluid rounded-card"> 
        <i class="fas fa-times top-right cursor" @click="removeKeepFromVault"></i><div class="bottom-left col-6 p-0 text-left rounded">{{keepProp.name}}</div>
       
          <i class="far fa-user-circle profile shadow bottom-right col-6 p-0 text-right" @click.stop="routerPush"></i> 
          
      </div>      
    </div> 
   
 
</template>

<script>
export default {
  name: "vault-keeps-component",
  props: ["keepProp"],
  components: {},
  
  mounted() {
    this.$store.dispatch("getProfile");
    this.$store.dispatch("getVaultKeeps", this.$route.params.vaultId);
  },

  computed: {
    
  },
  methods: {   
    setActiveKeep() {           
      this.$store.dispatch("getActiveKeep", this.keepProp.id); 
    },
      removeKeepFromVault(){
this.$store.dispatch("removeFromVault", this.keepProp.vaultKeepId)
    }
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

  .top-right {
  position: absolute;
  top: 8px;
  right: 16px;
}

  .profile:hover {
    box-shadow: 0px 0px 2px grey;
  }


</style>
