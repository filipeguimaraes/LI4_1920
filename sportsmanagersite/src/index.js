import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Switch, Route } from 'react-router-dom';

import * as serviceWorker from './utils/serviceWorker';

import LandingPage from './pages/landingpage';
import Contact from './pages/contact';
import Login from './pages/login';
import Signup from './pages/signup';
import Register from './pages/register';
import Instructor from './pages/instructor';

const SportsManager = () => (
    <BrowserRouter>
        <Switch>
            <Route exact path="/" component={LandingPage} />
            <Route path="/contact" component={Contact} />
            <Route path="/login" component={Login} />
            <Route path="/signup" component={Signup} />
            <Route path="/register" component={Register} />
            <Route path="/instructor" component={Instructor} />
        </Switch>
    </BrowserRouter>
);

ReactDOM.render(<SportsManager />, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.register();
