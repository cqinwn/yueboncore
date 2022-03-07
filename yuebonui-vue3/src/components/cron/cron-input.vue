<template>
  <div>
    <el-popover v-model="visible">
      <div style="text-align: right; margin: 0">
        <i class="el-icon-close" style="cursor:pointer;" @click="visible = false" />
      </div>
      <cron v-model="cron_" :size="size" @change="change" />
      <template v-slot:reference>
      <el-input readonly :value="value" :placeholder="$t('common.inputPlaceholder')" :size="size" @change="setCron" @input="$emit('input', $event.target.value)">
        <template v-slot:append>
        <el-button icon="el-icon-refresh" @click="reset" />
      </template>
      </el-input>
      </template>
    </el-popover>
  </div>
</template>

<script>
import Cron from '@/components/cron/cron'
import { DEFAULT_CRON_EXPRESSION } from '@/components/cron/constant/filed'
import Vue from 'vue'
import translate from '@/components/cron/mixins/plugins/translate'
Vue.use(translate)
export default {
  name: 'CronInput',
  components: {
    Cron
  },
  props: {
    value: {
      type: String,
      default: DEFAULT_CRON_EXPRESSION
    },
    size: {
      type: String,
      default: ''
    }
  },
  data() {
    return {
      cron_: '',
      visible: false
    }
  },
  watch: {
    value(val) {
      this.setCron(val || DEFAULT_CRON_EXPRESSION)
    }
  },
  created() {
    this.setCron(this.value || DEFAULT_CRON_EXPRESSION)
  },
  methods: {
    setCron(newValue) {
      this.cron_ = newValue
    },
    change(cron) {
      this.cron_ = cron
      this.$emit('input', cron)
    },
    reset() {
      this.$emit('input', DEFAULT_CRON_EXPRESSION)
    }
  }
}
</script>
