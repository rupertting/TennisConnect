import { authHeader } from "@/_helpers/auth-header";

export default class UserService {
  API_URL = process.env.VUE_APP_API_URL;

  public async login(emailaddress, password) {
    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ emailaddress, password }),
    };

    return fetch(`${this.API_URL}/users/authenticate`, requestOptions)
      .then(this.handleResponse)
      .then((user) => {
        // login successful if there's a jwt token in the response
        if (user.token) {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem("user", JSON.stringify(user));
        }

        return user;
      });
  }

  public logout() {
    // remove user from local storage to log user out
    localStorage.removeItem("user");
  }

  public async register(user) {
    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(user),
    };

    return fetch(`${this.API_URL}/users/register`, requestOptions).then(
      this.handleResponse
    );
  }

  public async getAll() {
    const requestOptions = {
      method: "GET",
      headers: authHeader(),
    };

    return fetch(`${this.API_URL}/users`, requestOptions).then(
      this.handleResponse
    );
  }

  public async getById(id) {
    const requestOptions = {
      method: "GET",
      headers: authHeader(),
    };

    return fetch(`${this.API_URL}/users/${id}`, requestOptions).then(
      this.handleResponse
    );
  }

  public async update(user) {
    const requestOptions = {
      method: "PUT",
      headers: { ...authHeader(), "Content-Type": "application/json" },
      body: JSON.stringify(user),
    };

    return fetch(`${this.API_URL}/users/${user.id}`, requestOptions).then(
      this.handleResponse
    );
  }

  // prefixed function name with underscore because delete is a reserved word in javascript
  public async _delete(id) {
    const requestOptions = {
      method: "DELETE",
      headers: authHeader(),
    };

    return fetch(`${this.API_URL}/users/${id}`, requestOptions).then(
      this.handleResponse
    );
  }

  public async handleResponse(response) {
    return response.text().then((text) => {
      const data = text && JSON.parse(text);
      if (!response.ok) {
        if (response.status === 401) {
          // auto logout if 401 response returned from api
          this.logout();
          location.reload(true);
        }

        const error = (data && data.message) || response.statusText;
        return Promise.reject(error);
      }

      return data;
    });
  }
}
