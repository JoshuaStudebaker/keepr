<template>
  <div>
    <form v-if="keepForm" @submit.prevent="createKeep" class="shadow p-3">
          <div class="form-group">
            <input
              type="text"
              class="form-control"
              id="keepName"
              v-model="newKeep.name"
              placeholder="Enter the Name of your New Keep..."
              required
            />
          </div>
          <div class="form-group">
            <textarea
              rows="4"
              class="form-control"
              id="keepDescription"
              v-model="newKeep.description"
              placeholder="Enter its Description..."
              required
            ></textarea>
          </div>
          <div class="form-group">
            <input
              type="text"
              class="form-control"
              id="keepImg"
              v-model="newKeep.img"
              placeholder="Enter its Img Url..."
              required
            />
          </div>
          <button type="submit" class="btn btn-primary">Submit</button>
          <button
            type="button"
            class="btn btn-danger mx-2"
            @click="keepFormCancel"
          >
            Cancel
          </button>
        </form>
  </div>
</template>

<script>
export default {
  name: "keeps-form-component",
  props: [],
  components: {},
  data() {
    return {
      newKeep: {},     
    };
  },
  
  mounted() {

  },

  computed: {
    keepForm(){
     return this.$store.state.keepForm
    }

  },
  methods: {  
createKeep() {
      
      console.log("newKeep", this.newKeep);
      this.$store.dispatch("createKeep", this.newKeep);
      this.$store.commit("keepFormToggle")
      // this.newKeep = { name: "", description: "", img: ""};
      // this.formShow = false;
    },
    keepFormCancel(){
       this.$store.commit("keepFormToggle")
    }
  },
};
</script>

<style>


</style>
