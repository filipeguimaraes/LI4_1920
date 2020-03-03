import React from 'react';
import mainLogo from '../images/white.png';
import { Grid, Cell } from 'react-mdl';

function Landing() {
  return (
    <div style={{ width: '100%', margin: 'auto' }}>
      <Grid className="landing-grid">
        <Cell col={12}>
          <img
            src={mainLogo}
            alt="sports"
            id="sports-img"
          />
          <div>
            <h1 style={{ color: 'white', textAlign: "center" }}>Sports Manager</h1>
          </div>
        </Cell>
      </Grid>
    </div>
  );
}

export default Landing;
