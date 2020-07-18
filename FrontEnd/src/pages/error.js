import React from 'react';
import chainLogo from '../images/chain.jpg';
import { Grid, Cell } from 'react-mdl';

function Error() {
  return (
      <div style={{ width: '100%', margin: 'auto' }}>
        <Grid className="loading-grid">
          <Cell col={12}>
            <img
              src={chainLogo}
              alt="sports"
              id="sports-img"
            />
            <div>
              <h1 style={{ color: '#dedede', textAlign: "center" }}>Oops! It looks like we're having some trouble...</h1>
            </div>
          </Cell>
        </Grid>
      </div>
  );
}

export default Error;
