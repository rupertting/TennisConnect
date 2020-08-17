import Vue from "vue";
import Vuex from "vuex";

import { profiles } from "./profiles.module";
import { users } from "./users.module";
import { alert } from "./alert.module";
import { account } from "./account.module";
import { friends } from "./friends.module";
import { clubs } from "./clubs.module";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    profiles,
    users,
    alert,
    account,
    friends,
    clubs,
  },
});
