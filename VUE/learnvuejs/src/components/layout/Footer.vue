<template>
    <div class="footer">
        <div class="botton-page-left">hiển thị 1-10/1000 khách hàng</div>
        <div class="botton-page-center flex">
            <button type="button" class="button-icon"><i class="fas fa-angle-double-left"></i></button>
            <button type="button" class="button-icon"><i class="fas fa-angle-left"></i></button>
            <button type="button">1</button>
            <button type="button">2</button>
            <button type="button">3</button>
            <button type="button">4</button>
            <button type="button" class="button-icon"><i class="fas fa-angle-right"></i></button>
            <button type="button" class="button-icon"><i class="fas fa-angle-double-right"></i></button>
        </div>
        <div class="botton-page-right">10 nhân viên/trang</div>
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

  }
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.footer{
    display: flex;
    border-top: 1px solid #e5e5e5;

}
.botton-page-left{
    width: 30%;
    padding: 8px;
}
.botton-page-center{
    width: 50%;
    align-items: center;
}
.botton-page-center button{
    width: 35px;
    height: 35px;
    border-radius: 50%;
    margin: 8px;
    outline: none;
    border: 1px solid gray;
    background-color: white;
}
.botton-page-center button:hover{
    background-color: rgb(194, 192, 192);
}
.botton-page-right{
    width: 20%;
    text-align: right;
    padding: 8px;
}
.button-icon{
    border: none !important;
    font-size: 16px;
    border-radius: 0px !important;
}
</style>
