#pragma checksum "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0649957d829072d5b995ffa9149bcf9e3cd81f33"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manga_Info), @"mvc.1.0.view", @"/Views/Manga/Info.cshtml")]
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
#line 1 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\_ViewImports.cshtml"
using GoodWeebs.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\_ViewImports.cshtml"
using GoodWeebs.Web.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0649957d829072d5b995ffa9149bcf9e3cd81f33", @"/Views/Manga/Info.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1540139dc578fd88aa692dae140857466376be7e", @"/Views/_ViewImports.cshtml")]
    public class Views_Manga_Info : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GoodWeebs.Web.ViewModels.MangaViewModels.MangaInfoViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-dark text-decoration-none lead"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Shelves", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToRead", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToReading", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToWantToRead", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Info", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
  
    this.ViewData["Title"] = $"Anime";

#line default
#line hidden
#nullable disable
            WriteLiteral("<style>\r\n    .card {\r\n        display: inline-block;\r\n    }\r\n</style>\r\n<div class=\"row\">\r\n    <div class=\"col-md-1\"> </div>\r\n    <div class=\"col-md-2 border-bottom\">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 294, "\"", 323, 1);
#nullable restore
#line 13 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
WriteAttributeValue("", 300, Model.Manga.PictureUrl, 300, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 324, "\"", 330, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\" text-justify-left\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0649957d829072d5b995ffa9149bcf9e3cd81f335942", async() => {
                WriteLiteral(" Read ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 15 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
                                                                                                            WriteLiteral(Model.MangaId);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n            <hr>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0649957d829072d5b995ffa9149bcf9e3cd81f338482", async() => {
                WriteLiteral(" Reading ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 17 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
                                                                                                               WriteLiteral(Model.MangaId);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n            <hr>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0649957d829072d5b995ffa9149bcf9e3cd81f3311028", async() => {
                WriteLiteral(" Want To Read  ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 19 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
                                                                                                                    WriteLiteral(Model.MangaId);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n            <hr>\r\n            <p>Type: ");
#nullable restore
#line 21 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
                Write(Model.Manga.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p>Genre: ");
#nullable restore
#line 22 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
                 Write(Model.Manga.Genres);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p>Aired: ");
#nullable restore
#line 23 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
                 Write(Model.Manga.Published);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p>Volumes: ");
#nullable restore
#line 24 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
                   Write(Model.Manga.Volumes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p>Chapters: ");
#nullable restore
#line 25 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
                    Write(Model.Manga.Chapters);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p>Authors: ");
#nullable restore
#line 26 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
                   Write(Model.Manga.Authors);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-md-8\">\r\n        <h3>");
#nullable restore
#line 30 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
       Write(Model.Manga.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n        <hr>\r\n        <p>");
#nullable restore
#line 32 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
      Write(Model.Manga.Synopsis);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n        <hr>\r\n        <h1 class=\"display-4 text-center\">Similar Manga</h1>\r\n        <div class=\"row display-flex justify-content-center\">\r\n");
#nullable restore
#line 37 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
             foreach (var manga in Model.SimilarManga)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card\" style=\" width: 12rem;\">\r\n                    <img class=\"card-img-top img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 1658, "\"", 1681, 1);
#nullable restore
#line 40 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
WriteAttributeValue("", 1664, manga.PictureUrl, 1664, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"card-body \">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0649957d829072d5b995ffa9149bcf9e3cd81f3316700", async() => {
                WriteLiteral(" <h5 class=\"card-title\">");
#nullable restore
#line 42 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
                                                                                         Write(manga.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
                                               WriteLiteral(manga.Id);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n                        <p class=\"card-text\">");
#nullable restore
#line 43 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
                                        Write(manga.Synopsis.Substring(0, 80));

#line default
#line hidden
#nullable disable
            WriteLiteral("...</p>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 46 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Manga\Info.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <div class=\"col-md-1\"> </div>\r\n        \r\n        </div>\r\n        \r\n        <div class=\"col-md-2\"></div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GoodWeebs.Web.ViewModels.MangaViewModels.MangaInfoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
