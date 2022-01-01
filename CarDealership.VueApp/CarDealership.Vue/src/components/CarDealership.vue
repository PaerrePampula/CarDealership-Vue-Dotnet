<template>
    <div class="post">
        <Cars ></Cars>
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

        },
    });
</script>