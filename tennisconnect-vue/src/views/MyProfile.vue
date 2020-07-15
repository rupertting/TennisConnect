<template>
  <h1>
    {{ current }}
  </h1>
</router-view>
</template>

<script>
import { mapState, mapActions, mapGetters } from "vuex";

export default {
  data() {
    return {
      loading: false,
    };
  },
  props: {
    userId: {
      type: Number,
      required: true,
    },
  },
  computed: {
    ...mapState({
      current: (state) => state.profiles.current,
    }),
    ...mapGetters("profiles", 
      ["getByUserId"]
    ),
  },
  created() {
     this.getProfile();
  },
  methods: {
    ...mapActions("profiles", ["getSingle"]
    ),
    getProfile (){
      this.loading = true

      this.getSingle(this.$route.params.userId).then(
        this.loading = false
      )
    }
  },
};
</script>
