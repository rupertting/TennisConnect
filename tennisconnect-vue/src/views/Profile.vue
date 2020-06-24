<template>
  <div class="about">
    <h1>My Profile</h1>
  </div>
</template>

<script lang="ts">
import { Component, Vue} from 'vue-property-decorator';
import IProfile from "@/types/profile";
import ProfileService from '../services/profile-service';

const profileService = new ProfileService();

@Component({
    name: 'MyProfile',
    components: {}
})
export default class MyProfile extends Vue{
  //data
  myProfiles: IProfile[] = [];

  //computed properties

  //props

  //methods

  //lifecycle hooks
  created(){
    profileService.getAllProfiles().then(res => this.myProfiles = res);
  }


}

</script>