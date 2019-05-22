<template>
    <b-row>
        <b-col>
            <b-img rounded="circle" 
                :src="image" 
                :alt="altText" 
                @click="onIncrement" 
                width="40px" 
                height="40px" 
                class="vote-button" />
            <br />
            <div class="j-counter">{{voteCount}}</div>
        </b-col>
    </b-row>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
  props: {
    image: {
      type: String,
    },
    voteCount: {
      type: Number,
    },
    altText: {
      type: String,
    },
  },
  methods: {
    onIncrement(): void {
        this.$emit('increment-count');
    },
  },
});
</script>

<style lang="scss" scoped>
.j-counter {
    font-size: 0.7em;
    width: 100%;
    text-align: center;
}

.vote-button {
    padding: 3px;
}
</style>
