<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/tc-logo.png">
    <HelloWorld msg="Welcome to TennisConnect!"/>
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'

export default {
  name: 'Home',
  components: {
    HelloWorld
  }
}
</script>
