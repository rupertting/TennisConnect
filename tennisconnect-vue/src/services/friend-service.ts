import axios from "axios";
import { authHeader } from "@/_helpers/auth-header";
import { getToken } from "@/_helpers/auth-header";
import IFriend from "@/types/friend";

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

  public async connect(requestedById: number, requestedToId: number) {
    console.log(
      "Connect requestedById:",
      requestedById,
      "requestedToId",
      requestedToId
    );

    const headers = {
      Authorization: "Bearer " + getToken(),
    };

    const payload = {};

    let res = await axios.post(
      `${this.API_URL}/friendrequest/requestedById=${requestedById}&requestedToId=${requestedToId}`,
      payload,
      { headers }
    );

    console.log("friend service res: " + res.status);
    return res.status;
  }

  public async getFriends(profileId: number): Promise<IFriend[]> {
    const requestOptions = {
      method: "GET",
      headers: authHeader(),
    };

    let result = await axios.get(
      `${this.API_URL}/getfriends/profileId=${profileId}`,
      requestOptions
    );
    console.log(result.data);
    return result.data;
  }

  public async confirmIfFriends(profileId: number, friendId: number) {
    var friends = this.getFriends(profileId);

    (await friends).forEach(function(friend) {
      if (friend.FriendId === friendId) {
        return true;
      }
      return false;
    });
  }
}
