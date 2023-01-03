import Navbar from "./components/navbar";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { Content } from "./views/content";
import Header from "./views/header";
import { LoginForm } from "./views/loginForm";
import { RegistrationForm } from "./views/registrationForm";
import { Home } from "./views/home";

export const App: view = () => {
  return (
    <>
      <Router>
        <Navbar />
        <Routes>
          <Route path='/' element={<Home />} />
          <Route path="/register" element={<RegistrationForm />} />
          <Route path="/login" element={<LoginForm />} />
        </Routes>
      </Router>
    </>
  );
};

// App.producers([greeting]);
