<template>
  <div class="table-eml">
        <table id="table-employee">
            <thead>
                <td class="wight-2">Mã khách hàng</td>
                <td class="wight-2"> Họ và tên</td>
                <td class="wight-1">Giới tính</td>
                <td class="wight-2">Ngày sinh </td>
                <td class="wight-2">Nhóm ngành hàng</td>
                <td class="wight-1">Điện thoại</td>
                <td class="wight-2">Email</td>
                <td class="wight-3">Địa chỉ</td>
                <td class="wight-1">Mã thẻ thành viên</td>
            </thead>
            <tbody>
                <!-- truyền vào dữ liệu thông tin khách hàng  -->
                <tr v-for="(data, index) in dataList" :key="index">
                    <td class="wight-2">Mã khách hàng</td>
                    <td class="wight-2"> Họ và tên</td>
                    <td class="wight-1">Giới tính</td>
                    <td class="wight-2">Ngày sinh </td>
                    <td class="wight-2">Nhóm ngành hàng</td>
                    <td class="wight-1">Điện thoại</td>
                    <td class="wight-2">Email</td>
                    <td class="wight-3">Địa chỉ</td>
                    <td class="wight-1">Mã thẻ thành viên</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'MISATable',
  created(){
    this.loadData();
  },
  props: {
    msg: String
  },
  data(){
    return{
      dataList: [],
    }
  },
  methods:{
    loadData(){
        axios.get('http://api.manhnv.net/api/customers')
        .then(response => {
            console.log(response)
        this.dataList =response
        })
        .catch(error => {
            console.log(error)
            this.errored = true
        })
        .finally(() => this.loading = false)
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
    overflow-x: auto;
    background-color: burlywood;
}
.table-eml tr {
    border-bottom: 1px solid rgb(179, 175, 175);
    display: block;
    padding: 12px;
}
.table-eml tr:hover{
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
