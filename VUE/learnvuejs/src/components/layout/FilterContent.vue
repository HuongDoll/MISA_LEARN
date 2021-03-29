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
                        <i class="fas fa-search"></i>
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
                    <button type="button" class="button-refresh" id="button-refresh"> 
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
}

/* button thêm khách hàng */
.button-add-eml{
    background-color: green;
    border: none;
    padding: 4px;
    position: absolute;
    right: 8px;
    outline: none;
    margin-top: 8px;
    border-radius: 4px;
    
}
.button-add-eml span{
    color: white;
    margin: 4px;
    margin-bottom: 8px;
}
.button-add-eml img{
    color: white;
    width: 25px;
    margin: 0px;
}

.button-refresh{
    position: absolute;
    margin-top: 4px;
    right: 8px;
    width: 35px;
    height: 35px;
    background-color: white;
    outline: none;
    border: 1px solid rgb(179, 175, 175);
    border-radius: 4px;
}
.button-refresh:hover{
    background-color: rgb(212, 206, 206);
}
.box-form-select{
    vertical-align :middle;
    padding: 8px;
    margin: 4px;
    border-color: rgb(179, 175, 175);
    outline: none;
    border-radius: 4px;
}
.find-table{
    vertical-align :middle;
    padding: 8px;
    margin: 4px;
    border: 1px solid rgb(179, 175, 175);
    border-radius: 4px;
}
.find-table input{
    border: none;
    outline: none;
}
.find-table i{
    color: rgb(179, 175, 175);
    margin-right: 4px;
}
.flex{
    display: flex;
}
</style>
