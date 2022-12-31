import React, { useState } from "react";
import "../style.css";
export const RegistrationForm: view = ({
  updateUsernameInput = update.dashboard.registration.usernameInput,
  updatePasswordInput = update.dashboard.registration.passwordInput,
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
        <div className="confirm-password">
          <label className="form__label" htmlFor="confirmPassword">
            Confirm Password{" "}
          </label>
          <input
            className="form__input"
            type="password"
            id="confirmPassword"
            placeholder="Confirm Password"
          />
        </div>
      </div>
      <div className="footer">
        <button type="submit" className="btn">
          Register
        </button>
      </div>
    </div>
  );
};
