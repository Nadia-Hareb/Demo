<template>
  <div>
    <v-list-item>
      <template v-slot:default>
        <v-list-item-content>
          <v-list-item-title v-text="task.name"></v-list-item-title>         
        </v-list-item-content>
         <v-list-item-content>
          <v-list-item-title v-text="task.number"></v-list-item-title>         
        </v-list-item-content>
        <v-list-item-action>
          <task-menu :task="task" />
        </v-list-item-action>
      </template>
    </v-list-item>
    <v-divider></v-divider>
  </div>
</template>

<script>
export default {
  props: ["task"],
  components: {
    "task-menu": require("@/components/Todo/TaskMenu.vue").default,
  },
};
</script>