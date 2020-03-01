import React from 'react';
import { Switch, Route } from 'react-router-dom';
import LandingPage from './landingpage';
import About from './about';
import Contact from './contact';
import Login from './login';
import Signup from './signup';

const Main = () => (
    <Switch>
        <Route exact path="/" component = {LandingPage} />
        <Route path="/about" component = {About} />
        <Route path="/contact" component = {Contact} />
        <Route path="/login" component = {Login} />
        <Route path="/signup" component = {Signup} />
    </Switch>    
)

export default Main;