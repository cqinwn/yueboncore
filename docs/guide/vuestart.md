# 基础搭建

本项目技术栈基于 ES2015+、vue、vuex、vue-router 、vue-cli 、axios 和 element-ui，在项目目录VueUI中，它使用了最新的前端技术栈。

## 开发工具及扩展

### 开发工具
我们使用Visual Studio Code作为IDE开发工具。下地址：https://code.visualstudio.com/

### 扩展
安装vscode后请安装以下扩展：

1、ESLint

2、Vetur

3、Chinese 中文简体

### 设置

在vscode中``文件-首选项-设置`打开`setting.json`将以下代码粘贴进去：

``` json
{
    "editor.fontSize": 22,
    "editor.formatOnPaste": true,
    "eslint.format.enable": true,
    "explorer.confirmDelete": false,
    // 保存时自动格式化
    "editor.codeActionsOnSave": {
        "source.fixAll.eslint": true
    },
    "editor.formatOnSave": true,
    "editor.formatOnType": true,
    "git.autofetch": true,
    "window.zoomLevel": -1,
    // 添加 vue 支持
    "eslint.validate": [
        "javascript",
        "javascriptreact",
        {
            "language": "vue",
            "autoFix": true
        }
    ],
    //  #让函数(名)和后面的括号之间加个空格
    "javascript.format.insertSpaceBeforeFunctionParenthesis": true,
    "vetur.format.defaultFormatter.html": "js-beautify-html",
    "vetur.format.defaultFormatter.js": "vscode-typescript",
    "vetur.format.defaultFormatterOptions": {
        "js-beautify-html": {
            "wrap_attributes": "auto"
            // #vue组件中html代码格式化样式
        }
    },
    "beautify.config": {
        "brace_style": "collapse,preserve-inline" //解决花括号中换行
    },
}
```


## 修改接口访问地址

在目录中VueUI\src修改setting.js文件中接口访问地址，将地址改为webapi项目启动访问地址


```js

 apiHostUrl: 'http://localhost:54678/api/', // 基础接口
 apiSecurityUrl: 'http://localhost:54678/api/Security/', // 权限管理系统接口
 fileUrl: 'http://localhost:54678/', // 文件访问路径
 fileUploadUrl: 'http://localhost:54678/api/Files/Upload'// 文件上传路径

```

## 编译运行

```sh

#进入目录
 cd VueUI

# 安装依赖
npm install

# 强烈建议不要用直接使用 cnpm 安装，会有各种诡异的 bug，可以通过重新指定 registry 来解决 npm 安装速度慢的问题。
npm install --registry=https://registry.npm.taobao.org

# 本地开发 启动项目
npm run dev
```
打开浏览器，输入：http://localhost:8085 （默认账户 admin/admin888）
若能正确展示登录页面，并能成功登录，菜单及页面展示正常，则表明环境搭建成功


::: tip 提示
因为本项目是前后端分离的，所以需要前后端都编译启动好，才能进行访问
:::

```sh
# 打包正式环境
npm run build:prod
```

如遇到问题到[Issues](https://gitee.com/yuebon/YuebonNetCore/issues)反馈
