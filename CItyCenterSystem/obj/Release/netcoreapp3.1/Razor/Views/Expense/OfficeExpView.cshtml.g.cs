#pragma checksum "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Expense\OfficeExpView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7665e928d237395f0a48ed1133533c88e7c9554b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Expense_OfficeExpView), @"mvc.1.0.view", @"/Views/Expense/OfficeExpView.cshtml")]
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
#line 21 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Expense\OfficeExpView.cshtml"
using FiboInfraStructure;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7665e928d237395f0a48ed1133533c88e7c9554b", @"/Views/Expense/OfficeExpView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd336beda5a2acf43ac2fe33525f36885b8934e6", @"/Views/_ViewImports.cshtml")]
    public class Views_Expense_OfficeExpView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FiboBilling.Src.ViewModel.ExpenseViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Expense\OfficeExpView.cshtml"
  
    decimal amount = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script type=""text/javascript"">
    function CallPrint(strid) {
        var mywindow = document.getElementById('profile');
        var popupWin = window.open('', ""Kaamana Format"", 'width=350,height=150,location=no,left=200px');

        popupWin.document.open();
        popupWin.document.write('<html><title>' + """" + '</title><link rel=""stylesheet"" type=""text/css""  href=""../Content/bootstrap.min.css"" /></head><body onload=""window.print()"">')
        popupWin.document.write('<html><title>' + """" + '</title><link rel=""stylesheet"" type=""text/css"" href=""../Content/print.css"" /></head><body onload=""window.print()"">')
        popupWin.document.write(mywindow.innerHTML);
        popupWin.document.write('</html>');

        popupWin.document.close();

    }

</script>
");
            WriteLiteral("<div class=\"col-lg-12\">\r\n    <div class=\"card\">\r\n        <div class=\"card-body\">\r\n");
#nullable restore
#line 25 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Expense\OfficeExpView.cshtml"
             using (Html.BeginForm("OfficeExpView", "Expense", FormMethod.Get, new { @class = "form-view-data" }))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-lg-12\">\r\n                    <div class=\"row\">\r\n                        <div class=\"col-lg-3\">\r\n                            <label>From Date</label>\r\n                            ");
#nullable restore
#line 31 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Expense\OfficeExpView.cshtml"
                       Write(Html.TextBoxFor(x => x.FromMiti, "{0:yyyy/MM/dd }", new { @class = "form-control nepali-datepicker", @placeholder = "yyyy/MM/dd", @autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div cl ass=\"col-lg-3\">\r\n                            <label>To Date</label>\r\n                            ");
#nullable restore
#line 35 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Expense\OfficeExpView.cshtml"
                       Write(Html.TextBoxFor(x => x.ToMiti, "{0:yyyy/MM/dd }", new { @class = "form-control nepali-datepicker", @placeholder = "yyyy/MM/dd", @autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                        <div class=""btn btn-group"">
                            <button type=""submit"" class=""btn btn-success"">Search</button>
                            <button type=""button"" class=""btn btn-success""
                                    style=""background-color:darkblue;color:white;font-weight:bold""
                                    onclick=""CallPrint('strid')"" data-ma-action=""print"">
                                <i class=""mdi mdi-cloud-print""></i> Print
                            </button>
                        </div>
                    </div>
                </div>
");
#nullable restore
#line 47 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Expense\OfficeExpView.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>
    </div>
</div>
<div class=""col-lg-12"" id=""profile"">
    <div class=""card"">
        <div class=""card-body"">

            <hr />
            <div class=""table-responsive"">
                <div class=""tableFixHead"">
                    <table class=""table table-bordered table-striped"" BORDER=""1"" width=""100%"">
                        <thead>
                            <tr>
                                <th>Date</th>
                                <th>Name</th>
                                <th>Total Amount</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 68 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Expense\OfficeExpView.cshtml"
                             foreach (var item in Model.Expenses.Where(x => x.IsInActive()))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 72 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Expense\OfficeExpView.cshtml"
                                   Write(item.Date.ToNepDate());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 75 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Expense\OfficeExpView.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 79 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Expense\OfficeExpView.cshtml"
                                   Write(item.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 82 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Expense\OfficeExpView.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td colspan=\"2\" style=\"text-align:right\">Total</td>\r\n                                <td>\r\n");
#nullable restore
#line 86 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Expense\OfficeExpView.cshtml"
                                     foreach (var item in Model.Expenses.Where(x => x.IsInActive()))
                                    {
                                        amount += item.Amount.ToDecimal();
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
#nullable restore
#line 90 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Expense\OfficeExpView.cshtml"
                               Write(amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7665e928d237395f0a48ed1133533c88e7c9554b10820", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 103 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Expense\OfficeExpView.cshtml"
 if (ViewBag.Message != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <script type=""text/javascript"">
    'use strict';
    $(window).on('load', function () {
        function notify(message) {
            $.notify({
                message: message,
                type: 'inverse',
                allow_dismiss: false,
                label: 'Cancel',
                className: 'btn-xs btn-inverse',
                placement: { from: 'bottom', align: 'right' },
                delay: 2500,
                animate: { enter: 'animated fadeInRight', exit: 'animated fadeOutRight' },
                offset: { x: 30, y: 30 }
            });
        };
        /**/
        notify('");
#nullable restore
#line 122 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Expense\OfficeExpView.cshtml"
           Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n    /**/\r\n    });\r\n    </script>\r\n");
#nullable restore
#line 126 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Expense\OfficeExpView.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FiboBilling.Src.ViewModel.ExpenseViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591