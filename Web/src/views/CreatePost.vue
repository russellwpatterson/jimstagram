<template>
  <div class="createPost">
    <h4>Create a New Post</h4>

    <b-form @submit.prevent="onCreatePost">
      <b-form-group
        id="message-input-group"
        label="Post Text:"
        label-for="message"
      >
        <b-form-input
          id="message-input"
          v-model="form.message"
          type="text"
          required
          placeholder="Enter message text"
        />
      </b-form-group>
      <b-form-group
        id="file-input-group"
        label="Image:"
        label-for="file"
      >
        <b-form-file
          id="file-input"
          v-model="form.file"
          :state="Boolean(form.file)"
          placeholder="Choose a file..."
          drop-placeholder="Drop a file here..."
          accept=".jpg, .png, .gif, .jpeg"
        />
      </b-form-group>
      <b-button type="submit" variant="primary">Create Post</b-button>
    </b-form>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { UPLOAD_IMAGE, CREATE_POST } from '../types';

export default Vue.extend({
  data() {
    return {
      form: {
        file: '',
        message: '',
      },
    };
  },
  methods: {
    async onCreatePost(): Promise<void> {
      await this.$store.dispatch(UPLOAD_IMAGE, this.form.file);
      return this.$store.dispatch(CREATE_POST, {
        message: this.form.message,
        imageFilename: this.$store.state.uploadFilename,
      });
    },
  },
});
</script>