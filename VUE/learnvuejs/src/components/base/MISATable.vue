<template>
  <div class="table-eml">
        <table id="table-employee">
            <thead>
                <tr>
                    <td class="wight-2">Mã khách hàng</td>
                    <td class="wight-2">Họ và tên</td>
                    <td class="wight-1">Giới tính</td>
                    <td class="wight-2">Ngày sinh </td>
                    <td class="wight-2">Nhóm ngành hàng</td>
                    <td class="wight-1">Điện thoại</td>
                    <td class="wight-2">Email</td>
                    <td class="wight-3">Địa chỉ</td>
                    <td class="wight-1">Mã thẻ thành viên</td>
                </tr>
                
            </thead>
            <tbody>
                <!-- truyền vào dữ liệu thông tin khách hàng  -->
                <tr v-for="(data, index) in dataList" :key="index" @dblclick="clickrow($event, data.customerId)" >
                    <td class="wight-2">{{data.customerCode}}</td>
                    <td class="wight-2">{{data.fullName}}</td>
                    <td class="wight-1">{{formatGender(data.gender)}}</td>
                    <td class="wight-2">{{formatDate(data.dateOfBirth)}} </td>
                    <td class="wight-2">{{data.customerGroupName}}</td>
                    <td class="wight-1">{{data.phoneNumber}}</td>
                    <td class="wight-2">{{data.email}}</td>
                    <td class="wight-3">{{data.address}}</td>
                    <td class="wight-1">{{data.memberCardCode}}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
// import axios from 'axios'

export default {
    name: 'MISATable',
    props: {
        isLoad: Boolean
    },
    created(){
        this.$store.dispatch('getCustomers')
    },
    data(){
        return{
        }
    },
    computed:{
        dataList(){
            return this.$store.getters.getCustomers
        }
    },
    watch: {
        isLoad: function() {
            if(this.isLoad) this.loadData();
        }
    },
    methods:{
        clickrow(event, customerId){
            console.log(event.screenX);
            console.log(event.screenY);
            console.log(customerId);
            this.$emit("doubleClick", event.screenX, event.screenY ,customerId)
        },
        formatDate(datee) {
            if(datee != null){
                var date = new Date(datee);
                var year = date.getFullYear();
            
                var month = (1 + date.getMonth()).toString();
                month = month.length > 1 ? month : '0' + month;
            
                var day = date.getDate().toString();
                day = day.length > 1 ? day : '0' + day;
            
                return day + "/" + month + "/" + year;
            }else return null;
            
        },

        formatDatee(datee) {
            if(datee != null){
                var date = new Date(datee);
                var year = date.getFullYear();
            
                var month = (1 + date.getMonth()).toString();
                month = month.length > 1 ? month : '0' + month;
            
                var day = date.getDate().toString();
                day = day.length > 1 ? day : '0' + day;
            
                return year + "-" + month + "-" + day;
            }else return null;
            
        },
        // format lại giới tính
        formatGender(gender) {
            if (gender == 1) return "Nam";
            else {
                if (gender == 2) return "Nữ";
                else return "Khác";
            }
        }
    }
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
table{
    margin: 0;
}
.table-eml{
    width: 100%;
    height: calc(100vh - 220px);
    overflow-x: auto;
}
.table-eml tr {
    border-bottom: 1px solid rgb(179, 175, 175);
    display: block;
    padding: 12px;
}
.table-eml thead tr {
    border-bottom: 1px solid black;
    display: block;
    padding: 12px;
}
.table-eml tbody tr:hover{
    background-color: whitesmoke;
}
.table-eml thead{
    font-weight: bold;
    display: block;
}
.table-eml tbody{
    display:block;
    overflow: auto;
    max-height: calc(100vh - 300px);
  }
/* scrollbar */
::-webkit-scrollbar {
    width: 7px;
    height: 7px;
    position: absolute;
    right: 8px;
  }
 
/* Track */
::-webkit-scrollbar-track {
    box-shadow: inset 0 0 5px grey; 
    border-radius: 10px;
}

/* Handle */
::-webkit-scrollbar-thumb {
    background: gray; 
    border-radius: 10px;
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover {
    background: rgb(77, 76, 76); 
    
}
/* định dạng độ rộng phần tử */
.wight-1{
    min-width: 100px;
}
.wight-2{
    min-width: 200px;
}
.wight-3{
    min-width: 300px;
}
.wight-4{
    min-width: 400px;
}
</style>
