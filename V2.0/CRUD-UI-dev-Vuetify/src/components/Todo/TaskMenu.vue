<template>
  <div>
    <v-menu bottom left>
      <template v-slot:activator="{ on, attrs }">
        <v-btn color="primary" icon v-bind="attrs" v-on="on">
          <v-icon>mdi-dots-vertical</v-icon>
        </v-btn>
      </template>

      <v-list>
        <v-list-item
          v-for="(item, index) in items"
          :key="index"
          @click="handleClick(index)"
        >
          <v-list-item-icon>
            <v-icon v-text="item.icon"></v-icon>
          </v-list-item-icon>
          <v-list-item-title>{{ item.title }}</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-menu>

    <!-- <dialog-edit
      v-if="dialogs.edit"
      @close="dialogs.edit = false"
      :task="task"
    /> -->
    <add-document
      v-if="dialogs.edit"
      @close="dialogs.edit = false"
      :ressource="task"
    />
    <dialog-delete
      v-if="dialogs.delete"
      @close="dialogs.delete = false"
      :task="task"
    />
  </div>
</template>

<script>
export default {
  props: ["task"],
  data: () => ({
    dialogs: {
      edit: false,
      delete: false,
    },
    items: [
      {
        title: "Modifier",
        icon: "mdi-pencil",
        click() {
          this.dialogs.edit = true;
        },
      },
      {
        title: "Associer",
        icon: "mdi-google-maps",
        click() {
          console.log("due date");
        },
      },
      {
        title: "Supprimer",
        icon: "mdi-delete",
        click() {
          this.dialogs.delete = true;
        },
      },
    ],
  }),
  methods: {
    handleClick(index) {
      this.items[index].click.call(this);
    },
  },
  components: {
    // 'dialog-edit': require('@/components/Todo/Dialogs/DialogEdit.vue').default,
    "dialog-delete": require("@/components/Todo/Dialogs/DialogDelete.vue")
      .default,
    "add-document": require("@/components/Todo/Dialogs/AddDocument.vue")
      .default,
  },
};
</script>

<style>
</style>