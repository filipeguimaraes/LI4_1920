import React, { Component } from 'react';
import '../styles/signup.css'

import Layout from '../layouts/BaseLayout';

class Signup extends Component{
    constructor () {
            super();
    
            this.state = { 
                inputEmail: '',
                inputPassword: '',
                inputRePass: ''
            };

            this.handleChangeEmail = this.handleChangeEmail.bind(this);
    
            this.handleChangePassword = this.handleChangePassword.bind(this);

            this.handleRePass = this.handleRePass.bind(this);
    }

    handleChangeEmail(e) {
            this.setState({ inputEmail: e.target.value });
    }

    handleChangePassword(e) {
            this.setState({ inputPassword: e.target.value });
    }

    handleRePass(e) {
        this.setState({ inputRePass: e.target.value });
    }

    handleSignup() {
            alert("LOGIN:"+this.state.inputEmail+"  PASS:"+this.state.inputPassword);
            //localStorage.setItem(this.state.inputEmail,this.state.inputPassword);
    }

    render() {
            return (
                <Layout>
                    <div class="login-page">
                        <div class="form">
                            <form action="/register" class="login-form">
                                <input type="text" placeholder="email" onChange={this.handleChangeEmail} />
                                <input type="password" placeholder="password" onChange={this.handleChangePassword} />
                                <input type="password" placeholder="confirm password" onChange={this.handleRePass} />
                                <button>Sign up</button>
                                <p class="message">Already registered? <a href="/login">Log in</a></p>
                            </form>
                        </div>
                    </div>
                </Layout>
            );
    }
}

export default Signup;
