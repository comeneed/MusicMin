const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: true,
  lintOnSave:false,
  devServer:{
    proxy:{
      "/api":{
        target:"https://localhost:7275/api/",
        secure:false,
        changeOrigin:true, //host
        pathRewrite:{
          "^/api":"",
        }
      }
    }
  }
})
