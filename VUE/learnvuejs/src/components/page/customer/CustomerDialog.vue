<template>
    <div>
        <div class="mini-dialog" id="mini-dialog" @click="closedialog()">
        </div>
        <div class="mini-select" id="mini-select">
            <button type="button" id="button-edit"><i class="fas fa-edit"></i></button>
            <button type="button" id="button-delete-item"><i class="far fa-trash-alt"></i></button>
        </div>
    </div>
</template>
<script>
export default {
    name: "CusTomerDialog",
    props: {
    },
    data() {
        return {
        };
    },
    methods: {
        closedialog(){
            this.$emit("closedialog");
        }
    }
}
</script>
<style scoped>
.mini-dialog{
    width: 100%;
    height: 100vh;
    position: fixed;
    left: 0px;
    top: 0px;
}
.mini-select{
    background-color: white;
    position: absolute;
    top: 500px;
    left: 100px;
    padding: 8px;
    border-radius: 10px;
    border-top-right-radius: 0px;
    border: 1px solid gray;
    box-shadow: 5px 10px 8px #888888;
}
.mini-select button{
    margin: 4px;
    width: 30px;
    height: 30px;
}
.mini-select button i{
    font-size: 16px;
    color: gray;
}
.mini-select button i:hover{
    color: black;
}
</style>
