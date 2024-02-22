<template>
    <div class="login">
      <el-card class="box-card">
        <div slot="header" class="clearfix">
          <span>登录注册</span>
        </div>
        <el-form label-width="80px" :model="form" ref="form" >
          <el-form-item label="用户名" prop="userName">
            <el-input v-model="form.userName"></el-input>
          </el-form-item>
          <el-form-item label="密码" prop=" password" >
            <el-input v-model="form.password" type="password"></el-input>
          </el-form-item>
          <el-button type="primary" @click="login">登录</el-button>
        </el-form>
      </el-card>
    </div>
  </template>
  
  <script>
 import router from  "../router/index.js"
 import service from "../service.js"
  import {setToken} from "../utlis/setToken.js"
  import login  from "../Api/Api.js"
  export default {
    data() {
       
      return {
        form: {
        userName: "",
        password: "",
        },
       
      };
    },
    methods: {
        login(form) {
            login(this.form).then(res=>{
                if (res.status === 200) {
                        setToken('userName',res.data.userName)
                        setToken('Token',res.data.token)
                        this.$message({message:res.data.message, type:'success'})
                        this.$router.push('/home')
                    }
            })

            // console.log(this.form);
            // service.post('/User/login', this.form)
            //     .then(res => {
            //         console.log(res);
            //         if (res.status === 200) {
            //             setToken('userName',res.data.userName)
            //             setToken('Token',res.data.token)
            //             this.$message({message:res.data.message, type:'success'})
            //             this.$router.push('/home')
            //         }
            //     })
            //     .catch(err => {
            //         console.error(err);
            //     });
        }
    }
   
 
  }
  </script>
  


  
  <style lang="scss">
  .login {
    width: 100%;
    height: 100%;
    position: absolute;
    background: url("../assets/bg.png") center no-repeat;
    .el-card {
      background: #65768557;
    }
    .box-card {
      width: 450px;
      margin: 200px auto;
      color: #fff;
      .el-form .el-form-item__label {
        color: #fff;
      }
      .el-card__header {
        font-size: 34px;
      }
      .el-button {
        width: 100%;
      }
    }
  }
  </style>
  