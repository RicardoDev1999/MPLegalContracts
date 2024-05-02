import { createApp } from "vue";
import "./styles/main.css";

import App from "./App.vue";

import { createWebHistory, createRouter } from "vue-router";

import HomeView from "./views/HomeView.vue";
import LegalContractView from "./views/legal-contracts/Index.vue";
import LegalContractUpdateView from "./views/legal-contracts/UpdateView.vue";
import LegalContractDeleteView from "./views/legal-contracts/DeleteView.vue";
import LegalContractAddView from "./views/legal-contracts/AddView.vue";

const routes = [
    { path: "/", component: HomeView },
    { name: "legal-contract", path: "/legal-contract/:id", component: LegalContractView },
    { name: "legal-contract-update", path: "/legal-contract/:id/update", component: LegalContractUpdateView },
    { name: "legal-contract-delete", path: "/legal-contract/:id/delete", component: LegalContractDeleteView },
    { name: "legal-contract-add", path: "/legal-contract/add", component: LegalContractAddView },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
  scrollBehavior(to, from, savedPosition) {
    if (to.hash) {
      return {
        el: to.hash,
        behavior: "smooth",
      };
    }
  },
});

createApp(App).use(router).mount("#app");
