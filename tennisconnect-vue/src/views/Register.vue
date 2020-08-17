<template>
  <v-card width="400" class="mx-auto mt-5">
    <v-card-title>
      <h1 class="display-1">Register</h1>
    </v-card-title>
    <v-card-text>
      <ValidationObserver
        tag="form"
        ref="observer"
        v-slot="{ validate, reset }"
      >
        <v-form @submit.prevent="handleSubmit" id="register-form">
          <validation-provider
            name="firstName"
            rules="required"
            v-slot="{ errors }"
          >
            <v-text-field
              type="text"
              v-model="user.firstName"
              :counter="10"
              :error-messages="errors"
              label="First name"
              required
            >
            </v-text-field>
          </validation-provider>

          <validation-provider
            name="lastName"
            rules="required"
            v-slot="{ errors }"
          >
            <v-text-field
              type="text"
              v-model="user.lastName"
              :counter="10"
              :error-messages="errors"
              label="Last name"
              required
            >
            </v-text-field>
          </validation-provider>

          <validation-provider
            name="email"
            rules="required|email"
            v-slot="{ errors }"
          >
            <v-text-field
              type="text"
              v-model="user.emailaddress"
              :error-messages="errors"
              label="Email"
              required
            >
            </v-text-field>
          </validation-provider>

          <validation-provider
            name="password"
            rules="required|min:6"
            v-slot="{ errors }"
          >
            <v-text-field
              type="password"
              v-model="user.password"
              :error-messages="errors"
              label="Password"
              required
            >
            </v-text-field>
          </validation-provider>
        </v-form>
      </ValidationObserver>
    </v-card-text>
    <v-divider></v-divider>
    <v-card-actions>
      <v-btn :to="{ name: 'Login' }" color="info">Login</v-btn>
      <v-spacer />
      <v-btn type="submit" form="register-form" color="success">Register</v-btn>
      <v-spacer />
      <v-btn @click="clear" color="error">clear</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
import { mapState, mapActions } from "vuex";

export default {
  data() {
    return {
      user: {
        firstName: "",
        lastName: "",
        email: "",
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
    clear() {
      this.user.firstName = "";
      this.user.lastName = "";
      this.user.email = "";
      this.user.password = "";
      this.$refs.observer.reset();
    },
  },
};
</script>
