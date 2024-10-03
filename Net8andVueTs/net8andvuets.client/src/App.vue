<script setup lang="ts">
    import { ref } from 'vue';
    import HelloWorld from './components/HelloWorld.vue';
    import TheWelcome from './components/TheWelcome.vue';
    import Product from './components/Product.vue';

    const activeComponent = ref('TheWelcome');

    const toggleComponent = (componentName: string) => {
        activeComponent.value = componentName;
    };
</script>

<template>
    <header>
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">My App</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" 
                        data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link active" aria-current="page" href="#" @click="toggleComponent('TheWelcome')">Home</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#" @click="toggleComponent('Product')">Products</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <img alt="Vue logo" class="logo" src="./assets/logo.svg" width="125" height="125" />

        <div class="wrapper">
            <HelloWorld msg="You did it!" />
        </div>
    </header>

    <main>
        <!--<Product />-->
        <component :is="activeComponent" />
    </main>
</template>
<script lang="ts">
    //import { ref } from 'vue';
    //import HelloWorld from './components/HelloWorld.vue';
    //import TheWelcome from './components/TheWelcome.vue';
    //import Product from './components/Product.vue';

    //const activeComponent = ref('TheWelcome');

    //const toggleComponent = (componentName: string) => {
    //    activeComponent.value = componentName;
    //};

    export default {
        components: {
            TheWelcome,
            Product
        },
        setup() {
            return {
                activeComponent,
                toggleComponent
            };
        }
    };
</script>
<style>
    /* 添加Bootstrap的CSS */
    @import 'bootstrap/dist/css/bootstrap.css';
</style>

<style scoped>
    header {
        line-height: 1.5;
        margin-bottom: 2rem; /* 添加底部邊距，防止與內容擠在一起 */
    }

    .logo {
        display: block;
        margin: 0 auto 2rem;
    }

    @media (min-width: 1024px) {
        header {
            display: flex;
            flex-direction: column; /* 將header的方向設為列，讓navbar和logo在不同的行 */
            place-items: center; /* 居中對齊元素 */
            padding-right: calc(var(--section-gap) / 2);
        }

        .logo {
            margin: 0 2rem 0 0; /* 調整logo的邊距 */
        }

        header .wrapper {
            display: flex;
            place-items: flex-start;
            flex-wrap: wrap;
            justify-content: center; /* 居中wrapper中的內容 */
        }
    }
</style>