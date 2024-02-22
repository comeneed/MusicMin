<template>
    <div class="studentList">
        <el-form :inline="true" :model="formInline" class="demo-form-inline" size="mini">
            <el-form-item label="歌名">
              <el-input v-model="formInline.name" placeholder="请输入歌名查询"></el-input>
            </el-form-item>      
            <el-form-item>
              <el-button type="primary" @click="reset">查询</el-button>
            </el-form-item>
          </el-form>
        <el-table  :data="tableData"stripe  style="width: 100%">
            <el-table-column prop="Name" label="艺人" align="center"> </el-table-column>
            <el-table-column prop="ImagePath " label="艺人封面" align="center"></el-table-column>
           
            <el-table-column  label="操作" align="center"> 
              <template>
                <el-button type="danger" size="mini" icon="el-icon-delete"></el-button>
              </template>
            </el-table-column>
      </el-table>   
    </div>
</template>

<script>
    import {ArtistAll} from "@/Api/Api.js"
    export default {
      data() {
        return {
          tableData: [],          
        };
      },
      created() {
        this.getData();
      },
     methods: {      
       getData(params){
        ArtistAll(params).then((res=>{
            console.log(res);
            if(res.status === 200){
              console.log("你好");
              this.tableData = res.data;
            }
        }))
       }
      },
    }
  </script>
  <style lang="scss">
    .studentList {
      .demo-form-inline,.el-form-item {
        text-align: left;
      }
      .el-pagination {
        text-align: left;
        margin-top: 20px;
      }
    }
    </style>