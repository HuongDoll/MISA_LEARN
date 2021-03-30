<template>
  <div id="app">
    <Menu/>
    <Content/>
  </div>
</template>

<script>
import Menu from './components/layout/Menu'
import Content from './components/layout/Content'

export default {
  name: 'MISACukCuk',
  components: {
    Menu,
    Content
  }
}
</script>

<style>
@import './css/font.css';
body{
  margin: 0px;
  padding: 0px;
}
</style>
