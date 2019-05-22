<template>
  <div class="login-form">
    <b-form @submit.prevent="onSubmit">
      <b-form-group>
        <b-form-input
        id="username"
        v-model="username"
        type="text" placeholder="Username"
        required />
      </b-form-group>
      <b-form-group>
      <b-form-input
        id="password"
        v-model="password"
        type="password" placeholder="Password"
        required />
      </b-form-group>
      <b-button type="submit" variant="primary">Login</b-button>
    </b-form>    
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import * as types from '../types';

export default Vue.extend({
  data() {
    return {
      username: '',
      password: '',
    };
  },
  methods: {
    onSubmit(): void {
      if (this.username && this.password) {
        this.$store.dispatch(types.LOGIN, { username: this.username, password: this.password, nextRoute: '/' });
        return;
      } else {
        alert('Please enter a username and password.');
      }
    },
  },
  mounted() {
    this.$store.commit(types.CLEAR_USER);
  },
});
</script>

<style scoped>
.login-form {
  text-align: center;
  max-width: 50%;
  margin: auto;
}
</style>
