#pragma checksum "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Electricity\ToggleStatus.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5953c4953a6c82e47b69586772c23b903abfbc96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Electricity_ToggleStatus), @"mvc.1.0.view", @"/Views/Electricity/ToggleStatus.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5953c4953a6c82e47b69586772c23b903abfbc96", @"/Views/Electricity/ToggleStatus.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd336beda5a2acf43ac2fe33525f36885b8934e6", @"/Views/_ViewImports.cshtml")]
    public class Views_Electricity_ToggleStatus : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FiboInfraStructure.Entity.FiboBlock.Electricity>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ToggleStatus", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Electricity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Electricity\ToggleStatus.cshtml"
   Layout = null; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5953c4953a6c82e47b69586772c23b903abfbc964448", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 6 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Electricity\ToggleStatus.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 7 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Electricity\ToggleStatus.cshtml"
Write(Html.HiddenFor(x => x.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <div class=""modal-content"">
        <div class=""modal-header"">
            <h5 class=""modal-title"">Electricity Unit</h5>
            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true""><i class=""ti-close""></i></span></button>
        </div>
        <div class=""modal-body"">
            <p>
                Are You Sure to
");
#nullable restore
#line 16 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Electricity\ToggleStatus.cshtml"
                 if (Model.IsActive())
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <label style=\"color:darkred\">Disable</label>\r\n");
#nullable restore
#line 19 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Electricity\ToggleStatus.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <label style=\"color:green\">Enable</label>\r\n");
#nullable restore
#line 23 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Electricity\ToggleStatus.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                ?\r\n            </p>\r\n        </div>\r\n        <div class=\"modal-footer\">\r\n            <button type=\"button\" class=\"btn-sm  btn-secondary\" data-dismiss=\"modal\"><i class=\"ti-close\"></i> Cancel</button>\r\n");
#nullable restore
#line 29 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Electricity\ToggleStatus.cshtml"
             if (Model.IsActive())
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <button type=\"submit\" class=\"btn-sm  btn-danger\"><i class=\"ti-thumb-down\"></i> Disable</button>\r\n");
#nullable restore
#line 32 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Electricity\ToggleStatus.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <button type=\"submit\" class=\"btn-sm  btn-success\"><i class=\"ti-thumb-up\"></i> Enable</button>\r\n");
#nullable restore
#line 36 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Electricity\ToggleStatus.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FiboInfraStructure.Entity.FiboBlock.Electricity> Html { get; private set; }
    }
}
#pragma warning restore 1591
