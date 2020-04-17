import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Switch, Route, Redirect } from 'react-router-dom';

import * as serviceWorker from './utils/serviceWorker';
//MainPage
import LandingPage from './pages/landingpage';
import Contact from './pages/contact';
import Login from './pages/login';
import Signup from './pages/signup';
import Register from './pages/register';
//User
import User from './pages/user';
import Statistics from './pages/statistics';
import Classes from './pages/classes';
import Places from './pages/places';
import Settings from './pages/settings';
//Instructor
import Instructor from './pages/instructor';
//Aditional pages
import Loading from './pages/loading';
import Error from './pages/error';

const SportsManager = () => (
    <BrowserRouter>
        <Switch>
            <Route exact path="/" component={LandingPage} />
            <Route path="/contact" component={Contact} />
            <Route path="/login" component={Login} />
            <Route path="/signup" component={Signup} />
            <Route path="/register" component={Register} />
            <Route path="/user" component={User} />
            <Route path="/statistics" component={Statistics} />
            <Route path="/classes" component={Classes} />
            <Route path="/places" component={Places} />
            <Route path="/settings" component={Settings} />
            <Route path="/instructor" component={Instructor} />
            <Route path="/loading" component={Loading} />
            <Route path="/error" component={Error} />
            <Redirect to={{ pathname: '/' }}/>
        </Switch>
    </BrowserRouter>
);

ReactDOM.render(<SportsManager />, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.register();
