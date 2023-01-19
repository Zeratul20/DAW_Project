import React, { useState } from "react";
// import "../style.css";
export const RegistrationForm: view = ({
  updateUsernameInput = update.dashboard.registration.usernameInput,
  updatePasswordInput = update.dashboard.registration.passwordInput,
  usernameInput = get.dashboard.registration.usernameInput,
  passwordInput = get.dashboard.registration.passwordInput,
  updateSubmitted = update.dashboard.registration.submitted,
  submitted = get.dashboard.registration.submitted,
}) => {
  const handleUsernameChange = ({target}:{target:{value:String}}) => {
    updateUsernameInput.set(target.value);
  };

  const handlePasswordChange = ({target}:{target:{value:String}}) => {
    updatePasswordInput.set(target.value);
  };

  const handleSubmit = (event: any) => {
    event.preventDefault();
    console.log("Username before: ", !usernameInput.value());
    if (!usernameInput.value() || !passwordInput.value())
      return (
        <div className="error">
          <p>Please enter all the fields</p>
        </div>
      );

    console.log("Username after: ", usernameInput.value());
    updateSubmitted.set(true);
    console.log("Submitted");
    return (
      <div
        className="success"
        style={{
          display: submitted.value() ? "" : "none",
        }}
      >
        <p>User {usernameInput.value()} successfully registered!!</p>
      </div>
    );
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
      <div className="submit">
        <button type="submit" onClick={handleSubmit} className="btn">
          Register
        </button>
      </div>
    </div>
  );
};
