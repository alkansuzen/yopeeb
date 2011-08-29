// JavaScript Document
$(function(){
	
	// Ajuste de altura do mapa
	//resizeMap()
	
	// Ajuste para redimencionar a tela
	$(window).resize(function() {
		   resizeMap()
		   map.setCenter(local)
		});

	/* Inicia o mapa e configurações iniciais */
	initialize()
});

function resizeMap(){
	//$("#map").css({"height":$(window).height()-96, "margin-top":"48px"})
}
	

	
/**************************************************
		
	Configuração do Mapa
		
 ***************************************************/
	var map;
	var infowindow;
	var local;
	var geocoder;
	function initialize() {
	    geocoder = new google.maps.Geocoder();
	    local = new google.maps.LatLng(-34.397, 150.644);
	    infowindow = new google.maps.InfoWindow();
	    infowindow.setContent("Are you here?")
	    infowindow.setPosition(local)
	    var myOptions = {
	        zoom: 8,
	        center: local,
	        mapTypeId: google.maps.MapTypeId.ROADMAP,
	        mapTypeControl: true,
	        mapTypeControlOptions: {
	            style: google.maps.MapTypeControlStyle.HORIZONTAL_BAR,
	            position: google.maps.ControlPosition.TOP_RIGHT
	        },
	        navigationControl: true,
	        navigationControlOptions: {
	            style: google.maps.NavigationControlStyle.SMALL,
	            position: google.maps.ControlPosition.TOP_RIGHT
	        },
	        scaleControl: false,
	        scaleControlOptions: {
	            position: google.maps.ControlPosition.BOTTOM_LEFT
	        }
	    }
	    map = new google.maps.Map(document.getElementById("map"), myOptions);
	    //console.log(map)
	    infowindow.open(map)

	    $.geolocation.find(function (location) {
	        if (location) {
	            geo_success(location);
	            placeMarker(location);
	        } else {
	            geo_error('erro');
	        }

	    });

	}          	
	function geo_success( p){
			local =  new google.maps.LatLng(p.latitude, p.longitude)
			map.setCenter(local)
			map.setZoom(15)
			infowindow.setPosition(local)
			infowindow.open(map)
	}
	
	function geo_error(error){
			alert('Ocorreu um erro')
			//console.log('error')
	}

	var marker;
	function placeMarker(location) {
	    /*Colocar no evento onde selecionará local*/
	    var image = 'http://beepoy.com/Content/Images/icons/bee64.png';
	    var myLatLng = new google.maps.LatLng(location.latitude, location.longitude);
	    var marker = new google.maps.Marker({
	        position: myLatLng,
	        map: map,
	        icon: image,
	        draggable: true
	    });

	    $("#latitude").val(location.latitude);
	    $("#longitude").val(location.longitude);

	    google.maps.event.addListener(marker, 'position_changed', function () {
	        $("#latitude").val(marker.getPosition().lat());
	        $("#longitude").val(marker.getPosition().lng());
	    });

	    google.maps.event.addListener(marker, 'drag', function () {
	        geocoder.geocode({ 'latLng': marker.getPosition() }, function (results, status) {
	            if (status == google.maps.GeocoderStatus.OK) {
	                if (results[0]) {
	                    $('#address').val(results[0].formatted_address);
	                    $(".share-where").css("background-position", "left top");
//	                    $('#latitude').val(marker.getPosition().lat());
//	                    $('#longitude').val(marker.getPosition().lng());
	                }
	            }
	        });
	    });
	}
	/**************************************************
		
	Mecanismo de busca
		
	***************************************************/
 
  function codeAddress() {
    //var address = document.getElementById("address").value;
	var address = $('#onde').val()
	
    geocoder.geocode( { 'address': address}, function(results, status) {
      if (status == google.maps.GeocoderStatus.OK) {
        map.setCenter(results[0].geometry.location);
        var marker = new google.maps.Marker({
            map: map, 
            position: results[0].geometry.location
        });
      } else {
        alert("Geocode was not successful for the following reason: " + status);
      }
    });
  }