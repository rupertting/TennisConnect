import axios from "axios";
import Club from "@/types/club";
import { authHeader } from "@/_helpers/auth-header";

export default class ClubService {
  API_URL = process.env.VUE_APP_API_URL;

  public async getAll(): Promise<Club[]> {
    const requestOptions = {
      method: "GET",
      headers: authHeader(),
    };

    const result = await axios.get(`${this.API_URL}/clubs/`, requestOptions);
    console.log(result.data);
    return result.data;
  }
}
