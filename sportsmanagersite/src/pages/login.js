import React from 'react';
import '../styles/signup.css';

function Login() {
  return (
    <div class="login-page">
      <div class="form">
        <form class="login-form">
          <input type="text" placeholder="email" />
          <input type="password" placeholder="password" />
          <button>log in</button>
          <p class="message">Not registered? <a href="/signup">Create an account</a></p>
        </form>
      </div>
    </div>
  );
}

export default Login;
