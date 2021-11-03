<template>
  <div>
    <v-data-table
      :headers="headers"
      :items="$store.state.tasks"
      item-key="name"
      class="elevation-1 pa-6"
    >
      <template v-slot:top>
        <!-- v-container, v-col and v-row are just for decoration purposes. -->
        <v-container fluid class="pa-0">
          <v-row>
            <v-col cols="12" sm="6" md="4">
              <v-text-field
                label="Nom"
                auto-grow
                outlined
                rows="1"
                row-height="15"
                clearable
                v-model="nameFilterValue"
              ></v-text-field>
            </v-col>
            <v-col cols="12" sm="6" md="4">
              <v-text-field
                label="Numéro"
                auto-grow
                outlined
                rows="1"
                clearable
                row-height="15"
                v-model="numeroFilterValue"
              ></v-text-field>
            </v-col>

            <v-col cols="12" sm="6" md="4">
              <v-select
                auto-grow
                outlined
                :items="docTypeList"
                v-model="docTypeFilterValue"
                label="Type document"
              ></v-select>
            </v-col>
          </v-row>
        </v-container>
      </template>

      <template v-slot:item.actions="{ item }">
        <v-icon small class="mr-2" @click="editItem(item)"> mdi-pencil </v-icon>
        <v-icon small @click="deleteItem(item)"> mdi-delete </v-icon>
      </template>
      <add-document
        v-if="dialog"
        @close="dialog = false"
        :ressource="editedItem"
      />
      <dialog-delete
        v-if="dialogDelete"
        @close="dialogDelete = false"
        :task="editedItem"
      />
    </v-data-table>

    <add-document
      v-if="dialog"
      @close="dialog = false"
      :ressource="editedItem"
    />
    <dialog-delete
      v-if="dialogDelete"
      @close="dialogDelete = false"
      :task="editedItem"
    />
  </div>
</template>

<script>
export default {
  data() {
    return {
      dialog: false,
      dialogDelete: false,
      editedIndex: -1,
      editedItem: null,

      // We need some values for our select.
      docTypeList: [
        { text: "", value: null },
        { text: "Affaire legislatif", value: "AF_LEGIS" },
        { text: "Règlement codifié", value: "REG_COD" },
        { text: "Règlement d'urbanisme", value: "REG_URB" },
      ],

      // Filter models.
      nameFilterValue: "",
      numeroFilterValue: "",
      docTypeFilterValue: null,

      // Table data.
    };
  },
  watch: {
    dialog(val) {
      val || this.close();
    },
    dialogDelete(val) {
      val || this.closeDelete();
    },
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "New Item" : "Edit Item";
    },
    headers() {
      return [
        {
          text: "Nom",
          align: "left",
          sortable: false,
          value: "name",
          filter: this.nameFilter,
        },
        {
          text: "Numero",
          value: "number",
          filter: this.numeroFilter,
        },
        {
          text: "Type Document",
          value: "doctype",
          sortable: false,
          filter: this.docTypeFilter,
        },
        { text: "Entrée en vigueur", value: "effectiveDate" },
        { text: "Actions", value: "actions", sortable: false },
      ];
    },
  },
  methods: {
    editItem(item) {
      this.editedItem = item;
      this.dialog = true;
    },

    deleteItem(item) {
      this.editedItem = item;
      this.dialogDelete = true;
      
    },

    nameFilter(value) {
      // If this filter has no value we just skip the entire filter.
      if (!this.nameFilterValue) {
        return true;
      }

      // Check if the current loop value (The dessert name)
      // partially contains the searched word.
      return value.toLowerCase().includes(this.nameFilterValue.toLowerCase());
    },
    numeroFilter(value) {
      // If this filter has no value we just skip the entire filter.
      if (!this.numeroFilterValue) {
        return true;
      }

      // Check if the current loop value (The dessert name)
      // partially contains the searched word.
      return value.toLowerCase().includes(this.numeroFilterValue.toLowerCase());
    },

    /**
     * Filter for calories column.
     * @param value Value to be tested.
     * @returns {boolean}
     */
    docTypeFilter(value) {
      // If this filter has no value we just skip the entire filter.
      if (!this.docTypeFilterValue) {
        return true;
      }

      // Check if the current loop value (The calories value)
      // equals to the selected value at the <v-select>.
      return value === this.docTypeFilterValue;
    },

    deleteItemConfirm() {
      this.closeDelete();
    },

    close() {
      this.dialog = false;
      this.editedItem = null;
    },

    closeDelete() {
      this.dialogDelete = false;
      this.editedItem = null;
    },

    save() {
      this.close();
    },
  },
  components: {
    // 'dialog-edit': require('@/components/Todo/Dialogs/DialogEdit.vue').default,
    "dialog-delete": require("@/components/Todo/Dialogs/DialogDelete.vue")
      .default,
    "add-document": require("@/components/Todo/Dialogs/AddDocument.vue")
      .default,
  },
  mounted() {
    this.$store.dispatch("getRessources");   
  },
};
</script>
<style>
</style>