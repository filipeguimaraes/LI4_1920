import React from 'react';
import { Link } from 'react-router-dom';
import { Header, Navigation, Drawer } from 'react-mdl';

const Navbar = () => (
    <>
        <Header className="header-color" title="Sports Manager" scroll>
            <Navigation>
                <Link to="/login">Log in</Link>
                <Link to="/signup">Sign up</Link>
                <Link to="/contact">Contact us</Link>
            </Navigation>
        </Header>
        <Drawer title="Sports Manager" style={{ color: '#85D8CE' }}>
            <Navigation>
                <Link to="/login" style={{ color: '#85D8CE' }}>Log in</Link>
                <Link to="/signup" style={{ color: '#85D8CE' }}>Sign up</Link>
                <Link to="/contact" style={{ color: '#85D8CE' }}>Contact us</Link>
            </Navigation>
        </Drawer>
    </>
);

export default Navbar;
