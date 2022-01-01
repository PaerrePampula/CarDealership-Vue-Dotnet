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
            <a @click="toggleEdit(car.key)" class="btn btn-success btn-sm text-white">Edit</a>
        </td>
    </tr>
</template>
<script>
    export default {
        name: 'Car',

        props: {
            car: Object,
        },

 }
</script>
