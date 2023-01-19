import { Navbar } from "./components/navbar";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { Content } from "./views/content";
import Header from "./views/header";
import { LoginForm } from "./views/loginForm";
import { RegistrationForm } from "./views/registrationForm";
import { Home } from "./views/home";
import { Designers } from "./views/designers";
import { Clients } from "./views/clients";

export const App: view = () => {
  return (
    <>
      <Router>
        <Navbar />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/Home" element={<Home />} />
          <Route path="/Register" element={<RegistrationForm />} />
          <Route path="/Login" element={<LoginForm />} />
          <Route path="/Designers" element={<Designers />} />
          <Route path="/Clients" element={<Clients />} />
        </Routes>
      </Router>
    </>
  );
};

// App.producers([greeting]);
