<template>
    <div class="container">

        <div v-if="loading" class="loading border">
            .Net API backend is currently launching, please wait...
        </div>
        <div v-if="post" class="content container">
            <button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#collapseAdd" aria-expanded="false" aria-controls="collapseAdd" style="margin:5px;">
                Add a new car
            </button>
            <UpsertCar class="collapse" id="collapseAdd" @add-car="addCar" :isEdit=false></UpsertCar>


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
                    <Car @delete-car="deleteCar" @edit-car="editCar" :car="car" />
                </tbody>
            </table>
        </div>
    </div>

</template>
<script>
    import Car from './Car.vue'
    import UpsertCar from './UpsertCar.vue'
    export default {
        name: 'Cars',
        emits: ['delete-car', 'add-car', 'edit-car'],
        components: {
            Car,
            UpsertCar,
        },
        data() {
            return {
                cars: [],
                loading: false,
                post: null
            };
        },
        async created() {
            // fetch the data when the view is created and the data is
            // already being observed
            await this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData() {
                this.post = null;
                this.loading = true;
                //For whatever reason, the solution is unable
                //to proxy /api/Car... to the target of localhost at 5001, so
                //I will directly fetch from the url, even though I should
                //Really use the config as my advantage to reroute this api call.
                fetch('https://localhost:5001/Car')
                    .then(res => res.json())
                    .then(json => {
                        this.post = json;
                        this.loading = false;
                        this.cars = json.data
                        return
                    });
            },
            fetchCar(id) {
                fetch(`https://localhost:5001/Car/{$id}`)
                    .then(res => res.json())
                    .then(json => {
                        return json.data;
                    });
            },
            async deleteCar(key) {
                if (confirm('Are you sure you want to delete?')) {
                    console.log(key);
                    const response = await fetch(`https://localhost:5001/Car/${key}`, {
                        method: 'DELETE'
                    })
                    response.status === 201 ? this.cars = this.cars.filter((car) => car.key !== key) : alert("Error in deleting")

                }
            },
            async addCar(car) {
                const response = await fetch("https://localhost:5001/Car", {
                    method: 'POST',
                    headers:
                    {
                        'Content-type': 'application/json',

                    },
                    body: JSON.stringify(car)

                })

                const data = await response.json()
                this.cars = [...this.cars, data]
            },
            async editCar(car) {
                await fetch(`https://localhost:5001/Car/${car.key}`, {
                    method: 'PUT',
                    headers:
                    {
                        'Content-type': 'application/json',

                    },
                    body: JSON.stringify(car)

                })
                await this.fetchData()
            }
        },

    }
</script>