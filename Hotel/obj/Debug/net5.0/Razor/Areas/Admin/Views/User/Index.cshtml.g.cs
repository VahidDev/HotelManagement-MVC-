#pragma checksum "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31985521599198ef627a07d2cf45dc307582dc75"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_User_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/User/Index.cshtml")]
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
using Hotel.Constants.POCOConstants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\_ViewImports.cshtml"
using Hotel.Utilities.ControllerUtilities.UserUtilities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31985521599198ef627a07d2cf45dc307582dc75", @"/Areas/Admin/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3062034ac226a9ea466d5e52be01c7976f4a67e", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserIndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MakeHotelUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31985521599198ef627a07d2cf45dc307582dc756622", async() => {
                WriteLiteral("User");
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
                        <li class=""breadcrumb-item active"">Users</li>
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
                                        <th>ID</th>
                                        <th>Username</th>
                                        <th>Email</th>
                       ");
            WriteLiteral("                 <th>Roles</th>\r\n                                    </tr>\r\n                                </thead>\r\n                                <tbody>\r\n");
#nullable restore
#line 42 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
                                     foreach (UserAndRole userAndRole in Model.UsersRoles)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr class=\"userInfoEl\">\r\n                                            <td");
            BeginWriteAttribute("class", " class=\"", 2014, "\"", 2022, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 45 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
                                                    Write(userAndRole.User.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 46 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
                                           Write(userAndRole.User.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 47 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
                                           Write(userAndRole.User.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>\r\n                                                <select class=\"form-control\">\r\n");
#nullable restore
#line 50 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
                                                     foreach (string role in userAndRole.RolesNames)
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31985521599198ef627a07d2cf45dc307582dc7511297", async() => {
#nullable restore
#line 52 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
                                                           Write(role);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n");
#nullable restore
#line 53 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                </select>\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31985521599198ef627a07d2cf45dc307582dc7512918", async() => {
                WriteLiteral("Detail");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 57 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
                                                                              WriteLiteral(userAndRole.User.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31985521599198ef627a07d2cf45dc307582dc7515254", async() => {
                WriteLiteral("Update");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 58 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
                                                                             WriteLiteral(userAndRole.User.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 3146, "\"", 3174, 1);
#nullable restore
#line 59 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
WriteAttributeValue("", 3154, userAndRole.User.Id, 3154, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                                <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 3248, "\"", 3282, 1);
#nullable restore
#line 60 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
WriteAttributeValue("", 3256, userAndRole.User.UserName, 3256, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                                                <!--Fake Button trigger modal -->
                                                <button type=""button"" class=""btn btn-danger modalBtn"">
                                                    Delete
                                                </button>
");
#nullable restore
#line 65 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
                                                 if (userAndRole.User.IsBlocked)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <button type=\"button\" class=\"btn btn-dark unblock\">\r\n                                                        Unblock\r\n                                                    </button>\r\n");
#nullable restore
#line 70 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <button type=\"button\" class=\"btn btn-dark BlockModalBtn\">\r\n                                                    Block\r\n                                                </button>\r\n");
#nullable restore
#line 76 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </td>\r\n");
#nullable restore
#line 78 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
                                             if (!userAndRole.User.IsHotelUser)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <td>\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31985521599198ef627a07d2cf45dc307582dc7520655", async() => {
                WriteLiteral("Make Hotel User");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 81 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
                                                                                 WriteLiteral(userAndRole.User.Id);

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
            WriteLiteral("\r\n                                                </td>\r\n");
#nullable restore
#line 83 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <td></td>\r\n");
#nullable restore
#line 87 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </tr>\r\n");
#nullable restore
#line 89 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
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
                Are you sure you want to delete this user? User: <span class=""text-primary"" id=""userInfo""></span>
                <input type=""hidden"" id=""userId"" />
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-bs-dismiss=""modal"">Cancel</button>
                <button type=""button"" class=""btn btn-danger"" data-bs-dismiss=""modal"" id=""deleteUser"">Delete</button>
            </div>
        </div>
    </div>
</div>
<!--Block modal-->
<!-- Real Button trigger modal -->
<input type=""hidden"" id=""BlockModalActivate"" data-bs-toggle=""modal"" data-bs-target=""#exampleModalBlock"">
<!-- Modal -->
<div class=""modal fade"" id=""exampleModalBlock"" tabindex=""-1"" aria-labelledby=""exampleModalLabelBlock"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabelBlo");
            WriteLiteral(@"ck"">Block User</h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                Are you sure you want to block this user? User: <span class=""text-primary"" id=""userInfoBlock""></span>
                <input type=""hidden"" id=""userIdBlock"" />
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-bs-dismiss=""modal"">Cancel</button>
                <button type=""button"" class=""btn btn-danger"" data-bs-dismiss=""modal"" id=""blockUser"">Block</button>
            </div>
        </div>
    </div>
</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM\" crossorigin=\"anonymous\"></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31985521599198ef627a07d2cf45dc307582dc7527156", async() => {
                    WriteLiteral(@"
        ""use strict"";
        window.onload = () => {
            // For Deleting
            let modalBtns = document.querySelectorAll("".modalBtn"");
            for (let modalBtn of modalBtns) {
                modalBtn.addEventListener(""click"", GetUserId);
            }
            jQuery(document).on(""click"", ""#deleteUser"", function (e) {
                $.ajax({
                    method: ""Post"",
                    url: ""User/Delete/"" + $(""#userId"").val(),
                    success: function (res) {
                        if (res) {
                            $("".elToDelete"").detach()
                        } else {
                            window.location.replace(window.location.href + ""NotFound"");
                        }
                    }
                });
            });
            // For Blocking
            let BlockModalBtns = document.querySelectorAll("".BlockModalBtn"");
            for (let blockmodalBtn of BlockModalBtns) {
                blockmodalBtn.");
                    WriteLiteral(@"addEventListener(""click"", GetUserIdBlock);
            }
            jQuery(document).on(""click"", ""#blockUser"", function (e) {
                $.ajax({
                    method: ""Post"",
                    url: ""User/Block/"" + $(""#userIdBlock"").val(),
                    success: function (res) {
                        if (res) {
                            $("".userToBlock"").removeClass(""userToBlock"").addClass(""unblock"").text(""Unblock"");
                        } else {
                            window.location.replace(window.location.href + ""NotFound"");
                        }
                    }
                });
            });
        }
        function GetUserId(e) {
            let btn = e.target;
            let userName = btn.previousElementSibling.value;
            document.querySelector(""#userId"").value = btn.previousElementSibling
                .previousElementSibling.value;
            document.getElementById(""userInfo"").textContent = userName;
            docum");
                    WriteLiteral(@"ent.querySelector(""#modalActivate"").click();
            btn.closest("".userInfoEl"").classList.add(""elToDelete"");
        }
        function GetUserIdBlock(e) {
            let btn = e.target;
            let userName = btn.previousElementSibling.previousElementSibling.value;
            document.querySelector(""#userIdBlock"").value = btn.previousElementSibling.
            previousElementSibling.previousElementSibling.value;
            document.getElementById(""userInfoBlock"").textContent = userName;
            document.querySelector(""#BlockModalActivate"").click();
            btn.classList.add(""userToBlock"")
        }
    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
#nullable restore
#line 151 "C:\Users\User\OneDrive\Рабочий стол\Hotel\Hotel\Areas\Admin\Views\User\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
