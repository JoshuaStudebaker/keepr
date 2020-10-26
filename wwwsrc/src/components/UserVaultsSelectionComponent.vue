<template>
  <option :value="selectionProp.id">{{selectionProp.name}}</option>
</template>

<script>
export default {
  name: "user-vaults-selection-component",
  props: ["selectionProp"],
  components: {},
  
  mounted() {},

  computed: {},
  methods: {  
  
  },
};
</script>

<style>



</style>
