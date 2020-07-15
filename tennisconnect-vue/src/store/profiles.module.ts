import ProfileService from "../services/profile-service";
import IProfile from "@/types/profile";

const state = {
  all: {},
  current: {},
};

const profileService = new ProfileService();

const actions = {
  getAll({ commit }: any) {
    commit("getAllRequest");

    profileService.getAll().then(
      (profiles: IProfile[]) => commit("getAllSuccess", profiles),
      (error) => commit("getAllFailure", error)
    );
  },

  getSingle({ commit }: any, id: Number) {
    commit("getSingleRequest");

    profileService.getByUserId(id).then(
      (profile: IProfile) => {
        commit("getSingleSuccess", profile);
        console.log(profile);
      },
      (error) => commit("getSingleFailure", error)
    );
  },

  delete({ commit }: any, id: any) {
    commit("deleteRequest", id);

    profileService.delete(id).then(
      (profile: IProfile) => commit("deleteSuccess", id),
      (error: { toString: () => any }) =>
        commit("deleteFailure", { id, error: error.toString() })
    );
  },
};

const mutations = {
  getAllRequest(state: { all: { loading: boolean } }) {
    state.all = { loading: true };
  },
  getSingleRequest(state: { current: { loading: boolean } }) {
    state.current = { loading: true };
  },
  getAllSuccess(state: { all: { items: any } }, profiles: any) {
    state.all = { items: profiles };
  },
  getSingleSuccess(state: { current: { items: any } }, profile: IProfile) {
    state.current = { items: profile };
  },
  getAllFailure(state: { all: { error: any } }, error: any) {
    state.all = { error };
  },
  getSingleFailure(state: { current: { error: any } }, error: any) {
    state.current = { error };
  },
  deleteRequest(state: { all: { items: IProfile[] } }, id: number) {
    // add 'deleting:true' property to user being deleted
    state.all.items = state.all.items.map((profile: IProfile) =>
      profile.id === id ? { ...profile, deleting: true } : profile
    );
  },
  deleteSuccess(state: { all: { items: any[] } }, id: number) {
    // remove deleted user from state
    state.all.items = state.all.items.filter(
      (profile: IProfile) => profile.id !== id
    );
  },
  deleteFailure(
    state: { all: { items: any }; items: IProfile[] },
    { id, error }: any
  ) {
    // remove 'deleting:true' property and add 'deleteError:[error]' property to user
    state.all.items = state.items.map((profile: IProfile) => {
      if (profile.id === id) {
        // make copy of user without 'deleting:true' property
        const { deleting, ...profileCopy } = profile;
        // return copy of user with 'deleteError:[error]' property
        return { ...profileCopy, deleteError: error };
      }

      return profile;
    });
  },
};

const getters = {
  getById: (state: { all: { items: any[] } }) => (id: number) => {
    return state.all.items.find((profile) => profile.id === id);
  },
  getByUserId: (state: { all: { items: any[] } }) => (userId: number) => {
    return state.all.items.find((profile) => profile.userModel.id === userId);
  },
};

export const profiles = {
  namespaced: true,
  state,
  actions,
  mutations,
  getters,
};
