import React from 'react';
import greyLogo from '../images/grey.png';
import { Grid, Cell } from 'react-mdl';

function Loading() {
  return (
      <div style={{ width: '100%', margin: 'auto'}}>
        <Grid className="loading-grid">
          <Cell col={12}>
            <img
              src={greyLogo}
              alt="sports"
              id="sports-img"
            />
          </Cell>
        </Grid>
      </div>
  );
}

export default Loading;
