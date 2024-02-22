<template>
    <div>
        <el-table  :data="tableData"stripe  style="width: 100%">
            <el-table-column prop="artist" label="歌手" align="center"> </el-table-column>
            <el-table-column prop="title" label="专辑名称" align="center"></el-table-column>
            <el-table-column prop="genre" label="专辑类型" align="center"></el-table-column>
            <el-table-column prop="releaseDate" label="专辑发售时间" align="center"></el-table-column>

            <el-table-column  label="操作" align="center"> 
              <template>
                <el-button type="danger" size="mini" icon="el-icon-delete"></el-button>
              </template>
            </el-table-column>
      </el-table>   
    </div>
</template>

<script>
    import {AlbumAll} from "@/Api/Api.js"
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
        SongAll(params).then((res=>{
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