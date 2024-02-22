<template>
    <div clas="studentList">
      <el-form :inline="true" :model="formInline" class="demo-form-inline" size="mini">
        <el-form-item label="歌名">
          <el-input v-model="formInline.name" placeholder="请输入歌名查询"></el-input>
        </el-form-item>      
        <el-form-item>
          <el-button type="primary" @click="reset">查询</el-button>
          <el-button type="primary" @click="clearn">重置</el-button>
          <el-button type="info" round @click="AddSong">添加</el-button>
        </el-form-item>
      </el-form>
        <el-table  :data="tableData"stripe  style="width: 100%">
            <el-table-column prop="title" label="歌名" align="center"> </el-table-column>
            <el-table-column prop="artist" label="歌手" align="center"></el-table-column>
            <el-table-column prop="album" label="专辑" align="center"></el-table-column>
            <el-table-column prop="genre" label="类型" align="center"></el-table-column>
            <el-table-column prop="duration" label="点击量" align="center"></el-table-column>
            <el-table-column prop="filePath" label="歌曲路径" align="center"> </el-table-column>
            <el-table-column  label="操作" align="center"> 
              <template slot-scope="scope">
                <el-button type="danger" size="mini" icon="el-icon-delete" @click="del(scope.row)" ></el-button>
                <el-button type="danger" size="mini" icon="el-icon-refresh" @click="edit(scope.row)"></el-button>
              </template>
            </el-table-column>
      </el-table>

      <!-- 弹出窗 -->

      <el-dialog :title= "state?'添加歌曲信息' :'修改歌曲信息'":visible.sync="dialogFormVisible" width="500px">
        <el-form :model="form">
          <el-form-item label="歌名"  prop="title">
            <el-input v-model="form.title" autocomplete="off"></el-input>
          </el-form-item>
          <el-form-item label="歌手"  prop="artist">
            <el-input v-model="form.artist" autocomplete="off"></el-input>
          </el-form-item>
          <el-form-item label="专辑"  prop="album" >
            <el-input v-model="form.album" autocomplete="off"></el-input>
          </el-form-item>
          <el-form-item label="类型"  prop="genre">
            <el-input v-model="form.genre" autocomplete="off"></el-input>
          </el-form-item>
          <el-form-item label="点击量"  prop="duration">
            <el-input v-model="form.duration" autocomplete="off"></el-input>
          </el-form-item>
          <el-form-item label="歌曲路径"  prop="filePath">
            <el-input v-model="form.filePath" autocomplete="off"></el-input>
          </el-form-item>
          <el-form-item label="歌曲封面"  prop="CoverPath">
            <el-input v-model="form.CoverPath" autocomplete="off"></el-input>
          </el-form-item>
        </el-form>
        <div slot="footer" class="dialog-footer">
          <el-button @click="dialogFormVisible = false">取 消</el-button>
          <el-button type="primary" @click="sure('form')">确 定</el-button>
        </div>
      </el-dialog>
      

    </div>
</template>

<script>
    import {SongAll, SongDelete,SongName,Songinfo,SongUpdate} from "@/Api/Api.js"
    export default {
      data() {
        return {
          tableData: [],
          formInline:{
            name:''
          },
          dialogFormVisible:false,
          form:{
            title:"",
            artist:"",
            album:"",
            genre:"",
            duration:"",
            filePath:"",
            CoverPath:""
          },     
          state:true,  
         
        };
      },
      created() {
        this.getData();      
      },
      methods: {
        edit(row){
          console.log(row);
          this.form = row
          this.state = false
          this.dialogFormVisible=true
        },


        sure(form) {
          if(this.state){
        Songinfo(this.form).then(res => {
            console.log(form);
            if (res.status === 200) {
                this.dialogFormVisible = false;
                this.$message({ type: 'success', message: '添加歌曲成功' });
            }
        }).catch(err => {
            console.error('添加歌曲失败：', err);
        })}else{
          SongUpdate(this.form).then(res=>{
            if (res.status === 204){
              this.dialogFormVisible = false;
              this.$message({ type: 'success', message: '修改歌曲成功' });
            }
          }).catch(err=>{
            console.error('修改歌曲失败：', err);
          })
        }
    },
        clearn(){
         this.getData();
        },
        reset(){
          const keyword = this.formInline.name; // 获取用户输入的歌名关键字
          SongName(keyword).then((res) => {
         console.log(res);
        if (res.status === 200) {
        console.log("你好");
        this.tableData = res.data;
      }
    });
      
        },
        
       getData(params){
        SongAll(params).then((res=>{
            console.log(res);
            if(res.status === 200){
              console.log("你好");
              this.tableData = res.data;
            }
        }))
       },

       del(row){
        console.log(row);
        SongDelete(row.title).then(res=>{
          console.log(res);
          if(res.status === 200){
            this.$message({message:'删除数据成功' ,type:'success'})
            this.getData();
          }
        })
       },

       
       AddSong(){
      this.state =true
      this.form = {
            title:"",
            artist:"",
            album:"",
            genre:"",
            duration:"",
            filePath:"",
            CoverPath:""
          },       
        this.dialogFormVisible= true
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