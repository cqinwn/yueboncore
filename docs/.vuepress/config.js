module.exports = {
    title: 'YuebonCore快速开发框架'
    , description: '.net快速开发框架,vue前后分离框架,netcore开发框架,权限管理系统'
    , head: [
        ['link', { rel: 'icon', href: '/logo.png' }]
    ]
    , themeConfig: {
        logo: '/assets/img/logo.png',
        lastUpdated: '最后更新时间', // string | boolean
        nav: [
            { text: '首页', link: '/' },
            { text: '指南', link: '/guide/' },
            { text: '手册', link: '/help/' },
            {
                text: '体验',
                ariaLabel: 'Proj Menu',
                items: [
                    { text: 'vue版', link: 'http://netvue.ts.yuebon.com', target: '_blank' },
                    { text: 'api接口', link: 'http://netcoreapi.ts.yuebon.com', target: '_blank' }
                ]
            },
            { text: 'gitee', link: 'https://gitee.com/yuebon/YuebonNetCore', target: '_blank' }
        ],
        sidebar: {
            '/guide/': [
                ['', '指南']
                , {
                    title: '快速了解',   // 必要的
                    path: 'kslj',      // 可选的, 标题的跳转链接，应为绝对路径且必须存在
                    sidebarDepth: 1,    // 可选的, 默认值是 1
                    collapsable: false
                }
                , {
                    title: '环境部署',   // 必要的
                    path: 'start',      // 可选的, 标题的跳转链接，应为绝对路径且必须存在
                    sidebarDepth: 2,    // 可选的, 默认值是 1
                    collapsable: false,
                    children: [
                        "start"
                        , "deploy"
                    ]
                }, {
                    title: '手摸手',   // 必要的
                    sidebarDepth: 2,    // 可选的, 默认值是 1
                    collapsable: false,
                    children: [
                        'devnew'
                        , "repository"
                    ]
                }
                , {
                    title: '后台开发',   // 必要的
                    path: 'peizhi',      // 可选的, 标题的跳转链接，应为绝对路径且必须存在
                    sidebarDepth: 2,    // 可选的, 默认值是 1
                    collapsable: false,
                    children: [
                        "peizhi"
                        , "entity"
                        , "cache"
                        , "job"
                        , "dboperation"
                        , "subsys"
                        , "webapiswagger"
                    ]
                }
                , {
                    title: '前端开发',   // 必要的
                    sidebarDepth: 2,    // 可选的, 默认值是 1
                    collapsable: false,
                    children: [
                        'vuestart',
                        'eslint'
                    ]
                }
                , {
                    title: '更新日志',   // 必要的
                    sidebarDepth: 2,    // 可选的, 默认值是 1
                    collapsable: false,
                    children: [
                        'changelog'
                    ]
                }
                , "faq"
            ],

            '/help/': [
                ['', '手册']
            ]
        }
    }
}