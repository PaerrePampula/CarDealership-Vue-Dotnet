<template>
    <div class="post">
        <Cars @delete-car="deleteCar"></Cars>
    </div>
</template>

<script lang="js">
    import Vue from 'vue';
    import Cars from './Cars.vue';
    export default Vue.extend({
        name: 'CarDealership',
        components: {
            Cars,
        },

        methods: {
            deleteCar(key) {
                if (confirm('Are you sure you want to delete?'))
                {

                }
            }
        },
    });
</script>