#pragma checksum "C:\Users\Utman\source\repos\SSICMS\RegistrationPortal\Views\Shared\_StateDropdownPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe33a174edd2ec7537a28876f35a08988f578fd4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__StateDropdownPartial), @"mvc.1.0.view", @"/Views/Shared/_StateDropdownPartial.cshtml")]
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
#line 1 "C:\Users\Utman\source\repos\SSICMS\RegistrationPortal\Views\_ViewImports.cshtml"
using RegistrationPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Utman\source\repos\SSICMS\RegistrationPortal\Views\_ViewImports.cshtml"
using RegistrationPortal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe33a174edd2ec7537a28876f35a08988f578fd4", @"/Views/Shared/_StateDropdownPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3542ca2e1ebe98af9e1c577a9266dadf7de9c113", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__StateDropdownPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<script>
    const states = [""Abuja"", ""Abia"", ""Lagos"", ""Ogun"", ""Osun""];
    const stateSelect = document.querySelector(""select#State"");

    states.forEach(state => {
        let option = document.createElement('option');
        option.value = state;
        option.text = state;
        stateSelect.appendChild(option);
    })

    const countries = [""Nigeria""];
    const countrySelect = document.querySelector(""select#Country"");

    countries.forEach(country => {
        let option = document.createElement('option');
        option.value = country;
        option.text = country;
        countrySelect.appendChild(option);
    })
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
