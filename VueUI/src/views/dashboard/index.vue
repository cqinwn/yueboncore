<template>
  <div class="app-container ">
    <el-row :gutter="40" class="panel-group">
      <el-col :xs="12" :sm="12" :lg="6" class="card-panel-col">
        <div class="card-panel">
          <div class="card-panel-icon-wrapper icon-people">
            <div class="iconfont icon-friend card-panel-icon" />
          </div>
          <div class="card-panel-description">
            <div class="card-panel-text">
              用户
            </div>
            <countto :start-val="0" :end-val="SysSetting.TotalUser" :duration="2600" class="card-panel-num" />
          </div>
        </div>
      </el-col>
      <el-col :xs="12" :sm="12" :lg="6" class="card-panel-col">
        <div class="card-panel">
          <div class="card-panel-icon-wrapper icon-message">
            <div class="iconfont icon-module card-panel-icon" />
          </div>
          <div class="card-panel-description">
            <div class="card-panel-text">
              模块
            </div>
            <countto :start-val="0" :end-val="SysSetting.TotalModule" :duration="3000" class="card-panel-num" />
          </div>
        </div>
      </el-col>
      <el-col :xs="12" :sm="12" :lg="6" class="card-panel-col">
        <div class="card-panel">
          <div class="card-panel-icon-wrapper icon-money">
            <div class="iconfont icon-jiaose3-01 card-panel-icon" />
          </div>
          <div class="card-panel-description">
            <div class="card-panel-text">
              岗位角色
            </div>
            <countto :start-val="0" :end-val="SysSetting.TotalRole" :duration="3200" class="card-panel-num" />
          </div>
        </div>
      </el-col>
      <el-col :xs="12" :sm="12" :lg="6" class="card-panel-col">
        <div class="card-panel">
          <div class="card-panel-icon-wrapper icon-shopping">
            <div class="iconfont icon-log card-panel-icon" />
          </div>
          <div class="card-panel-description">
            <div class="card-panel-text">
              日志
            </div>
            <countto :start-val="0" :end-val="SysSetting.TotalLog" :duration="3600" class="card-panel-num" />
          </div>
        </div>
      </el-col>
    </el-row>
    <el-row :gutter="20" class="panel-group">
      <el-col :xs="12" :sm="12" :lg="12">
        <el-card>
          <div slot="header" class="clearfix">
            <span class="iconfont icon-notice">系统公告</span>
          </div> <div class="systeminfo">
            <div>系统设置</div>
            <div>系统设置</div>
            <div>系统设置</div>
            <div>系统设置</div>
            <div>系统设置</div>
            <div>系统设置</div>
            <div>系统设置</div>
          </div>
        </el-card>
      </el-col>

      <el-col :xs="12" :sm="12" :lg="12">
        <el-card>
          <div slot="header" class="clearfix">
            <span class="iconfont icon-about">系统信息</span>
          </div>
          <div class="systeminfo">
            <div class="lidiv">系统名称：{{ SysSetting.Title }}</div>
            <div class="lidiv">公司名称：{{ SysSetting.CertificatedCompany }}</div>
            <div class="lidiv">域名：{{ SysSetting.WebUrl }}</div>
            <div class="lidiv">授权方式：按域名授权</div>
            <div class="lidiv">系统版本：{{ SysSetting.Version }}</div>
            <div class="lidiv">版本更新：<a :href="SysSetting.UpdateUrl" target="_blank">更新</a></div>
          </div>
          <div class="systeminfo">
            <div class="lidiv">服务器名称：{{ SysSetting.MachineName }}</div>
            <div class="lidiv">操作系统：{{ SysSetting.OSDescription }}</div>
            <div class="lidiv">服务器IP：{{ SysSetting.IPAdress }}</div>
            <div class="lidiv">服务器端口：{{ SysSetting.Port }}</div>
            <div class="lidiv">运行时的版本号：{{ SysSetting.SystemVersion }}</div>
            <div class="lidiv">开发团队：{{ SysSetting.Manufacturer }}</div>
            <div class="lidiv">官方网址：<a :href="SysSetting.WebSite" target="_blank"> {{ SysSetting.WebSite }}</a></div>
          </div>
        </el-card>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import countto from 'vue-count-to'
import { getSysInfo } from '@/api/basebasic'
import { getUrlKey } from '@/utils/index'
import defaultSettings from '@/settings'
export default {
  components: { countto },
  data() {
    return {
      SysSetting: [],
      syskey: ''
    }
  },
  created() {
    this.syskey = getUrlKey('openmf')
    if (this.syskey !== '' && this.syskey !== null && this.syskey !== 'null' && this.syskey !== undefined) {
      this.loadsysType()
    }
    this.InitDictItem()
  },
  methods: {
    /**
     * 初始化数据
     */
    InitDictItem() {
      getSysInfo().then(res => {
        this.SysSetting = res.ResData
      })
    },
    loadsysType() {
      var data = {
        openmf: this.syskey,
        appId: defaultSettings.appId,
        systemCode: defaultSettings.activeSystemCode
      }
      this.loading = true
      this.$store
        .dispatch('user/sysConnetLogin', data)
        .then(res => {
          window.location.href = res.ResData.ActiveSystemUrl
          this.loading = false
        })
        .catch(res => {
          this.loading = false
        })
    }
  }
}
</script>

<style lang="scss" scoped>
.panel-group {
  margin-top: 18px;
  .card-panel-col {
    margin-bottom: 32px;
  }
  .card-panel {
    height: 108px;
    cursor: pointer;
    font-size: 12px;
    position: relative;
    overflow: hidden;
    color: #666;
    background: #fff;
    box-shadow: 4px 4px 40px rgba(0, 0, 0, .05);
    border-color: rgba(0, 0, 0, .05);
    &:hover {
      .card-panel-icon-wrapper {
        color: #fff;
      }
      .icon-people {
        background: #40c9c6;
      }
      .icon-message {
        background: #36a3f7;
      }
      .icon-money {
        background: #f4516c;
      }
      .icon-shopping {
        background: #34bfa3
      }
    }
    .icon-people {
      color: #40c9c6;
    }
    .icon-message {
      color: #36a3f7;
    }
    .icon-money {
      color: #f4516c;
    }
    .icon-shopping {
      color: #34bfa3
    }
    .card-panel-icon-wrapper {
      float: left;
      margin: 14px 0 0 14px;
      padding: 16px;
      transition: all 0.38s ease-out;
      border-radius: 6px;
    }
    .card-panel-icon {
      float: left;
      font-size: 48px;
    }
    .card-panel-description {
      float: right;
      font-weight: bold;
      margin: 26px;
      margin-left: 0px;
      .card-panel-text {
        line-height: 18px;
        color: rgba(0, 0, 0, 0.45);
        font-size: 16px;
        margin-bottom: 12px;
      }
      .card-panel-num {
        font-size: 20px;
      }
    }
  }
}
@media (max-width:550px) {
  .card-panel-description {
    display: none;
  }
  .card-panel-icon-wrapper {
    float: none !important;
    width: 100%;
    height: 100%;
    margin: 0 !important;
    .svg-icon {
      display: block;
      margin: 14px auto !important;
      float: none !important;
    }
  }
}
.systeminfo{
  line-height: 25px;
    float: left;
    width: 50%;
    margin-bottom: 20px;
  .lidiv{
  line-height: 25px;
  }
}
</style>
