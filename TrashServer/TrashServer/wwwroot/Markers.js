 map = new OpenLayers.Map("mapdiv");
    map.addLayer(new OpenLayers.Layer.OSM());

	//Import OpenLayers.js before this file.
	
	/**
	* Request a specific URL.
	* //Source used: https://stackoverflow.com/questions/247483/http-get-request-in-javascript
	* @param theUrl The URL you want to request.
	* @return The response text of the request.
	*/
	function httpGet(theUrl)
	{
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open( "GET", theUrl, false ); // false for synchronous request
    xmlHttp.send( null );
    return xmlHttp.responseText;
	  }

	  /**
	  * Return the icon, based on filled percentage
	  * @param level Value between 0 and 100, representing the filled percentage.
	  * @return An OpenLayers Icon.
	  */
	  function getIcon(level) { 
		  if (level===null) {
			  return new OpenLayers.Icon("markerNull.png"); 
		  }
		  if (level < 25) {
			  return new OpenLayers.Icon("marker0.png");
		  }
		  if (level < 50) {
			  return new OpenLayers.Icon("marker25.png");
		  }
		  if (level < 75) {
			  return new OpenLayers.Icon("marker50.png");
		  }
		  return new OpenLayers.Icon("marker75.png");
	  }

	  /**
	  * Return the first element with a specific ID.
	  * @param array Array of elements. Elements must have a "NUMMER" property.
	  * @param number A string, representing the ID of the trashcan, such as "SK005".
	  * @return The first element (if found), or null (if not found).
	  */
	  function getByNumber(array, number) {
		  for (i = 0; i < array.length; i++) {
			  if (array[i].NUMMER=number) {
				  return array[i];
			  }
		  }
		  return null;
	  }
	  
	  /**
	  * Check if trashCan is almost full.
	  * @param trashCan Any element that has the Level property.
	  * @return true if level is greater than or equal to 75.
	  */
	  function isAlmostFull(trashCan) {
		  return trashCan.Level >= 75;
	  }

	  /**
	  * Filter trashcans that are almost full. Function does not work yet.
	  */
	  function filterFull(trashCans) {
		  return trashCans.filter(isAlmostFull);
	  }
	  
	  /**
	  * Creates an OpenLayers map, and fills it with markers based on trashcan locations.
	  */
	  function fillMap(){
		  var afvalmandenJSON = httpGet("afvalmanden.json");
	  var trashCansValuesJSON = httpGet("trash.json");
	  var arr_from_json = JSON.parse(afvalmandenJSON);
	  var trashCansValues = JSON.parse(trashCansValuesJSON);
	  //trashCansValues = filterFull(trashCansValues);

	  var zoom = 16;
	  var markers = new OpenLayers.Layer.Markers("Markers");
	  map.addLayer(markers);
	  //var size = OpenLayers.Size(10, 10);
	  //var size = new OpenLayers.Size(25, 25);
	  //var offset = new OpenLayers.Pixel(-(size.w / 2), -size.h);
	  for (i = 0; i < arr_from_json.length; i++){
		  if (arr_from_json[i].json_geometry) { //filter corrupt entries
			  var icon = getIcon(trashCansValues[i].Level);
			  var lonLat = new OpenLayers.LonLat(arr_from_json[i].json_geometry.coordinates[0], arr_from_json[i].json_geometry.coordinates[1])
				  .transform(
					  new OpenLayers.Projection("EPSG:4326"), // transform from WGS 1984
					  map.getProjectionObject() // to Spherical Mercator Projection
			  );
			  markers.addMarker(new OpenLayers.Marker(lonLat,icon));
		  }		  
	  }

	  var lonLat = new OpenLayers.LonLat(3.224700, 51.209348)
		  .transform(
			  new OpenLayers.Projection("EPSG:4326"), // transform from WGS 1984
			  map.getProjectionObject() // to Spherical Mercator Projection
		  );

    map.setCenter (lonLat, zoom);
	  }
	  
	  fillMap();