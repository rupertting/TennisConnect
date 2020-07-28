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
        <span v-if="sentFriendRequestsAwaiting.length > 0">
            <ul>
              <li v-for="request in sentFriendRequestsAwaiting" :key="request.requestedToId">
                {{ getById(request.requestedToId).userModel.firstName }}
                {{ getById(request.requestedToId).userModel.lastName }}

              </li>
            </ul>
        </span>

        <h2>Friend requests received</h2>
        <span v-if="receivedFriendRequestsAwaiting.length > 0">
            <ul>
              <li v-for="request in receivedFriendRequestsAwaiting" :key="request.requestedById">
                <FriendReceivedRequestItem :requestedToId="request.requestedToId" :requestedFromId="request.requestedById"></FriendReceivedRequestItem>
              </li>
            </ul>
        </span>

        <h2>Friends</h2>
        <span v-if="friends.length > 0">
          <ul>
            <li v-for="friend in friends" :key="friend.friendId">
              <router-link :to="{ name: 'Profile', params: { id: friend.friendId } }">
                {{ getById(friend.friendId).userModel.firstName }}
                {{ getById(friend.friendId).userModel.lastName }}
              </router-link>
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
      sentFriendRequestsAwaiting: [],
      receivedFriendRequestsAwaiting: [],
      friends: [],
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
        this.sentFriendRequestsAwaiting = this.singleState.profile.sentFriendRequestsAwaiting
        this.receivedFriendRequestsAwaiting = this.singleState.profile.receivedFriendRequestsAwaiting
        this.friends = this.singleState.profile.friends
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
