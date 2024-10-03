import './assets/main.css'
// src/main.ts
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap';

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'; // 引入 router

//createApp(App).mount('#app')
const app = createApp(App);
app.use(router); // 使用 router
app.mount('#app');