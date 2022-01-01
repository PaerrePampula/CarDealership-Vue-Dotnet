<template>
    <form @submit="onSubmit" class="add-form">
        <div class="form-control">
            <label>Brand</label>
            <input type="text" v-model="brand" name="brand" placeholder="Add brand" />
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
            <input type="text" v-model="year" name="year" placeholder="Add year" />
        </div>
        <input type="submit" value="Save Car" class="btn btn-block" />
    </form>
</template>
<script>
export default {
    name : 'AddCar',
    data()
    {
        return {
            brand: '',
            model: '',
            year: 0,
            key: 0,
        }
    },
}
</script>