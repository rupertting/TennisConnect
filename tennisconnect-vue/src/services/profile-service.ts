import axios from "axios";
import IProfile from "@/types/profile";
import { authHeader } from "@/_helpers/auth-header";

export default class ProfileService {
  API_URL = process.env.VUE_APP_API_URL;

  public async getAll(): Promise<IProfile[]> {
    const requestOptions = {
      method: "GET",
      headers: authHeader(),
    };

    const result = await axios.get(`${this.API_URL}/profiles/`, requestOptions);
    console.log(result.data);
    return result.data;
  }

  public async getByUserId(userId: number): Promise<IProfile> {
    const requestOptions = {
      method: "GET",
      headers: authHeader(),
    };

    const result = await axios.get(
      `${this.API_URL}/profile/userId=${userId}`,
      requestOptions
    );
    console.log(result.data);
    return result.data;
  }

  public async getByProfileId(profileId: number): Promise<IProfile> {
    const requestOptions = {
      method: "GET",
      headers: authHeader(),
    };

    const result = await axios.get(
      `${this.API_URL}/profile/profileId=${profileId}`,
      requestOptions
    );
    console.log(result.data);
    return result.data;
  }

  public async delete(id: any): Promise<IProfile> {
    throw new Error("Method not implemented.");
  }
}
