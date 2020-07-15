import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import { ValidationProvider, extend, ValidationObserver } from "vee-validate";
import { required } from "vee-validate/dist/rules";

extend("required", {
  ...required,
  message: "This field is required",
});

extend("min", {
  validate(value, args) {
    return value.length >= args.length;
  },
  params: ["length"],
});

Vue.component("ValidationProvider", ValidationProvider);
Vue.component("ValidationObserver", ValidationObserver);
Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount("#app");
