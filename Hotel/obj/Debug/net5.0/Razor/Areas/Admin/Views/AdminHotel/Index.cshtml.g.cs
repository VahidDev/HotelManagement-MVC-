#pragma checksum "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa047552ea62201f69fb2e30e6b1b9097b027326"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AdminHotel_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/AdminHotel/Index.cshtml")]
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
#line 2 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\_ViewImports.cshtml"
using Hotel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\_ViewImports.cshtml"
using Hotel.ViewModels.AdminViewModels.UserViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\_ViewImports.cshtml"
using Hotel.ViewModels.AdminViewModels.AdminHotelViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\_ViewImports.cshtml"
using Hotel.Constants.POCOConstants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\_ViewImports.cshtml"
using Hotel.Utilities.ControllerUtilities.UserUtilities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\_ViewImports.cshtml"
using Hotel.Utilities.ControllerUtilities.AdminHotelUtilities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa047552ea62201f69fb2e30e6b1b9097b027326", @"/Areas/Admin/Views/AdminHotel/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"430b1de4e2ffa7426d5d511cdab84ca52cc2e12d", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_AdminHotel_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AdminHotelIndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AdminHotel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-block w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"    <!-- Content Wrapper. Contains page content -->
<div class=""content-wrapper"" id=""myModal"">
    <!-- Content Header (Page header) -->
    <section class=""content-header"">
        <div class=""container-fluid"">
            <div class=""row mb-2"">
                <div class=""col-sm-6"">
                    <h1>User list</h1>
                </div>
                <div class=""col-sm-6"">
                    <ol class=""breadcrumb float-sm-right"">
                        <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa047552ea62201f69fb2e30e6b1b9097b0273267192", async() => {
                WriteLiteral("Hotel");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                        <li class=""breadcrumb-item active"">Hotels</li>
                    </ol>
                </div>
            </div>
        </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class=""content"">
        <div class=""container-fluid"">
            <div class=""row"">
                <div class=""col-12"">
                    <div class=""card"">
                        <div class=""card-header"">
                            <h3 class=""card-title"">Users</h3>
                        </div>
                        <!-- /.card-header -->
                        <div class=""card-body"">
                            <table id=""example2"" class=""table table-bordered table-hover"">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Name</th>
                                        <th>Owner</th>
                           ");
            WriteLiteral(@"             <th>Description</th>
                                        <th>Rating</th>
                                        <th>Address</th>
                                        <th>City</th>
                                        <th>Reservation Count</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 46 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
                                     foreach (Hotel hotel in Model.Hotels)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr class=\"hotelInfoEl\">\r\n                                        <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fa047552ea62201f69fb2e30e6b1b9097b02732610453", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2277, "~/img/HOTEL/", 2277, 12, true);
#nullable restore
#line 49 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
AddHtmlAttributeValue("", 2289, hotel.Image, 2289, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                                        <td class=\"text-bold\">");
#nullable restore
#line 50 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
                                                         Write(hotel.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 51 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
                                       Write(hotel.User.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 52 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
                                       Write(hotel.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n                                            <ul class=\"hotel-stars text-warning\" style=\"list-style:none; display:flex;\">\r\n");
#nullable restore
#line 55 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
                                                  
                                                    int count = 0;
                                                    float rating = hotel.Rating.Name;
                                                    bool isInteger = Int32.TryParse(rating.ToString(), out int result);
                                                    int intRating = (int)rating;
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
                                                 for (int i = 0; i < intRating; i++)
                                                {
                                                    count++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <li><i class=\"fas fa-star\"></i></li>\r\n");
#nullable restore
#line 65 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
                                                 if (!isInteger)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <li><i class=\"fas fa-star-half-alt\"></i></li>\r\n");
#nullable restore
#line 69 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
                                                    count++;
                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
                                                 while (count != 5)
                                                {
                                                    count++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <li><i class=\"far fa-star\"></i></li>\r\n");
#nullable restore
#line 75 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
                                                  
                                                    count = 0;
                                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                </ul>\r\n                                        </td>\r\n                                        <td>");
#nullable restore
#line 81 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
                                       Write(hotel.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 82 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
                                       Write(hotel.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 83 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
                                       Write(hotel.ReservationCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa047552ea62201f69fb2e30e6b1b9097b02732617485", async() => {
                WriteLiteral("Detail");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 85 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
                                                                         WriteLiteral(hotel.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa047552ea62201f69fb2e30e6b1b9097b02732619807", async() => {
                WriteLiteral("Update");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 86 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
                                                                         WriteLiteral(hotel.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 4988, "\"", 5005, 1);
#nullable restore
#line 87 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
WriteAttributeValue("", 4996, hotel.Id, 4996, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 5075, "\"", 5094, 1);
#nullable restore
#line 88 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
WriteAttributeValue("", 5083, hotel.Name, 5083, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                                            <!--Fake Button trigger modal -->
                                            <button type=""button"" class=""btn btn-danger modalBtn"">Delete</button>
                                        </td>
                                    </tr>
");
#nullable restore
#line 93 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </tbody>
                            </table>
                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </section>
    <!-- /.content -->
</div>
<!--Delete modal-->
<!-- Real Button trigger modal -->
<input type=""hidden"" id=""modalActivate"" data-bs-toggle=""modal"" data-bs-target=""#exampleModal"">
<!-- Modal -->
<div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Delete User</h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </d");
            WriteLiteral(@"iv>
            <div class=""modal-body"">
                Are you sure you want to delete this user? Hotel: <span class=""text-primary"" id=""hotelInfo""></span>
                <input type=""hidden"" id=""hotelId"" />
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-bs-dismiss=""modal"">Cancel</button>
                <button type=""button"" class=""btn btn-danger"" data-bs-dismiss=""modal"" id=""deleteHotel"">Delete</button>
            </div>
        </div>
    </div>
</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM\" crossorigin=\"anonymous\"></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa047552ea62201f69fb2e30e6b1b9097b02732625497", async() => {
                    WriteLiteral(@"
        ""use strict"";
        window.onload = () => {
            // For Deleting
            let modalBtns = document.querySelectorAll("".modalBtn"");
            for (let modalBtn of modalBtns) {
                modalBtn.addEventListener(""click"", GetUserId);
            }
            jQuery(document).on(""click"", ""#deleteHotel"", function (e) {
                $.ajax({
                    method: ""Post"",
                    url: ""AdminHotel/Delete/"" + $(""#hotelId"").val(),
                    success: function (res) {
                        if (res===""Success"") {
                            $("".elToDelete"").detach()
                        } else if (res === ""Hotel Error"") {
                            $("".elToDelete"").append(`<span class=""text-danger error"">
                    First you need to delete the rooms of this hotel
                               </span>`).removeClass(""elToDelete"");
                            setTimeout(function () {
                                $("".error"").d");
                    WriteLiteral(@"etach();
                            }, 3 * 1000);
                        } else {
                            window.location.replace(window.location.href + ""NotFound"");
                        }
                    }
                });
            });
        }
        function GetUserId(e) {
            let btn = e.target;
            let HotelName = btn.previousElementSibling.value;
            document.querySelector(""#hotelId"").value = btn.previousElementSibling
                .previousElementSibling.value;
            document.getElementById(""hotelInfo"").textContent = HotelName;
            document.querySelector(""#modalActivate"").click();
            btn.closest("".hotelInfoEl"").classList.add(""elToDelete"");
        }
    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
#nullable restore
#line 133 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\AdminHotel\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AdminHotelIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591