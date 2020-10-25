<template>
  <div>
    <form v-if="vaultForm" @submit.prevent="createVault" class="shadow p-3">
          <div class="form-group">
            <input
              type="text"
              class="form-control"
              id="vaultName"
              v-model="newVault.name"
              placeholder="Enter the Name of your New Vault..."
              required
            />
          </div>
          <div class="form-group">
            <textarea
              rows="4"
              class="form-control"
              id="vaultDescription"
              v-model="newVault.description"
              placeholder="Enter its Description..."
              required
            ></textarea>
          </div>
          <div class="form-group">
            <div class="custom-control custom-radio">
  <input type="radio" id="customRadio1" name="customRadio" class="custom-control-input" v-model="newVault.isPrivate" value=true>
  <label class="custom-control-label" for="customRadio1">Set to Private</label>
</div>
<div class="custom-control custom-radio">
  <input type="radio" id="customRadio2" name="customRadio" class="custom-control-input" v-model="newVault.isPrivate" value=false>
  <label class="custom-control-label" for="customRadio2">Set to Public</label>
</div>
          </div>
          <button type="submit" class="btn btn-primary">Submit</button>
          <button
            type="button"
            class="btn btn-danger mx-2"
            @click="vaultFormCancel"
          >
            Cancel
          </button>
        </form>
  </div>
</template>

<script>
export default {
  name: "vaults-form-component",
  props: [],
  components: {},
  data() {
    return {
      newVault: {},     
    };
  },
  
  mounted() {

  },

  computed: {
    vaultForm(){
     return this.$store.state.vaultForm
    }

  },
  methods: {  
createVault() {
      
      console.log("newVault", this.newVault);
      this.$store.dispatch("createVault", this.newVault);
      this.$store.commit("vaultFormToggle")
      // this.newVault = { name: "", description: "", img: ""};
      // this.formShow = false;
    },
    vaultFormCancel(){
       this.$store.commit("vaultFormToggle")
    }
  },
};
</script>

<style>


</style>
