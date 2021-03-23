<template>
    <div class="header">
        <select class="header-select">
            <option>Nhà hàng biển đông 1</option>
            <option>Nhà hàng biển đông 2</option>
            <option>Nhà hàng biển đông 3</option>
            <option>Nhà hàng biển đông 4</option>
        </select>
        <div class="header-acount">
            <img class="avt" src="../../assets/content/icon/avatar-default.png">
            <div>Hoàng Thị Thu Hương</div>
            <img class="option-image" src="../../assets/content/icon/option.png">
        </div>
    </div>
</template>

<script>
export default {
  name: 'content title',
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
.header{
    /* phẩn header */
    height: 50px;
    border-bottom: 1px solid gray;
    padding: 8px;
    display: flex;
    width: calc(100% - 16px);
    background-color: brown;
}
.header select{
    vertical-align :middle;
    padding: 8px;
    border-color: white;
    outline: none;
}
.header option{
    outline: none;
}
/* mini acount */
.header-acount{
    position: absolute;
    right: 8px;
    align-items: center;
    display: flex;
}
.header-acount .option-image{
    width: 20px;
    height: 20px;
}
.header-acount .avt{
    width: 40px;
}
.header-acount div{
    padding: 8px;
}
</style>
