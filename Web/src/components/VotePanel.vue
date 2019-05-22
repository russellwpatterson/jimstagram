<template>
  <b-col>
    <b-row>
      <VoteButton
        image="images/so-good.png"
        altText="So good."
        :voteCount="soGoods"
        @increment-count="onSoGood"
      />
      <VoteButton
        image="images/thats-decent.jpg"
        altText="That's decent."
        :voteCount="thatsDecents"
        @increment-count="onThatsDecent"
      />
      <VoteButton
        image="images/not-so-good.png"
        altText="Not so good."
        :voteCount="notSoGoods"
        @increment-count="onNotSoGood"
      />
    </b-row>
  </b-col>
</template>

<script lang="ts">
import Vue from 'vue';
import VoteButton from './VoteButton.vue';

export default Vue.extend({
  components: {
    VoteButton,
  },
  props: {
    soGoods: {
      type: Number,
    },
    thatsDecents: {
      type: Number,
    },
    notSoGoods: {
      type: Number,
    },
  },
  methods: {
    onSoGood(): void {
      this.$emit('increment-so-goods');
    },
    onThatsDecent(): void {
      this.$emit('increment-decents');
    },
    onNotSoGood(): void {
      this.$emit('increment-not-so-goods');
    },
  },
});
</script>
