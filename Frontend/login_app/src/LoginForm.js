import React, { useState } from "react";
import './LoginForm.css';

const LoginForm = ({ onSubmit }) => {
  const [login, setLogin] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");

  const handleSubmit = (event) => {
    event.preventDefault();
    const trimmedLogin = login.trim();
    const trimmedPassword = password.trim();

    if (!trimmedLogin && !trimmedPassword) {
      setError("Username and password are required.");
    } else if (!trimmedLogin) {
      setError("Username is required.");
    } else if (!trimmedPassword) {
      setError("Password is required.");
    } else {
      onSubmit({ login: trimmedLogin, password: trimmedPassword });
      setLogin("");
      setPassword("");
      setError("");
    }
  };

  return (
    <form className="form" onSubmit={handleSubmit}>
      <h1>Login</h1>
      <label htmlFor="name">Name</label>
      <input
        type="text"
        id="name"
        value={login}
        onChange={(e) => setLogin(e.target.value)}
      />
      <label htmlFor="password">Password</label>
      <input
        type="password"
        id="password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />
      <button type="submit">Continue</button>
      {error && <p className="error">{error}</p>}
    </form>
  );
};

export default LoginForm;