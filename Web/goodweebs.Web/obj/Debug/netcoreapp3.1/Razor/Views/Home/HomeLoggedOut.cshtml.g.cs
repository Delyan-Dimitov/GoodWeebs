#pragma checksum "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Home\HomeLoggedOut.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b6fcb2017f62e92ff5544e141cdcf88729c3f0b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_HomeLoggedOut), @"mvc.1.0.view", @"/Views/Home/HomeLoggedOut.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b6fcb2017f62e92ff5544e141cdcf88729c3f0b", @"/Views/Home/HomeLoggedOut.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1540139dc578fd88aa692dae140857466376be7e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_HomeLoggedOut : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GoodWeebs.Web.ViewModels.AnimeViewModels.HomeAnimeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Home\HomeLoggedOut.cshtml"
  
    ViewData["Title"] = "HomeLG";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script src=""https://code.jquery.com/jquery-3.2.1.slim.min.js"" integrity=""sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN"" crossorigin=""anonymous""></script>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"" integrity=""sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q"" crossorigin=""anonymous""></script>
<script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"" integrity=""sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl"" crossorigin=""anonymous""></script>
<style>
    nav {
        margin-bottom: 0;
    }
    .card {
        margin-bottom:10px;
    }
</style>
<!-- carousel -->

<div id=""carouselExampleIndicators"" class=""carousel slide"" data-ride=""carousel"">

    <ol class=""carousel-indicators"">
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""0"" class=""active""></li>
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""1""></li>
    <");
            WriteLiteral(@"/ol>
    <div class=""carousel-inner"">
        <div class=""carousel-item active"">
            <img class=""d-block w-100"" src=""https://i.imgur.com/bGexNHz.png"" alt=""First slide"">

        </div>
        <div class=""carousel-item"">
            <img class=""d-block w-100"" src=""https://i.imgur.com/wJp9SZm.png"" alt=""Second slide"">
        </div>

    </div>
    <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
        <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Previous</span>
    </a>
    <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
        <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Next</span>
    </a>
</div>
<div d-flex justify-content-center text-center>
    <h2 class=""display-4 text-center  text-white bg-warning"">Heres some of the comunities favorite anime!</h2>
</div>
<div clas");
            WriteLiteral("s=\"container\">\r\n    <div class=\"row display-flex\">\r\n");
#nullable restore
#line 50 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Home\HomeLoggedOut.cshtml"
         foreach (var anime in Model.TopAnimes.Take(5))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card\" style=\"width: 12rem;\">\r\n                <img class=\"card-img-top img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 2385, "\"", 2408, 1);
#nullable restore
#line 53 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Home\HomeLoggedOut.cshtml"
WriteAttributeValue("", 2391, anime.PictureUrl, 2391, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Card image cap\" >\r\n                <div class=\"card-body\" >\r\n                    <h5 class=\"card-title\">");
#nullable restore
#line 55 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Home\HomeLoggedOut.cshtml"
                                      Write(anime.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p class=\"card-text\">");
#nullable restore
#line 56 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Home\HomeLoggedOut.cshtml"
                                    Write(anime.Synopsis.Substring(0, 30));

#line default
#line hidden
#nullable disable
            WriteLiteral("...</p>\r\n                </div>\r\n\r\n            </div>\r\n");
#nullable restore
#line 60 "C:\Users\gunex\Desktop\GoodWeebs\Web\goodweebs.Web\Views\Home\HomeLoggedOut.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</div>
<section>
    <h2 class=""display-4 text-center  text-white bg-warning"">Important new about the anime/manga industry!</h2>
    <div class=""container"">
        <div class=""row display-flex"">
            <div class=""card"" style=""width: 16rem;"">
                <img class=""card-img-top img-responsive""");
            BeginWriteAttribute("src", " src=\"", 3000, "\"", 3158, 2);
            WriteAttributeValue("", 3006, "https://m.media-amazon.com/images/M/MV5BZmQ5NGFiNWEtMmMyMC00MDdiLTg4YjktOGY5Yzc2MDUxMTE1XkEyXkFqcGdeQXVyNTA4NzY1MzY", 3006, 115, true);
            WriteLiteral("@");
            WriteAttributeValue("", 3123, "._V1_UY1200_CR93,0,630,1200_AL_.jpg", 3123, 35, true);
            EndWriteAttribute();
            WriteLiteral(@" alt=""Card image cap"">
                <div class=""card-body"">
                    <h5 class=""card-title"">Card title</h5>
                    <p class=""card-text"">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                </div>
            </div>
            <div class=""card"" style=""width: 16rem;"">
                <img class=""card-img-top"" src=""..."" alt=""Card image cap"">
                <div class=""card-body"">
                    <h5 class=""card-title"">Card title</h5>
                    <p class=""card-text"">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                </div>
            </div>
            <div class=""card"" style=""width: 16rem;"">
                <img class=""card-img-top"" src=""..."" alt=""Card image cap"">
                <div class=""card-body"">
                    <h5 class=""card-title"">Card title</h5>
                    <p class=""card-text"">Some quick example text to b");
            WriteLiteral(@"uild on the card title and make up the bulk of the card's content.</p>
                </div>
            </div>
            <div class=""card"" style=""width: 16rem;"">
                <img class=""card-img-top"" src=""..."" alt=""Card image cap"">
                <div class=""card-body"">
                    <h5 class=""card-title"">Card title</h5>
                    <p class=""card-text"">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                </div>
            </div>
        </div>
    </div>
</section>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GoodWeebs.Web.ViewModels.AnimeViewModels.HomeAnimeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
