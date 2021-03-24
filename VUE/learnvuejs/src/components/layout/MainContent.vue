<template>
  <div class="maincontent">
    <!-- <router-view></router-view> -->
    <Filter-content @opendialog="opendialog" />
    <MISATable/>
    <CustomerDetail :isShowDialog =isShowDialog v-show="isShowDialog" @closedialog="clodedialog"/>
  </div>
</template>

<script>
import FilterContent from './FilterContent'
import MISATable from '../base/MISATable'
import CustomerDetail from '../page/customer/CustomerDetail'

export default {
  name: 'Content',
  components: {
    FilterContent,
    MISATable,
    CustomerDetail
  },
  props: {
    msg: String
  },
  data(){
    return{
      isShowDialog: false,
    }
  },
  methods:{
    clodedialog(){
      this.isShowDialog = false;
    },
    opendialog(){
      this.isShowDialog = true;
    }
  }
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.maincontent{
    width: 100%;
}
</style>
