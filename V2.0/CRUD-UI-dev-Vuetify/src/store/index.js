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
    tasks: [],
    snackbar: {
      show: false,
      text: ''
    }
  },
  mutations: {
    setSearch(state, value) {
      state.search = value
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
          })
        });
       
      commit('showSnackbar', 'Règlement a jour!')
    },


    async getRessources({ commit }) {
     await axios.get(variables.API_URL)
        .then(response => {
          commit('SET_RESSOURCES', response.data);
        })
    },
    async deleteRessource({ commit }, id) {
      await axios.delete(variables.API_URL + "/" + id).then((response) => {
        axios.get(variables.API_URL)
          .then(response => {
            commit('SET_RESSOURCES', response.data);
          })
      });
      commit('showSnackbar', 'Règlement supprimé')
    },
    async addRessource({ commit }, element) {
      console.log(element);
      await axios.post(variables.API_URL, element).then((response) => {
        axios.get(variables.API_URL)
          .then(response => {
            commit('SET_RESSOURCES', response.data);
          })
      });
      commit('showSnackbar', 'Règlement ajouté !')
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
    }

  }
})
