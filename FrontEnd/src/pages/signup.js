import React, { Component } from 'react';
import '../styles/signup.css'

import Layout from '../layouts/BaseLayout';

import { checkRegister , validateAuth } from '../components/WebAPI';


export const validSignUp = 'signup';

class Signup extends Component {
    constructor() {
        super();

        this.state = {
            inputEmail: '',
            inputPassword: '',
            inputRePass: '',
            alreadyLogged: 'signup'
        };

        this.handleChangeEmail = this.handleChangeEmail.bind(this);

        this.handleChangePassword = this.handleChangePassword.bind(this);

        this.handleRePass = this.handleRePass.bind(this);
    }

    async componentWillMount() {
        await checkRegister(this);
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
        if (this.state.inputPassword !== "" && this.state.inputPassword === this.state.inputRePass) {
            sessionStorage.setItem('email', this.state.inputEmail);
            sessionStorage.setItem('pass', this.state.inputPassword);
            sessionStorage.setItem('repass', this.state.inputRePass);
        }
        else {
            alert("Passwords do not match.");
        }
    }

    render() {
        if (this.state.alreadyLogged !== validSignUp) return validateAuth(this, validSignUp);

        return (
            <Layout>
                <div class="login-page">
                    <div class="form">
                        <form class="singup-form">
                            <input type="text" placeholder="email" onChange={this.handleChangeEmail} />
                            <input type="password" placeholder="password" onChange={this.handleChangePassword} />
                            <input type="password" placeholder="confirm password" onChange={this.handleRePass} />
                            <button onClick={() => this.handleSignup()}>Sign up</button>
                            <p class="message">Already registered? <a href="/login">Log in</a></p>
                        </form>
                    </div>
                </div>
            </Layout>
        );
    }
}

export default Signup;
