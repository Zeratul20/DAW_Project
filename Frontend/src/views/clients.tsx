import React, { useState } from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";

import { Form } from "../components/form";
import { clients } from "../mock-data/clients";

export const Clients: view = () => {
  if (!clients) {
    return null;
  }
  let firstClient = {};
  for (let client in clients) {
    firstClient = clients[client];
    break;
  }
  return (
    <div>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell>Clients</TableCell>
              <TableCell align="right">Phone</TableCell>
              <TableCell align="right">Address&nbsp;</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {Object.keys(clients).map((client) => (
              <TableRow
                key={clients[client].id}
                sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
              >
                <TableCell component="th" scope="row">
                  {clients[client].name}
                </TableCell>
                <TableCell align="right">{clients[client].phone}</TableCell>
                <TableCell align="right">
                  {clients[client].address.city} |{" "}
                  {clients[client].address.zipcode}
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      <Form data={firstClient} type="client" key={firstClient} />
    </div>
  );
};
