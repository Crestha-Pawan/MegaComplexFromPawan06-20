#pragma checksum "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\SalarySheet\SalarySheetReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ca6337c540f97290e7c096b3ba9ac599a4a278db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SalarySheet_SalarySheetReport), @"mvc.1.0.view", @"/Views/SalarySheet/SalarySheetReport.cshtml")]
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
#nullable restore
#line 6 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\SalarySheet\SalarySheetReport.cshtml"
using FiboInfraStructure;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca6337c540f97290e7c096b3ba9ac599a4a278db", @"/Views/SalarySheet/SalarySheetReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd336beda5a2acf43ac2fe33525f36885b8934e6", @"/Views/_ViewImports.cshtml")]
    public class Views_SalarySheet_SalarySheetReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Payroll.Src.ViewModel.SalarySheetViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("select2 form-control custom-select"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SalarySheetReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "SalarySheet", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\SalarySheet\SalarySheetReport.cshtml"
   Layout = "~/Views/Shared/_Layout.cshtml";
    ViewBag.Title = "Index";
    decimal? netsalary = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\SalarySheet\SalarySheetReport.cshtml"
 using (Html.BeginForm("SalarySheetReport", "SalarySheet", FormMethod.Get, new { @class = "form-view-data" }))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-sm-12\">\r\n        <div class=\"card\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca6337c540f97290e7c096b3ba9ac599a4a278db6285", async() => {
                WriteLiteral(@"
                <div class=""card-body"">
                    <div class=""col-lg-12"">
                        <div class=""row"">
                            <div class=""col-lg-4"">
                                <label>Employee Name</label><br />
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca6337c540f97290e7c096b3ba9ac599a4a278db6831", async() => {
                    WriteLiteral("\r\n                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca6337c540f97290e7c096b3ba9ac599a4a278db7135", async() => {
                        WriteLiteral("---Select Employee---");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 19 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\SalarySheet\SalarySheetReport.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.EmployeeId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 19 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\SalarySheet\SalarySheetReport.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.EmployeeList;

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
                                <div style=""text-align:left"">
                                    <div class=""btn btn-group"">
                                        <button type=""submit"" class=""btn btn-success"">Search</button>
                                        <button type=""button"" class=""btn btn-secondary"" style=""float: right""");
                BeginWriteAttribute("onclick", "\r\n                                                onclick=\"", 1455, "\"", 1581, 5);
                WriteAttributeValue("", 1514, "window.location.href", 1514, 20, true);
                WriteAttributeValue(" ", 1534, "=", 1535, 2, true);
                WriteAttributeValue(" ", 1536, "\'", 1537, 2, true);
#nullable restore
#line 28 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\SalarySheet\SalarySheetReport.cshtml"
WriteAttributeValue("", 1538, Url.Action("ExportToExcel","SalarySheet"), 1538, 42, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1580, "\'", 1580, 1, true);
                EndWriteAttribute();
                WriteLiteral(@">
                                            Export Excel
                                        </button>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 41 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\SalarySheet\SalarySheetReport.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""col-sm-12"">
    <div class=""card"">
        <div class=""card-body"">
            <hr />
            <div class=""table-responsive"">
                <div class=""tableFixHead"">
                    <table class=""table table-bordered"">
                        <thead style=""background-color: #FFFFFFCC;"">
                            <tr>
                                <th>Name</th>
                                <th>Salary</th>
                                <th style=""text-align:center"">
                                    Action
                                </th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 60 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\SalarySheet\SalarySheetReport.cshtml"
                             foreach (var item in Model.SalarySheetVMList)
                            {

                                var employee = await _re.GetByIdAsync((long)item.EmployeeId);


#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 68 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\SalarySheet\SalarySheetReport.cshtml"
                                   Write(employee.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>");
#nullable restore
#line 70 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\SalarySheet\SalarySheetReport.cshtml"
                                   Write(employee.BasicSalary);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td style=\"text-align:center\">\r\n\r\n                                        <div class=\"overlay-edit\">\r\n\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 3292, "\"", 3390, 1);
#nullable restore
#line 75 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\SalarySheet\SalarySheetReport.cshtml"
WriteAttributeValue("", 3299, Url.Action("MonthlyReport","SalarySheet", new { id=item.EmployeeId, actionName="Report" }), 3299, 91, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" data-toggle=""tooltip"" title=""Monthly Report!""><i class=""ti-eye"" aria-hidden=""true"" style=""font-size:21px; text-align:center""></i></a>
                                        </div>
                                    </td>
                                </tr>
");
#nullable restore
#line 79 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\SalarySheet\SalarySheetReport.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>

            </div>
        </div>
    </div>
</div>
<div class=""modal"" id=""myModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-md"" id=""DeleteBody"">

        <!-- /.modal-content -->
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca6337c540f97290e7c096b3ba9ac599a4a278db16901", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(""#myModal"").on('show.bs.modal', function (ke) {
            const SalaryId = $(ke.relatedTarget).attr('SalaryId');
            const type = $(ke.relatedTarget).attr('ReferenceType');
            if (SalaryId > 0) {
                if (type == null) {
                    var url = '");
#nullable restore
#line 104 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\SalarySheet\SalarySheetReport.cshtml"
                          Write(Url.Action("Delete", "SalarySheet"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\' + \"?id=\" + SalaryId;\r\n                    $(\"#DeleteBody\").load(url, function () {\r\n\r\n                        $(\"#myModal\").modal(\'show\');\r\n                    });\r\n                }\r\n                else {\r\n                    var url = \'");
#nullable restore
#line 111 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\SalarySheet\SalarySheetReport.cshtml"
                          Write(Url.Action("Update", "SalarySheet"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\' + \"?id=\" + SalaryId;\r\n                    $(\"#DeleteBody\").load(url, function () {\r\n\r\n                        $(\"#myModal\").modal(\'show\');\r\n                    });\r\n                }\r\n            }\r\n            else {\r\n                 var url = \'");
#nullable restore
#line 119 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\SalarySheet\SalarySheetReport.cshtml"
                       Write(Url.Action("Create", "SalarySheet"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';
                 $(""#DeleteBody"").load(url, function () {

                     $(""#myModal"").modal('show');
                 });
             }
        })

        $(document).ready(function () {
            $('[data-toggle=""tooltip""]').tooltip();
        });
    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Payroll.InfraStructure.Repository.IEmployeeRepository _re { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Payroll.Src.ViewModel.SalarySheetViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591