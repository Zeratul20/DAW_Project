import { Content } from "./views/content";
import Header from "./views/header";
import { LoginForm } from "./views/loginForm";
import { RegistrationForm } from "./views/registrationForm";

export const App: view = () => {
  return (
    <>
      <Header />
      <RegistrationForm />
      <LoginForm />
    </>
  );
};

// App.producers([greeting]);
