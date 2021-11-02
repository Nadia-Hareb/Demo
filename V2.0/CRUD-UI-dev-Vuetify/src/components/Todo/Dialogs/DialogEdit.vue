<template>
  <v-dialog :value="true" persistent>
    <v-card>
      <v-card-title class="headline"> Modifier Reglement </v-card-title>

      <v-card-text>
        <v-container>
          <v-row>
            <v-col cols="12" sm="6">
              <v-text-field
                v-model="name"
                label="Nom"
                @keyup.enter="saveTask"
              ></v-text-field>
            </v-col>
            <v-col cols="12" sm="6">
              <v-text-field
                v-model="number"
                label="Numéro"
                @keyup.enter="saveTask"
              ></v-text-field>
            </v-col>
            <v-col cols="12" sm="6">
              <v-text-field
                v-model="effectiveDate"
                label="Entrée en vigueur"
                @keyup.enter="saveTask"
              ></v-text-field>
            </v-col>
            <v-col cols="12" sm="6">
              <v-text-field
                v-model="doctype"
                label="Type document"
                @keyup.enter="saveTask"
              ></v-text-field>
            </v-col>
          </v-row>
        </v-container>
      </v-card-text>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn @click="$emit('close')" text> Cancel </v-btn>
        <v-btn
          @click="saveTask"
          :disabled="taskTitleInvalid"
          color="red darken-1"
          text
        >
          Save
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  props: ["task"],
  data() {
    return {
      id: "",
      name: "",
      number: "",
      effectiveDate: null,
      doctype: null,
    };
  },
  computed: {
    taskTitleInvalid() {
      return !this.name || this.name === this.task.name;
    },
  },
  methods: {
    saveTask() {
      if (!this.taskTitleInvalid) {
        let payload = {
          id: this.task.id,
          name: this.name,
          number: this.number,
          effectiveDate: this.effectiveDate,
          doctype: this.doctype,
        };
        this.$store.dispatch("updateRessourceTitle", payload);
        this.$emit("close");
      }
    },
  },
  mounted() {
    this.name = this.task.name;
    this.number = this.task.number;
    this.effectiveDate = this.task.effectiveDate;
    this.doctype = this.task.doctype;
  },
};
</script>

<style>
</style>