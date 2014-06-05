app.maps = {
    map: null,

    markers: [],

    infoWindows: [],

    markerClusterer: null,

    init: function (context) {
        if ($('#map-canvas', context).length) {
            google.maps.event.addDomListener(window, 'load', app.maps.initialize);
        }
    },

    initialize: function () {
        var mapOptions = {
            center: new google.maps.LatLng(32.8646393, -96.7637629),
            zoom: 8
        };
        app.maps.map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);

        $(window).on('resize', app.maps.resizeMap);

        //app.maps.updateMap({});
    },

    resizeMap: function () {
        var self = app.maps,
            center = self.map.getCenter(),
            //$mapWrapper = $('#search-map-view'),
            $w = $(window);

        //$mapWrapper.height($w.height() - $mapWrapper.offset().top);

        google.maps.event.trigger(self.map, "resize");
        self.map.setCenter(center);
    },

    updateMap: function (searchParams) {
        var self = app.maps;
        $.ajax('/address', {
            method: 'GET',
            data: searchParams,
            success: function (result) {
                self.clearMap();
                for (var i = 0, ii = result.length; i < ii; i++) {
                    self.addMarker(result[i]);
                }
                self.orientMap();
            }
        });
    },

    clearMap: function () {
        var self = app.maps;
        for (var i = 0, ii = self.markers.length; i < ii; i++) {
            self.markers[i].setMap(null);
        }
        self.markers = [];
    },

    addMarker: function (address) {
        if (address.latitude != null && address.longitude != null) {
            var self = app.maps,
                infoContent = address.familyMembers + '<br/>' + address.formatted,
                // create the marker
                marker = new google.maps.Marker({
                    position: new google.maps.LatLng(address.latitude, address.longitude),
                    map: self.map,
                    title: infoContent,
                    html: infoContent
                }),
                infoWindowOptions = {
                    content: infoContent, // address.infoWindowContent,
                    //disableAutoPan: false,
                    maxWidth: 800//,
                    //pixelOffset: new google.maps.Size(-140, 0),
                    //position: new google.maps.LatLng(address.latitude, address.longitude),
                    //zIndex: null
                },
                infoWindow = new google.maps.InfoWindow(infoWindowOptions);

            infoWindow.address = address;
            infoWindow.isOpen = false;

            google.maps.event.addListener(marker, 'mouseover', function (e) {
                _.each(self.infoWindows, function (x) {
                    if (x.address.id !== infoWindow.address.id && x.isOpen) {
                        x.close();
                        x.isOpen = false;
                    }
                });
                if (!infoWindow.isOpen) {
                    infoWindow.open(self.map, this);
                    infoWindow.isOpen = true;
                }
            });

            google.maps.event.addListener(marker, 'click', function (e) {
                if (infoWindow.isOpen) {
                    infoWindow.close();
                    infoWindow.isOpen = false;
                }
            });

            self.markers.push(marker);
            self.infoWindows.push(infoWindow);
        }
    },

    // Centers the map from the markers
    orientMap: function () {
        var self = app.maps,
            //  Make an array of the LatLng's of the markers you want to show
            //  Create a new viewpoint bound
            bounds = new google.maps.LatLngBounds();

        //  Go through each...
        for (var i = 0, ii = self.markers.length; i < ii; i++) {
            //  And increase the bounds to take this point
            bounds.extend(self.markers[i].position);
        }

        //  Fit these bounds to the map
        self.map.fitBounds(bounds);
        self.markerClusterer = new MarkerClusterer(self.map, self.markers, {
            maxZoom: 8,
            gridSize: 50
        });

        //if (self.markerClusterer) {
        //    self.markerClusterer.clearMarkers();
        //}
    }
};