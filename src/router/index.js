import Vue from 'vue'
import Router from 'vue-router';
//import Home from '../components/Home.vue';

Vue.use(Router)

export default new Router({
    routes:[
        {
            path:"/",
            redirect:'/login',
            hidden:true,
            component:()=>import('@/components/Login')
        }, 
        {
            path:"/login",
            name:'Login',
            hidden:true,
            component:()=>import('@/components/Login')
        },
        {
            path:"/home",
            redirect:'/home/Songs',
            name:"曲库",
            component:()=>import('@/components/Home'),
            children:[
                {
                    path:'/home/Songs',
                    name:'Song',
                    component:()=>import('@/components/Songs/SongInfo.vue'),
                },
                {
                    path:'/home/Artist',
                    name:'Artist',
                    component:()=>import('@/components/Songs/Artistinfo.vue'),
                },
                {
                    path:'/home/Album',
                    name:'Album',
                    component:()=>import('@/components/Songs/Albuminfo.vue'),
                },
            ]
        },
        {
            path:'/users',
            name:"Admin",
            component:()=>import('@/components/Home'),
            children:[
                {
                    path:'/users/user',
                    name:'用户信息',
                    component:()=>import('@/components/User/Userinfo.vue'),
                }
            ]
        }
      

    ],

    mode:'history'

})