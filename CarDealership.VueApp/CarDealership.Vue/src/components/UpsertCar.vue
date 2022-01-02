<template>
    <form @submit="onSubmit" class="add-form">
        <div class="form-control">
            <label>Brand</label>
            <input type="text"
                   v-model="brand"
                   name="brand"
                   placeholder="Add brand" />
        </div>
        <div class="form-control">
            <label>Model</label>
            <input type="text"
                   v-model="model"
                   name="model"
                   placeholder="Car model" />
        </div>
        <div class="form-control form-control-check">
            <label>Year</label>
            <input type="text"
                   v-model="year"
                   name="year"
                   placeholder="Add year" />
        </div>
        <input type="submit" value="Save Car" class="btn btn-block" />
    </form>
</template>
<script>
    export default {
        name: 'UpsertCar',
        props: {
            isEdit: Boolean,
            car: Object,
        },
        data() {
            return {

                brand: '',
                model: '',
                year: 0,


            }
        },
        created() {
            if (this.car != null)
            {
                this.brand = this.car.brand;
                this.model = this.car.model;
                this.year = this.car.year;
            }
        },
        methods:
        {
            onSubmit(event) {
                //Prevent the website from reloading during the submission
                event.preventDefault();
                //Make sure that all fields are filled in.
                if (!this.brand || !this.model || !this.year) {
                    alert('Please fill in all required fields!')
                    return
                }

                //Construct the car object
                const newCar = {
                    key: this.isEdit ? this.car.key : null,
                    brand: this.brand,
                    model: this.model,
                    year: this.year,
                }
                //the new car object is set up, it needs to be emitted to the cars component above.
                if (!this.isEdit) {
                    this.$emit('add-car', newCar)
                }
                else {
                    this.$emit('edit-car', newCar)
                }
                //Reset the form fields
                this.brand = '';
                this.model = '';
                this.year = 0;
            },
        },
    }
</script>