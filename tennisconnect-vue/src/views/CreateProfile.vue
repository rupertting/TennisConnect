<template>
  <v-card width="400" class="mx-auto mt-5">
    {{ clubs.items }}
    <v-card-title>
      <h1 class="display-1">Create profile</h1>
    </v-card-title>
    <ValidationObserver ref="observer" v-slot="{ validate, reset }">
      <form>
        <ValidationProvider
          v-slot="{ errors }"
          name="Name"
          rules="required|max:10"
        >
          <v-text-field
            v-model="name"
            :counter="10"
            :error-messages="errors"
            label="Name"
            required
          ></v-text-field>
        </ValidationProvider>
        <ValidationProvider
          v-slot="{ errors }"
          name="email"
          rules="required|email"
        >
          <v-text-field
            v-model="email"
            :error-messages="errors"
            label="E-mail"
            required
          ></v-text-field>
        </ValidationProvider>
        <ValidationProvider v-slot="{ errors }" name="select" rules="required">
          <v-select
            v-model="select"
            :items="allClubs.items"
            :error-messages="errors"
            label="Select"
            data-vv-name="select"
            required
          ></v-select>
        </ValidationProvider>
        <ValidationProvider
          v-slot="{ errors, valid }"
          rules="required"
          name="checkbox"
        >
          <v-checkbox
            v-model="checkbox"
            :error-messages="errors"
            value="1"
            label="Option"
            type="checkbox"
            required
          >
          </v-checkbox>
        </ValidationProvider>

        <v-btn class="mr-4" @click="submit">submit</v-btn>
        <v-btn @click="clear">clear</v-btn>
      </form>
    </ValidationObserver>
  </v-card>
</template>

<script>
import { mapState, mapActions } from "vuex";

export default {
  data: () => ({
    name: "",
    email: "",
    select: null,
    items: ["Item 1", "Item 2", "Item 3", "Item 4"],
    checkbox: null,
    allClubs: {},
  }),
  computed: {
    ...mapState({
      clubs: (state) => state.clubs.all,
    }),
  },
  methods: {
    submit() {
      this.$refs.observer.validate();
    },
    clear() {
      this.name = "";
      this.email = "";
      this.select = null;
      this.checkbox = null;
      this.$refs.observer.reset();
    },
    ...mapActions("clubs", ["getAll"]),
  },
  created() {
    this.getAll();
  },
  watch: {
    clubs: function(newClubs, oldClubs) {
      this.allClubs = newClubs;
    },
  },
};
</script>
