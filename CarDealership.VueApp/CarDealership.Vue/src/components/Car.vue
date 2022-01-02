<template>
    <tr class="border" @dblclick="$emit('edit',car.key)">
        <td>
            {{ car.brand }}
        </td>
        <td>
            {{ car.model }}
        </td>
        <td>
            {{ car.year }}
        </td>
        <td>
            <button @click="$emit('delete-car', car.key)" class="btn btn-danger btn-sm">Delete</button>
            <button @click="editToggle" class="btn btn-success btn-sm text-white">Edit</button>
            <UpsertCar v-if="showEdit" v-bind:car="car" v-bind:id="car.key" :isEdit=true @edit-car="editCar"></UpsertCar>
        </td>


    </tr>
</template>
<script>
    import UpsertCar from './UpsertCar.vue'
    export default {
        name: 'Car',
        components: {
            UpsertCar,
        },
        data() {
            return {
                showEdit: false,
            }
        },
        props: {
            car: Object,
        }, 
        methods: {
            editToggle() {
                this.showEdit = !this.showEdit;
            },
            editCar(newCar) {
                this.$emit('edit-car', newCar)
                this.editToggle();

            }
        },

 }
</script>
