import Vue from "vue";
import Vuex from "vuex";

import { profiles } from "./profiles.module";
import { users } from "./users.module";
import { alert } from "./alert.module";
import { account } from "./account.module";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    profiles,
    users,
    alert,
    account,
  },
});
