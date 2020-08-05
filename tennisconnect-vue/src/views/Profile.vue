<template>
  <section class="profile-wrapper">
    <link
      rel="stylesheet"
      href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"
    />

    <div class="card">
      <img
        :src="require(`@/assets/anonymous-avatar.png`)"
        :alt="firstName"
        style="width:100%"
      />
      <h1>
        {{ firstName }}
        {{ lastName }}
      </h1>
      <p class="title">{{ clubName }}</p>
      <p v-if="town !== null">
        {{ town }}
      </p>
      <p v-if="!confirmIfFriend(this.$route.params.id)">
        <button :disabled="isDisabled" v-on:click="connectFriend">
          Connect
        </button>
      </p>
    </div>
  </section>
</template>

<script>
import { mapState, mapActions, mapGetters } from "vuex";
import { getProfileId } from "@/_helpers/auth-header";

export default {
  data() {
    return {
      singleState: {},
      firstName: "",
      lastName: "",
      clubName: "",
      isClub: false,
      town: "",
      bio: "",
      friends: [],
      profileId: "",
      rating: "",
      hasClicked: false,
    };
  },
  props: {
    id: {
      type: Number,
      required: true,
    },
  },
  computed: {
    ...mapState({
      single: (state) => state.profiles.single,
      all: (state) => state.friends.all,
    }),
    isDisabled: function() {
      return !this.hasClicked;
    },
  },
  created() {
    this.getProfile(this.$route.params.id);
  },
  mounted() {
    this.getFriends(getProfileId());
  },
  methods: {
    ...mapActions("profiles", { getProfile: "getSingleByProfile" }),
    ...mapActions("profiles", { getProfileByUserId: "getSingleByUser" }),
    ...mapActions("friends", ["connect", "getFriends"]),
    connectFriend() {
      let o = {
        requestedById: getProfileId(),
        requestedToId: this.profileId,
      };
      this.connect(o);
    },
    confirmIfFriend(friendId) {
      return this.all.items.some(function(friend) {
        return friend.friendId === friendId;
      });
    },
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
      this.friends = this.singleState.profile.friends;
      this.bio = this.singleState.profile.bio;
      this.rating = this.singleState.profile.rating;
    },
  },
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
