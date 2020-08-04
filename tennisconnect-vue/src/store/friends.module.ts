import FriendService from "../services/friend-service";
import IFriend from "@/types/friend";

const state = {
  result: {},
  all: {},
};

const friendService = new FriendService();

const actions = {
  connect(
    { commit, dispatch }: any,
    {
      requestedById,
      requestedToId,
    }: { requestedById: number; requestedToId: number }
  ) {
    commit("connectRequest");

    friendService.connect(requestedById, requestedToId).then(
      (statusResult: any) => {
        commit("connectSuccess", statusResult);
        dispatch("profiles/getSingleByProfile", requestedById, {
          root: true,
        });
      },
      (error) => commit("connectFailure", error)
    );
  },

  accept(
    { commit, dispatch }: any,
    {
      requestedById,
      requestedToId,
    }: { requestedById: number; requestedToId: number }
  ) {
    commit("acceptRequest");
    console.log("Friend module id: " + requestedToId);

    friendService.accept(requestedById, requestedToId).then(
      (statusResult: any) => {
        console.log("Friends module status result: " + statusResult);
        commit("acceptSuccess", statusResult);
        dispatch("profiles/getSingleByProfile", requestedToId, {
          root: true,
        });
      },
      (error) => commit("acceptFailure", error)
    );
  },

  reject(
    { commit }: any,
    {
      requestedById,
      requestedToId,
    }: { requestedById: number; requestedToId: number }
  ) {
    commit("rejectRequest");

    friendService.reject(requestedById, requestedToId).then(
      (statusResult: any) => commit("rejectSuccess", statusResult),
      (error) => commit("rejectFailure", error)
    );
  },

  getFriends({ commit }: any, profileId: number) {
    commit("getFriendsRequest");

    friendService.getFriends(profileId).then(
      (friends: IFriend[]) => commit("getFriendsSuccess", friends),
      (error) => commit("getFriendsFailure", error)
    );
  },
};

const mutations = {
  acceptRequest(state: { result: { processing: boolean } }) {
    state.result = { processing: true };
  },
  rejectRequest(state: { result: { processing: boolean } }) {
    state.result = { processing: true };
  },
  connectRequest(state: { result: { processing: boolean } }) {
    state.result = { processing: true };
  },
  getFriendsRequest(state: { friends: { processing: boolean } }) {
    state.friends = { processing: true };
  },
  acceptSuccess(state: { result: { status: any } }, statusResult: any) {
    state.result = { status: statusResult };
  },
  rejectSuccess(state: { result: { status: any } }, statusResult: any) {
    state.result = { status: statusResult };
  },
  connectSuccess(state: { result: { status: any } }, statusResult: any) {
    state.result = { status: statusResult };
  },
  getFriendsSuccess(state: { all: { items: any } }, friends: any) {
    state.all = { items: friends };
  },
  acceptFailure(state: { result: { error: any } }, error: any) {
    state.result = { error };
  },
  rejectFailure(state: { result: { error: any } }, error: any) {
    state.result = { error };
  },
  connectFailure(state: { result: { error: any } }, error: any) {
    state.result = { error };
  },
  getFriendsFailure(state: { result: { error: any } }, error: any) {
    state.result = { error };
  },
};

export const friends = {
  namespaced: true,
  state,
  actions,
  mutations,
};
