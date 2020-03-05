import React from 'react';
import { Layout, Content } from 'react-mdl';

import Navbar from '../components/Navbar';

import 'react-mdl/extra/material.css';
import 'react-mdl/extra/material.js';
import '../styles/index.css';

const links = [
    {
        link: "/login",
        text: "Log in"
    },
    {
        link: "/signup",
        text: "Sign up"
    },
    {
        link: "/contact",
        text: "Contact us"
    }
]

const BaseLayout = ({ children }) => (
    <div className="demo-big-content">
        <Layout>
            <Navbar pages={links} />
            <Content>
                <div className="page-content" />
                {children}
            </Content>
        </Layout>
    </div>
);

export default BaseLayout;
