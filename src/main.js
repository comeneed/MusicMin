import Vue from 'vue'
import App from './App.vue'
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
// import  axios  from 'axios'
import service from './service';
import router from './router';
import reast from '@/assets/Css/reast.css'


// Vue.prototype.axios = axios
Vue.prototype.service = service
Vue.use(ElementUI)
Vue.use(reast)
Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
