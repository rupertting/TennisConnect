<template>
  <h1>
    <!-- {{ profiles }} -->
    {{ getProfile(this.userId) }}
    <!-- Hello {{ getProfile(this.profiles, this.userId).userModel.firstName }}
    {{ getProfile(this.profiles, this.userId).userModel.lastName }} -->
  </h1>
</router-view>
</template>

<script>
import { mapState, mapActions, mapGetters } from "vuex";

export default {
  data() {
    return {};
  },
  props: {
    userId: {
      type: Number,
      required: true,
    },
  },
  computed: {
    ...mapState({
      profiles: (state) => state.profiles.all,
    }),
    ...mapGetters("profiles", {
      getProfile: "getByUserId",
    }),
  },
  created() {
     this.getAllProfiles();
  },
  methods: {
    ...mapActions("profiles", {
      getAllProfiles: "getAll",
    }),
  },
};
</script>
