export function authHeader() {
  // return authorization header with jwt token
  let user = JSON.parse(localStorage.getItem("user"));
  console.log("User token:" + user.token);

  if (user && user.token) {
    return { Authorization: "Bearer " + user.token };
  } else {
    return {};
  }
}

export function getUserId() {
  let user = JSON.parse(localStorage.getItem("user"));

  if (user) {
    return user.id;
  } else {
    return {};
  }
}

export function getToken() {
  // return authorization header with jwt token
  let user = JSON.parse(localStorage.getItem("user"));
  console.log("User token:" + user.token);

  if (user && user.token) {
    return user.token;
  } else {
    return {};
  }
}
