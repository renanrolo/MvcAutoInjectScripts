# MvcAutoInjectScripts
Read javascript files, bundle then and inject into view without code reference

Create javascript files in the same folder as views.

The javascript file will be implemented in the view without the need to explicity include them.

- Views
  - Home
    - Index.cshtml (view)
    - Index.js     (javascript)
              
              
This simplify the scructure of the project. 
One of the greatest benefit from this pattner is to simplify the location and creation 
 of new js files for complex/existing views.
 
 
 
 
 Important notes:
 1) You have to change the webconfig file of the views to allow the reading of javascript files within views folders
 /Views/Web.config 
 ```
<configuration>
  ...
  <system.webServer>
    <handlers>
      <add name="JavaScriptHandler" path="*.js" verb="*" preCondition="integratedMode" type="System.Web.StaticFileHandler" />  
      <remove name="BlockViewHandler"/>
      <add name="BlockViewHandler" path="*" verb="*" preCondition="integratedMode" type="System.Web.HttpNotFoundHandler" />
    </handlers>
  </system.webServer>
  ...
</configuration>
```

2) You need to inherit BaseController onto all your controllers.

3) The javascript files are loaded into the bundle, so you have to register it on application start
```
Application_Start()
{
    ...
    BundleInjectConfig.RegisterBundles(BundleTable.Bundles);
    ...
}
```

4) The injection of the javascript in the view can bee seen on '_Layout.cshtml'
