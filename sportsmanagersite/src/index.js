import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import { Layout, Content } from 'react-mdl';

import * as serviceWorker from './utils/serviceWorker';

import './styles/index.css';
import 'react-mdl/extra/material.css';
import 'react-mdl/extra/material.js';

import Navbar from './components/Navbar';
import LandingPage from './pages/landingpage';
import Contact from './pages/contact';
import Login from './pages/login';
import Signup from './pages/signup';


const SportsManager = () => (
    <BrowserRouter>
        <div className="demo-big-content">
            <Layout>
                <Navbar />
                <Content>
                    <div className="page-content" />
                    <Switch>
                        <Route exact path="/" component={LandingPage} />
                        <Route path="/contact" component={Contact} />
                        <Route path="/login" component={Login} />
                        <Route path="/signup" component={Signup} />
                    </Switch>
                </Content>
            </Layout>
        </div>
    </BrowserRouter>
);

ReactDOM.render(<SportsManager />, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.register();
