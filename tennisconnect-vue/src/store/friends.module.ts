import FriendService from "../services/friend-service";

const state = {
  result: {},
};

const friendService = new FriendService();

const actions = {
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
};

const mutations = {
  acceptRequest(state: { result: { processing: boolean } }) {
    state.result = { processing: true };
  },
  rejectRequest(state: { result: { processing: boolean } }) {
    state.result = { processing: true };
  },
  acceptSuccess(state: { result: { status: any } }, statusResult: any) {
    state.result = { status: statusResult };
  },
  rejectSuccess(state: { result: { status: any } }, statusResult: any) {
    state.result = { status: statusResult };
  },
  acceptFailure(state: { result: { error: any } }, error: any) {
    state.result = { error };
  },
  rejectFailure(state: { result: { error: any } }, error: any) {
    state.result = { error };
  },
};

export const friends = {
  namespaced: true,
  state,
  actions,
  mutations,
};
