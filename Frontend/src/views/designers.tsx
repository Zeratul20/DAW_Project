import React, { useState } from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import { Button } from "@mui/material";

import { Form } from "../components/form";
import { designers } from "../mock-data/designers";

export const Designers: view = () => {
  if (!designers) {
    return null;
  }
  let firstDesigner = {};
  for (let designer in designers) {
    firstDesigner = designers[designer];
    break;
  }
  return (
    <div>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell>Designers</TableCell>
              <TableCell align="right">Age&nbsp;</TableCell>
              <TableCell align="right">Gender&nbsp;</TableCell>
              <TableCell align="right">Address&nbsp;</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {Object.keys(designers).map((designer) => (
              <TableRow
                key={designers[designer].id}
                sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
              >
                <TableCell component="th" scope="row">
                  {designers[designer].name}
                </TableCell>
                <TableCell align="right">{designers[designer].age}</TableCell>
                <TableCell align="right">
                  {designers[designer].gender}
                </TableCell>
                <TableCell align="right">
                  {designers[designer].address.city} |{" "}
                  {designers[designer].address.zipcode}
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      <Form data={firstDesigner} key={firstDesigner}/>
      {/* <Button></Button> */}
    </div>
  );
};
