#pragma checksum "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a90127f3c8feb5cc0c545c8b92520630dd12d657"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Billing__billingDetails), @"mvc.1.0.view", @"/Views/Billing/_billingDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a90127f3c8feb5cc0c545c8b92520630dd12d657", @"/Views/Billing/_billingDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd336beda5a2acf43ac2fe33525f36885b8934e6", @"/Views/_ViewImports.cshtml")]
    public class Views_Billing__billingDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FiboBilling.Src.Dto.BillingDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control DebitTotal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control CreditTotal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Fine"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("autocomplete", new global::Microsoft.AspNetCore.Html.HtmlString("off"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onkeyup", new global::Microsoft.AspNetCore.Html.HtmlString("CalculateNetPayable()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Discount"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control NetPayable"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("NetPayable"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateBilling", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Billing", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("needs-validation"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
   ViewBag.Title = "_billingDetails"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a90127f3c8feb5cc0c545c8b92520630dd12d6578376", async() => {
                WriteLiteral("\n    ");
#nullable restore
#line 5 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
                WriteLiteral("\n    ");
#nullable restore
#line 6 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
Write(Html.HiddenFor(x => x.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n    ");
#nullable restore
#line 7 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
Write(Html.HiddenFor(x => x.CreatedDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n    ");
#nullable restore
#line 8 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
Write(Html.HiddenFor(x => x.CreatedBy));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n    ");
#nullable restore
#line 9 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
Write(Html.HiddenFor(x => x.ModifiedBy));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n    ");
#nullable restore
#line 10 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
Write(Html.HiddenFor(x => x.ModifiedDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n    ");
#nullable restore
#line 11 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
Write(Html.HiddenFor(x => x.ClientId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n    ");
#nullable restore
#line 12 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
Write(Html.HiddenFor(x => x.BlockId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n    ");
#nullable restore
#line 13 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
Write(Html.HiddenFor(x => x.RoomId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n    ");
#nullable restore
#line 14 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
Write(Html.HiddenFor(x => x.DueAmount));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n    ");
#nullable restore
#line 15 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
Write(Html.HiddenFor(x => x.DueDate));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <div class=""card-body"">
        <div class=""table-responsive"">
            <table class=""table table-bordered"" id=""table"">
                <thead>
                    <tr style=""background-color: #4CAF50; color: white; height: 2px; line-height: 2px; text-align: center"">
                        <th style=""width: 10%;"">Year</th>
                        <th style=""width: 10%;"">Month</th>
                        <th>Rent Amount</th>
                        <th style=""width: 8%;"">Unit</th>
                        <th style=""width: 8%;"">Unit Amount</th>
                        <th>Total</th>
                        <th>Debit</th>
                        <th>Credit</th>
                        <th>Remarks</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 33 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
                     if (Model.billingDetails.Count() > 0)
                    {
                        for (int k = 0; k < Model.billingDetails.Count(); k++)
                        {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
   Write(Html.HiddenFor(x => x.billingDetails[k].Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
                       Write(Html.HiddenFor(x => x.billingDetails[k].BillingId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
                                           Write(Html.HiddenFor(x => x.billingDetails[k].CreatedDate));

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
                                                               Write(Html.HiddenFor(x => x.billingDetails[k].CreatedBy));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                                                        <tr>
                                                                                            <td>
                                                                                                ");
#nullable restore
#line 43 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
                                                                                           Write(Html.DropDownListFor(x => x.billingDetails[k].YearId, Model.YearList, new { @class = "form-control YearId", @readonly = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

                                                                                            </td>
                                                                                            <td>
                                                                                                ");
#nullable restore
#line 47 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
                                                                                           Write(Html.DropDownListFor(x => x.billingDetails[k].MonthId, Model.MonthList, new { @class = "form-control MonthId", @readonly = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                                                            </td>
                                                                                            <td>
                                                                                                ");
#nullable restore
#line 50 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
                                                                                           Write(Html.TextBoxFor(x => x.billingDetails[k].RentAmount, new { @class = "form-control RentAmount", @readonly = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                                                            </td>
                                                                                            <td>
                                                                                                ");
#nullable restore
#line 53 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
                                                                                           Write(Html.TextBoxFor(x => x.billingDetails[k].ElectricityUnit, new { @class = "form-control ElectricityUnit", @readonly = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                                                            </td>
                                                                                            <td>
                                                                                                ");
#nullable restore
#line 56 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
                                                                                           Write(Html.TextBoxFor(x => x.billingDetails[k].ElectricityBillAmount, new { @class = "form-control Rate ElectricityBillAmount", @readonly = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                                                            </td>
                                                                                            <td>
                                                                                                ");
#nullable restore
#line 59 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
                                                                                           Write(Html.TextBoxFor(x => x.billingDetails[k].Total, new { @class = "form-control Total", @readonly = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                                                            </td>
                                                                                            <td>
                                                                                                ");
#nullable restore
#line 62 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
                                                                                           Write(Html.TextBoxFor(x => x.billingDetails[k].Debit, new { @class = "form-control Rate Debit", @onkeyup = "DebitAmount(this,event)", @readonly = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                                                            </td>
                                                                                            <td>
                                                                                                ");
#nullable restore
#line 65 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
                                                                                           Write(Html.TextBoxFor(x => x.billingDetails[k].Credit, new { @class = "form-control Rate Credit", @onkeyup = "CreditAmount(this,event)", @readonly = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                                                            </td>
                                                                                            <td>
                                                                                                ");
#nullable restore
#line 68 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
                                                                                           Write(Html.TextBoxFor(x => x.billingDetails[k].Remarks, new { @class = "form-control Rate Remarks" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                                                                                            </td>\n                                                                                        </tr>\n");
#nullable restore
#line 71 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
}

                                                                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </tbody>
                <tfoot>
                    <tr>
                        <td colspan=""5"" style=""text-align:right"">
                            Total
                        </td>
                        <td colspan=""1"">
                            <input type=""text"" class=""form-control GrandTotal"" id=""GrandTotal"" readonly />
                        </td>
                        <td>
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a90127f3c8feb5cc0c545c8b92520630dd12d65721002", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 84 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.DebitTotal);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("readonly", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                        </td>\n                        <td>\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a90127f3c8feb5cc0c545c8b92520630dd12d65723210", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 87 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CreditTotal);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("readonly", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                        </td>
                        <td colspan=""1"">
                        </td>
                    </tr>
                    <tr>
                        <td colspan=""5"" style=""text-align:right"">
                            Fine
                        </td>
                        <td>
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a90127f3c8feb5cc0c545c8b92520630dd12d65725674", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 97 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Fine);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("required", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

                        </td>
                        <td colspan=""3"">
                        </td>
                    </tr>
                    <tr>
                        <td colspan=""5"" style=""text-align:right"">
                            Discount
                        </td>
                        <td>
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a90127f3c8feb5cc0c545c8b92520630dd12d65728397", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 108 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Discount);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("required", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

                        </td>
                        <td colspan=""3"">
                        </td>
                    </tr>
                    <tr>
                        <td colspan=""5"" style=""text-align:right"">
                            Net Payable
                        </td>
                        <td colspan=""1"">
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a90127f3c8feb5cc0c545c8b92520630dd12d65731142", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 119 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Billing\_billingDetails.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BillingAmount);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("readonly", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                        </td>
                        <td colspan=""3"">
                        </td>
                    </tr>
                </tfoot>

            </table>
        </div>
        <div class=""card-footer"">
            <div class=""form-group"">
                <div class=""col-md-12"" style=""text-align:right"">
                    <button type=""submit"" style=""margin-right:-40px"" class=""btn  btn-success"" id=""btnSubmit""><i class=""feather mr-2 icon-check-square""></i>Submit</button>
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("novalidate", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FiboBilling.Src.Dto.BillingDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
