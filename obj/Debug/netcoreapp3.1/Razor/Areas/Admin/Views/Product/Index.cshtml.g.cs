<<<<<<< HEAD
#pragma checksum "C:\Users\Dipen\Desktop\TBSTech\Areas\Admin\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "81c19e72a8f2571cc5cd25c0d18c348a8a44f4f4"
=======
#pragma checksum "C:\Users\Komal-PC\Documents\tbstechnology\Areas\Admin\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da39a3ee5e6b4b0d3255bfef95601890afd80709"
>>>>>>> 525c12e485af9fc1d7f1fb4e6f259c8882014ba0
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Product_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Product/Index.cshtml")]
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
<<<<<<< HEAD
#line 1 "C:\Users\Dipen\Desktop\TBSTech\Areas\Admin\Views\_ViewImports.cshtml"
=======
#line 1 "C:\Users\Komal-PC\Documents\tbstechnology\Areas\Admin\Views\_ViewImports.cshtml"
>>>>>>> 525c12e485af9fc1d7f1fb4e6f259c8882014ba0
using TBSTech;

#line default
#line hidden
#nullable disable
#nullable restore
<<<<<<< HEAD
#line 2 "C:\Users\Dipen\Desktop\TBSTech\Areas\Admin\Views\_ViewImports.cshtml"
=======
#line 2 "C:\Users\Komal-PC\Documents\tbstechnology\Areas\Admin\Views\_ViewImports.cshtml"
>>>>>>> 525c12e485af9fc1d7f1fb4e6f259c8882014ba0
using TBSTech.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81c19e72a8f2571cc5cd25c0d18c348a8a44f4f4", @"/Areas/Admin/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a96452969f0347a042b5cbcc04ea2989a5c94cc1", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<TBSTech.Models.Product>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Avatar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("table-avatar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@" <!-- Content Wrapper. Contains page content -->
  <div class=""content-wrapper"">
    <!-- Content Header (Page header) -->
    <section class=""content-header"">
      <div class=""container-fluid"">
        <div class=""row mb-2"">
          <div class=""col-sm-6"">
            <h1>Projects</h1>
          </div>
          <div class=""col-sm-6"">
            <ol class=""breadcrumb float-sm-right"">
              <li class=""breadcrumb-item""><a href=""#"">Home</a></li>
              <li class=""breadcrumb-item active"">Products</li>
            </ol>
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class=""content"">

      <!-- Default box -->
");
#nullable restore
#line 25 "C:\Users\Dipen\Desktop\TBSTech\Areas\Admin\Views\Product\Index.cshtml"
       foreach (var item in Model)
      {
          
      

#line default
#line hidden
#nullable disable
            WriteLiteral(@"      <div class=""card"">
        <div class=""card-header"">
          <h3 class=""card-title"">Products</h3>

          <div class=""card-tools"">
            <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"" data-toggle=""tooltip"" title=""Collapse"">
              <i class=""fas fa-minus""></i></button>
            <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove"" data-toggle=""tooltip"" title=""Remove"">
              <i class=""fas fa-times""></i></button>
          </div>
        </div>
        <div class=""card-body p-0"">
          <table class=""table table-striped projects"">
              <thead>
                  <tr>
                      <th style=""width: 1%"">
                          #
                      </th>
                      <th style=""width: 20%"">
                          Project Name
                      </th>
                      <th style=""width: 30%"">
                          Product Image
                      </th>
                ");
            WriteLiteral(@"      <th>
                          Product Description
                      </th>
                      <th style=""width: 8%"" class=""text-center"">
                          Status
                      </th>
                      <th style=""width: 20%"">
                      </th>
                  </tr>
              </thead>
              <tbody>
                  <tr>
                      <td>
                          #
                      </td>
                      <td>
                          <a>
                              ");
#nullable restore
#line 70 "C:\Users\Dipen\Desktop\TBSTech\Areas\Admin\Views\Product\Index.cshtml"
                         Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                          </a>\r\n                          <br/>\r\n                          <small>\r\n                              ");
#nullable restore
#line 74 "C:\Users\Dipen\Desktop\TBSTech\Areas\Admin\Views\Product\Index.cshtml"
                         Write(item.CreatedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                          </small>\r\n                      </td>\r\n                      <td>\r\n                          <ul class=\"list-inline\">\r\n                              <li class=\"list-inline-item\">\r\n                                  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "81c19e72a8f2571cc5cd25c0d18c348a8a44f4f47371", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2875, "~/ProductImages/", 2875, 16, true);
#nullable restore
#line 80 "C:\Users\Dipen\Desktop\TBSTech\Areas\Admin\Views\Product\Index.cshtml"
AddHtmlAttributeValue("", 2891, item.ImageUrl, 2891, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                              </li>
                          
                          </ul>
                      </td>
                      <td class=""project_progress"">
                          <div class=""progress progress-sm"">
                              <div class=""progress-bar bg-green"" role=""progressbar"" aria-volumenow=""57"" aria-volumemin=""0"" aria-volumemax=""100"" style=""width: 57%"">
                              </div>
                          </div>
                          <small>
                              ");
#nullable restore
#line 91 "C:\Users\Dipen\Desktop\TBSTech\Areas\Admin\Views\Product\Index.cshtml"
                         Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                          </small>
                      </td>
                      <td class=""project-state"">
                          <span class=""badge badge-success"">Success</span>
                      </td>
                      <td class=""project-actions text-right"">
                          <a class=""btn btn-primary btn-sm"" href=""#"">
                              <i class=""fas fa-folder"">
                              </i>
                              View
                          </a>
                          <a class=""btn btn-info btn-sm"" href=""#"">
                              <i class=""fas fa-pencil-alt"">
                              </i>
                              Edit
                          </a>
                          <a class=""btn btn-danger btn-sm"" href=""#"">
                              <i class=""fas fa-trash"">
                              </i>
                              Delete
                          </a>
                      </td>
             ");
            WriteLiteral("     </tr>\r\n                  \r\n              </tbody>\r\n          </table>\r\n        </div>\r\n   \r\n      </div>\r\n");
#nullable restore
#line 121 "C:\Users\Dipen\Desktop\TBSTech\Areas\Admin\Views\Product\Index.cshtml"
      
      }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </section>\r\n    <!-- /.content -->\r\n  </div>\r\n  <!-- /.content-wrapper -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<TBSTech.Models.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
