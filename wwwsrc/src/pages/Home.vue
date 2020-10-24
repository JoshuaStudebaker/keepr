<template>
  <div class="home">
    <h1>Welcome</h1>
    <div class="row">
      <all-keeps-component v-for="iKeep in keeps" :key="iKeep.id" :keepProp="iKeep" />
    </div>
    <div class="row">
      <active-keep-component />
    </div>
  </div>
</template>

<script>
import allKeepsComponent from "../components/AllKeepsComponent";
import activeKeepComponent from "../components/ActiveKeepComponent"

export default {
  name: "home",
  components: {
    allKeepsComponent,
    activeKeepComponent
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
