<template>
  <div class="content">
    <HeaderContent/>
    <MainContent/>
    <Footer/>
  </div>
</template>

<script>
import HeaderContent from './HeaderContent'
import MainContent from './MainContent'
import Footer from './Footer'

export default {
  name: 'Content',
  components: {
    HeaderContent,
    MainContent,
    Footer
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
    width: calc(100% - 220px);
    padding: 8px;
}
</style>
