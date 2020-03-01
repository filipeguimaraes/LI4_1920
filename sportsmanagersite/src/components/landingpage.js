import React from 'react';
import { Grid, Cell } from 'react-mdl';

function Landing() {
    return (
  <div style={{width: '100%', margin: 'auto'}}>
    <Grid className="landing-grid">
        <Cell col={12}>
            <img 
                src = "https://cdn4.iconfinder.com/data/icons/zb-sports/20/multisport-512.png"
                alt = "sports"
                className = "sports-img"
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
  