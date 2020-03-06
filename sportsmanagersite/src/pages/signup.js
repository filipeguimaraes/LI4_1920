import React from 'react';
import '../styles/signup.css'

import Layout from '../layouts/BaseLayout';

const Signup = () => (
  <Layout>
    <div class="login-page">
      <div class="form">
        <form action="/register" class="login-form">
          <input type="text" placeholder="email" />
          <input type="password" placeholder="password" />
          <input type="password" placeholder="confirm password" />
          <button>Sign up</button>
          <p class="message">Already registered? <a href="/login">Log In</a></p>
        </form>
      </div>
    </div>
  </Layout>
);

export default Signup;
