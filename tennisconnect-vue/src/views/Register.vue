<template>
  <div>
    <link
      href="//netdna.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css"
      rel="stylesheet"
    />
    <h2>Register</h2>
    <ValidationObserver tag="form" ref="observer" v-slot="{ invalid }">
      <form @submit.prevent="handleSubmit">
        <div class="form-group">
          <label for="firstName">First Name</label>
          <validation-provider
            name="First Name"
            rules="required"
            v-slot="{ errors }"
          >
            <input
              type="text"
              v-model="user.firstName"
              name="firstName"
              class="form-control"
              :class="{ 'is-invalid': submitted && errors.length > 0 }"
            />
            <span>{{ errors[0] }}</span>
          </validation-provider>
        </div>
        <div class="form-group">
          <label for="lastName">Last Name</label>
          <validation-provider
            name="Last Name"
            rules="required"
            v-slot="{ errors }"
          >
            <input
              type="text"
              v-model="user.lastName"
              name="lastName"
              class="form-control"
              :class="{ 'is-invalid': submitted && errors.length > 0 }"
            />
            <span>{{ errors[0] }}</span>
          </validation-provider>
        </div>
        <div class="form-group">
          <label for="emailaddress">Email Address</label>
          <validation-provider
            name="Email"
            rules="required"
            v-slot="{ errors }"
          >
            <input
              type="text"
              v-model="user.emailaddress"
              name="emailaddress"
              class="form-control"
              :class="{ 'is-invalid': submitted && errors.length > 0 }"
            />
            <span>{{ errors[0] }}</span>
          </validation-provider>
        </div>
        <div class="form-group">
          <label htmlFor="password">Password</label>
          <validation-provider
            name="Password"
            rules="required|min:6"
            v-slot="{ errors }"
          >
            <input
              type="password"
              v-model="user.password"
              name="password"
              class="form-control"
              :class="{ 'is-invalid': submitted && errors.length > 0 }"
            />
            <span>{{ errors[0] }}</span>
          </validation-provider>
        </div>
        <div class="form-group">
          <button class="btn btn-primary" :disabled="status.registering">
            Register
          </button>

          <router-link to="/login" class="btn btn-link">Cancel</router-link>
        </div>
      </form>
    </ValidationObserver>
  </div>
</template>

<script>
import { mapState, mapActions } from "vuex";

export default {
  data() {
    return {
      user: {
        firstName: "",
        lastName: "",
        emailaddress: "",
        password: "",
      },
      submitted: false,
    };
  },
  computed: {
    ...mapState("account", ["status"]),
  },
  methods: {
    ...mapActions("account", ["register"]),
    async handleSubmit(e) {
      this.submitted = true;
      const isValid = await this.$refs.observer.validate();
      if (!isValid) {
        return;
      }
      this.register(this.user);
    },
  },
};
</script>
