#pragma checksum "C:\Users\klaas\Documents\KU Leuven\Master sem 1\Hackaton\Repository\VuilbakWebApp\TrashServer\TrashServer\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87b6ef8e1f18af4e980d0dbec4b8c2e4ab94a6b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TrashServer.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Index.cshtml", typeof(TrashServer.Pages.Pages_Index), null)]
namespace TrashServer.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\klaas\Documents\KU Leuven\Master sem 1\Hackaton\Repository\VuilbakWebApp\TrashServer\TrashServer\Pages\_ViewImports.cshtml"
using TrashServer;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87b6ef8e1f18af4e980d0dbec4b8c2e4ab94a6b9", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f5d8924872e39c9ad4800e1359c5c1fc523478d", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\klaas\Documents\KU Leuven\Master sem 1\Hackaton\Repository\VuilbakWebApp\TrashServer\TrashServer\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
            BeginContext(71, 3374, true);
            WriteLiteral(@"  <div id=""mapdiv"" style=""height:800px;""></div>
  <script src=""http://www.openlayers.org/api/OpenLayers.js""></script>
  <script>
    map = new OpenLayers.Map(""mapdiv"");
    map.addLayer(new OpenLayers.Layer.OSM());

	function httpGet(theUrl)
	{
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open( ""GET"", theUrl, false ); // false for synchronous request
    xmlHttp.send( null );
    return xmlHttp.responseText;
	  }

	  function getIcon(level) { 
		  if (level===null) {
			  return new OpenLayers.Icon(""markerNull.png""); 
		  }
		  if (level < 25) {
			  return new OpenLayers.Icon(""marker0.png"");
		  }
		  if (level < 50) {
			  return new OpenLayers.Icon(""marker25.png"");
		  }
		  if (level < 75) {
			  return new OpenLayers.Icon(""marker50.png"");
		  }
		  return new OpenLayers.Icon(""marker75.png"");
	  }

	  function getByNumber(array, number) {
		  for (i = 0; i < array.length; i++) {
			  if (array[i].NUMMER=number) {
				  return array[i];
			  }
		  }
		  return nul");
            WriteLiteral(@"l;
	  }

	  /*
	  function isFull(trashCan) {
		  return trashCan.Level >= 75;
	  }

	  function filterFull(trashCans) {
		  return trashCans.filter(isFull);
	  }*/
	
	  var afvalmandenJSON = httpGet(""afvalmanden.json"");
	  var trashCansValuesJSON = httpGet(""trash.json"");
	  var arr_from_json = JSON.parse(afvalmandenJSON);
	  var trashCansValues = JSON.parse(trashCansValuesJSON);
	  //trashCansValues = filterFull(trashCansValues);
	  
	  

	/*
	fetch('file.txt')
  .then(response => response.text())
  .then(text => console.log(text))*/
  
  /*
  function loadJSON(callback) {   

    var xobj = new XMLHttpRequest();
        xobj.overrideMimeType(""application/json"");
    xobj.open('GET', 'my_data.json', true); // Replace 'my_data' with the path to your file
    xobj.onreadystatechange = function () {
          if (xobj.readyState == 4 && xobj.status == ""200"") {
            // Required use of an anonymous callback as .open will NOT return a value but simply returns undefined in as");
            WriteLiteral(@"ynchronous mode
            callback(xobj.responseText);
          }
    };
    xobj.send(null);  
	}*/

	  /*
	fetch('file.json')
  .then(response => response.json())
  .then(jsonResponse => console.log(jsonResponse));
	*/

	  var zoom = 16;
	  var markers = new OpenLayers.Layer.Markers(""Markers"");
	  map.addLayer(markers);
	  //var size = OpenLayers.Size(10, 10);
	  //var size = new OpenLayers.Size(25, 25);
	  //var offset = new OpenLayers.Pixel(-(size.w / 2), -size.h);
	  for (i = 0; i < arr_from_json.length; i++){
		  if (arr_from_json[i].json_geometry) { //filter corrupt entries
			  var icon = getIcon(trashCansValues[i].Level);
			  var lonLat = new OpenLayers.LonLat(arr_from_json[i].json_geometry.coordinates[0], arr_from_json[i].json_geometry.coordinates[1])
				  .transform(
					  new OpenLayers.Projection(""EPSG:4326""), // transform from WGS 1984
					  map.getProjectionObject() // to Spherical Mercator Projection
			  );
			  markers.addMarker(new OpenLayers.Marker(lonLat,");
            WriteLiteral(@"icon));
		  }		  
	  }

	  var lonLat = new OpenLayers.LonLat(3.224700, 51.209348)
		  .transform(
			  new OpenLayers.Projection(""EPSG:4326""), // transform from WGS 1984
			  map.getProjectionObject() // to Spherical Mercator Projection
		  );

    map.setCenter (lonLat, zoom);
  </script>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
