import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)
const variables = {
  API_URL: "https://localhost:44313/api/Ressource",
};
export default new Vuex.Store({
  state: {
    search: null,
    searchGo:null,
    tasks: [],
    tasksgo: [],
    snackbar: {
    show: false,
    text: ''
    }
  },
  mutations: {
    setSearch(state, value) {
      state.search = value
    },
    setSearchGo(state, value) {
      state.searchGo = value
    },
    addTask(state, newTaskTitle) {
      let newTask = {
        id: Date.now(),
        title: newTaskTitle,
        done: false
      }
      state.tasks.push(newTask)
    },
    doneTask(state, id) {
      let task = state.tasks.filter(task => task.id === id)[0]
      task.done = !task.done
    },
    deleteTask(state, id) {
      state.tasks = state.tasks.filter(task => task.id !== id)
    },
    updateTaskTitle(state, payload) {
      let task = state.tasks.filter(task => task.id === payload.id)[0]
      task.title = payload.title
    },
    showSnackbar(state, text) {
      let timeout = 0
      if (state.snackbar.show) {
        state.snackbar.show = false
        timeout = 300
      }
      setTimeout(() => {
        state.snackbar.show = true
        state.snackbar.text = text
      }, timeout)
    },
    hideSnackbar(state) {
      state.snackbar.show = false
    },
    
    SET_RESSOURCES_GO(state, param) {
      state.tasksgo = param
    
    },
    SET_RESSOURCES(state, param) {
      state.tasks = param
    },
  },


  actions: {
    addTask({ commit }, newTaskTitle) {
      commit('addTask', newTaskTitle)
      commit('showSnackbar', 'Règlement ajouté!')
    },
    deleteTask({ commit }, id) {
      commit('deleteTask', id)
      commit('showSnackbar', 'Règlement supprimé!')
    },
    updateTaskTitle({ commit }, payload) {
      commit('updateTaskTitle', payload)
      commit('showSnackbar', 'Règlement a jour!')
    },

    async updateRessourceTitle({ commit }, payload) {
      try {

      axios.patch(variables.API_URL + "/" + payload.id, {

        name: payload.name,
        number:payload.number,
        effectiveDate:payload.effectiveDate,
        doctype:payload.doctype

      })
        .then((response) => {
          axios.get(variables.API_URL)
          .then(response => {
            commit('SET_RESSOURCES', response.data);
            commit('showSnackbar', 'Règlement a jour!')
          })
        });
       
     }
      catch (err) {
        commit('showSnackbar', 'Update error'+' '+err)
        
      }
    },


    async getRessources({ commit }) {
      try {
     await axios.get(variables.API_URL)
        .then(response => {
          commit('SET_RESSOURCES', response.data);
        })
      }
      catch (err) {
        commit('showSnackbar', err)
        
      }
    },
   

    async deleteRessource({ commit }, id) {
      try {
      await axios.delete(variables.API_URL + "/" + id).then((response) => {
        axios.get(variables.API_URL)
          .then(response => {
            commit('SET_RESSOURCES', response.data);
          })
      });
      commit('showSnackbar', 'Règlement supprimé')}
      catch (err) {
        commit('showSnackbar','Delete fail'+ ' '+err)
        
      }
    },
    async addRessource({ commit }, element) {
      try {
      await axios.post(variables.API_URL, element).then((response) => {
        axios.get(variables.API_URL)
          .then(response => {
            commit('SET_RESSOURCES', response.data);
          })
      });
      commit('showSnackbar', 'Règlement ajouté !')}
      catch (err) {
        commit('showSnackbar', 'Add fail'+' '+err)
        
      }
    },

    async searchRessourceGo({ commit }, element) {
      
      try {
      await axios.get(variables.API_URL+ "/" + element).then(response => {       
        commit('SET_RESSOURCES_GO', response.data);
      })}
       catch (err) {
        commit('showSnackbar', err)
        
      }
    },

  },
  getters: {
    tasksFiltered(state) {
      if (!state.search) {
        return state.tasks
      }
      return state.tasks.filter(task =>
        task.number.toLowerCase().includes(state.search.toLowerCase())
      )
    },

    tasksFilteredGo(state) {
      
        return state.tasksgo;
      
    },
     


  }
})
