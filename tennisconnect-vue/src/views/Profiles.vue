<template>
  <div class="profiles-container">
    <h1>Profiles</h1>
    <div v-if="profiles.items">
      <div v-for="profile in profiles.items" :key="profile.id">
        <router-link :to="{ name: 'Profile', params: { id: profile.id } }">
          <ProfileListItem :profile="profile"> </ProfileListItem>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { mapState, mapActions } from "vuex";
import { Component, Vue } from "vue-property-decorator";
import ProfileListItem from "@/components/ProfileListItem.vue";

export default {
  name: "Profiles",
  components: {
    ProfileListItem,
  },
  computed: {
    ...mapState({
      profiles: (state) => state.profiles.all,
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

<style scoped lang="scss">
.profile-wrapper {
  margin: 0.8rem;
  padding: 0.4rem;
  border: 1px solid #555;
  border-radius: 1rem;
}
</style>
