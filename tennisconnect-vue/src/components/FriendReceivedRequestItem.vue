<template>
  <div>
    {{ getById(requestedFromId).userModel.firstName }}
    {{ getById(requestedFromId).userModel.lastName }}
    <button v-on:click="acceptFriend">Accept</button>
    <button v-on:click="rejectFriend">Reject</button>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import { mapState, mapActions, mapGetters } from "vuex";
import IProfile from "@/types/Profile";

export default {
  component: {
    name: "FriendReceivedRequestItem",
    components: {},
  },
  data() {
    return {
      singleState: {},
      sentFriendRequestsAwaiting: [],
      receivedFriendRequestsAwaiting: [],
    };
  },
  props: {
    required: true,
    requestedToId: {
      type: Number,
    },
    requestedFromId: {
      type: Number,
    },
  },
  watch: {
    single: function(newSingle, oldSingle) {
      this.singleState = newSingle;
      this.sentFriendRequestsAwaiting = this.singleState.profile.sentFriendRequestsAwaiting;
      this.receivedFriendRequestsAwaiting = this.singleState.profile.receivedFriendRequestsAwaiting;
    },
  },
  computed: {
    ...mapState({
      single: (state) => state.profiles.single,
      profiles: (state) => state.profiles.all,
    }),
    ...mapGetters("profiles", ["getByUserId", "getById"]),
  },
  methods: {
    ...mapActions("profiles", ["getAll", "getSingleByProfile"]),
    ...mapActions("friends", ["accept", "reject"]),
    acceptFriend() {
      const o = {
        requestedById: this.requestedFromId,
        requestedToId: this.requestedToId,
      };
      this.accept(o);
    },
    rejectFriend() {
      const o = {
        requestedById: this.requestedFromId,
        requestedToId: this.requestedToId,
      };
      this.reject(o);
    },
  },
  created() {
    this.getAll();
  },
};
</script>
