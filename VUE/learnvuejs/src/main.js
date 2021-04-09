import Vue from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import App from './App.vue'
import VueRouter from 'vue-router'
import CustomerList from './components/page/customer/CustomerList.vue'
import EmployeeList from './components/page/employee/EmployeeList.vue'
import '@fortawesome/fontawesome-free/css/all.css'
import '@fortawesome/fontawesome-free/js/all.js'
import store from './store/index'


Vue.config.productionTip = false
Vue.use(VueRouter)
Vue.use(VueAxios, axios)


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
    store: store,
}).$mount('#app')