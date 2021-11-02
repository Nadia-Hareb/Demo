<template>
  <div class="home">
    <!-- <field-add-task /> -->
    <div class="pa-3">
      <search></search>
    </div>
    <list-tasks v-if="$store.state.tasks.length" />

    <no-tasks v-else />
  </div>
</template>

<script>
export default {
  name: "Home",
  components: {
    "field-add-task": require("@/components/Todo/FieldAddTask.vue").default,
    "list-tasks": require("@/components/Todo/ListTasks.vue").default,
    "no-tasks": require("@/components/Todo/NoTasks.vue").default,
    search: require("@/components/Tools/Search.vue").default,
  },
  mounted() {
    this.$store.dispatch("getRessources");
  },
};
</script>