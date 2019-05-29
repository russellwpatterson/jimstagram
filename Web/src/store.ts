import Vue from 'vue';
import Vuex from 'vuex';
import axios from 'axios';
import {
  FETCH_POSTS,
  SET_POSTS,
  GET_POSTS,
  GET_POSTS_COUNT,
  INCREMENT_SO_GOODS,
  INCREMENT_THATS_DECENTS,
  INCREMENT_NOT_SO_GOODS,
  SO_GOOD,
  THATS_DECENT,
  NOT_SO_GOOD,
  LOGIN,
  SET_ACCESS_TOKEN,
  CREATE_POST,
  DISPLAY_POST,
  SET_USERNAME,
  UPLOAD_IMAGE,
  SET_CURRENT_FILENAME,
} from './types';
import router from './router';

Vue.use(Vuex);

const BASE_API = 'http://localhost/api';
const POSTS_API = `${BASE_API}/posts`;
const AUTH_API = `${BASE_API}/auth`;
const LIKES_API = `${BASE_API}/likes`;
const IMAGES_API = `${BASE_API}/images`;


export default new Vuex.Store({
  state: {
    posts: [] as any[],
    accessToken: localStorage.getItem('jimstagram-access-token') || '',
    username: localStorage.getItem('jimstagram-username') || '',
    uploadFilename: '',
  },
  getters: {
    [GET_POSTS](state, getters) {
      return state.posts;
    },
    [GET_POSTS_COUNT](state, getters) {
      return getters[GET_POSTS].length;
    },
  },
  mutations: {
    [DISPLAY_POST](state, post) {
      state.posts.unshift(post);
    },
    [SET_POSTS](state, posts) {
      state.posts = posts;
    },
    [SET_ACCESS_TOKEN](state, { access_token }) {
      state.accessToken = access_token;
      localStorage.setItem('jimstagram-access-token', access_token);
    },
    [SET_USERNAME](state, username) {
      state.username = username;
      localStorage.setItem('jimstagram-username', username);
    },
    [SET_CURRENT_FILENAME](state, uploadFilename) {
      state.uploadFilename = uploadFilename;
    },
    [INCREMENT_SO_GOODS](state, postId) {
      const post = state.posts.find((p) => p.id === postId);

      if (post) {
        post.soGoods++;
      }
    },
    [INCREMENT_THATS_DECENTS](state, postId) {
      const post = state.posts.find((p) => p.id === postId);

      if (post) {
        post.thatsDecents++;
      }
    },
    [INCREMENT_NOT_SO_GOODS](state, postId) {
      const post = state.posts.find((p) => p.id === postId);

      if (post) {
        post.notSoGoods++;
      }
    },
  },
  actions: {
    async [FETCH_POSTS]({ commit }) {
      const response = await axios.get(POSTS_API);
      return commit(SET_POSTS, response.data);
    },
    async [CREATE_POST]({ commit, state }, post) {
      if (!state.accessToken) {
        alert('You have to login to do that.');
        return;
      }

      const response = await axios.post(POSTS_API, post, {
        headers: { Authorization: `Bearer ${state.accessToken}` },
      });
      post.id = response.data;
      await commit(DISPLAY_POST, post);

      router.push('/');
    },
    async [SO_GOOD]({ commit, state }, { postId }) {
      if (!state.accessToken) {
        alert('You have to login to do that.');
        return;
      }

      const response = await axios.post(`${LIKES_API}/${postId}/sogood`, null, {
        headers: { Authorization: `Bearer ${state.accessToken}` },
      });
      return commit(INCREMENT_SO_GOODS, postId);
    },
    async [THATS_DECENT]({ commit, state }, { postId }) {
      if (!state.accessToken) {
        alert('You have to login to do that.');
        return;
      }

      const response = await axios.post(`${LIKES_API}/${postId}/thatsdecent`, null, {
        headers: { Authorization: `Bearer ${state.accessToken}` },
      });
      return commit(INCREMENT_THATS_DECENTS, postId);
    },
    async [NOT_SO_GOOD]({ commit, state }, { postId }) {
      if (!state.accessToken) {
        alert('You have to login to do that.');
        return;
      }

      const response = await axios.post(`${LIKES_API}/${postId}/notsogood`, null, {
        headers: { Authorization: `Bearer ${state.accessToken}` },
      });
      return commit(INCREMENT_NOT_SO_GOODS, postId);
    },

    async [LOGIN]({ commit }, { username, password, nextRoute }) {
      try {
        const response = await axios.post(AUTH_API, {
          username,
          password,
        });

        await commit(SET_USERNAME, username);
        await commit(SET_ACCESS_TOKEN, response.data);
      } catch (err) {
        alert('Invalid username or password.');
        return;
      }

      if (nextRoute) {
        router.push('/');
      }
    },

    async [UPLOAD_IMAGE]({ commit, state }, file) {
      try {
        const formData = new FormData();
        formData.append('file', file);

        const response = await axios.post(IMAGES_API, formData, {
          headers: {
            'Authorization': `Bearer ${state.accessToken}`,
            'Content-Type': 'application/x-www-form-urlencoded',
          },
        });

        return commit(SET_CURRENT_FILENAME, response.data);
      } catch (err) {
        alert(`Error uploading file. ${err}`);
      }
    },
  },
});
