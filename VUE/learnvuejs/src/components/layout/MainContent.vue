<template>
  <div class="maincontent">
    <!-- <router-view></router-view> -->
    <Filter-content @opendialog="opendialogput" />
    <MISATable :isLoad =isLoadDataTable @LoadDone="loadDone"/>
    <CustomerDetail :msg =msg v-show="isShowDialog" @closedialog="clodedialog" @reload="loadtable" />
    <CustomerDialog v-show="isShowDialogMini" @closedialog="closeDialogMini" />
  </div>
</template>

<script>
import FilterContent from './FilterContent'
import MISATable from '../base/MISATable'
import CustomerDetail from '../page/customer/CustomerDetail'
import CustomerDialog from '../page/customer/CustomerDialog'

export default {
  name: 'Content',
  components: {
    FilterContent,
    MISATable,
    CustomerDetail,
    CustomerDialog
  },
  props: {
  },
  data(){
    return{
      isShowDialog: false,
      isLoadDataTable: false,
      isShowDialogMini: true,
      msg: "",
    }
  },
  
  methods:{
    closeDialogMini(){
      this.isShowDialogMini = false;
    },
    loadDone(){
      this.isLoadDataTable = false;
    },
    loadtable(){
      this.isLoadDataTable = true;
    },
    clodedialog(){
      this.isShowDialog = false;
    },
    opendialogput(){
      this.isShowDialog = true;
      this.msg = "post";
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
