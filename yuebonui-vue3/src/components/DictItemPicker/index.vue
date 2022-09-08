<!--
	作用：把字典编码转换为字典值的单选框。
	依据 EnCode, ItemCode 查找到对应的字典项。
	其中 LocationItemCode 的取值是 ItemDetail 中的 ItemCode ，Item 表中 Encode 的值为 "LocationValues"
	在form中使用的示例如下：
	<el-form-item label="选择位置" :label-width="formLabelWidth" prop="LocationItemCode">
		<YtDictItemPicker v-model="editFrom.LocationItemCode" EnCode="LocationValues"></YtDictItemPicker>
	</el-form-item>
	在界面上显示字典的值，用户选择值，设置 editFrom.LocationItemCode 为字典 "LocationValues" 中的 ItemCode 。
-->
<template>
	<div>
		<el-select :modelValue="props.modelValue" @update:modelValue="newValue=>$emit('update:modelValue', newValue)" class="m-2" placeholder="选择位置">
			<el-option v-for="item in options" :key="item.ItemCode" :label="item.ItemName" :value="item.ItemCode" />
		</el-select>
	</div>
</template>

<script setup name="DictItemPicker">
import { ref } from 'vue'
import { getListItemDetailsByCode } from '@/api/basebasic'

const { proxy } = getCurrentInstance()
const value = ref('')

const options = ref([])

const props = defineProps({
	// 字典编码
	EnCode: String,
	// v-model
	modelValue: String
})

const emit = defineEmits(['update:modelValue'])

onMounted(() => {
	getListItemDetailsByCode(props.EnCode).then(res => {
		if (res.Success) {
			options.value = res.ResData;
		} else {
			proxy.$modal.msgError(res.ErrMsg)
		}
	}
	)
})

</script>

<style>
</style>
