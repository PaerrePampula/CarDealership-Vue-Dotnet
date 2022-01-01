<template>
    <div class="container">

        <div v-if="loading" class="loading border">
            .Net backend is currently launching, please wait...
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
                <tbody v-for="car in cars" :key="car.key">
                    <Car @delete-car="deleteCar" :car="car" />
                </tbody>
            </table>
        </div>
    </div>

</template>
<script>
    import Car from './Car.vue'
    export default {
        name: 'Cars',
        emits: ['delete-car'],
        components: {
            Car,
        },
        data() {
            return {
                cars: [],
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
                        this.cars = json.data;
                        return;
                    });
            },
            deleteCar(key) {
                if (confirm('Are you sure you want to delete?')) {
                    console.log(key);
                    this.cars = this.cars.filter((car) => car.key !== key);
                }
            }
        },

    }
</script>