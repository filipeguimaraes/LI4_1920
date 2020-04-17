import React from 'react';
import { Link } from 'react-router-dom';
import { Header, Navigation, Drawer } from 'react-mdl';

const Navbar = ({ pages }) => (
    <>
        <Header className="header-color" title="Sports Manager" scroll>
            <Navigation>
                {
                    pages.map((entry) => (
                        <Link to={entry.link} onClick={entry.onClick}>{entry.text}</Link>
                    ))
                }
            </Navigation>
        </Header>
        <Drawer title="Sports Manager" style={{ color: '#85D8CE' }}>
            <Navigation>
                {
                    pages.map((entry) => (
                        <Link to={entry.link} style={{ color: '#85D8CE' }} onClick={entry.onClick}>{entry.text}</Link>
                    ))
                }
            </Navigation>
        </Drawer>
    </>
);

export default Navbar;
