#pragma checksum "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23421fda9c9bce415ecf7c73ee0874f32650505a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ElectricityUnitSetup_Index), @"mvc.1.0.view", @"/Views/ElectricityUnitSetup/Index.cshtml")]
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
#line 1 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\_ViewImports.cshtml"
using CItyCenterSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\_ViewImports.cshtml"
using CItyCenterSystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23421fda9c9bce415ecf7c73ee0874f32650505a", @"/Views/ElectricityUnitSetup/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd336beda5a2acf43ac2fe33525f36885b8934e6", @"/Views/_ViewImports.cshtml")]
    public class Views_ElectricityUnitSetup_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FiboBlock.Src.ViewModel.ElectricityUnitSetupViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("select2 custom-select form-control ClientId"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("select2 custom-select form-control BlockId"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ElectricityUnitSetup", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(" btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
  Layout = "~/Views/Shared/_Layout.cshtml";
    ViewBag.Title = "Index"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"col-lg-12\">\r\n    <div class=\"card\">\r\n        <div class=\"card-body\">\r\n");
#nullable restore
#line 13 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
             using (Html.BeginForm("Index", "ElectricityUnitSetup", FormMethod.Get, new { @class = "form-view-data" }))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""col-sm-12"">
                    <div class=""card"">
                        <div class=""card-body"">
                            <div class=""row"">
                                <div class=""col-lg-4"">
                                    <label for=""ClientName"">Client Name<br /><span style=""color:red"" id=""message""></span></label><br />
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23421fda9c9bce415ecf7c73ee0874f32650505a7681", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 21 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ClientId);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 21 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.ClientSelectList;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                </div>
                                <div class=""col-lg-4"">
                                    <label for=""Block"">Block<br /><span style=""color:red"" id=""message""></span></label><br />
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23421fda9c9bce415ecf7c73ee0874f32650505a9958", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 25 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BlockId);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 25 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.BlockList;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                </div>
                                <div class=""btn btn-group"">
                                    <button type=""submit"" class=""btn btn-success"">Search</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
");
#nullable restore
#line 34 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"col-lg-12\">\r\n    <div class=\"card\">\r\n        <div class=\"card-body\">\r\n            <div style=\"text-align:left\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23421fda9c9bce415ecf7c73ee0874f32650505a12745", async() => {
                WriteLiteral("<i class=\"ti-plus\"></i> Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <hr />
            <div class=""table-responsive"">
                <div class=""tableFixHead"">
                    <table class=""table table-bordered"">
                        <thead style=""background-color: #FFFFFFCC;"">
                            <tr>
                                <th>
                                    Year/Month
                                </th>
                                <th>Block Name</th>
                                <th>Room Name</th>
                                <th>Client Name</th>
                                <th>Unit</th>
                                <th>Rate</th>
                                <th>Amount</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 64 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
                             foreach (var item in Model.Electricities)
                            {
                                var block = await _blockrepo.GetByIdAsync((long)item.BlockId);
                                var room = await _roomrepo.GetByIdAsync((long)item.RoomId);
                                var client = await _clientrepo.GetByIdAsync((long)item.ClientId);

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n");
#nullable restore
#line 71 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
                                          
                                            var year = await _yearRepo.GetByIdAsync((long)item.YearId);
                                            var month = await _monthRepo.GetByIdAsync((long)item.MonthId);
                                            var YearMonth = string.Format("{0}/{1}", year.YearName, month.MonthName);

                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
#nullable restore
#line 77 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
                                   Write(YearMonth);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n");
#nullable restore
#line 80 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
                                         if (item.BlockId != null)
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
                                       Write(block.Name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
                                                       
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 86 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
                                   Write(room.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 89 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
                                   Write(client.OwnerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 92 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
                                   Write(item.Unit);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 95 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
                                   Write(item.Rate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>");
#nullable restore
#line 97 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
                                   Write(item.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                    <td style=""text-align:center"">
                                        <div class=""overlay-edit"">
                                            <div class=""btn-group-sm"">
                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23421fda9c9bce415ecf7c73ee0874f32650505a19791", async() => {
                WriteLiteral("<i class=\"ti-pencil-alt\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 101 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
                                                                                                                                                        WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                <a type=\"button\" class=\" btn btn-danger\" href=\"#!\" data-toggle=\"modal\"");
            BeginWriteAttribute("RoomId", " RoomId=\"", 5607, "\"", 5624, 1);
#nullable restore
#line 102 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
WriteAttributeValue("", 5616, item.Id, 5616, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-target=\"#myModal\"><i class=\"ti-trash\"></i></a>\r\n                                            </div>\r\n                                        </div>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 107 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23421fda9c9bce415ecf7c73ee0874f32650505a23605", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 118 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
 if (ViewBag.Message != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <script type=""text/javascript"">
    'use strict';
    $(window).on('load', function () {
        function notify(message,type) {
            $.growl({
                message: message
            }, {
                type: type,
                allow_dismiss: false,
                label: 'Cancel',
                className: 'btn-xs btn-inverse',
                placement: {from: 'top', align: 'right'},
                delay: 2500,
                animate: { enter: 'animated rotateIn', exit: 'animated rotateIn'},
                offset: {x: 30,y: 30}
            });
        };
        notify('");
#nullable restore
#line 137 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
           Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\'success\');\r\n    });\r\n\r\n    </script>\r\n");
#nullable restore
#line 141 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            DefineSection("scripts", async() => {
                WriteLiteral(@"

    <script>
        $(document).ready(function () {
            $(function () {
                $("".ClientId"").change();
            });

        });
    </script>
    <script type=""text/javascript"">
       $("".ClientId"").change(function () {
            var Id = $(""#ClientId"").val();
            $.ajax({
                data: { Id: Id },
                dataType: ""Json"",
                type: ""GET"",
                url: '");
#nullable restore
#line 159 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\ElectricityUnitSetup\Index.cshtml"
                 Write(Url.Action("LoadRoomBlock", "Billing"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                success: function (blocks) {
                    debugger;
                    $('#BlockId').empty();
                    let i = 0;
                    for (var client in blocks) {
                        var html = '<option value=""' + blocks[i].id + '"">' + blocks[i].name + '</option>';
                        $('#BlockId').append(html);
                        i++;
                    }
                }
            });
       });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FiboOffice.InfraStructure.Repository.IMonthRepository _monthRepo { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FiboOffice.InfraStructure.Repository.IYearRepository _yearRepo { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FiboBlock.InfraStructure.Repository.IClientRepository _clientrepo { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FiboBlock.InfraStructure.Repository.IRoomRepository _roomrepo { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FiboBlock.InfraStructure.Repository.IBlockRepository _blockrepo { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FiboBlock.Src.ViewModel.ElectricityUnitSetupViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
