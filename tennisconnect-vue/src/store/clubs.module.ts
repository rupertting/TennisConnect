import ClubService from "../services/club-service";
import Club from "@/types/club";

const state = {
  all: {},
};

const clubService = new ClubService();

const actions = {
  getAll({ commit }: any) {
    commit("getClubsRequest");

    clubService.getAll().then(
      (clubs: Club[]) => commit("getClubsSuccess", clubs),
      (error: any) => commit("getClubsFailure", error)
    );
  },
};

const mutations = {
  getClubsRequest(state: { all: { processing: boolean } }) {
    state.all = { processing: true };
  },
  getClubsSuccess(state: { all: { items: any } }, clubs: any) {
    state.all = { items: clubs };
  },
  getClubsFailure(state: { all: { error: any } }, error: any) {
    state.all = { error };
  },
};

export const clubs = {
  namespaced: true,
  state,
  actions,
  mutations,
};
