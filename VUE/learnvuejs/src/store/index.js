import Vuex from 'vuex'
import Vue from 'vue'
import axios from 'axios'
Vue.use(Vuex)

const store = new Vuex.Store({
    state: {
        customers: [],
        customerById: [],
    },
    getters: {
        getCustomers(state) {
            // console.log("getter " + state.customers)
            return state.customers
        },
        getCustomerById(state){
            console.log("getter customerId")
            return state.customerById;
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
            state.customers.unshift(customer);
            console.log(state.customers);
        },
        getCustomerById(state, customerId){
            state.customerById = state.customers.filter(p => p.customerId == customerId);
        }
    },
    actions: {
        getCustomerById(context, customerId){
            context.commit("getCustomerById", customerId)
        },
        getCustomers(context) {
            console.log("actions")
            axios.get('https://localhost:44379/api/Customer')
                .then(response => {
                    console.log(response)
                    context.commit("setCustomers", response.data)
                })

        },
        deleteCustomer(context, customerId) {

            axios.delete('https://localhost:44379/api/customer/' + customerId)
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
            axios({
                method: "post",
                url: "https://localhost:44379/api/customer",
                data: customer,
            }).then(response => {
                alert(" success!")
                console.log(JSON.parse(response.config.data));
                context.commit("addCustomer", JSON.parse(response.config.data))
            })
            .catch(error => {
                console.log(error);
                alert(" errrrrrrrrrr!")
            });
        },
        updateCustomer(context, customer){
            console.log("customer");
            console.log(customer);
            axios({
                method: "put",
                url: 'https://localhost:44379/api/customer/' + customer.customerId,
                data: customer,
            }).then(response => {
                alert(" success!")
                console.log("response.data");
                console.log(JSON.parse(response.config.data));
                context.commit("removeCustomer", customer.customerId);
                context.commit("addCustomer", JSON.parse(response.config.data));
            })
            .catch(error => {
                console.log(error);
                alert(" errrrrrrrrrr!");
                console.log(customer);
            });
        },
    }
})

export default store