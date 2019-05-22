import Vue from 'vue';
import Router from 'vue-router';
import PostList from './views/PostList.vue';

Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'postList',
      component: PostList,
    },
    {
      path: '/createPost',
      name: 'createPost',
      component: () => import(/* webpackChunkName: "createPost" */ './views/CreatePost.vue'),
    },
    {
      path: '/login',
      name: 'login',
      component: () => import(/* webpackChunkName: "login" */ './views/Login.vue'),
    },
  ],
});
