<template>
  <div class="profiles-container">
    <h1>Profiles</h1>
    <div v-if="allProfiles.length">
      <profile
        :profile="profile"
        v-for="profile in allProfiles"
        :key="profile.id"
      >
      </profile>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import IProfile from "@/types/profile";
import ProfileService from "../services/profile-service";
import Profile from "@/components/Profile.vue";

const profileService = new ProfileService();

@Component({
  name: "Profiles",
  components: { Profile },
})
export default class Profiles extends Vue {
  allProfiles: IProfile[] = [];

  get profileCount() {
    return this.allProfiles.length;
  }

  created() {
    profileService
      .getAllProfiles()
      .then((res) => (this.allProfiles = res))
      .catch((err) => console.error(err));
  }
}
</script>
