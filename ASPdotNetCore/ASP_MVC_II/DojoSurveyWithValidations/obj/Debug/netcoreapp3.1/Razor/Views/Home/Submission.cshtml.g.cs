#pragma checksum "C:\Users\Usmig\OneDrive\Coding_Dojo\C#\ASPdotNetCore\ASP_MVC_II\DojoSurveyWithValidations\Views\Home\Submission.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71b750c540e3a43ad4bb8503a38641227ab55477"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Submission), @"mvc.1.0.view", @"/Views/Home/Submission.cshtml")]
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
#line 1 "C:\Users\Usmig\OneDrive\Coding_Dojo\C#\ASPdotNetCore\ASP_MVC_II\DojoSurveyWithValidations\Views\_ViewImports.cshtml"
using DojoSurveyWithValidations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Usmig\OneDrive\Coding_Dojo\C#\ASPdotNetCore\ASP_MVC_II\DojoSurveyWithValidations\Views\_ViewImports.cshtml"
using DojoSurveyWithValidations.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71b750c540e3a43ad4bb8503a38641227ab55477", @"/Views/Home/Submission.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1ce34a5b46c0fb7100a79cca97847504334e373", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Submission : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Survey>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Usmig\OneDrive\Coding_Dojo\C#\ASPdotNetCore\ASP_MVC_II\DojoSurveyWithValidations\Views\Home\Submission.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Submission"; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""grid-container"">
    <div class=""grid-x grid-padding-y align-center"">
        <span class=""cell h3 text-center"">Survey Response</span>
        <div class=""cell medium-2"">
            <span class=""lead"">Name:</span>
            <hr>
            <span class=""lead"">Campus:</span>
            <hr>
            <span class=""lead"">Favorite Language:</span>
            <hr>
            <span class=""lead"">Comment:</span>
        </div>
        <div class=""cell medium-2"">
            <span class=""lead"">");
#nullable restore
#line 20 "C:\Users\Usmig\OneDrive\Coding_Dojo\C#\ASPdotNetCore\ASP_MVC_II\DojoSurveyWithValidations\Views\Home\Submission.cshtml"
                          Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            <hr>\r\n            <span class=\"lead\">");
#nullable restore
#line 22 "C:\Users\Usmig\OneDrive\Coding_Dojo\C#\ASPdotNetCore\ASP_MVC_II\DojoSurveyWithValidations\Views\Home\Submission.cshtml"
                          Write(Model.Campus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            <hr>\r\n            <span class=\"lead\">");
#nullable restore
#line 24 "C:\Users\Usmig\OneDrive\Coding_Dojo\C#\ASPdotNetCore\ASP_MVC_II\DojoSurveyWithValidations\Views\Home\Submission.cshtml"
                          Write(Model.FavoriteLanguage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            <hr>\r\n            <span class=\"lead\">");
#nullable restore
#line 26 "C:\Users\Usmig\OneDrive\Coding_Dojo\C#\ASPdotNetCore\ASP_MVC_II\DojoSurveyWithValidations\Views\Home\Submission.cshtml"
                          Write(Model.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Survey> Html { get; private set; }
    }
}
#pragma warning restore 1591
