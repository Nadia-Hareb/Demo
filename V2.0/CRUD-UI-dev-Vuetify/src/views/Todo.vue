<template>
  <div class="home">
    <!-- <field-add-task /> -->
    <div class="pa-3">
      <search-go></search-go>
    </div>
    <list-tasks-go v-if="$store.state.tasksgo.length" />

    <no-tasks v-else />
  </div>
</template>

<script>
export default {
  name: "Home",
  components: {
    "field-add-task": require("@/components/Todo/FieldAddTask.vue").default,
    // "list-tasks": require("@/components/Todo/ListTasks.vue").default,
    "list-tasks-go": require("@/components/Todo/ListTasksGo.vue").default,
    "no-tasks": require("@/components/Todo/NoTasks.vue").default,
    // search: require("@/components/Tools/Search.vue").default,
    "search-go": require("@/components/Tools/SearchGo.vue").default,
  },
 
};
</script>