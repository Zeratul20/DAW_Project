import * as React from "react";
import { useNavigate } from "react-router-dom";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import Box from "@mui/material/Box";

export const Navbar: view = ({
  selectedMenu = get.selectedMenu,
  setSelectedMenu = update.selectedMenu,
}) => {
  const navigate = useNavigate();

  const handleChange = (event: React.SyntheticEvent, value: string) => {
    navigate(value);
    setSelectedMenu.set(value);
  };

  return (
    <Box sx={{ width: "100%" }}>
      <Tabs
        value={selectedMenu.value()}
        onChange={handleChange}
        textColor="secondary"
        indicatorColor="secondary"
        aria-label="secondary tabs example"
      >
        <Tab value="Home" label="Home" />
        <Tab value="Register" label="Register" />
        <Tab value="Login" label="Login" />
        <Tab value="Designers" label="Designers" />
        <Tab value="Clients" label="Clients" />
      </Tabs>
    </Box>
  );
};
