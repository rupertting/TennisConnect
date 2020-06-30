<template>
  <div class="profile-wrapper">
    {{ profile.userModel.firstName }} {{ profile.userModel.lastName }}
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import IProfile from "@types/Profile";

@Component({
  name: "Profile",
  components: {},
})
export default class Profile extends Vue {
  @Prop({ required: true })
  profile!: IProfile;
}
</script>

<style scoped lang="scss">
.profile-wrapper {
  margin: 0.8rem;
  padding: 0.4rem;
  border: 1px solid #555;
  border-radius: 1rem;
}
</style>
