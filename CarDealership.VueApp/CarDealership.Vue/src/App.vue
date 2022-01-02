<template>
  <div id="app">
    <img alt="logo" src="./assets/cars.png">
    <CarDealership msg="Welcome to Your Vue.js App"/>
  </div>
</template>

<script>
import CarDealership from './components/CarDealership.vue'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'jquery/src/jquery.js'
import 'bootstrap/dist/js/bootstrap.min.js'

export default {
  name: 'App',
  components: {
      CarDealership
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
