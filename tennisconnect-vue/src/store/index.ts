import Vue from "vue";
import Vuex from "vuex";

import { profiles } from "./profiles.module";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    profiles,
  },
});
