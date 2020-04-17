import React, { Component } from 'react';
import '../styles/signup.css';

import Layout from '../layouts/BaseLayout';
import { Redirect } from 'react-router-dom';

import { authentication, checkLogin, varsLogin, validateAuth } from '../components/WebAPI';
import loadingPage from './loading';


class Login extends Component{
    constructor () {
        super();
    
        this.state = { 
            inputEmail: '',
            inputPassword: '',
            alreadyLogged: null
        };

        this.handleChangeEmail = this.handleChangeEmail.bind(this);
    
        this.handleChangePassword = this.handleChangePassword.bind(this);

        this.handleLogin = this.handleLogin.bind(this);
    }

    async componentWillMount() {
        await checkLogin(this);
        await authentication(this);
    }

    handleChangeEmail(e) {
        this.setState({ inputEmail: e.target.value });
    }

    handleChangePassword(e) {
        this.setState({ inputPassword: e.target.value });
    }

    handleLogin() {
        varsLogin(this.state.inputEmail,this.state.inputPassword);
    }

    render() {
        if(this.state.alreadyLogged !== null) return validateAuth(this, null);
//        if(this.state.alreadyLogged === 'loading') return loadingPage();
//        if(this.state.alreadyLogged !== null) return (<Redirect to={{ pathname: '/'+this.state.alreadyLogged }}/>);

        return (
            <Layout>
                <div class="login-page">
                    <div class="form">
                        <form class="login-form">
                            <input type="text" placeholder="email" onChange={this.handleChangeEmail} />
                            <input type="password" placeholder="password" onChange={this.handleChangePassword} />
                            <button onClick={this.handleLogin}>log in </button>
                            <p class="message">Not registered? <a href="/signup">Create an account</a></p>
                        </form>
                    </div>
                </div>
            </Layout>
        );
    }
}

export default Login;
