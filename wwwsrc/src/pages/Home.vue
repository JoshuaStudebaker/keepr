<template>
  <div class="home">
    <h1>Welcome</h1>
    <div class="row">
      <all-keeps-component v-for="iKeep in keeps" :key="iKeep.id" :keepProp="iKeep" />
    </div>
  </div>
</template>

<script>
import allKeepsComponent from "../components/AllKeepsComponent";

export default {
  name: "home",
  components: {
    allKeepsComponent,
  },
  mounted() {
    this.$store.dispatch("getAllKeeps");
  },
  computed: {
    keeps() {
      return this.$store.state.allKeeps;
    },
  },
};
</script>
