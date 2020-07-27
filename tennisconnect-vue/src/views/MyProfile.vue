<template>
   <div>
     <h1>Welcome, {{ firstName }}</h1>

     <div class="contact-info">
       <h2>Contact info</h2>
       <span> <b>First name</b>: {{ firstName }} </span>
       <br/>
       <span> <b>Last name</b>: {{ lastName }} </span>
       <br/>
       <span> <b>Email</b>: {{ emailAddress }}</span>
       <br/>
       <span v-if="fullAddress !== null">
         <b>Address</b>: 
        {{ fullAddress }}
       </span>
       <br/>
     </div>

     <div class="profile-info">
       <h2>About me</h2>
       <span>
        <b>Bio</b>: {{ bio }}
       </span>
       <br/>
      <span>
        <b>Playing ability</b>: {{ rating }}
      </span>
      <br/>
      <span v-if="'{{isClub}}'">
        <b>Club</b>: {{clubName}}
      </span>
     </div>

     <div class="friends-info">
       <h2>Friend requests sent</h2>
        <span v-if="sentFriendRequests.length > 0">
            <ul>
              <li v-for="request in sentFriendRequests" :key="request.requestedToId">
                {{ getById(request.requestedToId).userModel.firstName }}
                {{ getById(request.requestedToId).userModel.lastName }}

              </li>
            </ul>
        </span>

        <h2>Friend requests received</h2>
        <span v-if="receivedFriendRequests.length > 0">
            <ul>
              <li v-for="request in receivedFriendRequests" :key="request.requestedById">
                <FriendReceivedRequestItem :requestedToId="request.requestedToId" :requestedFromId="request.requestedById"></FriendReceivedRequestItem>
              </li>
            </ul>
        </span>
     </div>
   </div> 
  </router-view>
</template>

<script>
import { mapState, mapActions, mapGetters } from "vuex";
import FriendReceivedRequestItem from "@/components/FriendReceivedRequestItem.vue";

export default {
    name: "MyProfile",
    components: {
          FriendReceivedRequestItem,
        },
  data() {
    return {
      loading: false,
      address: {},
      singleState: {},
      sentFriendRequests: [],
      receivedFriendRequests: [],
      firstName: '',
      lastName: '',
      emailAddress: '',
      bio: '',
      rating: '',
      isClub: false,
      clubName: ''
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
      single: (state) => state.profiles.single,
      profiles: (state) => state.profiles.all
    }),
    ...mapGetters("profiles", ["getByUserId", "getById"]
    ),
    fullAddress: function(){
      if(this.address == null ){
        return
      }
      return this.address.numberSupplement + ' ' + this.address.streetName + ' ' + this.address.town + ' ' + this.address.postCode
    }
  },
  watch: {
    single: 
      function(newSingle, oldSingle) {
        this.singleState = newSingle
        this.sentFriendRequests = this.singleState.profile.sentFriendRequests
        this.receivedFriendRequests = this.singleState.profile.receivedFriendRequests
        this.firstName = this.singleState.profile.userModel.firstName
        this.lastName = this.singleState.profile.userModel.lastName
        this.emailAddress = this.singleState.profile.userModel.emailAddress
        this.address = this.singleState.profile.address
        this.bio = this.singleState.profile.bio
        this.rating = this.singleState.profile.rating
        this.isClub = this.singleState.profile.isClub
        this.clubName = this.singleState.profile.club.name
      },
    },
  
  created() {
     this.getProfile();
     this.getAll();
  },
  methods: {
    ...mapActions("profiles", ["getSingleByUser", "getAll"],
    ),
    getProfile (){
      this.loading = true

      this.getSingleByUser(this.$route.params.userId).then(
        this.loading = false
      )
    },
  },
};
</script>
