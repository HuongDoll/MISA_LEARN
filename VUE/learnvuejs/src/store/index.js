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
            console.log(state.customers)
        },
        addCustomer(state, customer) {
            state.customers = state.customers.add(customer);
        }
    },
    actions: {
        getCustomers(context) {
            console.log("actions")
            axios.get('https://localhost:44384/api/customer')
                .then(response => {
                    console.log(response)
                    context.commit("setCustomers", response.data.data)
                })

        },
        deleteCustomer(context, customerId) {

            alert(customerId)
            axios.delete('https://localhost:44384/api/customer/' + customerId)
                .then(response => {
                    console.log(response)
                    alert("delete success!")
                    context.commit("removeCustomer", customerId)
                })
                .catch(error => {
                    console.log(error);
                    alert("delete error!")
                })
        },
        insertCustomer(context, customer){
            alert("insert");
            axios({
                method: "post",
                url: "https://localhost:44384/api/customer",
                data: customer,
            }).then(response => {
                alert(" success!")
                console.log(response);
                this.closedialog();
                context.commit("addCustomer", response.data.data)
            })
            .catch(error => {
                console.log(error);
            });
        }
    }
})

export default store