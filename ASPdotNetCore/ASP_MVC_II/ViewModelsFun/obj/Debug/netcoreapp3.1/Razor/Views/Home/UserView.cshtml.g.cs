#pragma checksum "C:\Users\Usmig\OneDrive\Coding_Dojo\C#\ASPdotNetCore\ASP_MVC_II\ViewModelsFun\Views\Home\UserView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "79d90eba0e1196787f8eb727a8cc81e5970d5e01"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_UserView), @"mvc.1.0.view", @"/Views/Home/UserView.cshtml")]
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
#line 1 "C:\Users\Usmig\OneDrive\Coding_Dojo\C#\ASPdotNetCore\ASP_MVC_II\ViewModelsFun\Views\_ViewImports.cshtml"
using ViewModelsFun;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Usmig\OneDrive\Coding_Dojo\C#\ASPdotNetCore\ASP_MVC_II\ViewModelsFun\Views\_ViewImports.cshtml"
using ViewModelsFun.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Usmig\OneDrive\Coding_Dojo\C#\ASPdotNetCore\ASP_MVC_II\ViewModelsFun\Views\Home\UserView.cshtml"
using ViewModelsFun.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79d90eba0e1196787f8eb727a8cc81e5970d5e01", @"/Views/Home/UserView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a81a75cfaf1d772b53b0c424a0286222e9a36db2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_UserView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Usmig\OneDrive\Coding_Dojo\C#\ASPdotNetCore\ASP_MVC_II\ViewModelsFun\Views\Home\UserView.cshtml"
  
    ViewData["Title"] = "User";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h2>Here are some names!</h2>\r\n    <p>");
#nullable restore
#line 9 "C:\Users\Usmig\OneDrive\Coding_Dojo\C#\ASPdotNetCore\ASP_MVC_II\ViewModelsFun\Views\Home\UserView.cshtml"
  Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 9 "C:\Users\Usmig\OneDrive\Coding_Dojo\C#\ASPdotNetCore\ASP_MVC_II\ViewModelsFun\Views\Home\UserView.cshtml"
                    Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User> Html { get; private set; }
    }
}
#pragma warning restore 1591
