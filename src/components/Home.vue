<template>
  <div class="home">
    <Header></Header>
    <el-container class="content">
      <Menu></Menu>
      <el-container>
        <el-main>
          <Bread/>
          <div class="cont">
            <router-view></router-view>
          </div>
        </el-main>
        <el-footer><Footer></Footer></el-footer>
      </el-container>
    </el-container>
  </div>
</template>

<script>
import Header from "./common/Header.vue";
import Footer from "./common/Footer.vue";
import Menu from "./common/Menu.vue";
import Bread from './common/Beradcrumb.vue';
export default {
  components:{
    Header,
    Footer,
    Menu,
    Bread
  },
 data() {
  return {
    
  }
 },
 
}
</script>

<style lang="scss" scoped>
  .home {
    width: 100%;
    height: 100%;
    .content {
      position: absolute;
      width: 100%;
      top: 60px;
      bottom: 0;
      .cont {
        margin: 20px 0;
      }
    }
  }
  </style>
