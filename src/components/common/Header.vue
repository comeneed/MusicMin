<template>
    <div class="header">
        <el-header>
            <div class="title">Mypple-Music</div>
            <div>{{name}}</div>
        </el-header>
    </div>
</template>
<script>
import { getToken } from '../../utlis/setToken.js'
export default {
    data() {
        return {
            name: ''
        }
    },
    created() {
        this.name = getToken('userName')
    }
}
</script>
<style lang="scss" scoped>
.header {
    .el-header {
        background: #2578b5;
        color: #fff;
        line-height: 60px;
        display: flex;
        justify-content: space-between;
        .title {
            width: 200px;
            font-size: 24px;
        }
    }
}
</style>