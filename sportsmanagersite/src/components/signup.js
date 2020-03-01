import React from 'react';
import './signup.css'

function Signup() {
    return (
<div class="login-page">
  <div class="form">
    <form class="login-form">
      <input type="text" placeholder="email"/>
      <input type="password" placeholder="password"/>
      <input type="password" placeholder="confirm password"/>
      <button>Sign up</button>
      <p class="message">Already registered? <a href="#">Log In</a></p>
    </form>
  </div>
</div>
    );
  }
  
  export default Signup;
 