import Vue from 'vue'
import VueRouter from 'vue-router'
import Todo from '../views/Todo.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Todo',
    component: Todo
  },
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  },
  {       
    path: '/document/add',
    name: 'Add',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AddDocument.vue')
  },
   {
    path: '/document/:id',
    name: 'Display',
    component: () => import('../views/DisplayDocument.vue')
  },
  {
    path: '/recherche',
    name: 'Recherche',
    component: () => import('../views/Recherche.vue')
  },
]

const router = new VueRouter({
  routes
})

export default router
