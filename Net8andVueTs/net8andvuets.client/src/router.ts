// src/router.ts
import { createRouter, createWebHistory } from 'vue-router';
import TheWelcome from './components/TheWelcome.vue';
import Product from './components/Product.vue';

const routes = [
    { path: '/', component: TheWelcome, name: 'home' },
    { path: '/products', component: Product, name: 'products' },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;