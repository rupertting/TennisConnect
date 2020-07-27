import axios from "axios";
import { authHeader } from "@/_helpers/auth-header";

export default class FriendService {
  API_URL = process.env.VUE_APP_API_URL;

  public async accept(requestedById: number, requestedToId: number) {
    console.log(
      "requestedById:",
      requestedById,
      "requestedToId",
      requestedToId
    );
    const requestOptions = {
      method: "POST",
      headers: authHeader(),
    };

    let res = await axios.post(
      `${this.API_URL}/acceptfriendrequest/requestedById=${requestedById}&requestedToId=${requestedToId}`,
      { requestOptions }
    );

    console.log("friend service res: " + res.status);
    return res.status;
  }

  public async reject(requestedById: number, requestedToId: number) {
    const requestOptions = {
      method: "POST",
      headers: authHeader(),
    };

    let res = await axios.post(
      `${this.API_URL}/rejectfriendrequest/requestedById=${requestedById}&requestedToId=${requestedToId}`,
      { requestOptions }
    );
    return res.status;
  }
}
