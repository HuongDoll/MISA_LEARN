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
  name: 'menu',
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
    background-color: aquamarine;
    width: 220px;
    height: calc(100vh - 16px);
}
/* menu chính */
.image-menu{
    width: 100%;
    height: 50px;
}
.image-menu-icon{
    width: 25px;
    vertical-align :middle;
}
.image-menu-logo{
    width: 130px;
    vertical-align :middle;
}
/* tùy chỉnh lựa chọn  */
.menu-option{
    vertical-align: middle;
    padding: 8px;
}
.menu-option img {
    width: 25px;
    height: 25px;
    align-items: center;
    margin-right: 8px;
}
.menu-option span{
    vertical-align: middle;
}
.menu-option:hover{
    background-color: whitesmoke;
}
</style>
