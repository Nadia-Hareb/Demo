<template>
  <form class="elevation-1 pa-6">
    <v-text-field
      v-model="name"
      :error-messages="nameErrors"
      :counter="50"
      label="Nom"
      required
      @input="$v.name.$touch()"
      @blur="$v.name.$touch()"
    ></v-text-field>
    <v-text-field
      v-model="number"
      :error-messages="numberErrors"
      label="Numéro"
      required
      :counter="10"
      @input="$v.number.$touch()"
      @blur="$v.number.$touch()"
    ></v-text-field>
    <div>
      <v-menu
        ref="menu"
        v-model="menu"
        :close-on-content-click="false"
        transition="scale-transition"
        offset-y
        min-width="auto"
      >
        <template v-slot:activator="{ on, attrs }">
          <v-text-field
            v-model="effectiveDate"
            label="Entrée en vigueur"
            prepend-icon="mdi-calendar"
            readonly
            v-bind="attrs"
            v-on="on"
          ></v-text-field>
        </template>
        <v-date-picker
          v-model="effectiveDate"
          :active-picker.sync="activePicker"
          :max="
            new Date(Date.now() - new Date().getTimezoneOffset() * 60000)
              .toISOString()
              .substr(0, 10)
          "
          min="1950-01-01"
          @change="save"
        ></v-date-picker>
      </v-menu>
    </div>
    <v-select
      v-model="doctype"
      :items="docTypeList"
      :error-messages="selectErrors"
      label="Type document"
      required
      @change="$v.doctype.$touch()"
      @blur="$v.doctype.$touch()"
    ></v-select>
    <v-btn class="mr-4" @click="submit"> Soumettre </v-btn>
    <v-btn @click="clear"> Effacer </v-btn>
  </form>
</template>

<script>
import { validationMixin } from "vuelidate";
import { required, maxLength, email } from "vuelidate/lib/validators";

export default {
  mixins: [validationMixin],

  validations: {
    name: { required, maxLength: maxLength(50) },
    number: { required, maxLength: maxLength(10) },
    doctype: { required },
  },
  props: ["ressource"],
  data: () => ({
    id:"",
    name: "",
    activePicker: null,
    date: null,
    effectiveDate: null,
    menu: false,
    number: "",
    doctype: null,
    docTypeList: [
      { text: "Affaire legislatif", value: "AF_LEGIS" },
      { text: "Règlement codifié", value: "REG_COD" },
      { text: "Règlement d'urbanisme", value: "REG_URB" },
    ],
  }),
  watch: {
    menu(val) {
      val && setTimeout(() => (this.activePicker = "YEAR"));
    },
  },

  computed: {
    selectErrors() {
      const errors = [];
      if (!this.$v.doctype.$dirty) return errors;
      !this.$v.doctype.required && errors.push("Type de document obligatoire");
      return errors;
    },
    nameErrors() {
      const errors = [];
      if (!this.$v.name.$dirty) return errors;
      !this.$v.name.maxLength &&
        errors.push("Name must be at most 30 characters long");
      !this.$v.name.required && errors.push("Nom est obligatoire.");
      return errors;
    },
    numberErrors() {
      const errors = [];
      if (!this.$v.number.$dirty) return errors;
      !this.$v.number.maxLength &&
        errors.push("Number must be at most 10 characters long");
      !this.$v.number.required && errors.push("Numéro est obligatoire.");
      return errors;
    },
  },

  methods: {
    save(date) {
      this.$refs.menu.save(date);
    },
    submit() {
      this.$v.$touch();

      if (!this.$v.$invalid) {
        this.$store.dispatch("addRessource", {
          name: this.name,
          number: this.number,
          doctype: this.doctype,
          effectiveDate: this.effectiveDate,
        });
        this.$v.$reset();
        this.name = "";
        this.number = "";
        this.doctype = null;
        this.effectiveDate = null;
      }
    },
    clear() {
      this.$v.$reset();
      this.name = "";
      this.number = "";
      this.doctype = null;
      this.effectiveDate = null;
    },
  },

  mounted() {
    if (this.ressource) {
      this.id = this.ressource.id;
      this.name = this.ressource.name;
      this.number = this.ressource.number;
      this.effectiveDate = this.ressource.effectiveDate;
      this.doctype = this.ressource.doctype;
    }
  },
};
</script>

<style>
</style>