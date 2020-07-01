import React from 'react'
import '../../styles/map.css'
import marker from '../../images/marker.png';
import Grid from '@material-ui/core/Grid';

const LocationPin = ({ text }) => (
  <div className="pin">
    <img
      src={marker}
      alt={text}
      width="20"
    />
    <b>{text}</b>
  </div>
)

export default LocationPin
