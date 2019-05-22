<template>
  <div>
    <b-card :title="message" :img-src="displayImageUrl" :img-alt="username" img-top>
      <b-card-text>
        <em>- {{username}}</em>
        <br />
        <br />
        <VotePanel
          :soGoods="soGoods"
          :thatsDecents="thatsDecents"
          :notSoGoods="notSoGoods"
          @increment-so-goods="onSoGood"
          @increment-decents="onThatsDecent"
          @increment-not-so-goods="onNotSoGood"
        />
      </b-card-text>
    </b-card>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import VotePanel from './VotePanel.vue';
import { SO_GOOD, THATS_DECENT, NOT_SO_GOOD } from '../types';

export default Vue.extend({
  components: {
    VotePanel,
  },
  props: {
    id: {
      type: Number,
    },
    username: {
      type: String,
    },
    imageFilename: {
      type: String,
    },
    message: {
      type: String,
    },
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
  computed: {
    displayImageUrl(): string {
      return `/uploads/${this.imageFilename}`;
    },
  },
  methods: {
    onSoGood(): void {
      this.$store.dispatch(SO_GOOD, { postId: this.id });
    },
    onThatsDecent(): void {
      this.$store.dispatch(THATS_DECENT, { postId: this.id });
    },
    onNotSoGood(): void {
      this.$store.dispatch(NOT_SO_GOOD, { postId: this.id });
    },
  },
});
</script>