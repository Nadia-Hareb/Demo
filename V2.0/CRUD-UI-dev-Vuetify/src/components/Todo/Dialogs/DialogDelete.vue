<template>
  <v-dialog
    :value="true"
    persistent
    max-width="290"
  >
    <v-card>
      <v-card-title  class="text-h7">
        Supprimer 
      </v-card-title>
      <v-card-text>Êtes-vous sûr de vouloir supprimer le réglement Numéro: {{task.number}} ?</v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn
          @click="$emit('close')"
          text
        >
          Non
        </v-btn>
        <v-btn
          @click="deletetask(task.id)"
        
          color="red darken-1"
          text
        >
          Oui
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  props: ['task'],
  methods:{
deletetask(id){
    this.$store.dispatch('deleteRessource', id);
    this.$store.dispatch("getRessources");   
    this.$emit('close');
    }
  }
}
</script>

<style>

</style>