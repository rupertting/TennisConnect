import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import Home from "../views/Home.vue";
import Login from "../views/Login.vue";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/login",
    name: "Login",
    component: Login,
  },
  {
    path: "/createprofile",
    name: "CreateProfile",
    component: () =>
      import(
        /*webpackChunkName: "CreateProfile" */ "../views/CreateProfile.vue"
      ),
  },
  {
    path: "/register",
    name: "Register",
    component: () =>
      import(/*webpackChunkName: "Register" */ "../views/Register.vue"),
  },
  {
    path: "/profiles",
    name: "Profiles",
    component: () =>
      import(/* webpackChunkName: "Profiles" */ "../views/Profiles.vue"),
  },
  {
    path: "/profiles/:id",
    name: "Profile",
    component: () =>
      import(/* webpackChunkName: "Profile" */ "../views/Profile.vue"),
    props: true,
  },
  {
    path: "/myprofile/:userId",
    name: "MyProfile",
    component: () =>
      import(/* webpackChunkName: "MyProfile" */ "../views/MyProfile.vue"),
    props: true,
  },
  {
    path: "/unauthorized",
    name: "Unauthorized",
    component: () =>
      import(
        /* webpackChunkName: "Unauthorized" */ "../views/Unauthorized.vue"
      ),
  },

  // otherwise redirect to home
  {
    path: "*",
    redirect: "/",
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

router.beforeEach((to, from, next) => {
  // redirect to login page if not logged in and trying to access a restricted page
  const publicPages = ["Login", "Register"];
  const authRequired = !publicPages.includes(to.name);
  const loggedIn = localStorage.getItem("user");

  if (authRequired && !loggedIn) {
    return next("Login");
  }
  next();
});

export default router;
