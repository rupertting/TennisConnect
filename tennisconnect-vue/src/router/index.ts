import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import Home from "../views/Home.vue";
import Profiles from "../views/Profiles.vue";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/profiles",
    name: "Profiles",
    component: Profiles,
  },
  {
    path: "/profiles/:id",
    name: "Profile",
    component: () =>
    import(
      /* webpackChunkName: "Profile" */ "../views/Profile"
    ),
    props: true
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
