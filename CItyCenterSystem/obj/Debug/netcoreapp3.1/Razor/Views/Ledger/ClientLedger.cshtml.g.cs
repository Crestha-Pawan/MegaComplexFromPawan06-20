#pragma checksum "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5fea6627c246762f0d77c12448b55a1a47119ed3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ledger_ClientLedger), @"mvc.1.0.view", @"/Views/Ledger/ClientLedger.cshtml")]
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
#line 25 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
using FiboInfraStructure;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5fea6627c246762f0d77c12448b55a1a47119ed3", @"/Views/Ledger/ClientLedger.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd336beda5a2acf43ac2fe33525f36885b8934e6", @"/Views/_ViewImports.cshtml")]
    public class Views_Ledger_ClientLedger : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FiboBlock.Src.ViewModel.ClientViewModel>
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
#line 2 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
   Layout = "~/Views/Shared/_Layout.cshtml";
    ViewBag.Title = "Index";

    var clientList = await _clientRepo.GetAllClientAsync();
    var client = clientList.Where(x => x.Id == ViewBag.ClientID).FirstOrDefault();

    int count = 1;
    decimal? balance = 0;
    decimal? totalDr = 0;
    decimal? totalCr = 0;
    decimal? pmBalance = 0;
    decimal? pmTotalDr = 0;
    decimal? pmTotalCr = 0;
    decimal? totalBalance = 0;
    decimal? pmTotalBalance = 0;
    var blockList = await _blockRepo.GetAllBlockAsync();
    var roomList = await _roomRepo.GetAllRoomAsync();
    var clientBlock = await _clientBlockRepo.GetAllClientBlockRoomSetupAsync();
    decimal credit = 0;
    decimal debit = 0;
    var _block = string.Empty;
    var _room = string.Empty;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">
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
<div class=""col-lg-12"">
    <div class=""card"">
        <div class=""card-body"">
");
#nullable restore
#line 53 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
             using (Html.BeginForm("ClientLedger", "Ledger", FormMethod.Post, new { @class = "form-view-data" }))
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
           Write(Html.HiddenFor(x => x.ClientId));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""row"">
                    <div class=""col-lg-12"">
                        <div class=""row"">
                            <div class=""col-lg-3"">
                                <label>From Date</label>
                                ");
#nullable restore
#line 61 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                           Write(Html.TextBoxFor(x => x.FromMiti, "{0:yyyy/MM/dd }", new { @class = "form-control nepali-datepicker", @placeholder = "yyyy/MM/dd", @autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"col-lg-3\">\r\n                                <label>To Date</label>\r\n                                ");
#nullable restore
#line 65 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
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
                                <button type=""button"" class=""btn btn-secondary"" style=""float: right""");
            BeginWriteAttribute("onclick", "\r\n                                        onclick=\"", 3899, "\"", 4050, 5);
            WriteAttributeValue("", 3950, "window.location.href", 3950, 20, true);
            WriteAttributeValue(" ", 3970, "=", 3971, 2, true);
            WriteAttributeValue(" ", 3972, "\'", 3973, 2, true);
#nullable restore
#line 75 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
WriteAttributeValue("", 3974, Url.Action("LedgerExportToExcel","Ledger", new { clientId=Model.ClientId}), 3974, 75, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4049, "\'", 4049, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    Export Excel\r\n                                </button>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 82 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>
    </div>
</div>
<div class=""col-sm-12"" id=""profile"">
    <div class=""card"">
        <div class=""card-header""><h4>Client Information</h4><hr /></div>
        <div class=""card-body"">
            <table width=""100%"">
                <tr>
                    <td>
                        <label>Business Name</label>
                        <label>");
#nullable restore
#line 95 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                          Write(Model.Clients.FirstOrDefault().BusinessName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                    </td>\r\n                    <td>\r\n                        <label>Owner Name</label>\r\n                        <label>");
#nullable restore
#line 99 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                          Write(Model.Clients.FirstOrDefault().OwnerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                    </td>\r\n                    <td>\r\n                        <label>Contact</label>\r\n                        <label>");
#nullable restore
#line 103 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                          Write(Model.Clients.FirstOrDefault().ContactNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td>\r\n                        <label>RoomNo</label>\r\n                        <label>\r\n");
#nullable restore
#line 110 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                             foreach (var _detail in clientBlock.Where(x => x.ClientId == Model.Clients.FirstOrDefault().Id).ToList())
                            {
                                if (_detail.RoomId.Contains(","))
                                {
                                    string[] _tmpRoom = _detail.RoomId.Split(",");
                                    foreach (var id in _tmpRoom)
                                    {
                                        var room = roomList.Where(x => x.Id == long.Parse(id)).FirstOrDefault();
                                        _room += room.Name + ",";
                                    }
                                }
                                else
                                {
                                    var room = roomList.Where(x => x.BlockId == _detail.BlockId).FirstOrDefault();
                                    _room += room.Name + ",";
                                }
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
#nullable restore
#line 127 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                       Write(_room);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        </label>\r\n                    </td>\r\n                    <td>\r\n                        <label>Block No</label>\r\n                        <label>\r\n");
#nullable restore
#line 134 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                             foreach (var _detail in clientBlock.Where(x => x.ClientId == Model.Clients.FirstOrDefault().Id).ToList())
                            {
                                var block = await _blockRepo.GetByIdAsync((long)_detail.BlockId);
                                _block += block.Name + ",";
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
#nullable restore
#line 139 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                       Write(_block);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </label>\r\n                    </td>\r\n                    <td>\r\n                        <label>Opening Balance / Collatterol</label>\r\n                        <label>");
#nullable restore
#line 144 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                          Write(Model.Clients.FirstOrDefault().Collateral);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                        <br />\r\n                        <label>Closing Balance</label>\r\n");
#nullable restore
#line 147 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                         foreach (var item in Model.Billings)
                        {
                            credit += item.CashReceived.ToDecimal()+item.DuePaid.ToDecimal();
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 151 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                           var openingBal = Model.Clients.FirstOrDefault().Collateral; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 152 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                         if (openingBal.ToDecimal() > credit)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <label style=\"color:red\">");
#nullable restore
#line 154 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                                Write(credit);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>");
#nullable restore
#line 154 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                                                    }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <label style=\"color:green\">");
#nullable restore
#line 157 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                                  Write(credit);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>");
#nullable restore
#line 157 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                                                      }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td>\r\n                        <label></label>\r\n");
#nullable restore
#line 163 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                         foreach (var item in Model.Billings)
                        {
                            balance += item.CashReceived.ToDecimal() + item.DuePaid.ToDecimal();
                            totalBalance += item.GrandTotal.ToDecimal() + item.Fine.ToDecimal() + item.ElectricityFineAmount.ToDecimal() - item.Discount.ToDecimal();
                            totalDr = totalBalance - balance;
                            totalCr = balance - totalBalance;
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 170 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                         if (balance > totalBalance)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <label style=\"color:green\"> Cr(Advance) : ");
#nullable restore
#line 172 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                                                 Write(totalCr);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n");
#nullable restore
#line 173 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <lable style=\"color:red\">Dr(Due) : ");
#nullable restore
#line 176 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                                          Write(totalDr);

#line default
#line hidden
#nullable disable
            WriteLiteral("</lable>\r\n");
#nullable restore
#line 177 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                </tr>\r\n            </table>\r\n        </div>\r\n        <hr />\r\n        <div class=\"card-body\">\r\n");
            WriteLiteral(@"            <hr />
            <div class=""table-responsive"">
                <div class=""tableFixHead"">
                    <table class=""table table-bordered table-striped"" BORDER=""1"" width=""100%"">
                        <thead style=""background-color: #FFFFFFCC;"">
                            <tr>
                                <th>
                                    Date
                                </th>
                                <th>
                                    Particular
                                </th>
                                <th>Vch No.</th>
                                <th>
                                    Block
                                </th>
                                <th>Room</th>
                                <th>
                                    Room Rent
                                </th>
                                <th>
                                    Unit
                                </th>
            ");
            WriteLiteral(@"                    <th>
                                    Unit Charge
                                </th>
                                <th>Rent Fine</th>
                                <th>Electricity Fine</th>
                                <th>
                                    Total Amount
                                </th>
                                <th>
                                    Received Amount
                                </th>
                                <th>
                                    Due Amount
                                </th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 225 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                             foreach (var item in Model.Billings)
                            {

                                DateTime? dt = item.CreatedDate;
                                var detail = await _bDRepo.GetAllBillingAsync();
                                decimal rent = 0;
                                decimal unit = 0;
                                decimal electricity = 0;
                                decimal due = 0;
                                due = item.DuePaid.ToDecimal();
                                //decimal debit =0;
                                //decimal credit =0;
                                pmTotalDr = item.GrandTotal.ToDecimal() + item.Fine.ToDecimal() + item.ElectricityFineAmount.ToDecimal() - item.Discount.ToDecimal() - item.DuePaid.ToDecimal();
                                pmTotalCr = item.CashReceived.ToDecimal();
                                //var room = await _roomRepo.GetByIdAsync((long)item.RoomId);
                                //var block = await _blockRepo.GetByIdAsync((long)item.BlockId);
                                string YearMonth = string.Empty;
                                string Room = string.Empty;
                                string Block = string.Empty;



                                foreach (var _detail in detail.Where(x => x.BillingId == item.Id).ToList())
                                {
                                    rent += _detail.RentAmount.ToDecimal();
                                    electricity += _detail.ElectricityBillAmount.ToDecimal();
                                    unit += _detail.ElectricityUnit.ToDecimal();
                                    //total += _detail.Total.ToDecimal();
                                    //debit += _detail.Debit.ToDecimal();
                                    //credit += _detail.Credit.ToDecimal();
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 258 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                   Write(dt.ToNepDate());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n");
#nullable restore
#line 261 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                         foreach (var _detail in detail.Where(x => x.BillingId == item.Id).GroupBy(x => x.MonthId).Select(x => x.First()).ToList())
                                        {
                                            var year = await _yearRepo.GetByIdAsync((long)_detail.YearId);
                                            var month = await _monthRepo.GetByIdAsync((long)_detail.MonthId);
                                            YearMonth = string.Format("{0}/{1}", year.YearName, month.MonthName);
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 266 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                       Write(YearMonth);

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <br /><br />\r\n");
#nullable restore
#line 268 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 271 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                   Write(item.BillNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n");
#nullable restore
#line 274 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                         foreach (var _detail in detail.Where(x => x.BillingId == item.Id).GroupBy(x => x.BlockId).Select(x => x.First()).ToList())
                                        {
                                            var block = await _blockRepo.GetByIdAsync((long)_detail.BlockId);
                                            Block = block.Name;
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 278 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                       Write(Block);

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <br /><br />\r\n");
#nullable restore
#line 280 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td>\r\n");
#nullable restore
#line 283 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                         foreach (var _detail in detail.Where(x => x.BillingId == item.Id).GroupBy(x => x.RoomId).Select(x => x.First()).ToList())
                                        {
                                            var room = await _roomRepo.GetByIdAsync((long)_detail.RoomId);
                                            Room = room.Name;
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 287 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                       Write(Room);

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <br /><br />\r\n");
#nullable restore
#line 289 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 293 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                   Write(rent);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 296 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                   Write(unit);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 299 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                   Write(electricity);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>");
#nullable restore
#line 301 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                   Write(item.Fine);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 302 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                   Write(item.ElectricityFineAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 304 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                   Write(pmTotalDr);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n");
#nullable restore
#line 307 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                         if (due > pmTotalDr)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span>");
#nullable restore
#line 309 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                             Write(due.ToString().Trim('-'));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span><span style=\"color:red;\"><b>(Due Received)</b></span>\r\n");
#nullable restore
#line 310 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                        }
                                        else
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 313 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                       Write(item.CashReceived);

#line default
#line hidden
#nullable disable
#nullable restore
#line 313 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                                              
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td>\r\n");
#nullable restore
#line 317 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                          
                                            pmTotalBalance = pmTotalDr - pmTotalCr;
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 320 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                         if (pmTotalBalance.ToString().Contains('-'))
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span>(");
#nullable restore
#line 322 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                              Write(pmTotalBalance.ToString().Trim('-'));

#line default
#line hidden
#nullable disable
            WriteLiteral(")</span>\r\n");
#nullable restore
#line 323 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                        }
                                        else
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 326 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                       Write(pmTotalBalance);

#line default
#line hidden
#nullable disable
#nullable restore
#line 326 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                                           
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 330 "E:\Mega-Complex_City_Center_V4\CItyCenterSystem\Views\Ledger\ClientLedger.cshtml"
                                count++;
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5fea6627c246762f0d77c12448b55a1a47119ed333427", async() => {
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
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FiboBlock.InfraStructure.Repository.IClientBlockRoomSetupRepository _clientBlockRepo { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FiboBlock.InfraStructure.Repository.IBlockRepository _blockRepo { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FiboBlock.InfraStructure.Repository.IRoomRepository _roomRepo { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FiboOffice.InfraStructure.Repository.IMonthRepository _monthRepo { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FiboOffice.InfraStructure.Repository.IYearRepository _yearRepo { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FiboBlock.InfraStructure.Repository.IClientRepository _clientRepo { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FiboBilling.InfraStructure.Repository.IBillingDetailRepository _bDRepo { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FiboBlock.Src.ViewModel.ClientViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591