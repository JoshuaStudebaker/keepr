<template>
  <div class="col-4">
    <div class="card see-through rounded">
      <div class="card-header see-through-white">
        <h5 class="card-title active-keep-button" @click="setActiveKeep()">{{ keepProp.name }}</h5>
        <h6 class="card-subtitle text-muted"><i class="far fa-user profile" @click="creatorLink"></i> {{ keepProp.creator.name }}</h6>
      </div>
      <div class="card-body">
        <img :src="keepProp.img" class="img-fluid" alt="Responsive image">
      </div>
      <div class="card-footer see-through-white py-1">
        <p class="card-text">{{ keepProp.description }}</p>        
      </div>
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
    },

    
    creatorLink(){
      console.log("creatorId", this.keepProp.creatorId)
     
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
