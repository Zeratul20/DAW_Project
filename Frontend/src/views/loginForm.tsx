import React, { useState } from "react";
// import "../style.css";
export const LoginForm: view = ({
  updateUsernameInput = update.dashboard.login.usernameInput,
  updatePasswordInput = update.dashboard.login.passwordInput,
}) => {
  const handleUsernameChange = (event) => {
    updateUsernameInput.set(event.target.value);
  };
  const handlePasswordChange = (event) => {
    updatePasswordInput.set(event.target.value);
  };
  return (
    <div className="form">
      <div className="form-body">
        <div className="username">
          <label className="form__label" htmlFor="username">
            Username{" "}
          </label>
          <input
            className="form__input"
            type="text"
            id="username"
            placeholder="Username"
            onChange={handleUsernameChange}
          />
        </div>
        <div className="password">
          <label className="form__label" htmlFor="password">
            Password{" "}
          </label>
          <input
            className="form__input"
            type="password"
            id="password"
            placeholder="Password"
            onChange={handlePasswordChange}
          />
        </div>
      </div>
      <div className="footer">
        <button type="submit" className="btn">
          Login
        </button>
      </div>
    </div>
  );
};
