import './assets/main.css'
import { createApp } from 'vue'
import BootstrapVue3 from 'bootstrap-vue-next'
import App from './App.vue'

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
// Make BootstrapVue available throughout your project
const app = createApp(App);
app.use(BootstrapVue3);
app.mount("#app");
