import React from 'react';
import { Layout, Content } from 'react-mdl';

import Navbar from '../components/Navbar';

import 'react-mdl/extra/material.css';
import 'react-mdl/extra/material.js';
import '../styles/index.css';

const links = [
    {
        link: "/user",
        text: "Main page"
    },
    {
        link: "/",
        text: "Log out"
    }
]

const AuthenticatedLayout = ({ children }) => (
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

export default AuthenticatedLayout;
