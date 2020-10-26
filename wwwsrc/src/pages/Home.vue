<template>
  <div class="home">
    <!-- <h1 >Welcome</h1> -->
    <div class="row" v-if="!modalToggle">
      <all-keeps-component v-for="iKeep in keeps" :key="iKeep.id" :keepProp="iKeep"/>
    </div>
    <div class="row">
      <transition name="slide-fade">
      <div v-if="modalToggle" class="modal-overlay d-flex">
       <div class="col-6 p-2"><img :src="activeKeep.img" class="img-fluid" alt="Responsive image"> </div> 
       <div class="col-6"><div class="row justify-content-end px-2"><i class="far fa-times-circle x-out" @click="returnKeeps"></i></div><div class="row justify-content-center">
       <div class="m-2"> <i class="far fa-eye"></i> <span class="p-1">{{activeKeep.views}} </span></div><div class="m-2"><i class="fab fa-fort-awesome"></i><span class="p-1">{{activeKeep.keeps}}</span></div>
       </div>
       <div class="row justify-content-center"><h1>{{activeKeep.name}}</h1></div>
       <div class="row justify-content-center"><p>{{activeKeep.description}}</p></div>
       <div class="row"><select class="custom-select">
  <option selected>Open this select menu</option>
  <option value="1">One</option>
  <option value="2">Two</option>
  <option value="3">Three</option>
</select></div>
       </div>
      </div>
      </transition>
      <!-- <active-keep-component></active-keep-component> -->
    </div>
  </div>
</template>

<script>
import allKeepsComponent from "../components/AllKeepsComponent";
// import activeKeepComponent from "../components/ActiveKeepComponent"

export default {
  name: "home",
  components: {
    allKeepsComponent,
    // activeKeepComponent
  },
  mounted() {
    this.$store.dispatch("getAllKeeps");    
  },
  computed: {
    keeps() {
      return this.$store.state.allKeeps;
    }, 
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    modalToggle(){
      return this.$store.state.modalToggle
    },

    userVaults(){
     return this.$store.state.userVaults
    }
    
  },
  methods: {
    returnKeeps(){
      this.$store.commit("returnAllKeeps")
    }
  }
};
</script>
<style>

.modal-overlay {
  position: absolute;
  top: 15vh;
  left: 5vw;
  right: 5vw;  
  z-index: 98;
  background-color: silver;
}

.slide-fade-enter-active {
  transition: all 0.75s ease;
}

.slide-fade-leave-active {
  transition: all 1s ease;
}
.slide-fade-enter {
  transform: translateX(-500px);
  opacity: 0;
}
.slide-fade-leave-to {
  transform: translateY(1000px);
  opacity: 0;
}

.active-keep-button {
  cursor: pointer;}
  .active-keep-button:hover{
    box-shadow: 3px 3px black;
  }

.x-out{
  cursor: pointer;
}
  .x-out:hover{
    color: maroon;
    cursor: pointer;
    font-size: 1.1rem;
  }

</style>
