import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'
import CustomerList from './components/page/customer/CustomerList.vue'
import EmployeeList from './components/page/employee/EmployeeList.vue'


Vue.config.productionTip = false
Vue.use(VueRouter)

const routes = [
  { path: '/foo', component: CustomerList },
  { path: '/bar', component: EmployeeList }
]

const router = new VueRouter({
  routes // short for `routes: routes`
})

new Vue({
  render: h => h(App),
  router,
}).$mount('#app')
