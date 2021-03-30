<template>
  <div  class="menu">
    <div class="image-menu">
        <img class="image-menu-icon" src="../../assets/content/image/toggle.png">
        <img class="image-menu-logo" src="../../assets/content/image/cukcuk-logo.png">
    </div>

    <div class="menu-option">
        <span><img src="../../assets/content/icon/dashboard.png"></span>
        <span>Tổng quan</span>
    </div>
    <div class="menu-option">
        <span><img src="../../assets/content/icon/report.png"></span>
        <span>Báo cáo</span>
    </div>
    <div class="menu-option">
        <span><img src="../../assets/content/icon/dashboard.png"></span>
        <span>Mua hàng</span>
    </div>
    <!-- <router-link to="/foo" class="menu-option">
        <span><img src="../../assets/content/icon/dic-employee.png"></span>
        <span>Danh mục khách hàng</span>
    </router-link>
    <router-link to="/bar" class="menu-option">
        <span><img src="../../assets/content/icon/dic-employee.png"></span>
        <span>Danh mục nhân viên</span>
    </router-link> -->
    <div class="menu-option">
        <span><img src="../../assets/content/icon/dic-employee.png"></span>
        <span>Danh mục khách hàng</span>
    </div>
    <div class="menu-option">
        <span><img src="../../assets/content/icon/dic-employee.png"></span>
        <span>Danh mục nhân viên</span>
    </div>
    <div class="menu-option">
        <span><img src="../../assets/content/icon/setting.png"></span>
        <span>Thiết lập hệ thống</span>
    </div>
  </div>
</template>

<script>
export default {
  name: 'menuRight',
  props: {
    msg: String
  },
  data(){
    return{
      
    }
  },
  methods:{

  }
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.menu{
    width: 220px;
    height: calc(100vh - 16px);
    border-right: 1px solid #e5e5e5;
}
/* menu chính */
.image-menu{
    width: 100%;
    height: 46px;
    padding-left: 16px;
    padding-top: 12px;
    padding-bottom: 12px;
}
.image-menu-icon{
    width: 24px;
    height: 24px;
    vertical-align :middle;
    margin-right: 10px;
}
.image-menu-logo{
    width: 130px;
    vertical-align :middle;
}
/* tùy chỉnh lựa chọn  */
.menu-option{
    padding-top: 12px;
    vertical-align: middle;
    height: 32px;
    font-style: medium;
    font-size: 13px;
    padding-left: 16px;
}
.menu-option img {
    width: 20px;
    height: 20px;
    align-items: center;
    vertical-align: middle;
    margin-right: 10px;
}
.menu-option span{
    vertical-align: middle;
}
.menu-option:hover{
    background-color: #019160;
}
.menu-option:focus{
    background-color: #019160;
    color: #ffffff;
}
</style>
