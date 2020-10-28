<template>
  <option :value="selectionProp.id" ><span v-if="selectionProp.isPrivate == true" class="private-color"> {{selectionProp.name}} - Private</span><span v-if="selectionProp.isPrivate == false" > {{selectionProp.name}}</span></option>
  
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
.private-color{
  background-color: rosybrown;
}


</style>
