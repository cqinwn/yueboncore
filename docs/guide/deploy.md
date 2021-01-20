# 部署

::: tip 提示
因.net core内部有自托管的Web服务器，推荐使用控制台方式部署
:::

## 接口Yuebon.WebApi部署

* 修改部署环境的连接字符串信息,特别注意是`appsettings.json`文件：
![说明](/bushu1.png "说明")

::: warning 注意
1、ConStringEncrypt配置数据库连接字符串是否加密，加密设置为true，否则设置false

2、DefaultDataBase设置默认数据库连接

3、是否启用Redis缓存，默认是开启的，关闭如下

```json
{
  "UseRedis": false,
}
```
:::

* 直接在解决方案资源管理器中，选中Yuebon.WebApi右键【发布】，出现下面的配置框，使用文件系统即可：

![说明](/bushu3.png "说明")

![说明](/bushu2.png "说明")


* 发布完成后可以在输出目录看到发布详情（红色框内即为发布的文件夹）：

![说明](/bushu5.png "说明")
* 发布【Yuebon.WebApi】完成后进入文件目录【~\publish】，直接使用`dotnet  Yuebon.WebApi.dll` 命令启动。

![说明](/bushu4.png "说明")

启动成功后使用浏览器打开http://localhost:5000/ 即可访问，如下图所示：

![说明](/bushu6.png "说明")

::: tip IIS部署中部分会出现method为delete时跨域问题？

请在web.config做如下配置：
```xml
<modules>
    <remove name="WebDAVModule" />
</modules>
<handlers>
    <remove name="WebDAV" />
</handlers>
```
:::

## 前端部署

当项目开发完毕，只需要运行一行命令就可以打包你的应用

```sh
# 打包正式环境
npm run build:prod

# 打包预发布环境
npm run build:stage
```

构建打包成功之后，会在根目录生成 dist 文件夹，里面就是构建打包好的文件，通常是 ***.js 、***.css、index.html 等静态文件。

通常情况下 dist 文件夹的静态文件发布到你的 nginx 或者静态服务器即可，其中的 index.html 是后台服务的入口页面。

::: tip outputDir 提示
如果需要自定义构建，比如指定 dist 目录等，则需要通过 config 的 outputDir 进行配置。
:::

::: tip publicPath 提示
部署时改变页面js 和 css 静态引入路径 ,只需修改 vue.config.js 文件资源路径即可。
:::

```js
publicPath: './' //请根据自己路径来配置更改
```

```js
export default new Router({
  mode: 'hash', // hash模式
})
```

所有测试环境或者正式环境变量的配置都在 .env.development 等 .env.xxxx文件中。

它们都会通过 webpack.DefinePlugin 插件注入到全局。


::: tip 注意！！！

环境变量必须以VUE_APP_为开头。如:VUE_APP_API、VUE_APP_TITLE

你在代码中可以通过如下方式获取:
```js
console.log(process.env.VUE_APP_xxxx)
```
:::

如遇到问题到[Issues](https://gitee.com/yuebon/YuebonNetCore/issues)反馈