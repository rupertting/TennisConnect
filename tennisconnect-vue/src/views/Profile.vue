<template>
  <section class="profile-wrapper">
    <link
      rel="stylesheet"
      href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"
    />

    <div class="card">
      <img
        :src="require(`@/assets/anonymous-avatar.png`)"
        :alt="getProfile(this.id).userModel.firstName"
        style="width:100%"
      />
      <h1>
        {{ getProfile(this.id).userModel.firstName }}
        {{ getProfile(this.id).userModel.lastName }}
      </h1>
      <p class="title">{{ getProfile(this.id).club.name }}</p>
      <p v-if="getProfile(this.id).address !== null">
        {{ getProfile(this.id).address.town }}
      </p>
      <p><button>Connect</button></p>
    </div>
  </section>
</template>

<script>
import { mapState, mapActions, mapGetters } from "vuex";

export default {
  data() {
    return {};
  },
  props: {
    id: {
      type: Number,
      required: true,
    },
  },
  computed: {
    ...mapGetters("profiles", {
      getProfile: "getById",
    }),
  },
  created() {},
  methods: {},
};
</script>

<style scoped lang="scss">
.card {
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
  max-width: 300px;
  margin: auto;
  text-align: center;
}

.title {
  color: grey;
  font-size: 18px;
}

button {
  border: none;
  outline: 0;
  display: inline-block;
  padding: 8px;
  color: white;
  background-color: #000;
  text-align: center;
  cursor: pointer;
  width: 100%;
  font-size: 18px;
}

a {
  text-decoration: none;
  font-size: 22px;
  color: black;
}

button:hover,
a:hover {
  opacity: 0.7;
}
</style>
