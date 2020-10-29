<template>
  <nav class="navbar navbar-expand-lg navbar-light see-through-white shadow">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center see-through-green rounded-card p-0">
        <h1 class=" p-2 m-0">Keepr</h1>
      </div>
    </router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
        <!-- Consider changing this to a profile picture -->
        <ul class="navbar-nav mr-auto">
        <li class="nav-item" :class="{ active: $route.name == 'Home' }">
          <router-link :to="{ name: 'Home' }" class="nav-link text-light"
            ><i class="fas fa-home sea-green-font p-2"></i></router-link
          >
        </li>
        <li
          class="nav-item"
          v-if="$auth.isAuthenticated"
          :class="{ active: $route.name == 'Profile' }"
        >
          <router-link class="nav-link text-light" :to="{ name: 'Profile',  params: {profileId: profile.id}}"
            ><i class="far fa-user sea-green-font p-2"></i></router-link
          >
        </li>
       </ul> 
      <span class="navbar-text">
        <button
          class="btn btn-success"
          @click="login"
          v-if="!$auth.isAuthenticated"
        >
          Login
        </button>
        <button class="btn btn-danger" @click="logout" v-else>Logout</button>
      </span>
    </div>
  </nav>
</template>

<script>
import { getUserData } from "@bcwdev/auth0-vue";
import { setBearer, resetBearer } from "../services/AxiosService";
export default {
  name: "Navbar",
  methods: {
    async login() {
      await this.$auth.loginWithPopup();
      if (this.$auth.isAuthenticated) {
        setBearer(this.$auth.bearer);
        this.$store.dispatch("getProfile");
      }
    },
    async logout() {
      resetBearer();
      await this.$auth.logout({ returnTo: window.location.origin });
    },
  },
   computed: {
    

    profile(){
      return this.$store.state.profile
    }
   
    
  },

};
</script>

<style>
/* .see-through-green{
  
  color: hsl(148.28, 93.55%, 71.76%);
  background-color: hsla(218, 19%, 98%, 0.4);
  border-radius: 45%;
  border: 1px solid green;
} */

.see-through-green {
  background-color: hsla(218, 19%, 98%, 0.4);
  color: hsl(148.28, 93.55%, 71.76%);
  border-radius: 45%;  
  box-shadow: 0px 0px 6px 1px hsl(148.28, 93.55%, 71.76%);
  text-shadow: 1px 1px 0px hsla(195, 53%, 59%, 1);;
}
.fa-user-circle:hover{
font-size: 1.4rem;
background-color: hsla(148.28, 93.55%, 71.76%, 0.4);
  color: hsla(218, 19%, 98%);
}

.sea-green-font{
  color:  hsl(148.28, 93.55%, 71.76%);
  font-size: 1.6rem; box-shadow: 0px 0px 6px 1px hsl(148.28, 93.55%, 71.76%);
  text-shadow: 1px 1px 1px hsla(195, 53%, 59%, 1);;
  border-radius: 50%
}
</style>
