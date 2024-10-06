<script setup lang="ts">
    import HelloWorld from './components/HelloWorld.vue';
    import TheWelcome from './components/TheWelcome.vue';
    import Product from './components/Product.vue';
    import feather from 'feather-icons';
    import { onMounted } from 'vue';

    onMounted(() => {
        feather.replace();
    });
</script>

<template>
    <!-- Navbar -->
    <nav class="navbar navbar-dark sticky-top bg-dark flex-md-nowrap p-0 shadow">
        <a class="navbar-brand col-md-3 col-lg-2 me-0 px-3" href="#">My Dashboard</a>
        <button class="navbar-toggler position-absolute d-md-none collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#sidebarMenu" aria-controls="sidebarMenu" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
    </nav>
    <div class="container-fluid">
        <div class="row">
            <!-- Sidebar -->
            <nav id="sidebarMenu" class="col-md-3 col-lg-2 d-md-block bg-light sidebar collapse">
                <div class="position-sticky pt-3">
                    <ul class="nav flex-column">
                        <li class="nav-item">
                            <router-link to="/" class="nav-link active" aria-current="page">
                                <span data-feather="home"></span>
                                Dashboard
                            </router-link>
                        </li>
                        <li class="nav-item">
                            <router-link to="/products" class="nav-link">
                                <span data-feather="file"></span>
                                Products
                            </router-link>
                        </li>
                        <li class="nav-item">
                            <router-link to="/reports" class="nav-link">
                                <span data-feather="bar-chart-2"></span>
                                Reports
                            </router-link>
                        </li>
                    </ul>
                </div>
            </nav>

            <!-- Main Content -->
            <main class="col-md-9 ms-sm-auto col-lg-10 px-md-4 main-content">
                <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
                    <h1 class="h2">Dashboard</h1>
                </div>
                <router-view></router-view> <!-- 這裡顯示路由對應的內容 -->
            </main>
        </div>
    </div>
</template>

<style scoped>
    .nav-link {
        font-weight: 500;
        color: #333;
    }

        .nav-link .feather {
            margin-right: 4px;
            color: #727272;
        }

        .nav-link.active {
            color: #007bff;
        }

            .nav-link:hover .feather,
            .nav-link.active .feather {
                color: inherit;
            }

    .navbar {
        margin-bottom: 1rem;
        margin: 0;
    }

    .container-fluid {
        flex-grow: 1;
    }

    /* 媒體查詢 */
    @media (max-width: 768px) {
        .sidebar {
            height: auto; /* 自動調整高度 */
        }
    }

    /* 響應式設計，確保小螢幕時 navbar 和 sidebar 表現良好 */
    @media (max-width: 767px) {
        .navbar-toggler {
            margin-right: 1rem; /* 調整折疊按鈕的位置，避免與標題重疊 */
        }

        .navbar-brand {
            width: 100%;
            text-align: center; /* 確保品牌名稱居中顯示 */
        }

        /* 讓 sidebar 在小螢幕時隱藏，通過 navbar 的摺疊按鈕顯示 */
        #sidebarMenu {
            top: 56px;
        }

        .main-content {
            padding-left: 0; /* 在小螢幕下取消左邊的 margin */
        }
    }

    @media (min-width: 768px) {
        /* Sidebar 在較大螢幕上自動展開 */
        .sidebar {
            display: block;
        }
    }
</style>
