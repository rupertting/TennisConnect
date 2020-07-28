import axios from "axios";
import { authHeader } from "@/_helpers/auth-header";
import { getToken } from "@/_helpers/auth-header";

export default class FriendService {
  API_URL = process.env.VUE_APP_API_URL;

  public async accept(requestedById: number, requestedToId: number) {
    console.log(
      "requestedById:",
      requestedById,
      "requestedToId",
      requestedToId
    );

    const headers = {
      Authorization: "Bearer " + getToken(),
    };

    const payload = {};

    let res = await axios.post(
      `${this.API_URL}/acceptfriendrequest/requestedById=${requestedById}&requestedToId=${requestedToId}`,
      payload,
      { headers }
    );

    console.log("friend service res: " + res.status);
    return res.status;
  }

  public async reject(requestedById: number, requestedToId: number) {
    const headers = {
      Authorization: "Bearer " + getToken(),
    };

    const payload = {};

    let res = await axios.post(
      `${this.API_URL}/rejectfriendrequest/requestedById=${requestedById}&requestedToId=${requestedToId}`,
      payload,
      { headers }
    );
    return res.status;
  }
}
