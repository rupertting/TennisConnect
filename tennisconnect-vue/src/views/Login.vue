<template>
  <v-card width="400" class="mx-auto mt-5">
    <v-card-title>
      <h1 class="display-1">Login</h1>
    </v-card-title>
    <v-card-text>
      <ValidationObserver ref="observer" v-slot="{ validate, reset }">
        <v-form @submit.prevent="handleSubmit" id="login-form">
          <ValidationProvider
            v-slot="{ errors }"
            name="email"
            rules="required|email"
          >
            <v-text-field
              v-model="emailaddress"
              type="text"
              :error-messages="errors"
              label="Email"
              name="emailaddress"
              required
              prepend-icon="mdi-account-circle"
            />
          </ValidationProvider>
          <ValidationProvider
            v-slot="{ errors }"
            name="password"
            rules="required"
          >
            <v-text-field
              :type="showPassword ? 'text' : 'password'"
              v-model="password"
              :error-messages="errors"
              label="Password"
              name="password"
              prepend-icon="mdi-lock"
              :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
              @click:append="showPassword = !showPassword"
            />
          </ValidationProvider>
        </v-form>
      </ValidationObserver>
    </v-card-text>
    <v-divider></v-divider>
    <v-card-actions>
      <v-btn :to="{ name: 'Register' }" color="success">Register</v-btn>
      <v-spacer></v-spacer>
      <v-btn type="submit" color="info" form="login-form">Login</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
import { mapState, mapActions } from "vuex";

export default {
  data() {
    return {
      emailaddress: "",
      password: "",
      submitted: false,
      showPassword: false,
    };
  },
  computed: {
    ...mapState("account", ["status"]),
  },
  created() {
    // reset login status
    this.logout();
  },
  methods: {
    ...mapActions("account", ["login", "logout"]),
    handleSubmit(e) {
      this.$refs.observer.validate();
      const { emailaddress, password } = this;
      if (emailaddress && password) {
        this.login({ emailaddress, password });
      }
    },
  },
};
</script>
