import { Nav, NavLink, NavMenu } from "./navbarElements";

const Navbar: view = () => {
  return (
    <>
      <h1>Designer</h1>
      <Nav>
        <NavMenu>
          <NavLink to="/">Home</NavLink>
          <NavLink to="/register">Register</NavLink>
          <NavLink to="/login">Login</NavLink>
        </NavMenu>
      </Nav>
    </>
  );
};

export default Navbar;
