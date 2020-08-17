<template>
  <v-app>
    <div id="app">
      <div id="nav">
        <router-link to="/">Home</router-link> |
        <router-link to="/profiles">Profiles</router-link> |
        <router-link :to="{ name: 'MyProfile', params: { userId: userId } }"
          >My Profile</router-link
        >
      </div>
    </div>

    <div class="jumbotron">
      <div class="container">
        <div class="row">
          <div class="col-sm-6 offset-sm-3">
            <div v-if="alert.message" :class="`alert ${alert.type}`">
              {{ alert.message }}
            </div>
            <router-view></router-view>
          </div>
        </div>
      </div>
    </div>
  </v-app>
</template>

<script>
import { mapState, mapActions } from "vuex";
import { getUserId } from "@/_helpers/auth-header";

export default {
  name: "app",
  data() {
    return {
      userId: "",
    };
  },
  computed: {
    ...mapState({
      alert: (state) => state.alert,
    }),
  },
  methods: {
    ...mapActions({
      clearAlert: "alert/clear",
    }),
  },
  watch: {
    $route(to, from) {
      // clear alert on location change
      this.clearAlert();
    },
  },
  created() {
    this.userId = getUserId();
    console.log("userId: " + this.userId);
  },
};
</script>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
