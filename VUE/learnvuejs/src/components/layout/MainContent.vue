<template>
  <div class="content">
    <div>content</div>
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  name: 'Content',
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
.content{
    background-color: khaki;
    padding: 8px;
    width: calc(100% - 16px);;
}
</style>
