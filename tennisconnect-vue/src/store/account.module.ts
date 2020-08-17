import UserService from "@/services/user-service";
import router from "@/router/index";

const user = JSON.parse(localStorage.getItem("user"));
const state = user
  ? { status: { loggedIn: true }, user }
  : { status: {}, user: null };

const userService = new UserService();

const actions = {
  login({ dispatch, commit }, { emailaddress, password }) {
    commit("loginRequest", { emailaddress });

    userService.login(emailaddress, password).then(
      (user) => {
        commit("loginSuccess", user);
        // console.log(user);
        // console.log(user.id);
        //router.push({ name: "Profiles" });
        evaluateRoute(user);
      },
      (error) => {
        commit("loginFailure", error);
        dispatch("alert/error", error, { root: true });
      }
    );
  },
  logout({ commit }) {
    userService.logout();
    commit("logout");
  },
  register({ dispatch, commit }, user) {
    commit("registerRequest", user);

    userService.register(user).then(
      (user) => {
        commit("registerSuccess", user);
        router.push("/login");
        setTimeout(() => {
          // display success message after route change completes
          dispatch("alert/success", "Registration successful", { root: true });
        });
      },
      (error) => {
        commit("registerFailure", error);
        dispatch("alert/error", error, { root: true });
      }
    );
  },
};

function evaluateRoute(user: any) {
  if (user.profileId == 0) {
    router.push("/createprofile");
  } else {
    router.push({ name: "MyProfile", params: { userId: user.id } });
  }
}

const mutations = {
  loginRequest(state, user) {
    state.status = { loggingIn: true };
    state.user = user;
  },
  loginSuccess(state, user) {
    state.status = { loggedIn: true };
    state.user = user;
  },
  loginFailure(state) {
    state.status = {};
    state.user = null;
  },
  logout(state) {
    state.status = {};
    state.user = null;
  },
  registerRequest(state, user) {
    state.status = { registering: true };
  },
  registerSuccess(state, user) {
    state.status = {};
  },
  registerFailure(state, error) {
    state.status = {};
  },
};

export const account = {
  namespaced: true,
  state,
  actions,
  mutations,
};
