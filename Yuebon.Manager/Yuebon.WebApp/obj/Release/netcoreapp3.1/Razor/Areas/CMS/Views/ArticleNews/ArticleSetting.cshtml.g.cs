#pragma checksum "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f7dbcc6d82edc1cefd56acc06afa0b65ed144fa3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_CMS_Views_ArticleNews_ArticleSetting), @"mvc.1.0.view", @"/Areas/CMS/Views/ArticleNews/ArticleSetting.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 7 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml"
using Yuebon.WebApp.Commons;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7dbcc6d82edc1cefd56acc06afa0b65ed144fa3", @"/Areas/CMS/Views/ArticleNews/ArticleSetting.cshtml")]
    public class Areas_CMS_Views_ArticleNews_ArticleSetting : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Yuebon.CMS.Models.ArtSetting>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("charset", new global::Microsoft.AspNetCore.Html.HtmlString("utf-8"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/ueditor/ueditor.config.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/ueditor/ueditor.all.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/ueditor/lang/zh-cn/zh-cn.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml"
  
    ViewData["Title"] = "文章管理-基础设置";
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewBag.CurrentMenuP = "ArticleNews";
    ViewBag.CurrentMenu = "ArticleNews/ArticleSetting";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""edit-page-wrapper"">
    <div class=""row"">
        <div class=""col-12"">
            <form class=""form-horizontal"" id=""frmSubmit"" method=""post"" enctype=""multipart/form-data"">
                <div class=""card"">
                    <div class=""card-header d-flex p-0"">
                        <ul class=""nav nav-pills p-2"">
                            <li class=""nav-item"">
                                <a class=""nav-link active"" href=""#basicInfo"" data-toggle=""tab"">基本信息</a>
                            </li>
                        </ul>
                    </div><!-- /.card-header -->
                    <div class=""card-body"">
                        <div class=""tab-content p-0"">
                            <!-- Morris chart - Sales -->
                            <div class=""chart tab-pane active"" id=""basicInfo"" style=""position: relative;"">
                                <div class=""form-group"">
                                    <div class=""row"">
                               ");
            WriteLiteral("         <label for=\"SoftName\" class=\"col-form-label col-md-2\">应用名设置:</label>\r\n                                        <input type=\"text\" class=\"form-control col-md-5\" name=\"AppName\" id=\"AppName\"");
            BeginWriteAttribute("value", " value=\"", 1480, "\"", 1502, 1);
#nullable restore
#line 29 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml"
WriteAttributeValue("", 1488, Model.AppName, 1488, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" placeholder=""请输入应用名称"">
                                        &nbsp;&nbsp;<span class=""help-block"">*默认名称为""头条""，应用名称最多4个字符</span>
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <label for=""IsOpenPush"" class=""col-form-label col-md-2"">开启推送:</label>
                                        <label for=""IsTop"">
                                            <input type=""checkbox"" class=""flat-red""");
            BeginWriteAttribute("checked", " checked=\"", 2087, "\"", 2116, 1);
#nullable restore
#line 37 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml"
WriteAttributeValue("", 2097, Model.IsOpenPush, 2097, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""IsOpenPush"" id=""IsOpenPush"">
                                            开启推送
                                        </label>
                                        &nbsp;&nbsp;<span class=""help-block"">当前状态：开启，关闭后，前台头条导航将不显示“今日头条”分类</span>
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <label for=""IsOpenAudit"" class=""col-form-label col-md-2"">开启审核:</label>
                                        <label for=""IsTop"">
                                            <input type=""checkbox"" class=""flat-red""");
            BeginWriteAttribute("checked", " checked=\"", 2823, "\"", 2851, 1);
#nullable restore
#line 47 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml"
WriteAttributeValue("", 2833, Model.IsOpenAudit, 2833, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""IsOpenAudit"" id=""IsOpenAudit"">
                                            开启审核
                                        </label>
                                        &nbsp;&nbsp;<span class=""help-block"">当前状态：开启，关闭后，前台留言无需审核自动显示</span>
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <label for=""IsOpenRecommend"" class=""col-form-label col-md-2"">开启推荐:</label>
                                        <label for=""IsTop"">
                                            <input type=""checkbox"" class=""flat-red""");
            BeginWriteAttribute("checked", " checked=\"", 3558, "\"", 3590, 1);
#nullable restore
#line 57 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml"
WriteAttributeValue("", 3568, Model.IsOpenRecommend, 3568, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""IsOpenRecommend"" id=""IsOpenRecommend"">
                                            开启推荐
                                        </label>
                                        &nbsp;&nbsp;<span class=""help-block"">当前状态：开启，闭后，前台文章内容页将不显示精彩推荐模块</span>
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <label for=""IsOpenReward"" class=""col-form-label col-md-2"">开启赞赏:</label>
                                        <label for=""IsTop"">
                                            <input type=""checkbox"" class=""flat-red""");
            BeginWriteAttribute("checked", " checked=\"", 4306, "\"", 4335, 1);
#nullable restore
#line 67 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml"
WriteAttributeValue("", 4316, Model.IsOpenReward, 4316, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""IsOpenReward"" id=""IsOpenReward"">
                                            开启赞赏
                                        </label>
                                        &nbsp;&nbsp;<span class=""help-block"">当前状态：开启，关闭后，前台文章内容页将不显示赞赏模块</span>
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <label for=""RewardAmount"" class=""col-form-label col-md-2"">赞赏金额:</label>
                                        <input type=""text"" class=""form-control col-md-5"" name=""RewardAmount"" id=""RewardAmount""");
            BeginWriteAttribute("value", " value=\"", 5026, "\"", 5053, 1);
#nullable restore
#line 76 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml"
WriteAttributeValue("", 5034, Model.RewardAmount, 5034, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                        &nbsp;&nbsp;<span class=""help-block"">*可为空，最多255个字符</span>
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <label for=""ListTitle"" class=""col-form-label col-md-2"">列表页显示标题:</label>
                                        <input type=""text"" class=""form-control col-md-5"" name=""ListTitle"" id=""ListTitle""");
            BeginWriteAttribute("value", " value=\"", 5586, "\"", 5610, 1);
#nullable restore
#line 83 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml"
WriteAttributeValue("", 5594, Model.ListTitle, 5594, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                        &nbsp;&nbsp;<span class=""help-block"">*可为空，最多60个字符</span>
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <label for=""ListShareTitle"" class=""col-form-label col-md-2"">列表页分享标题:</label>
                                        <input type=""text"" class=""form-control col-md-5"" name=""ListShareTitle"" id=""ListShareTitle""");
            BeginWriteAttribute("value", " value=\"", 6157, "\"", 6186, 1);
#nullable restore
#line 90 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml"
WriteAttributeValue("", 6165, Model.ListShareTitle, 6165, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                        &nbsp;&nbsp;<span class=""help-block"">*可为空，最多60个字符</span>
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <label for=""ListShareDesc"" class=""col-form-label col-md-2"">列表页分享详情:</label>
                                        <input type=""text"" class=""form-control col-md-5"" name=""ListShareDesc"" id=""ListShareDesc""");
            BeginWriteAttribute("value", " value=\"", 6730, "\"", 6758, 1);
#nullable restore
#line 97 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml"
WriteAttributeValue("", 6738, Model.ListShareDesc, 6738, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                        &nbsp;&nbsp;<span class=""help-block"">*可为空，最多255个字符</span>
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <label for=""SysLogo"" class=""col-form-label col-2"">列表页分享图:</label>
                                        <div class=""input-group col-5"">
                                            <input type=""text"" class=""form-control upload-path"" name=""ListShareImage"" id=""ListShareImage""");
            BeginWriteAttribute("value", " value=\"", 7375, "\"", 7404, 1);
#nullable restore
#line 105 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml"
WriteAttributeValue("", 7383, Model.ListShareImage, 7383, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                            <button type=""button"" id=""j_upload_img_btn"">选择图片</button>
                                            <ul id=""upload_img_wrap""></ul>
                                        </div>
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <label for=""ImgUrlPic"" class=""col-form-label col-2""></label>
                                        <div class=""input-group col-5"">
                                            <img");
            BeginWriteAttribute("src", " src=\"", 8055, "\"", 8082, 1);
#nullable restore
#line 115 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml"
WriteAttributeValue("", 8061, Model.ListShareImage, 8061, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 8083, "\"", 8089, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""ImgUrlPic"" class=""img-rounded"" width=""100"" height=""100"" />
                                        </div>
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <label for=""DetailShareBgImg"" class=""col-form-label col-2"">详情页面海报背景图:</label>
                                        <div class=""input-group col-5"">
                                            <input type=""text"" class=""form-control upload-path"" name=""DetailShareBgImg"" id=""DetailShareBgImg""");
            BeginWriteAttribute("value", " value=\"", 8733, "\"", 8764, 1);
#nullable restore
#line 123 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml"
WriteAttributeValue("", 8741, Model.DetailShareBgImg, 8741, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                            <button type=""button"" id=""j_upload_DetailShareBgImgimg_btn"">选择图片</button>
                                            <ul id=""upload_img_wrap""></ul>
                                        </div>&nbsp;&nbsp;<span class=""help-block""> 只能上传【460px*736px】【PNG】【透明底】图片，否则将严重影响海报效果。</span>
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <label for=""ImgUrlPicDetailShareBgImg"" class=""col-form-label col-2""></label>
                                        <div class=""input-group col-5"">
                                            <img");
            BeginWriteAttribute("src", " src=\"", 9534, "\"", 9563, 1);
#nullable restore
#line 133 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml"
WriteAttributeValue("", 9540, Model.DetailShareBgImg, 9540, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 9564, "\"", 9570, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""ImgUrlPicDetailShareBgImg"" class=""img-rounded"" width=""100"" height=""100"" />
                                        </div>
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <label for=""ListNotice"" class=""col-form-label col-md-2"">列表公告内容:</label>
                                        <input type=""text"" class=""form-control col-md-5"" name=""ListNotice"" id=""ListNotice""");
            BeginWriteAttribute("value", " value=\"", 10132, "\"", 10157, 1);
#nullable restore
#line 140 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml"
WriteAttributeValue("", 10140, Model.ListNotice, 10140, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                        &nbsp;&nbsp;<span class=""help-block"">*可为空，最多255个字符</span>
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <label for=""ListNoticeUrl"" class=""col-form-label col-md-2"">列表公告内容链接:</label>
                                        <input type=""text"" class=""form-control col-md-5"" name=""ListNoticeUrl"" id=""ListNoticeUrl""");
            BeginWriteAttribute("value", " value=\"", 10703, "\"", 10731, 1);
#nullable restore
#line 147 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml"
WriteAttributeValue("", 10711, Model.ListNoticeUrl, 10711, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                        &nbsp;&nbsp;<span class=""help-block"">*可为空，最多255个字符</span>
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <div class=""row"">
                                        <label for=""DetailCopyRight"" class=""col-form-label col-md-2"">详情页版权说明:</label>
                                        <input type=""text"" class=""form-control col-md-5"" name=""DetailCopyRight"" id=""DetailCopyRight""");
            BeginWriteAttribute("value", " value=\"", 11282, "\"", 11312, 1);
#nullable restore
#line 154 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Areas\CMS\Views\ArticleNews\ArticleSetting.cshtml"
WriteAttributeValue("", 11290, Model.DetailCopyRight, 11290, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                        &nbsp;&nbsp;<span class=""help-block"">*可为空，最多255个字符</span>
                                    </div>
                                </div>
                            </div>

                            <div class=""modal-footer"">
                                <button type=""submit"" class=""btn btn-primary btnSave"" id=""btnSaveOK""><i class=""fa fa-save""></i>保存</button>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</div>
<textarea id=""uploadEditor"" style=""display: none;""></textarea>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7dbcc6d82edc1cefd56acc06afa0b65ed144fa323432", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7dbcc6d82edc1cefd56acc06afa0b65ed144fa324638", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7dbcc6d82edc1cefd56acc06afa0b65ed144fa325844", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<style type=""text/css"">
    label {
        text-align: right;
    }
</style>

<script type=""text/javascript"">
    var optUploadCurr = 0;
    // 实例化编辑器，这里注意配置项隐藏编辑器并禁用默认的基础功能。
    var uploadEditor = UE.getEditor(""uploadEditor"", {
        isShow: false,
        focus: false,
        enableAutoSave: false,
        autoSyncData: false,
        autoFloatEnabled: false,
        wordCount: false,
        sourceEditor: null,
        scaleEnabled: true,
        toolbars: [[""insertimage"", ""attachment""]]
    });

    // 监听多图上传和上传附件组件的插入动作
    uploadEditor.ready(function () {
        uploadEditor.addListener(""beforeInsertImage"", _beforeInsertImage);
    });
    // 自定义按钮绑定触发多图上传和上传附件对话框事件
    document.getElementById('j_upload_img_btn').onclick = function () {
        var dialog = uploadEditor.getDialog(""insertimage"");
        dialog.title = '多图上传';
        dialog.render();
        dialog.open();
        optUploadCurr = 0;
    };
    // 自定义按钮绑定触发多图上传和上传附件对话框事件
    document.getElementB");
            WriteLiteral(@"yId('j_upload_DetailShareBgImgimg_btn').onclick = function () {
        var dialog = uploadEditor.getDialog(""insertimage"");
        dialog.title = '多图上传';
        dialog.render();
        dialog.open();
        optUploadCurr = 1;
    };
    // 多图上传动作
    function _beforeInsertImage(t, result) {
        if (optUploadCurr == 0) {
            $(""#ListShareImage"").val(result[0].src);
            $(""#ImgUrlPic"").attr(""src"", result[0].src);
        } else if (optUploadCurr == 1) {
            $(""#DetailShareBgImg"").val(result[0].src);
            $(""#ImgUrlPicDetailShareBgImg"").attr(""src"", result[0].src);
        }
    };
    //checkbox实现单选
    $('inputp[type=checkbox]').click(function () {
        $(this).attr('checked', 'checked').siblings().removeAttr('checked');
    });
</script>
<!-- page script -->
<script>
    $(function () {
        //iCheck for checkbox and radio inputs
        $('input[type=""checkbox""].flat-red').iCheck({
            checkboxClass: 'icheckbox_minimal-blue',
   ");
            WriteLiteral(@"         radioClass: 'iradio_minimal',
        });
        InitDictItem();
        BindSaveEvent();
    });
    //初始化数据字典
    function InitDictItem() {
    }
    //绑定保存按钮的事件
    function BindSaveEvent() {
        $(""#btnSaveOK"").click(function () {
            $(""#frmSubmit"").validate({
                rules: {
                    SoftName: {
                        required: true,
                        minlength: 2
                    },
                },
                messages: {
                    SoftName: {
                        required: ""请输入应用名称"",
                        minlength: ""应用名称至少2个字符""
                    },
                },
                errorClass: 'help-block help-block-error',
                focusInvalid: true,
                //unhighlight: function (element, errorClass, validClass) { //验证通过
                //    $(element).tooltip('destroy').removeClass(errorClass);
                //},
                highlight: function (element) {//验证未通过
    ");
            WriteLiteral(@"                $(element).closest('.form-group').addClass('has-error');
                },
                success: function (label, element) {
                    $(element).closest('.form-group').removeClass('has-error');
                    //label.remove();
                    $(element).attr(""title"", """").tooltip(""hide"");
                    //alert(element);
                },
                errorPlacement: function (error, element) {
                    //element.parent('div').append(error);
                    if ($(element).next(""div"").hasClass(""tooltip"")) {
                        $(element).attr(""data-original-title"", $(error).text()).tooltip(""show"");
                    } else {
                        $(element).attr(""title"", $(error).text()).tooltip(""show"");
                    }
                },
                submitHandler: function (form) {
                    var postData = {
                        ""AppName"": $(""#AppName"").val(),
                        ""IsOpenPush"": ");
            WriteLiteral(@"$(""#IsOpenPush"").is(':checked'),
                        ""IsOpenAudit"": $(""#IsOpenAudit"").is(':checked'),
                        ""IsOpenRecommend"": $(""#IsOpenRecommend"").is(':checked'),
                        ""IsOpenReward"": $(""#IsOpenReward"").is(':checked'),
                        ""RewardAmount"": $(""#RewardAmount"").val(),
                        ""ListShareTitle"": $(""#ListShareTitle"").val(),
                        ""ListShareDesc"": $(""#ListShareDesc"").val(),
                        ""ListShareImage"": $(""#ListShareImage"").val(),
                        ""DetailCopyRight"": $(""#DetailCopyRight"").val(),
                        ""ListNotice"": $(""#ListNotice"").val(),
                        ""ListNoticeUrl"": $(""#ListNoticeUrl"").val(),
                        ""ListTitle"": $(""#ListTitle"").val(),
                        ""DetailShareBgImg"": $(""#DetailShareBgImg"").val(),

                    };
                    var reqUrl = ""/CMS/ArticleNews/SaveSetting"";
                    $.ajax({
                 ");
            WriteLiteral(@"       url: reqUrl,
                        data: postData,
                        dataType: 'json',//服务器返回json格式数据
                        type: 'post',//HTTP请求类型
                        timeout: 100000,//超时时间设置为10秒；
                        success: function (data) {
                            //服务器返回响应，根据响应结果，分析是否登录成功；
                            if (data.Success) {
                                $(""#frmSubmit"")[0].reset();
                                toastr.success(""操作成功"");
                                setTimeout(function () {
                                    window.location.href = ""/CMS/ArticleNews/ArticleSetting""
                                }, 1500);
                            } else {
                                toastr.warning(""操作失败："" + data.ErrMsg);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            toastr.warning(""操作失败："" + errorThrown);
        ");
            WriteLiteral("                }\r\n                    });\r\n                }\r\n            });\r\n        });\r\n    }\r\n\r\n</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Yuebon.CMS.Models.ArtSetting> Html { get; private set; }
    }
}
#pragma warning restore 1591
