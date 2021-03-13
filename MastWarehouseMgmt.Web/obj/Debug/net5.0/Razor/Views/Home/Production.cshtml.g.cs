#pragma checksum "D:\repos\MastWarehouseMgmt\MastWarehouseMgmt.Web\Views\Home\Production.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "962b57fa43435b4d832fc65e8088248d9a20aa97"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Production), @"mvc.1.0.view", @"/Views/Home/Production.cshtml")]
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
#line 1 "D:\repos\MastWarehouseMgmt\MastWarehouseMgmt.Web\Views\_ViewImports.cshtml"
using MastWarehouseMgmt.Web.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"962b57fa43435b4d832fc65e8088248d9a20aa97", @"/Views/Home/Production.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"424a4b455c3b461e921c4d398131001aac9bd981", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Production : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProductionHistoryViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("@*btn btn-primary*@"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddProduction", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1 class=\"text-center\">История производства</h1>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "962b57fa43435b4d832fc65e8088248d9a20aa974000", async() => {
                WriteLiteral("Добавить");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<table class=""table table-striped mt-5 indextable"">
    <thead>
        <tr>
            <th scope=""col"">Дата</th>
            <th scope=""col"">Название</th>
            <th scope=""col"">Количество</th>
            <th scope=""col"">Цемент</th>
            <th scope=""col"">Песок</th>
            <th scope=""col"">CR400</th>
            <th scope=""col"">Гипс</th>
            <th scope=""col"">Литий</th>
            <th scope=""col"">Акронал</th>
            <th scope=""col"">Сода</th>
            <th scope=""col"">Клей</th>
            <th scope=""col"">C3</th>
            <th scope=""col"">Удалить</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 24 "D:\repos\MastWarehouseMgmt\MastWarehouseMgmt.Web\Views\Home\Production.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td scope=\"row\">");
#nullable restore
#line 27 "D:\repos\MastWarehouseMgmt\MastWarehouseMgmt.Web\Views\Home\Production.cshtml"
                           Write(item.CreatedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td scope=\"row\">");
#nullable restore
#line 28 "D:\repos\MastWarehouseMgmt\MastWarehouseMgmt.Web\Views\Home\Production.cshtml"
                           Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td scope=\"row\">");
#nullable restore
#line 29 "D:\repos\MastWarehouseMgmt\MastWarehouseMgmt.Web\Views\Home\Production.cshtml"
                           Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td scope=\"row\">");
#nullable restore
#line 30 "D:\repos\MastWarehouseMgmt\MastWarehouseMgmt.Web\Views\Home\Production.cshtml"
                           Write(item.Cement);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td scope=\"row\">");
#nullable restore
#line 31 "D:\repos\MastWarehouseMgmt\MastWarehouseMgmt.Web\Views\Home\Production.cshtml"
                           Write(item.Sand);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td scope=\"row\">");
#nullable restore
#line 32 "D:\repos\MastWarehouseMgmt\MastWarehouseMgmt.Web\Views\Home\Production.cshtml"
                           Write(item.CR400);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td scope=\"row\">");
#nullable restore
#line 33 "D:\repos\MastWarehouseMgmt\MastWarehouseMgmt.Web\Views\Home\Production.cshtml"
                           Write(item.Gypsum);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td scope=\"row\">");
#nullable restore
#line 34 "D:\repos\MastWarehouseMgmt\MastWarehouseMgmt.Web\Views\Home\Production.cshtml"
                           Write(item.Lithium);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td scope=\"row\">");
#nullable restore
#line 35 "D:\repos\MastWarehouseMgmt\MastWarehouseMgmt.Web\Views\Home\Production.cshtml"
                           Write(item.Acronal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td scope=\"row\">");
#nullable restore
#line 36 "D:\repos\MastWarehouseMgmt\MastWarehouseMgmt.Web\Views\Home\Production.cshtml"
                           Write(item.Soda);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td scope=\"row\">");
#nullable restore
#line 37 "D:\repos\MastWarehouseMgmt\MastWarehouseMgmt.Web\Views\Home\Production.cshtml"
                           Write(item.Glue);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td scope=\"row\">");
#nullable restore
#line 38 "D:\repos\MastWarehouseMgmt\MastWarehouseMgmt.Web\Views\Home\Production.cshtml"
                           Write(item.C3);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td scope=\"row\"><a class=\"btn btn-danger\" href=\"#\" role=\"button\">Удалить</a></td>\r\n            </tr>\r\n");
#nullable restore
#line 41 "D:\repos\MastWarehouseMgmt\MastWarehouseMgmt.Web\Views\Home\Production.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProductionHistoryViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591