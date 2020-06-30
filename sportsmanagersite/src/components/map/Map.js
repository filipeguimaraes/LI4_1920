import React from 'react'
import GoogleMapReact from 'google-map-react'
import '../../styles/map.css'

import LocationPin from './LocationPin';


const Map = ({ location, zoomLevel }) => (
    <div className="map">
      <div className="google-map">
        <GoogleMapReact
          bootstrapURLKeys={{ key: 'AIzaSyAOhnm5lirGamTJk3KwYGUjX2vMbhWouDs' }}
          defaultCenter={location}
          defaultZoom={zoomLevel}
        >
          <LocationPin
            lat={location.lat}
            lng={location.lng}
            text={location.address}
          />
        </GoogleMapReact>
      </div>
    </div>
  )

  export default Map
  