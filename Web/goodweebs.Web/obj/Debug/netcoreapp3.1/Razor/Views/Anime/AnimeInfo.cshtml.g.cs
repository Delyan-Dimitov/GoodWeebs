#pragma checksum "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30f35d803a3ec91ab0beced10c3570c716b3a21b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Anime_AnimeInfo), @"mvc.1.0.view", @"/Views/Anime/AnimeInfo.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30f35d803a3ec91ab0beced10c3570c716b3a21b", @"/Views/Anime/AnimeInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1540139dc578fd88aa692dae140857466376be7e", @"/Views/_ViewImports.cshtml")]
    public class Views_Anime_AnimeInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GoodWeebs.Web.ViewModels.AnimeViewModels.AnimeInfoViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-dark text-decoration-none lead"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Shelves", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToWatched", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToWatching", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToWantToWatch", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AnimeInfo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
  
    this.ViewData["Title"] = $"Anime";

#line default
#line hidden
#nullable disable
            WriteLiteral("<style>\r\n    .card {\r\n        display: inline-block;\r\n    }\r\n</style>\r\n<div class=\"row\">\r\n    <div class=\"col-md-1\"> </div>\r\n    <div class=\"col-md-2 border-bottom\">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 294, "\"", 323, 1);
#nullable restore
#line 13 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
WriteAttributeValue("", 300, Model.Anime.PictureUrl, 300, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 324, "\"", 330, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\" text-justify-left\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30f35d803a3ec91ab0beced10c3570c716b3a21b5987", async() => {
                WriteLiteral(" Watched ");
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
#line 15 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
                                                                                                               WriteLiteral(Model.AnimeId);

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30f35d803a3ec91ab0beced10c3570c716b3a21b8538", async() => {
                WriteLiteral(" Watching ");
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
#line 17 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
                                                                                                                WriteLiteral(Model.AnimeId);

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30f35d803a3ec91ab0beced10c3570c716b3a21b11091", async() => {
                WriteLiteral(" Want To Watch  ");
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
#line 19 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
                                                                                                                   WriteLiteral(Model.AnimeId);

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
#line 21 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
                Write(Model.Anime.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p>Genre: ");
#nullable restore
#line 22 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
                 Write(Model.Anime.Genres);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p>Aired: ");
#nullable restore
#line 23 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
                 Write(Model.Anime.Aired);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p>Episodes:");
#nullable restore
#line 24 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
                   Write(Model.Anime.Episodes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p>Duration: ");
#nullable restore
#line 25 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
                    Write(Model.Anime.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p>Studio: ");
#nullable restore
#line 26 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
                  Write(Model.Anime.Studios);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p>Rating: ");
#nullable restore
#line 27 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
                  Write(Model.Anime.Rating);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-md-8\">\r\n        <h3>");
#nullable restore
#line 31 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
       Write(Model.Anime.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n        <hr>\r\n        <p>");
#nullable restore
#line 33 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
      Write(Model.Anime.Synopsis);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <hr>\r\n        <h1 class=\"display-4 text-center\">Similar shows</h1>\r\n        <div class=\"row display-flex justify-content-center\">\r\n");
#nullable restore
#line 37 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
             foreach (var anime in Model.SimilarAnime)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card\" style=\" width: 12rem;\">\r\n                <img class=\"card-img-top img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 1700, "\"", 1723, 1);
#nullable restore
#line 40 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
WriteAttributeValue("", 1706, anime.PictureUrl, 1706, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" >\r\n                <div class=\"card-body \">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30f35d803a3ec91ab0beced10c3570c716b3a21b17063", async() => {
                WriteLiteral(" <h5 class=\"card-title\">");
#nullable restore
#line 42 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
                                                                                          Write(anime.Title);

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
#line 42 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
                                                WriteLiteral(anime.Id);

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
            WriteLiteral("\r\n                    <p class=\"card-text\">");
#nullable restore
#line 43 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
                                    Write(anime.Synopsis.Substring(0, 80));

#line default
#line hidden
#nullable disable
            WriteLiteral("...</p>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 46 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Anime\AnimeInfo.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <div class=\"col-md-1\"></div>\r\n    <div class=\"col-md-1\"></div>\r\n\r\n    <div class=\"col-md-2\"></div>\r\n\r\n\r\n\r\n        <div class=\"col-md-2\"></div>\r\n        </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GoodWeebs.Web.ViewModels.AnimeViewModels.AnimeInfoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
