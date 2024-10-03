import './assets/main.css'
// src/main.ts
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap';

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'; // �ޤJ router

//createApp(App).mount('#app')
const app = createApp(App);
app.use(router); // �ϥ� router
app.mount('#app');