#pragma checksum "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Cohorts\Assign.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e58adfc32df1edfc68b13fe1dc327bb73b88799"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cohorts_Assign), @"mvc.1.0.view", @"/Views/Cohorts/Assign.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cohorts/Assign.cshtml", typeof(AspNetCore.Views_Cohorts_Assign))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e58adfc32df1edfc68b13fe1dc327bb73b88799", @"/Views/Cohorts/Assign.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35d284a14b4eb9cc9cb6ecce7ed36cf0bb8fd1cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Cohorts_Assign : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GroupStack.Models.Cohort>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Assign", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(33, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Cohorts\Assign.cshtml"
  
    ViewData["Title"] = "Assign Groups";

#line default
#line hidden
            BeginContext(84, 175, true);
            WriteLiteral("\r\n<h1>Assign Groups</h1>\r\n\r\n<h3>Are you ready to assign groups?</h3>\r\n<div>\r\n    <h4>Cohort</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(260, 46, false);
#line 15 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Cohorts\Assign.cshtml"
       Write(Html.DisplayNameFor(model => model.CohortName));

#line default
#line hidden
            EndContext();
            BeginContext(306, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(368, 42, false);
#line 18 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Cohorts\Assign.cshtml"
       Write(Html.DisplayFor(model => model.CohortName));

#line default
#line hidden
            EndContext();
            BeginContext(410, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(471, 43, false);
#line 21 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Cohorts\Assign.cshtml"
       Write(Html.DisplayNameFor(model => model.UniName));

#line default
#line hidden
            EndContext();
            BeginContext(514, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(576, 39, false);
#line 24 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Cohorts\Assign.cshtml"
       Write(Html.DisplayFor(model => model.UniName));

#line default
#line hidden
            EndContext();
            BeginContext(615, 224, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Students\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            \"\" of \"\" have selected preferences.\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(840, 43, false);
#line 33 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Cohorts\Assign.cshtml"
       Write(Html.DisplayNameFor(model => model.MinSize));

#line default
#line hidden
            EndContext();
            BeginContext(883, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(945, 39, false);
#line 36 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Cohorts\Assign.cshtml"
       Write(Html.DisplayFor(model => model.MinSize));

#line default
#line hidden
            EndContext();
            BeginContext(984, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1045, 43, false);
#line 39 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Cohorts\Assign.cshtml"
       Write(Html.DisplayNameFor(model => model.MaxSize));

#line default
#line hidden
            EndContext();
            BeginContext(1088, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1150, 39, false);
#line 42 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Cohorts\Assign.cshtml"
       Write(Html.DisplayFor(model => model.MaxSize));

#line default
#line hidden
            EndContext();
            BeginContext(1189, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1250, 55, false);
#line 45 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Cohorts\Assign.cshtml"
       Write(Html.DisplayNameFor(model => model.PreferencesDeadline));

#line default
#line hidden
            EndContext();
            BeginContext(1305, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1367, 51, false);
#line 48 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Cohorts\Assign.cshtml"
       Write(Html.DisplayFor(model => model.PreferencesDeadline));

#line default
#line hidden
            EndContext();
            BeginContext(1418, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(1456, 212, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e58adfc32df1edfc68b13fe1dc327bb73b887999601", async() => {
                BeginContext(1482, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(1492, 42, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5e58adfc32df1edfc68b13fe1dc327bb73b887999993", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 53 "C:\Data\Bachelor of IT\2019 3 Programming Project\Webapp\GroupStack\Views\Cohorts\Assign.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CohortId);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1534, 83, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Assign\" class=\"btn btn-danger\" /> |\r\n        ");
                EndContext();
                BeginContext(1617, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e58adfc32df1edfc68b13fe1dc327bb73b8879911920", async() => {
                    BeginContext(1639, 12, true);
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
                BeginContext(1655, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1668, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GroupStack.Models.Cohort> Html { get; private set; }
    }
}
#pragma warning restore 1591
