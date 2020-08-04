<template>
  <h1>{{ firstName }} {{ lastName }}</h1>
</template>

<script lang="ts">
import { mapState, mapActions, mapGetters } from "vuex";

export default {
  data() {
    return {
      singleState: {},
      firstName: "",
      lastName: "",
      clubName: "",
      isClub: false,
      town: "",
      profileId: "",
      friends: [],
      bio: "",
      rating: "",
    };
  },
  props: {
    required: true,
    friendId: {
      type: Number,
    },
  },
  computed: {
    ...mapState({
      single: (state) => state.profiles.single,
    }),
  },
  created() {
    this.getProfile(this.$route.params.friendId);
  },
  methods: {
    ...mapActions("profiles", { getProfile: "getSingleByProfile" }),
  },
  watch: {
    single: function(newSingle, oldSingle) {
      this.singleState = newSingle;
      this.firstName = this.singleState.profile.userModel.firstName;
      this.lastName = this.singleState.profile.userModel.lastName;
      this.isClub = this.singleState.profile.club.isClub;
      this.clubName = this.singleState.profile.club.name;
      this.town = this.singleState.profile.address.town;
      this.profileId = this.singleState.profile.id;
      this.bio = this.singleState.profile.bio;
      this.rating = this.singleState.profile.rating;
      this.friends = this.singleState.profile.friends;
    },
  },
};
</script>
