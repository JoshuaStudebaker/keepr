<template>
  <div>
     
     <profile-roof-component v-if="!modalToggle && !keepForm && !vaultForm"/>
     <keeps-form-component v-if="keepForm"/>
     <vaults-form-component v-if="vaultForm"/>
     <div class="col-12 mb-0" v-if="!vaultForm && !modalToggle && !keepForm"><h3  class="mb-0">Vaults<span class="mx-2">   <i class="fas fa-plus cursor" v-if="profile.id == this.$route.params.profileId"  @click="vaultFormToggle"></i></span></h3></div>
     <div class="card-columns px-md-4 px-3 py-1 justify-content-center" v-if="!modalToggle && !keepForm && !vaultForm">
     <profile-vaults-component v-for="iVault in creatorVaults" :key="iVault.id" :vaultProp="iVault"/>
     </div>
      <div class="col-12 mb-0"><h3 v-if="!keepForm && !modalToggle &&!vaultForm" class="mb-0">Keeps<span class="mx-2">   <i class="fas fa-plus cursor" v-if="profile.id == this.$route.params.profileId"  @click="keepFormToggle"></i></span></h3></div>
     <div class="card-columns p-md-4 p-3 justify-content-center" v-if="!modalToggle" >
     <!-- <profile-keeps-component v-for="iKeep in creatorKeeps" :key="iKeep.id" :keepProp="iKeep"/> -->
     <all-keeps-component v-for="iKeep in creatorKeeps" :key="iKeep.id" :keepProp="iKeep"/>
     </div>
     <div class="row">
      <transition name="slide-fade">
      <div v-if="modalToggle" class="modal-overlay d-flex rounded-card-no-pointer">
       <div class="col-6 p-2 rounded-card-no-pointer d-flex align-items-center"><img :src="activeKeep.img" class="img-fluid rounded-card-no-pointer img-better" alt="Responsive image"> </div> 
       <div class="col-6 greyish-font"><div class="row justify-content-end px-2"><i class="far fa-times-circle x-out " @click="returnKeeps"></i></div><div class="row d-flex justify-content-center">
       <div class="m-2"> <i class="far fa-eye"></i> <span class="p-1">{{activeKeep.views}} </span></div><div class="m-2"><i class="fab fa-fort-awesome"></i><span class="p-1">{{activeKeep.keeps}}</span></div>
       </div>
       <div class="row d-flex justify-content-center"><h1>{{activeKeep.name}}</h1></div>
       <div class="row d-flex justify-content-center desc-class"><p>{{activeKeep.description}}</p></div>
       <div class="row hr"></div>
       <div class="row d-flex justify-content-center">
         <form @submit.prevent="addToVault" class="col-4">
         <select class="custom-select" v-model="vaultKeep.vaultId">
  <option selected>Add to Vault</option>
  <option v-for="uv in userVaults" :key="uv.id" :value="uv.id"><span class="private-vault" v-if="uv.isPrivate">
    {{uv.name}} - Private</span><span v-if="!uv.isPrivate">
    {{uv.name}}</span></option>
</select>
  <button type="submit" class="btn btn-primary">Submit</button>
         </form>
 <i class="fas fa-trash col-4" v-if="profile.id == activeKeep.creatorId" @click="deleteKeep"></i> <div @click.stop="routerPush" class="col-4"> <img :src="creator.picture" class="small-pic">{{creator.name}}</div>
</div>
       </div>
      </div>
      </transition>
      <!-- <active-keep-component/> -->
    </div>
  </div>
</template>

<script>
import profileRoofComponent from "../components/ProfileRoofComponent"
  import profileKeepsComponent from "../components/ProfileKeepsComponent";
  import profileVaultsComponent from "../components/ProfileVaultsComponent";
  import keepsFormComponent from "../components/KeepsFormComponent";
  import vaultsFormComponent from "../components/VaultsFormComponent";
  import allKeepsComponent from "../components/AllKeepsComponent"

export default {
  name: "profile-page",
  components: {
    profileRoofComponent,
    profileKeepsComponent,
    profileVaultsComponent,
    keepsFormComponent,
    vaultsFormComponent,
    allKeepsComponent
  },
  data() {
    return {
     vaultKeep: {},     
    };
  },
  mounted() {
    this.$store.dispatch("getProfile");
    this.$store.dispatch("getCreator", this.$route.params.profileId);
    
  },
  computed: {
    creatorKeeps() {
      return this.$store.state.creatorKeeps;
    }, 

    creatorVaults() {
      return this.$store.state.creatorVaults;
    }, 
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    modalToggle(){
      return this.$store.state.modalToggle
    },
    keepForm(){
      return this.$store.state.keepForm
    },
    vaultForm(){
      return this.$store.state.vaultForm
    },
    modalToggle(){
      return this.$store.state.modalToggle
    },

    userVaults(){
     return this.$store.state.userVaults
    },

    creator(){
      return this.$store.state.creatorInfo
    },

    profile(){
      return this.$store.state.profile
    }
  },
  methods: {   
    returnAllKeeps() {           
      this.$store.commit("returnAllKeeps");      
    },

    keepFormToggle(){
      this.$store.commit("keepFormToggle")
  },
  vaultFormToggle(){
      this.$store.commit("vaultFormToggle")
      },
      returnKeeps(){
      this.$store.commit("returnAllKeeps")
    },

    addToVault(){
      console.log("add to vault", this.vaultKeep.vaultId)
      this.vaultKeep.keepId = this.activeKeep.id
      console.log("vaultkeep", this.vaultKeep)
      this.$store.dispatch("addKeepToVault", this.vaultKeep)
    },
    deleteKeep(){
      this.$store.dispatch("deleteKeepFromActive", this.activeKeep.id)
      
    },
  },
  
};
</script>
<style>


.active-keep-button {
  cursor: pointer;}
  .active-keep-button:hover{
    box-shadow: 3px 3px black;
  }

  .modal-overlay {
  position: absolute;
  top: 15vh;
  left: 5vw;
  right: 5vw;  
  z-index: 98;
  background-color: silver;
}
@media screen and (min-width: 825px) {
.img-better{
  max-height: 75vh
}


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
  color: hsla(218, 19%, 39%, 1);
  /* background-color: hsla(195, 53%, 79%, 0.5); */
  /* border-radius: 50%; */
  font-size: 1.2rem

}
  .x-out:hover{
    color: maroon;
    cursor: pointer;
    font-size: 1.4rem;
  }
@media screen and (max-width: 700px) {
  .card-columns {  
    column-count: 2;
  }
}
@media screen and (min-width: 701px) {
  .card-columns {  
    column-count: 4;
  }
}
.greyish-font{
  color: hsla(218, 39%, 29%, 1);
}
  .fa-trash{
  font-size: 1.2rem;
  color: hsla(218, 19%, 39%, 1);
  cursor: pointer;
  
}
.fa-trash:hover{
font-size: 1.4rem;
color: maroon;
cursor: pointer;
}
.hr {
  margin-top: 1rem;
  margin-bottom: 1rem;
  border: 0;
  border-top: 1px solid rgba(0, 0, 0, 0.1);
  margin-right: 2rem;
  margin-left: 2rem
}

.small-pic{
  width: 1.4rem;
  height: 1.4rem
}

.cursor{
  cursor: pointer;
}

</style>
