(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-47dd42da"],{"386d":function(e,t,a){"use strict";var r=a("cb7c"),n=a("83a1"),i=a("5f1b");a("214f")("search",1,function(e,t,a,o){return[function(a){var r=e(this),n=void 0==a?void 0:a[t];return void 0!==n?n.call(a,r):new RegExp(a)[t](String(r))},function(e){var t=o(a,e,this);if(t.done)return t.value;var l=r(e),s=String(this),d=l.lastIndex;n(d,0)||(l.lastIndex=0);var c=i(l,s);return n(l.lastIndex,d)||(l.lastIndex=d),null===c?-1:c.index}]})},"3b2b":function(e,t,a){var r=a("7726"),n=a("5dbc"),i=a("86cc").f,o=a("9093").f,l=a("aae3"),s=a("0bfb"),d=r.RegExp,c=d,u=d.prototype,m=/a/g,f=/a/g,b=new d(m)!==m;if(a("9e1e")&&(!b||a("79e5")(function(){return f[a("2b4c")("match")]=!1,d(m)!=m||d(f)==f||"/a/i"!=d(m,"i")}))){d=function(e,t){var a=this instanceof d,r=l(e),i=void 0===t;return!a&&r&&e.constructor===d&&i?e:n(b?new c(r&&!i?e.source:e,t):c((r=e instanceof d)?e.source:e,r&&i?s.call(e):t),a?this:u,d)};for(var g=function(e){e in d||i(d,e,{configurable:!0,get:function(){return c[e]},set:function(t){c[e]=t}})},h=o(c),p=0;h.length>p;)g(h[p++]);u.constructor=d,d.prototype=u,a("2aba")(r,"RegExp",d)}a("7a56")("RegExp")},4917:function(e,t,a){"use strict";var r=a("cb7c"),n=a("9def"),i=a("0390"),o=a("5f1b");a("214f")("match",1,function(e,t,a,l){return[function(a){var r=e(this),n=void 0==a?void 0:a[t];return void 0!==n?n.call(a,r):new RegExp(a)[t](String(r))},function(e){var t=l(a,e,this);if(t.done)return t.value;var s=r(e),d=String(this);if(!s.global)return o(s,d);var c=s.unicode;s.lastIndex=0;var u,m=[],f=0;while(null!==(u=o(s,d))){var b=String(u[0]);m[f]=b,""===b&&(s.lastIndex=i(d,n(s.lastIndex),c)),f++}return 0===f?null:m}]})},5176:function(e,t,a){e.exports=a("51b6")},6908:function(e,t,a){"use strict";var r=function(){var e=this,t=e.$createElement,a=e._self._c||t;return null!=e.buttonList&&e.buttonList.length>0?a("el-col",{staticClass:"toolbar",staticStyle:{"padding-bottom":"0px"},attrs:{span:24}},[a("el-form",{attrs:{inline:!0},nativeOn:{submit:function(e){e.preventDefault()}}},[a("el-form-item",[a("el-input",{attrs:{placeholder:"请输入内容"},model:{value:e.searchVal,callback:function(t){e.searchVal=t},expression:"searchVal"}})],1),e._l(e.buttonList,function(t){return a("el-form-item",{key:t.id},[t.IsHide?e._e():a("el-button",{attrs:{type:!t.Func||-1==t.Func.toLowerCase().indexOf("handledel")&&-1==t.Func.toLowerCase().indexOf("stop")?"primary":"danger"},on:{click:function(a){e.callFunc(t)}}},[e._v(e._s(t.name))])],1)})],2)],1):e._e()},n=[],i=(a("cadf"),a("551c"),a("097d"),{name:"Toolbar",data:function(){return{searchVal:""}},props:["buttonList"],methods:{callFunc:function(e){e.search=this.searchVal,this.$emit("callFunction",e)}}}),o=i,l=a("2877"),s=Object(l["a"])(o,r,n,!1,null,null,null);s.options.__file="Toolbar.vue";t["a"]=s.exports},"83a1":function(e,t){e.exports=Object.is||function(e,t){return e===t?0!==e||1/e===1/t:e!=e&&t!=t}},"9fa2":function(e,t,a){"use strict";a.r(t);var r=function(){var e=this,t=e.$createElement,a=e._self._c||t;return a("section",[a("toolbar",{attrs:{buttonList:e.buttonList},on:{callFunction:e.callFunction}}),a("el-table",{directives:[{name:"loading",rawName:"v-loading",value:e.listLoading,expression:"listLoading"}],staticStyle:{width:"100%"},attrs:{data:e.users,"highlight-current-row":""},on:{"current-change":e.selectCurrentRow,"selection-change":e.selsChange}},[a("el-table-column",{attrs:{type:"selection",width:"50"}}),a("el-table-column",{attrs:{type:"index",width:"80"}}),a("el-table-column",{attrs:{prop:"Id",label:"Id",width:"",sortable:""}}),a("el-table-column",{attrs:{prop:"tdName",label:"标题",width:"",sortable:""}}),a("el-table-column",{attrs:{prop:"tdAuthor",label:"作者",width:"300",sortable:""}}),a("el-table-column",{attrs:{prop:"tdDetail",label:"内容",formatter:e.formattdDetail,width:"",sortable:""}}),a("el-table-column",{attrs:{prop:"tdCreatetime",label:"创建时间",formatter:e.formatCreateTime,width:"",sortable:""}})],1),a("el-col",{staticClass:"toolbar",attrs:{span:24}},[a("el-button",{attrs:{type:"danger",disabled:0===this.sels.length},on:{click:e.batchRemove}},[e._v("批量删除")]),a("el-pagination",{staticStyle:{float:"right"},attrs:{layout:"prev, pager, next","page-size":6,total:e.total},on:{"current-change":e.handleCurrentChange}})],1),a("el-dialog",{attrs:{title:"编辑",visible:e.editFormVisible,"close-on-click-modal":!1},on:{"update:visible":function(t){e.editFormVisible=t}},model:{value:e.editFormVisible,callback:function(t){e.editFormVisible=t},expression:"editFormVisible"}},[a("el-form",{ref:"editForm",attrs:{model:e.editForm,"label-width":"80px",rules:e.editFormRules}},[a("el-form-item",{attrs:{label:"接口地址",prop:"LinkUrl"}},[a("el-input",{attrs:{"auto-complete":"off"},model:{value:e.editForm.LinkUrl,callback:function(t){e.$set(e.editForm,"LinkUrl",t)},expression:"editForm.LinkUrl"}})],1),a("el-form-item",{attrs:{label:"接口描述",prop:"Name"}},[a("el-input",{attrs:{"auto-complete":"off"},model:{value:e.editForm.Name,callback:function(t){e.$set(e.editForm,"Name",t)},expression:"editForm.Name"}})],1),a("el-form-item",{attrs:{label:"状态",prop:"Enabled"}},[a("el-select",{attrs:{placeholder:"请选择状态"},model:{value:e.editForm.Enabled,callback:function(t){e.$set(e.editForm,"Enabled",t)},expression:"editForm.Enabled"}},e._l(e.statusList,function(e){return a("el-option",{key:e.value,attrs:{label:e.LinkUrl,value:e.value}})}),1)],1)],1),a("div",{staticClass:"dialog-footer",attrs:{slot:"footer"},slot:"footer"},[a("el-button",{nativeOn:{click:function(t){e.editFormVisible=!1}}},[e._v("取消")]),a("el-button",{attrs:{type:"primary",loading:e.editLoading},nativeOn:{click:function(t){return e.editSubmit(t)}}},[e._v("提交")])],1)],1),a("el-dialog",{attrs:{title:"新增",visible:e.addFormVisible,"close-on-click-modal":!1},on:{"update:visible":function(t){e.addFormVisible=t}},model:{value:e.addFormVisible,callback:function(t){e.addFormVisible=t},expression:"addFormVisible"}},[a("el-form",{ref:"addForm",attrs:{model:e.addForm,"label-width":"80px",rules:e.addFormRules}},[a("el-form-item",{attrs:{label:"接口地址",prop:"LinkUrl"}},[a("el-input",{attrs:{"auto-complete":"off"},model:{value:e.addForm.LinkUrl,callback:function(t){e.$set(e.addForm,"LinkUrl",t)},expression:"addForm.LinkUrl"}})],1),a("el-form-item",{attrs:{label:"接口描述",prop:"Name"}},[a("el-input",{attrs:{"auto-complete":"off"},model:{value:e.addForm.Name,callback:function(t){e.$set(e.addForm,"Name",t)},expression:"addForm.Name"}})],1),a("el-form-item",{attrs:{label:"状态",prop:"Enabled"}},[a("el-select",{attrs:{placeholder:"请选择状态"},model:{value:e.addForm.Enabled,callback:function(t){e.$set(e.addForm,"Enabled",t)},expression:"addForm.Enabled"}},[a("el-option",{attrs:{label:"激活",value:"true"}}),a("el-option",{attrs:{label:"禁用",value:"false"}})],1)],1)],1),a("div",{staticClass:"dialog-footer",attrs:{slot:"footer"},slot:"footer"},[a("el-button",{nativeOn:{click:function(t){e.addFormVisible=!1}}},[e._v("取消")]),a("el-button",{attrs:{type:"primary",loading:e.addLoading},nativeOn:{click:function(t){return e.addSubmit(t)}}},[e._v("提交")])],1)],1)],1)},n=[],i=(a("a481"),a("5176")),o=a.n(i),l=(a("386d"),a("a6dc")),s=a("4ec3"),d=a("cdc6"),c=a("6908"),u={components:{Toolbar:c["a"]},data:function(){return{filters:{LinkUrl:""},buttonList:[],currentRow:null,users:[],statusList:[{LinkUrl:"激活",value:!0},{LinkUrl:"禁用",value:!1}],total:0,page:1,listLoading:!1,sels:[],addDialogFormVisible:!1,editFormVisible:!1,editLoading:!1,editFormRules:{LinkUrl:[{required:!0,message:"请输入接口地址",trigger:"blur"}]},editForm:{Id:0,CreateBy:"",LinkUrl:"",Name:"",Enabled:!1},addFormVisible:!1,addLoading:!1,addFormRules:{LinkUrl:[{required:!0,message:"请输入接口地址",trigger:"blur"}]},addForm:{CreateBy:"",CreateId:"",LinkUrl:"",Name:"",Enabled:""}}},methods:{selectCurrentRow:function(e){this.currentRow=e},callFunction:function(e){this.filters={name:e.search},this[e.Func].apply(this,e)},formattdDetail:function(e,t){return e.tdDetail?e.tdDetail.substring(0,20):"N/A"},formatCreateTime:function(e,t){return e.tdCreatetime&&""!=e.tdCreatetime?l["a"].formatDate.format(new Date(e.tdCreatetime),"yyyy-MM-dd"):""},handleCurrentChange:function(e){this.page=e,this.getBugs()},getBugs:function(){var e=this,t={page:this.page,key:this.filters.LinkUrl};this.listLoading=!0,Object(s["C"])(t).then(function(t){e.total=t.data.response.dataCount,e.users=t.data.response.data,e.listLoading=!1})},handleDel:function(){var e=this,t=this.currentRow;t?this.$confirm("确认删除该记录吗?","提示",{type:"warning"}).then(function(){e.listLoading=!0;var a={id:t.Id};Object(s["fb"])(a).then(function(t){l["a"].isEmt.format(t)?e.listLoading=!1:(e.listLoading=!1,t.data.success?e.$message({message:"删除成功",type:"success"}):e.$message({message:t.data.msg,type:"error"}),e.getBugs())})}).catch(function(){}):this.$message({message:"请选择要删除的一行数据！",type:"error"})},handleEdit:function(){var e=this.currentRow;e?(this.editFormVisible=!0,this.editForm=o()({},e)):this.$message({message:"请选择要编辑的一行数据！",type:"error"})},handleAdd:function(){this.addFormVisible=!0,this.addForm={CreateBy:"",LinkUrl:"",Name:"",Enabled:"true"}},editSubmit:function(){var e=this;this.$refs.editForm.validate(function(t){t&&e.$confirm("确认提交吗？","提示",{}).then(function(){e.editLoading=!0;var t=o()({},e.editForm);t.ModifyTime=l["a"].formatDate.format(new Date,"yyyy-MM-dd"),Object(s["p"])(t).then(function(t){l["a"].isEmt.format(t)?e.editLoading=!1:t.data.success?(e.editLoading=!1,e.$message({message:t.data.msg,type:"success"}),e.$refs["editForm"].resetFields(),e.editFormVisible=!1,e.getBugs()):e.$message({message:t.data.msg,type:"error"})})})})},addSubmit:function(){var e=this,t=this;this.$refs.addForm.validate(function(a){a&&e.$confirm("确认提交吗？","提示",{}).then(function(){e.addLoading=!0;var a=o()({},e.addForm);a.CreateTime=l["a"].formatDate.format(new Date,"yyyy-MM-dd"),a.ModifyTime=a.CreateTime,a.IsDeleted=!1;var r=JSON.parse(window.localStorage.user);r&&r.uID>0?(a.CreateId=r.uID,a.CreateBy=r.uRealName):(e.$message({message:"用户信息为空，先登录",type:"error"}),t.$router.replace(t.$route.query.redirect?t.$route.query.redirect:"/")),Object(s["b"])(a).then(function(t){l["a"].isEmt.format(t)?e.addLoading=!1:t.data.success?(e.addLoading=!1,e.$message({message:t.data.msg,type:"success"}),e.$refs["addForm"].resetFields(),e.addFormVisible=!1,e.getBugs()):e.$message({message:t.data.msg,type:"error"})})})})},selsChange:function(e){this.sels=e},batchRemove:function(){this.$message({message:"该功能未开放",type:"warning"})}},mounted:function(){this.getBugs();var e=window.localStorage.router?JSON.parse(window.localStorage.router):[];this.buttonList=Object(d["a"])(this.$route.path,e)}},m=u,f=a("2877"),b=Object(f["a"])(m,r,n,!1,null,"49caa09c",null);b.options.__file="Bugs.vue";t["default"]=b.exports},a6dc:function(e,t,a){"use strict";var r=a("e814"),n=a.n(r),i=(a("a481"),a("386d"),a("4917"),a("3b2b"),/([yMdhsm])(\1*)/g),o="yyyy-MM-dd";function l(e,t){t-=(e+"").length;for(var a=0;a<t;a++)e="0"+e;return e}t["a"]={getQueryStringByName:function(e){var t=new RegExp("(^|&)"+e+"=([^&]*)(&|$)","i"),a=window.location.search.substr(1).match(t),r="";return null!=a&&(r=a[2]),t=null,a=null,null==r||""==r||"undefined"==r?"":r},formatDate:{format:function(e,t){return t=t||o,t.replace(i,function(t){switch(t.charAt(0)){case"y":return l(e.getFullYear(),t.length);case"M":return l(e.getMonth()+1,t.length);case"d":return l(e.getDate(),t.length);case"w":return e.getDay()+1;case"h":return l(e.getHours(),t.length);case"m":return l(e.getMinutes(),t.length);case"s":return l(e.getSeconds(),t.length)}})},parse:function(e,t){var a=t.match(i),r=e.match(/(\d)+/g);if(a.length==r.length){for(var o=new Date(1970,0,1),l=0;l<a.length;l++){var s=n()(r[l]),d=a[l];switch(d.charAt(0)){case"y":o.setFullYear(s);break;case"M":o.setMonth(s-1);break;case"d":o.setDate(s);break;case"h":o.setHours(s);break;case"m":o.setMinutes(s);break;case"s":o.setSeconds(s);break}}return o}return null}},isEmt:{format:function(e){return"undefined"==typeof e||null==e||""==e}}}},aae3:function(e,t,a){var r=a("d3f4"),n=a("2d95"),i=a("2b4c")("match");e.exports=function(e){var t;return r(e)&&(void 0!==(t=e[i])?!!t:"RegExp"==n(e))}}}]);
//# sourceMappingURL=chunk-47dd42da.97513c3e.js.map