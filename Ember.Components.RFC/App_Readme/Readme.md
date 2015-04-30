This document describes how to build a Visual Studio 2013 web site that contains:

- An Ember.js SPA application
- Uses Ember-Data
- Uses WebApi 2.2 with CORS
- Uses Entity code first framework
- Uses Optimization/Bundling
- Uses Bootstrap styling
- etc.

## Build a New Site Instructions

- Empty 2013 Project
- Check MVC
- Check API
- Create an empty controller ‘HomeController’
- Create a view ‘Index’
- NuGet Ember Javascript MVC API (1.11.1.849fbe2c)
- NuGet Moment.js
- Nuget Bootstrap 3.3.4
- Create an 'app' folder under Scripts
- Create the following folders under 'app'
    - components
    - controllers
    - helpers
    - models
    - routes
    - store
    - templates
    - views
- Build out your Ember.js application using these folders with an app.js file under the app folder
- Copy the ember-template-complier.js (1.11.1.849fbe2c) file to the Scripts directory
- Copy the ember-debug.js (1.11.1.849fbe2c) file to the Scripts directory

## _Layout.cshtml TOP

    @using System.Web.Optimization;
   
## _Layout.cshtml Header

    <head>

        <meta charset="utf-8" />
        <title>@ViewBag.Title Ember Components RFC</title>
        <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
        <link href="~/Content/bootstrap.css" rel="stylesheet" type="text/css" />
        <script src="~/Scripts/modernizr-2.6.2.js"></script>
        <script src="~/Scripts/moment.js"></script>
        <script src="~/Scripts/jquery-2.0.3.js"></script>
        <script src="~/Scripts/bootstrap.js"></script>
        <script src="~/Scripts/ember-template-compiler.js"></script>
        <script src="~/Scripts/ember.js"></script>

        @Scripts.Render("~/bundles/app")
        @Scripts.Render("~/bundles/templates")

        @*@HTMLBarsHelper.RawTemplateInjector.InjectRawTemplates("~/Scripts/app/templates", new[] { "*.hbs" })*@

    </head>
 
## _Layout.cshtml Body

    <body>

        @RenderBody()

    </body>

## Include Optimization/Bundles

- Convert project to use bundles
- [Bundles and Optimization Article](http://www.mikesdotnetting.com/article/197/optimising-asp-net-web-pages-sites-bundling-and-minification)
- Nuget Microsoft.AspNet.Web.Optimization Framework
- Nuget HandleBars Compiler/Bundler
- Nuget HTMLBars Compiler/Bundler

- In App_Start folder create a new class file called BundleConfig.cs
- Replace the content with:

<pre><code>using HTMLBarsHelper;
using System.Web;
using System.Web.Optimization;

namespace Ember.Components.RFC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/templates", new HTMLBarsTransformer())
                .IncludeDirectory("~/Scripts/app/templates", "*.hbs", true)
            );

            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include("~/Scripts/app/app.js")
                .IncludeDirectory("~/Scripts/app/components/", "*.js", true)
                .IncludeDirectory("~/Scripts/app/controllers/", "*.js", true)
                .IncludeDirectory("~/Scripts/app/helpers/", "*.js", true)
                .IncludeDirectory("~/Scripts/app/models/", "*.js", true)
                .IncludeDirectory("~/Scripts/app/routes/", "*.js", true)
                .IncludeDirectory("~/Scripts/app/store/", "*.js", true)
                .IncludeDirectory("~/Scripts/app/views/", "*.js", true)
            );

        }
    }
}
</code></pre>

- In Global.asax.cs add a new using statement

<pre><code>using System.Web.Optimization;</code></pre>

- Add the following line in Application_Start code

<pre><code>BundleConfig.RegisterBundles(BundleTable.Bundles);</code></pre>

- Add the following code to WebApiConfig.cs

<pre><code>// Web API configuration and services
var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
</code></pre>

- This tells Web API to return the JSON formatted in camelCase, the way ember expects it (and it's also my preference when working in JavaScript)

## TODO
- n/a

