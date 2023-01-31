import * as React from "react";
import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import Stack from "@mui/material/Stack";
import Button from "@mui/material/Button";

export const Form: view = ({
  data,
  type,
  designerInput = update.dashboard.designerInput,
  getDesignerInput = get.dashboard.designerInput,
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
        console.log("New Addr OPbj: ", newObj["address"]);
        let prop = target.id.split(" ")[1];
        newObj["address"][prop] = target.value;
        designerInput.set({ ...getDesignerInput.value(), ...newObj });
        console.log("Form Address Input: ", getDesignerInput.value());
      }
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
        <Button type="submit" variant="outlined">
          Add
        </Button>
      </Stack>
    </div>
  );
};
