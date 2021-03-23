<template>
  <div class="content">
    <HeaderContent/>
    <MainContent/>
  </div>
</template>

<script>
import HeaderContent from './HeaderContent'
import MainContent from './MainContent'

export default {
  name: 'Content',
  components: {
    HeaderContent,
    MainContent
  },
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
    background-color: cadetblue;
    width: calc(100% - 220px);
}
</style>
