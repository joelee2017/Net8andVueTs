<template>
    <div>
        <h1>Product List</h1>
        <table class="table">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="product in products" :key="product.id">
                    <td>{{ product.id }}</td>
                    <td>{{ product.name }}</td>
                    <td>
                        <button class="btn btn-primary" @click="editProduct(product)" data-bs-toggle="modal" data-bs-target="#exampleModal">Edit</button>
                        <button class="btn btn-danger" @click="delProduct(product.id)">Delete</button>
                    </td>
                </tr>
            </tbody>
        </table>
        <button class="btn btn-primary" @click="fetchData">Get Products</button>
        <button class="btn btn-success" @click="editProduct()" data-bs-toggle="modal" data-bs-target="#exampleModal">Create Products</button>
    </div>

    <!-- 彈跳視窗 -->
    <div class="modal" role="dialog" v-if="editingProduct" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel" v-if="editingProduct.id !==0">Edit Product</h5>
                    <h5 class="modal-title" id="exampleModalLabel" v-else>Create Product</h5>
                    <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close" @click="closeEditModal">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="id" v-if="editingProduct.id !=0">Id</label>
                        <input type="text" class="form-control" id="id" v-model="editingProduct.id" v-if="editingProduct.id !=0" readonly>
                        <label for="name">Name</label>
                        <input type="text" class="form-control" id="name" v-model="editingProduct.name">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" @click="closeEditModal">Close</button>
                    <!--<button type="button" class="btn btn-primary" @click="saveProduct">Save changes</button>-->

                    <button type="button" data-bs-dismiss="modal"
                            :class="editingProduct.id !== 0 ? 'btn btn-primary' : 'btn btn-success'"
                            @click="editingProduct.id !== 0 ? updateProduct() : saveProduct()">
                        {{ editingProduct.id !== 0 ? 'Save changes' : 'Create' }}
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import { Modal } from 'bootstrap'; // 引入Modal模組

    type Product = {
        Id: int,
        Name: string
    }[];

    interface Data {
        products: Product[];
        editingProduct: Product | null;
        modalInstance: Modal | null;
    }

    export default {
        data(): Data {
            return {
                products: [], // 初始產品列表
                editingProduct: { id: 0, name: '' }, // 編輯中的產品
                modalInstance: null // 保存 Bootstrap 的 Modal 實例
            };
        },
        methods: {
            // 獲取產品列表
            async fetchData(): Promise<void> {
                try {
                    this.products = [];
                    const response = await fetch('/api/product/GetProducts');
                    if (!response.ok) {
                        throw new Error('Failed to fetch products');
                    }
                    const data = await response.json() as Product[];
                    this.products = data;
                } catch (error) {
                    console.error('Fetch error:', error);
                }
            },
            // 新增產品
            createProduct() {
                this.editingProduct = { name: '' };
            },
            // 編輯產品
            editProduct(product) {
                this.editingProduct = product ? { ...product } : { id: 0, name: '' }; // 保證editingProduct不為null
            },
            closeEditModal() {
                if (this.modalInstance) {
                    this.modalInstance.hide();

                    this.editingProduct = { id: 0, name: '' }; // 重置編輯產品
                }
            },
            // 新增產品 (POST)
            async saveProduct() {
                try {
                    const response = await fetch('/api/product/PostProduct', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(this.editingProduct)
                    });

                    if (!response.ok) {
                        throw new Error('Failed to post product');
                    }

                    // 顯示成功訊息
                    alert('Operation completed successfully!');

                    // 重新加載產品列表
                    await this.fetchData();

                    // 關閉模態框
                    this.closeEditModal();
                } catch (error) {
                    console.error(error);
                }
            },
            async updateProduct() {
                try {
                    const response = await fetch('/api/product/PutProduct', {
                        method: 'PUT',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(this.editingProduct)
                    });

                    if (!response.ok) {
                        throw new Error('Failed to post product');
                    }

                    // 顯示成功訊息
                    alert('Operation completed successfully!');

                    // 重新加載產品列表
                    await this.fetchData();

                    // 關閉模態框
                    this.closeEditModal();
                } catch (error) {
                    console.error(error);
                }
            },
            // 刪除產品 (POST)
            async delProduct(productId: number) {

                console.log(JSON.stringify({ id: productId }));
                try {
                    const response = await fetch('/api/product/DeleteProduct', {
                        method: 'POST', // 使用POST方法傳遞產品ID來刪除
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(productId) // 將產品ID傳遞給後端
                    });

                    if (!response.ok) {
                        throw new Error('Failed to delete product');
                    }

                    alert('Product deleted successfully!');
                    await this.fetchData(); // 重新獲取產品列表
                } catch (error) {
                    console.error('Delete error:', error);
                }
            }
        },
        mounted() {
            this.fetchData();
        }
    };
</script>

<style>
    /* 添加Bootstrap的CSS */
    @import 'bootstrap/dist/css/bootstrap.css';
</style>