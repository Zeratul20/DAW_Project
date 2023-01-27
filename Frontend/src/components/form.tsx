import * as React from "react";
import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import Stack from "@mui/material/Stack";
import Button from "@mui/material/Button";

export const Form: view = ({ data, type }) => {
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
              <TextField key={d} id="input_key" label={d} variant="standard" />
            );
          const address = data[d];
          return Object.keys(address).map((a) => (
            <TextField
              key={a}
              id="input_key"
              label={"address " + a}
              variant="standard"
            />
          ));
        })}
      </Box>
      <Stack spacing={2} direction="row">
        <Button variant="outlined">Add</Button>
      </Stack>
    </div>
  );
};
