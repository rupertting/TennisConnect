export function authHeader() {
  // return authorization header with jwt token
  const user = JSON.parse(localStorage.getItem("user"));
  console.log("User token:" + user.token);

  if (user && user.token) {
    return { Authorization: "Bearer " + user.token };
  } else {
    return {};
  }
}

export function getUserId() {
  const user = JSON.parse(localStorage.getItem("user"));

  if (user) {
    return user.id;
  } else {
    return {};
  }
}

export function getProfileId() {
  const user = JSON.parse(localStorage.getItem("user"));

  if (user) {
    console.log("profileId: " + user.profileId);
    return user.profileId;
  } else {
    return {};
  }
}

export function getToken() {
  // return authorization header with jwt token
  const user = JSON.parse(localStorage.getItem("user"));
  console.log("User token:" + user.token);

  if (user && user.token) {
    return user.token;
  } else {
    return {};
  }
}
