<template>
    <div class="profile-wrapper">
      <div>
        <strong>Name</strong>: {{ profile.userModel.firstName }} {{ profile.userModel.lastName }} 
      </div>
      <div v-if="profile.club !== null">
        <strong>Club</strong>: {{ profile.club.name }}
      </div>
      <div v-if="profile.address !== null" >
        <strong>Location</strong>: {{ profile.address.town }}
      </div>
    </div>
  </template>
  
  <script lang="ts">
  import { Component, Vue, Prop } from "vue-property-decorator";
  import IProfile from "@types/Profile";
  
  @Component({
    name: "ProfileListItem",
    components: {},
  })
  export default class ProfileListItem extends Vue {
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