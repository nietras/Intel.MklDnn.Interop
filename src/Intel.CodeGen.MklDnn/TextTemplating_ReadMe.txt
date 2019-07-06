 For T4 to work in C++/CLI projects we need to get TextTemplating MSBuild integration. 
 This can be found in Visualization and Modeling SDK for VS2012, this requires the VS2012 SDK to be installed first.
  * VS2012 SDK http://www.microsoft.com/en-us/download/details.aspx?id=30668
  * Visualization and Modeling SDK for VS2012  https://www.microsoft.com/en-us/download/details.aspx?id=30680
  * Then follow procedure for build server by copying stuff  http://msdn.microsoft.com/en-us/library/ee847423.aspx#buildserver 
    * Copy from e.g. "C:\Program Files\Microsoft Visual Studio 11.0\VSSDK\VisualStudioIntegration\Common\Assemblies\v4.0"
		Microsoft.VisualStudio.TextTemplating.11.0.dll
		Microsoft.VisualStudio.TextTemplating.11.0.xml
		Microsoft.VisualStudio.TextTemplating.Interfaces.11.0.dll
		Microsoft.VisualStudio.TextTemplating.Interfaces.11.0.xml
		Microsoft.VisualStudio.TextTemplating.VSHost.11.0.dll
		Microsoft.VisualStudio.TextTemplating.VSHost.11.0.xml
	* Copy from e.g. "C:\Program Files\MSBuild\Microsoft\VisualStudio\v11.0\TextTemplating"
		Microsoft.VisualStudio.TextTemplating.Sdk.Host.11.0.dll
		Microsoft.TextTemplating.Build.Tasks.dll
		Microsoft.TextTemplating.targets
	* C:\Program Files\Microsoft Visual Studio 11.0\Common7\IDE\PublicAssemblies
		microsoft.visualstudio.texttemplating.modeling.11.0.xml
		Microsoft.VisualStudio.TextTemplating.Modeling.11.0.dll

 * http://www.olegsych.com/2010/04/understanding-t4-msbuild-integration/

 * Define *.tt files as after normal item groups:
   <ItemGroup>
    <None Include="Ipp.tt">
      <Generator>TextTemplatingFileGenerator</Generator>
    </None>
   </ItemGroup>
