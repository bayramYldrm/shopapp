#pragma checksum "C:\Users\ASUS\Desktop\Dosyalarım\shopapp\shopapp.webui\Views\Product\List.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "22c4b8bb03c99f2e2ffcc24f4d6eaf350c67896c9fef64aa3efb2f4f51ee26c8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_List), @"mvc.1.0.view", @"/Views/Product/List.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\Dosyalarım\shopapp\shopapp.webui\Views\_ViewImports.cshtml"
using shopapp.entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ASUS\Desktop\Dosyalarım\shopapp\shopapp.webui\Views\_ViewImports.cshtml"
using shopapp.webui.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ASUS\Desktop\Dosyalarım\shopapp\shopapp.webui\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ASUS\Desktop\Dosyalarım\shopapp\shopapp.webui\Views\_ViewImports.cshtml"
using shopapp.webui.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ASUS\Desktop\Dosyalarım\shopapp\shopapp.webui\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ASUS\Desktop\Dosyalarım\shopapp\shopapp.webui\Views\_ViewImports.cshtml"
using shopapp.webui.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"22c4b8bb03c99f2e2ffcc24f4d6eaf350c67896c9fef64aa3efb2f4f51ee26c8", @"/Views/Product/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"fbfbe6d65edb8462deb7247d34b3d2c339446211ece7e7b9b6b398850cdb6dd9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Product_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductListViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\ASUS\Desktop\Dosyalarım\shopapp\shopapp.webui\Views\Product\List.cshtml"
  
    var popularClass = Model.Products.Count>2? "popular":"";
    var products = Model.Products;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Categories", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 11 "C:\Users\ASUS\Desktop\Dosyalarım\shopapp\shopapp.webui\Views\Product\List.cshtml"
Write(await Component.InvokeAsync("Categories"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\ASUS\Desktop\Dosyalarım\shopapp\shopapp.webui\Views\Product\List.cshtml"
 if(products.Count == 0)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\ASUS\Desktop\Dosyalarım\shopapp\shopapp.webui\Views\Product\List.cshtml"
Write(await Html.PartialAsync("_noproduct"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\ASUS\Desktop\Dosyalarım\shopapp\shopapp.webui\Views\Product\List.cshtml"
                                          
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">                  \r\n");
#nullable restore
#line 21 "C:\Users\ASUS\Desktop\Dosyalarım\shopapp\shopapp.webui\Views\Product\List.cshtml"
         foreach (var product in products)
        {    

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-md-4\">\r\n                ");
#nullable restore
#line 24 "C:\Users\ASUS\Desktop\Dosyalarım\shopapp\shopapp.webui\Views\Product\List.cshtml"
           Write(await Html.PartialAsync("_product", product));

#line default
#line hidden
#nullable disable
            WriteLiteral("   \r\n        </div>       \r\n");
#nullable restore
#line 26 "C:\Users\ASUS\Desktop\Dosyalarım\shopapp\shopapp.webui\Views\Product\List.cshtml"
        }   

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 28 "C:\Users\ASUS\Desktop\Dosyalarım\shopapp\shopapp.webui\Views\Product\List.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductListViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
