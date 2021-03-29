import Vuex from 'vuex'
import Vue from 'vue'
import axios from 'axios'
Vue.use(Vuex)

const store = new Vuex.Store({
    state: {
        customers: [],
    },
    getters: {
        getCustomers(state) {
            console.log("getter " + state.customers)
            return state.customers
        }
    },
    mutations: {
        setCustomers(state, payload) {
            state.customers = payload
        },
        removeCustomer(state, customerId) {
            state.customers = state.customers.filter(p => p.customerId != customerId);
        }
    },
    actions: {
        getCustomers(context) {
            console.log("actions")
            axios.get('https://localhost:44312/api/person')
                .then(response => {
                    console.log(1)
                    context.commit("setCustomers", response.data)
                })

        },
        deleteCustomer(context, customerId) {

            alert(customerId)
            axios.delete('https://localhost:44312/api/person/' + customerId)
                .then(response => {
                    console.log(response)
                    alert("delete success!")
                    context.commit("removeCustomer", customerId)
                })
                .catch(error => {
                    console.log(error);
                    alert("delete error!")
                })
        }
    }
})

export default store