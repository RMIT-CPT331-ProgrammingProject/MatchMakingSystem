#pragma checksum "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Whitelists\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4cac47e29fa421e9949a26b1123e3117a2f96bf8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Whitelists_Index), @"mvc.1.0.view", @"/Views/Whitelists/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Whitelists/Index.cshtml", typeof(AspNetCore.Views_Whitelists_Index))]
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
#line 1 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\_ViewImports.cshtml"
using GroupStack;

#line default
#line hidden
#line 2 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\_ViewImports.cshtml"
using GroupStack.Models;

#line default
#line hidden
#line 1 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Whitelists\Index.cshtml"
using GroupStack.Data;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4cac47e29fa421e9949a26b1123e3117a2f96bf8", @"/Views/Whitelists/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35d284a14b4eb9cc9cb6ecce7ed36cf0bb8fd1cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Whitelists_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GroupStack.Models.Whitelist>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(73, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Whitelists\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(116, 18, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n");
            EndContext();
#line 9 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Whitelists\Index.cshtml"
 if (ViewData["cohortName"] != null)
{

#line default
#line hidden
            BeginContext(175, 4, true);
            WriteLiteral("<h2>");
            EndContext();
            BeginContext(180, 22, false);
#line 11 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Whitelists\Index.cshtml"
Write(ViewData["cohortName"]);

#line default
#line hidden
            EndContext();
            BeginContext(202, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
#line 12 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Whitelists\Index.cshtml"
}

#line default
#line hidden
            BeginContext(212, 11, true);
            WriteLiteral("\r\n<p>\r\n    ");
            EndContext();
            BeginContext(223, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4cac47e29fa421e9949a26b1123e3117a2f96bf84943", async() => {
                BeginContext(246, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(260, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(353, 44, false);
#line 21 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Whitelists\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IsMentor));

#line default
#line hidden
            EndContext();
            BeginContext(397, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(453, 42, false);
#line 24 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Whitelists\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UserId));

#line default
#line hidden
            EndContext();
            BeginContext(495, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(551, 42, false);
#line 27 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Whitelists\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Cohort));

#line default
#line hidden
            EndContext();
            BeginContext(593, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 33 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Whitelists\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(711, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(760, 43, false);
#line 36 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Whitelists\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IsMentor));

#line default
#line hidden
            EndContext();
            BeginContext(803, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(859, 41, false);
#line 39 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Whitelists\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserId));

#line default
#line hidden
            EndContext();
            BeginContext(900, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(956, 52, false);
#line 42 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Whitelists\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Cohort.CohortName));

#line default
#line hidden
            EndContext();
            BeginContext(1008, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1064, 79, false);
#line 45 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Whitelists\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { cohort=item.CohortId, user=item.UserId }));

#line default
#line hidden
            EndContext();
            BeginContext(1143, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1164, 85, false);
#line 46 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Whitelists\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { cohort=item.CohortId, user=item.UserId }));

#line default
#line hidden
            EndContext();
            BeginContext(1249, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1270, 83, false);
#line 47 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Whitelists\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { cohort=item.CohortId, user=item.UserId }));

#line default
#line hidden
            EndContext();
            BeginContext(1353, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 50 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Whitelists\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1392, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GroupStack.Models.Whitelist>> Html { get; private set; }
    }
}
#pragma warning restore 1591
