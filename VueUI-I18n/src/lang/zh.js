/**
 * =============================================
 * ========= 国际化语言 zh-cn.js ================
 * ====== 上海越邦网络科技有限公司 版权所有 =======
 * =============================================
 */

const zh = {
    /**
     * =============================================
     * ================ 公共部分 ====================
     * =============================================
     */


    /**
     * 列表操作按钮
     */
    toolbar: {
        btnAdd: "新增",
        btnModify: "修改",
        btnUpdate: "更新",
        btnEdit: "编辑",
        btnDelete: "删除",
        btnSoftDelete: "软删除",
        btnEnable: "启用",
        btnDisable: "禁用",
        btnRefresh: "刷新",
        btnResetAppSecret: "重置AppSecret",
        btnResetEncodingAESKey: "重置消息密钥"
    },
    /**
     * 窗口操作按钮
     */
    button: {
        btnOk: "确定",
        btnSave: "保 存",
        btnCancel: "取 消",
        btnEdit: "编辑",
        btnClose: "关闭",
        btnSearch: "查询",
        btnReset: "重置"
    },

    /**
     * 提示消息
     */
    message: {
        editAlertTips: "请选择一条数据进行编辑 / 修改",
        alertTips1: "请先选择要操作的数据",
        successTips: "恭喜你，操作成功！",
        deleteTips: "是否确认删除所选的数据项?",
        selectDataTips: "请选择一条数据进行重置"
    },
    route: {
        Dashboard: '控制台',
        Cms: "文章管理",
        Articlecategory: "文章分类",
        Articlenews: "文章列表",
        Articlecategory: "文章分类",
        CreateArticle: '创建文章',
        EditArticle: '编辑文章',
        Security: "系统管理",
        SysSetting: "系统设置",
        Organize: "组织机构",
        User: "用户管理",
        Role: "角色管理",
        Items: "数据字典",
        Tenant: "多租户",
        UploadFile: "文件管理",
        FilterIP: "访问控制",
        Task: "定时任务",
        TaskManager: "任务列表",
        TaskJobsLog: "任务日志",
        DocumentConfig: "单据配置",
        Sequence: "业务单据编码",
        SequenceRule: "单据编码规则",
        SysLog: "日志管理",
        LogLogin: "登录日志",
        LogList: "操作日志",
        LogException: "异常日志",
        LogSQL: "Sql日志",
        Tools: "开发者",
        SystemType: "系统类型",
        APP: "应用管理",
        Menu: "功能模块",
        CodeGenerator: "代码生成器",
        DbTools: "数据库连接",
        errorPages: '错误页面',
        page401: '401',
        page404: '404',
        errorLog: '错误日志',
        excel: 'Excel',
        exportExcel: '导出 Excel',
        selectExcel: '导出 已选择项',
        mergeHeader: '导出 多级表头',
        uploadExcel: '上传 Excel',
        zip: 'Zip',
        pdf: 'PDF',
        exportZip: 'Export Zip',
        theme: '换肤',
        i18n: '国际化',
        UserCenter: "个人中心",
        profile: '个人信息',
        modifyPassword: '修改密码',
        documentation: "官网文档"
    },
    layout: {
        home: "首页",
        giturl: "源码地址",
        docurl: "文档地址",
        layoutsize: "布局大小",
        systemNowTip: "您处在",
        switch: "切换",
        usercenter: "个人中心",
        layoutSet: "布局设置",
        logOut: "退出登录"
    },
    tagsView: {
        refresh: '刷新页面',
        close: '关闭',
        closeOthers: '关闭其它',
        closeLeft: '关闭左侧',
        closeRight: '关闭右侧',
        closeAll: '关闭所有'
    },
    settings: {
        title: '系统布局配置',
        theme: '主题色',
        topNav: "开启 TopNav",
        tagsView: '开启 Tags-View',
        fixedHeader: '固定 Header',
        sidebarLogo: '侧边栏 Logo',
        dynamicTitle: "动态标题"
    },
    dashboard: {
        serverInfo: "服务器信息",
        serverName: "服务器名称",
        operatingSystem: "操作系统",
        serverIP: "服务器IP",
        numberofCPUs: "CPU数量"
    },
    table: {
        removeStatus: "是否删除",
        createTime: "创建时间",
        updateTime: "更新时间",
        isEnable: "是否启用",
        enable: "启用",
        disable: "禁用",
        removeStatusYes: "已删除",
        removeStatusNo: "否",
        status: '状态',
        actions: '操作',
        Yes: "是",
        No: "否"
    },
    editform: {
        edit: "编辑",
        add: "新增",
    },
    /**
     * =============================================
     * ================ 各模块 ====================
     * =============================================
     */
    righttoolbar: {
        show: "显示",
        hide: "隐藏",
        showSearch: "显示搜索",
        hideSearch: "隐藏搜索",
        refresh: "刷新",
        showOrHideColumn: "显示/隐藏列"

    },
    login: {
        systemName: "管理系统",
        inputAccount: "登录账号",
        inputPassword: "登录密码",
        inputVcode: "验证码",
        btnLoginText: "登 录",
        btnLoginIngText: "登 录 中...",
        txtReg: "没有账号？",
        regLink: "点此注册",
        ruleAccount: "请输入登录账号！",
        rulePassword: "请输入您的账号密码,且不小于6位！",
        ruleVcodeTip: "请输入验证码",
        ruleVcodeLengTip: "长度4字符"
    },
    /**
     * 应用管理
     */
    app: {
        title: "应用名称",
        phTitle: "应用Id或授权Url",
        appId: "应用ID",
        appSecret: "应用密钥",
        token: "Token",
        encodingAESKey: "消息加密密钥",
        isOpenAEKey: "开启消息加密",
        authUrl: "授权URL",
        option: "选项",
        desc: "描述",
        editFormTitle: "应用",
        ruleAppId: "请输入应用ID",
        ruleAutoCreate: "系统自动生成",
        ruleToken: "请输入Token",
        ruleAppIdLengTip: "长度在 4 到 32 个字符",
        ruleTokenLengTip: "长度在 4 到 32 个字符"

    },
}

export default zh