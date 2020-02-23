#pragma checksum "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Views\MemberHome\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91ebcee248c4333fefe29eb13c8e261c5444e7ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MemberHome_Index), @"mvc.1.0.view", @"/Views/MemberHome/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91ebcee248c4333fefe29eb13c8e261c5444e7ed", @"/Views/MemberHome/Index.cshtml")]
    public class Views_MemberHome_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\netcorespace\YueGroup\权限管理\Yuebon.Manager\Yuebon.WebApp\Views\MemberHome\Index.cshtml"
  
    Layout = "~/Views/Shared/_LayoutMember.cshtml";
    ViewBag.CurrentMenu = "Home";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container-fluid"">
    <!-- Info boxes -->
    <div class=""row"">
        <div class=""col-12 col-sm-6 col-md-3"">
            <div class=""info-box"">
                <span class=""info-box-icon bg-info elevation-1""><i class=""fa fa-gear""></i></span>
                <div class=""info-box-content"">
                    <span class=""info-box-text"">CPU Traffic</span>
                    <span class=""info-box-number"">
                        10
                        <small>%</small>
                    </span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- /.col -->
        <div class=""col-12 col-sm-6 col-md-3"">
            <div class=""info-box mb-3"">
                <span class=""info-box-icon bg-danger elevation-1""><i class=""fa fa-google-plus""></i></span>
                <div class=""info-box-content"">
                    <span class=""info-box-text"">Likes</span>
                    <span ");
            WriteLiteral(@"class=""info-box-number"">41,410</span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- /.col -->
        <!-- fix for small devices only -->
        <div class=""clearfix hidden-md-up""></div>
        <div class=""col-12 col-sm-6 col-md-3"">
            <div class=""info-box mb-3"">
                <span class=""info-box-icon bg-success elevation-1""><i class=""fa fa-shopping-cart""></i></span>
                <div class=""info-box-content"">
                    <span class=""info-box-text"">Sales</span>
                    <span class=""info-box-number"">760</span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- /.col -->
        <div class=""col-12 col-sm-6 col-md-3"">
            <div class=""info-box mb-3"">
                <span class=""info-box-icon bg-warning elevation-1""><i class=""fa fa-users""></i></span>
 ");
            WriteLiteral(@"               <div class=""info-box-content"">
                    <span class=""info-box-text"">New Members</span>
                    <span class=""info-box-number"">2,000</span>
                </div>
                <!-- /.info-box-content -->
            </div>
            <!-- /.info-box -->
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->


    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""card"">
                <div class=""card-header"">
                    <h5 class=""card-title"">Monthly Recap Report</h5>
                    <div class=""card-tools"">
                        <button type=""button"" class=""btn btn-tool"" data-widget=""collapse"">
                            <i class=""fa fa-minus""></i>
                        </button>
                        <div class=""btn-group"">
                            <button type=""button"" class=""btn btn-tool dropdown-toggle"" data-toggle=""dropdown"">
                                <i class=""fa fa-wrench""");
            WriteLiteral(@"></i>
                            </button>
                            <div class=""dropdown-menu dropdown-menu-right"" role=""menu"">
                                <a href=""#"" class=""dropdown-item"">Action</a>
                                <a href=""#"" class=""dropdown-item"">Another action</a>
                                <a href=""#"" class=""dropdown-item"">Something else here</a>
                                <a class=""dropdown-divider""></a>
                                <a href=""#"" class=""dropdown-item"">Separated link</a>
                            </div>
                        </div>
                        <button type=""button"" class=""btn btn-tool"" data-widget=""remove"">
                            <i class=""fa fa-times""></i>
                        </button>
                    </div>
                </div>
                <!-- /.card-header -->
                <div class=""card-body"">
                    <div class=""row"">
                        <div class=""col-md-8"">
            ");
            WriteLiteral(@"                <p class=""text-center"">
                                <strong>Sales: 1 Jan, 2014 - 30 Jul, 2014</strong>
                            </p>
                            <div class=""chart"">
                                <!-- Sales Chart Canvas -->
                                <canvas id=""salesChart"" height=""180"" style=""height: 180px;""></canvas>
                            </div>
                            <!-- /.chart-responsive -->
                        </div>
                        <!-- /.col -->
                        <div class=""col-md-4"">
                            <p class=""text-center"">
                                <strong>Goal Completion</strong>
                            </p>
                            <div class=""progress-group"">
                                Add Products to Cart
                                <span class=""float-right""><b>160</b>/200</span>
                                <div class=""progress progress-sm"">
                         ");
            WriteLiteral(@"           <div class=""progress-bar bg-primary"" style=""width: 80%""></div>
                                </div>
                            </div>
                            <!-- /.progress-group -->
                            <div class=""progress-group"">
                                Complete Purchase
                                <span class=""float-right""><b>310</b>/400</span>
                                <div class=""progress progress-sm"">
                                    <div class=""progress-bar bg-danger"" style=""width: 75%""></div>
                                </div>
                            </div>
                            <!-- /.progress-group -->
                            <div class=""progress-group"">
                                <span class=""progress-text"">Visit Premium Page</span>
                                <span class=""float-right""><b>480</b>/800</span>
                                <div class=""progress progress-sm"">
                                    ");
            WriteLiteral(@"<div class=""progress-bar bg-success"" style=""width: 60%""></div>
                                </div>
                            </div>
                            <!-- /.progress-group -->
                            <div class=""progress-group"">
                                Send Inquiries
                                <span class=""float-right""><b>250</b>/500</span>
                                <div class=""progress progress-sm"">
                                    <div class=""progress-bar bg-warning"" style=""width: 50%""></div>
                                </div>
                            </div>
                            <!-- /.progress-group -->
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- ./card-body -->
                <div class=""card-footer"">
                    <div class=""row"">
                        <div class=""col-sm-3 col-6"">
         ");
            WriteLiteral(@"                   <div class=""description-block border-right"">
                                <span class=""description-percentage text-success""><i class=""fa fa-caret-up""></i> 17%</span>
                                <h5 class=""description-header"">$35,210.43</h5>
                                <span class=""description-text"">TOTAL REVENUE</span>
                            </div>
                            <!-- /.description-block -->
                        </div>
                        <!-- /.col -->
                        <div class=""col-sm-3 col-6"">
                            <div class=""description-block border-right"">
                                <span class=""description-percentage text-warning""><i class=""fa fa-caret-left""></i> 0%</span>
                                <h5 class=""description-header"">$10,390.90</h5>
                                <span class=""description-text"">TOTAL COST</span>
                            </div>
                            <!-- /.description-bloc");
            WriteLiteral(@"k -->
                        </div>
                        <!-- /.col -->
                        <div class=""col-sm-3 col-6"">
                            <div class=""description-block border-right"">
                                <span class=""description-percentage text-success""><i class=""fa fa-caret-up""></i> 20%</span>
                                <h5 class=""description-header"">$24,813.53</h5>
                                <span class=""description-text"">TOTAL PROFIT</span>
                            </div>
                            <!-- /.description-block -->
                        </div>
                        <!-- /.col -->
                        <div class=""col-sm-3 col-6"">
                            <div class=""description-block"">
                                <span class=""description-percentage text-danger""><i class=""fa fa-caret-down""></i> 18%</span>
                                <h5 class=""description-header"">1200</h5>
                                <span class=""de");
            WriteLiteral(@"scription-text"">GOAL COMPLETIONS</span>
                            </div>
                            <!-- /.description-block -->
                        </div>
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.card-footer -->
            </div>
            <!-- /.card -->
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
