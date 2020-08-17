import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import {
  ValidationProvider,
  extend,
  ValidationObserver,
  setInteractionMode,
} from "vee-validate";
import { required, email, max } from "vee-validate/dist/rules";
import vuetify from "./plugins/vuetify";

setInteractionMode("eager");

extend("required", {
  ...required,
  message: "{_field_} cannot be empty",
});

extend("min", {
  validate(value, args) {
    return value.length >= args.length;
  },
  params: ["length"],
});

extend("max", {
  ...max,
  message: "{_field_} may not be greater than {length} characters",
});

extend("email", {
  ...email,
  message: "Email must be valid",
});

Vue.component("ValidationProvider", ValidationProvider);
Vue.component("ValidationObserver", ValidationObserver);
Vue.config.productionTip = false;

new Vue({
  router,
  store,
  vuetify,
  render: (h) => h(App),
}).$mount("#app");
