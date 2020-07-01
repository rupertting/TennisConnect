<template>
  <div class="profiles-container">
    <h1>Profiles</h1>
    <!-- <h2> {{ profiles.items.length }}</h2> -->

    <div v-if="profiles.items">
      <!-- <div v-for="profile in profiles.items" :key="profile.id">
        {{ profile.userModel.firstName }} 
      </div> -->
      <ProfileListItem
        v-for="profile in profiles.items"
        :key="profile.id"
        :profile="profile"
      >
      </ProfileListItem>
    </div>
  </div>
</template>

<script lang="ts">
import {mapState, mapActions} from 'vuex';
import { Component, Vue} from "vue-property-decorator";
import ProfileListItem from "@/components/ProfileListItem.vue";
import IProfile from "@/types/profile";

export default{
  name: 'Profiles',
  components:{
    ProfileListItem
  },
  computed: {
    ...mapState({
      profiles: state => state.profiles.all,
    })
  },
  created(){
    this.getAllProfiles();
  },
  methods: {
    ...mapActions('profiles', {
      getAllProfiles: 'getAll'
    })
  }
}



// import { Component, Vue } from "vue-property-decorator";
// import IProfile from "@/types/profile";
// import ProfileService from "../services/profile-service";
// import Profile from "@/components/Profile.vue";

// const profileService = new ProfileService();


// export default class Profiles extends Vue {
//   allProfiles: IProfile[] = [];

//   get profileCount() {
//     return this.allProfiles.length;
//   }

//   created() {
//     profileService
//       .getAll()
//       .then((res) => (this.allProfiles = res))
//       .catch((err) => console.error(err));
//   }
// }
</script>
