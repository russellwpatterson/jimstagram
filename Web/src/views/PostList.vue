<template>
  <div class="post-list" v-if="postCount > 0">
    <div v-for="post in posts" v-bind:key="post.id">
      <Post
        :id="post.id"
        :username="post.username"
        :message="post.message"
        :imageFilename="post.imageFilename"
        :soGoods="post.soGoods"
        :thatsDecents="post.thatsDecents"
        :notSoGoods="post.notSoGoods"
      />
      <Spacer />
    </div>
    <Spacer />
    <Spacer />
    <Spacer />
    <Spacer />
    <Spacer />
    <Footer />
  </div>
  <div v-else class="jimstagram-empty">
    No one has posted anything to Jimstagram yet. Not so good.
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import Post from '@/components/Post.vue';
import Spacer from '@/components/Spacer.vue';
import Footer from '@/components/Footer.vue';
import { mapActions, mapGetters } from 'vuex';
import * as types from '@/types';

export default Vue.extend({
  components: {
    Post,
    Spacer,
    Footer,
  },
  computed: mapGetters({
    posts: types.GET_POSTS,
    postCount: types.GET_POSTS_COUNT,
  }),
  methods: {
    ...mapActions({
      fetchPosts: types.FETCH_POSTS,
    }),
  },
  created() {
    this.fetchPosts();
  },
});
</script>

<style scoped>
.jimstagram-empty {
  text-align: center;
}
</style>
