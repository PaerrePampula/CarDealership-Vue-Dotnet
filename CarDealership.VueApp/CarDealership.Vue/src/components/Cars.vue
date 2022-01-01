<template>
    <div class="container">
        <div v-if="loading" class="loading">
            Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
        </div>

        <div v-if="post" class="content container">
            <table class="table table-striped border">
                <tr class="table-secondary">
                    <th>
                        <label>Brand</label>
                    </th>
                    <th>
                        <label>Model</label>
                    </th>
                    <th>
                        <label>Year</label>
                    </th>
                    <th>

                    </th>
                </tr>
                <tbody v-for="car in post.data" :key="car.key">
                    <Car @delete-car="$emit('delete-car', car.key)" :car="car" />
                </tbody>
            </table>
        </div>
    </div>

</template>
<script>
    import Car from './Car.vue'
    export default {
        name: 'Cars',
        props: {
            cars: Array,
        },
        components: {
            Car,
        },
        data() {
            return {
                loading: false,
                post: null
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData() {
                this.post = null;
                this.loading = true;

                fetch('https://localhost:44301/api/Car')
                    .then(res => res.json())
                    .then(json => {
                        this.post = json;
                        this.loading = false;
                        return;
                    });
            },
        },
        emits: ['delete-car'],
    }
</script>