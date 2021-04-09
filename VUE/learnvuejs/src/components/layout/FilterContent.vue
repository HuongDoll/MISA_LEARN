<template>
  <div class="filter">
      <div class="flex content-title">
                    <span class="title-content">Danh sách khách hàng</span>
                    <span>
                        <button type="button" class="button-add-eml" id="add-employee" @click="opendialog">
                            <span><img src="../../assets/content/icon/add.png"></span>
                            <span>Thêm khách hàng</span>
                        </button>
                    </span>
                </div>
                <!-- filter của danh sách khách hàng -->
                <div class="flex">
                    <div class="find-table flex">
                        <span><img src="../../assets/content/icon/search.png"></span>
                        <input placeholder="Tìm kiếm theo mã, tên hoặc ố điện thoại..." id="input-filter">
                    </div>

                    <select class="box-form-select">
                        <option>Tất cả phòng ban</option>
                        <option>Tất cả phòng ban</option>
                        <option>Tất cả phòng ban</option>
                        <option>Tất cả phòng ban</option>
                    </select>
                    <select class="box-form-select">
                        <option>Tất cả vị trí</option>
                        <option>Tất cả vị trí</option>
                        <option>Tất cả vị trí</option>
                        <option>Tất cả vị trí</option>
                    </select>
                    <button type="button" class="button-refresh" id="button-refresh" @click="refresh"> 
                        <img src="../../assets/content/icon/refresh.png">
                    </button>
                </div>
  </div>
</template>

<script>

export default {
  name: 'FilterContent',
  props: {
    msg: String
  },
  data(){
    return{
      name: ''
    }
  },
  methods:{
      opendialog(){
          this.$emit('opendialog');
      },
      refresh(){
          this.$store.dispatch('getCustomers');
      }
  }
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
 /* tilte */
 .filter{
     width: 100%;
 }
.content-title{
    height: 50px;
    vertical-align: middle;
}
.content-title span{
    vertical-align: middle;
}
.content-title .title-content{
    padding: 8px;
    font-size: 20px;
    padding-left: 0px;
}

/* button thêm khách hàng */
.button-add-eml{
    background-color: #019160;
    border: none;
    position: absolute;
    right: 8px;
    outline: none;
    margin-top: 8px;
    border-radius: 4px;
    height: 40px;
    font-size: 13px;
    color: #ffffff;
    font-style: Regular;
    padding-right: 16px;
    padding-left: 16px;
    text-align: center;
}
.button-add-eml:hover {
    background-color: #2FBE8E;
}

.button-add-eml img{
    color: white;
    width: 20px;
    margin: 0px;
}

.button-refresh{
    position: absolute;
    margin-top: 4px;
    right: 8px;
    width: 40px;
    height: 40px;
    background-color: white;
    outline: none;
    border: 1px solid #BBBBBB;
    border-radius: 4px;
}
.button-refresh:hover{
    background-color: #BBBBBB;
    color: #000000;
}
.box-form-select{
    vertical-align :middle;
    padding-left: 16px;
    padding-right: 16px;
    margin: 4px;
    border:1px solid #BBBBBB;
    outline: none;
    border-radius: 4px;
    height: 40px;
    font-size: 11px;
    color: #BBBBBB;
    font-style: regular;
}
.find-table{
    vertical-align :middle;
    padding: 7px;
    margin: 4px;
    margin-left: 0px;
    border: 1px solid #BBBBBB;
    border-radius: 4px;
}
.find-table input{
    border: none;
    outline: none;
    font-style: italic;
    color: #BBBBBB;
    font-size: 11px;
}
.find-table img{
    color: #BBBBBB;
    padding-right: 4px;
    padding-top: 4px;
    width: 16px;
    height: 16px;
}
.flex{
    display: flex;
}
</style>
