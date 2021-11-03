<template>
  <v-text-field
    v-model="$store.state.searchGo"
    @keyup.enter="searchTask"
    @focus="searchClosed = false"
    @blur="searchClosed = true"
    class="expanding-search mt-1"
    :class="{ 'closed' : searchClosed && !$store.state.searchGo }"
    placeholder="Numéro reglement"
    prepend-inner-icon="mdi-magnify"
    filled
    dense
    clearable
  ></v-text-field>  
</template>

<script>
export default {
  data() {
    return {
      searchClosed: true,     
    }
  },
   methods: {
    searchTask() {
      if (this.$store.state.searchGo!==null) {
        this.$store.dispatch("searchRessourceGo", this.$store.state.searchGo);
       // this.newTaskTitleSearch = "";       
      }
    },
  },
}
</script>

<style lang="sass">
  .expanding-search
    transition: max-width 0.3s
    .v-input__slot
      cursor: pointer !important
      &:before, &:after
        border-color: transparent !important
    &.closed
      max-width: 45px
      .v-input__slot
        background: transparent !important
</style>