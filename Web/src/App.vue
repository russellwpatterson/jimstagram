<template>
  <div id="app" class="main-body">
    <b-navbar type="light">
      <b-container>
        <b-navbar-brand to="/">Jimstagram™</b-navbar-brand>
        <b-nav-text>Being social is so good.</b-nav-text>
        <b-nav-item v-if="username === '' && this.$route.name !== 'login'" to="login" class="login-button">Login</b-nav-item>
        <b-nav-item v-if="username !== ''" to="createPost" class="add-post">+</b-nav-item>
      </b-container>
    </b-navbar>
    <b-container>
      <router-view/>
    </b-container>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { mapState } from 'vuex';

export default Vue.extend({
  computed: mapState([
    'username',
  ]),
});
</script>

<style lang="scss">
.main-body {
  max-width: 600px;
  margin: auto;
}
.add-post {
  list-style: none;
  font-size: 1.5em;
}
.login-button {
  list-style: none;
  font-size: 1.0em;
}
</style>
