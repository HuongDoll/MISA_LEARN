<template>
  <div class="maincontent">
    <!-- <router-view></router-view> -->
    <Filter-content/>
    <MISATable/>
  </div>
</template>

<script>
import FilterContent from './FilterContent'
import MISATable from '../base/MISATable'

export default {
  name: 'Content',
  components: {
    FilterContent,
    MISATable
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
.maincontent{
    background-color:darkorchid;
    width: 100%;
}
</style>
