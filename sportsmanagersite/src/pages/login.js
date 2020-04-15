import React, { Component } from 'react';
import '../styles/signup.css';

import Layout from '../layouts/BaseLayout';


class Login extends Component{
    constructor () {
        super();
    
        this.state = { 
        inputEmail: '',
        inputPassword: ''
        };

        this.handleChangeEmail = this.handleChangeEmail.bind(this);
    
        this.handleChangePassword = this.handleChangePassword.bind(this);
    }

    handleChangeEmail(e) {
        this.setState({ inputEmail: e.target.value });
    }

    handleChangePassword(e) {
        this.setState({ inputPassword: e.target.value });
    }

    handleLogin() {
        alert("LOGIN:"+this.state.inputEmail+"  PASS:"+this.state.inputPassword);
        //localStorage.setItem(this.state.inputEmail,this.state.inputPassword);
    }

    render() {
        return (
            <Layout>
                <div class="login-page">
                    <div class="form">
                        <form class="login-form">
                            <input type="text" placeholder="email" onChange={this.handleChangeEmail} />
                            <input type="password" placeholder="password" onChange={this.handleChangePassword} />
                            <button onClick={() => this.handleLogin()}>log in </button>
                            <p class="message">Not registered? <a href="/signup">Create an account</a></p>
                        </form>
                    </div>
                </div>
            </Layout>
        );
    }
}

export default Login;
