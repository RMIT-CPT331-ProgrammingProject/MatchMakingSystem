#pragma checksum "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Projects\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98f8e4121ac0eff0ac15e541250f9aded4fbeaae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Projects_Details), @"mvc.1.0.view", @"/Views/Projects/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Projects/Details.cshtml", typeof(AspNetCore.Views_Projects_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98f8e4121ac0eff0ac15e541250f9aded4fbeaae", @"/Views/Projects/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35d284a14b4eb9cc9cb6ecce7ed36cf0bb8fd1cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Projects_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GroupStack.Models.Project>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(34, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Projects\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(79, 128, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Project</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(208, 43, false);
#line 14 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Projects\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.MinSize));

#line default
#line hidden
            EndContext();
            BeginContext(251, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(313, 39, false);
#line 17 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Projects\Details.cshtml"
       Write(Html.DisplayFor(model => model.MinSize));

#line default
#line hidden
            EndContext();
            BeginContext(352, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(413, 43, false);
#line 20 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Projects\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.MaxSize));

#line default
#line hidden
            EndContext();
            BeginContext(456, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(518, 39, false);
#line 23 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Projects\Details.cshtml"
       Write(Html.DisplayFor(model => model.MaxSize));

#line default
#line hidden
            EndContext();
            BeginContext(557, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(618, 45, false);
#line 26 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Projects\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.MaxGroups));

#line default
#line hidden
            EndContext();
            BeginContext(663, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(725, 41, false);
#line 29 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Projects\Details.cshtml"
       Write(Html.DisplayFor(model => model.MaxGroups));

#line default
#line hidden
            EndContext();
            BeginContext(766, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(827, 47, false);
#line 32 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Projects\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ProjectName));

#line default
#line hidden
            EndContext();
            BeginContext(874, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(936, 43, false);
#line 35 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Projects\Details.cshtml"
       Write(Html.DisplayFor(model => model.ProjectName));

#line default
#line hidden
            EndContext();
            BeginContext(979, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1040, 47, false);
#line 38 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Projects\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(1087, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1149, 43, false);
#line 41 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Projects\Details.cshtml"
       Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(1192, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1253, 42, false);
#line 44 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Projects\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Cohort));

#line default
#line hidden
            EndContext();
            BeginContext(1295, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1357, 47, false);
#line 47 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Projects\Details.cshtml"
       Write(Html.DisplayFor(model => model.Cohort.CohortId));

#line default
#line hidden
            EndContext();
            BeginContext(1404, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1465, 42, false);
#line 50 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Projects\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Mentor));

#line default
#line hidden
            EndContext();
            BeginContext(1507, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1569, 41, false);
#line 53 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Projects\Details.cshtml"
       Write(Html.DisplayFor(model => model.Mentor.Id));

#line default
#line hidden
            EndContext();
            BeginContext(1610, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1657, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98f8e4121ac0eff0ac15e541250f9aded4fbeaae10451", async() => {
                BeginContext(1710, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 58 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Projects\Details.cshtml"
                           WriteLiteral(Model.ProjectId);

#line default
#line hidden
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
            EndContext();
            BeginContext(1718, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1726, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98f8e4121ac0eff0ac15e541250f9aded4fbeaae12798", async() => {
                BeginContext(1748, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1764, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GroupStack.Models.Project> Html { get; private set; }
    }
}
#pragma warning restore 1591
