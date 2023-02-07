import * as React from "react";
import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import Stack from "@mui/material/Stack";
import Button from "@mui/material/Button";

export const Form: view = ({
  data,
  type,
  designerInput = update.dashboard.designerAdd.designerInput,
  getDesignerInput = get.dashboard.designerAdd.designerInput,
  updateDesignerSubmitted = update.dashboard.designerAdd.submitted,
  clientInput = update.dashboard.clientAdd.clientInput,
  getClientInput = get.dashboard.clientAdd.clientInput,
  updateClientSubmitted = update.dashboard.clientAdd.submitted,
}) => {
  const handleChange = ({ target }: any) => {
    if (type === "designer") {
      if (!target.id.startsWith("address")) {
        let newObj: any = {};
        newObj[target.id] = target.value;
        designerInput.set({ ...getDesignerInput.value(), ...newObj });
        console.log("Form Input: ", getDesignerInput.value());
      } else {
        let newObj: any = {};
        if (!getDesignerInput.value()["address"]) newObj = { address: {} };
        else newObj = getDesignerInput.value();
        let prop = target.id.split(" ")[1];
        newObj["address"][prop] = target.value;
        designerInput.set({ ...getDesignerInput.value(), ...newObj });
        console.log("Form Address Input: ", getDesignerInput.value());
      }
    } else if (type === "client") {
      if (!target.id.startsWith("address")) {
        let newObj: any = {};
        newObj[target.id] = target.value;
        clientInput.set({ ...getClientInput.value(), ...newObj });
        console.log("Form Input: ", getClientInput.value());
      } else {
        let newObj: any = {};
        if (!getClientInput.value()["address"]) newObj = { address: {} };
        else newObj = getClientInput.value();
        let prop = target.id.split(" ")[1];
        newObj["address"][prop] = target.value;
        clientInput.set({ ...getClientInput.value(), ...newObj });
        console.log("Form Address Input: ", getClientInput.value());
      }
    }
  };

  const handleSubmit = (event: any) => {
    event.preventDefault();
    if (type === "designer") {
      updateDesignerSubmitted.set(true);
      console.log("Designer added!");
    }
    if (type === "client") {
      updateClientSubmitted.set(true);
      console.log("Client added!");
    }
  };

  return (
    <div>
      <h3>Add a {type}</h3>
      <Box
        component="form"
        sx={{
          "& .MuiTextField-root": { m: 1, width: "25ch" },
        }}
        noValidate
        autoComplete="off"
      >
        {Object.keys(data).map((d) => {
          console.log(d);
          if (d !== "address")
            return (
              <TextField
                key={d}
                id={d}
                label={d}
                variant="standard"
                className={d}
                onChange={handleChange}
              />
            );
          const address = data[d];
          return Object.keys(address).map((a) => (
            <TextField
              key={a}
              id={"address " + a}
              label={"address " + a}
              className={"address " + a}
              variant="standard"
              onChange={handleChange}
            />
          ));
        })}
      </Box>
      <Stack spacing={2} direction="row">
        <Button type="submit" onClick={handleSubmit} variant="outlined">
          Add
        </Button>
      </Stack>
    </div>
  );
};
