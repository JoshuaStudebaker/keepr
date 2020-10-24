<template>
  
    <div class="card see-through rounded">
      <div class="card-header see-through-white">
        <h5 class="card-title">{{ activeKeep.name }}</h5>
        <h6 class="card-subtitle text-muted">By: {{ activeKeep.creator.name }}</h6>
      </div>
      <div class="card-body">
        <img :src="activeKeep.img" class="img-fluid" alt="Responsive image">
      </div>
      <div class="card-footer see-through-white py-1">
        <p class="card-text">{{ activeKeep.description }}</p>        
      </div>
    </div>
  
</template>

<script>
export default {
  name: "active-keep-component",
  
  
  mounted() {},

  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    },
  },
  methods: {
    
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
</style>
