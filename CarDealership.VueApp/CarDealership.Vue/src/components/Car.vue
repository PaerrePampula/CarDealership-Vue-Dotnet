<template>
    <tr>
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
            <button @click="onDelete(car.key)" class="btn btn-danger btn-sm">Delete</button>
            <a asp-page="Edit" asp-route-id="@item.Id" class="btn btn-success btn-sm text-white">Edit</a>
        </td>
    </tr>
</template>
<script>
    export default {
        name: 'Car',

        props: {
            car: Object,
        },
        methods: {
            onDelete(id)
            {
                this.$emit('delete-car', id)
            },
        },
 }
</script>
