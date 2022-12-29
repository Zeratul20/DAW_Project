import { Clients } from "../state";

export const clients: Clients = {
  client1: {
    id: "h&m",
    name: "H&M",
    phone: "111-222-333",
    address: {
      id: "berlin",
      city: "Berlin",
      zipcode: "8658493",
    },
  },
  client2: {
    id: "c&a",
    name: "C&A",
    phone: "222-333-444",
    address: {
      id: "paris",
      city: "Paris",
      zipcode: "938723",
    },
  },
  client3: {
    id: "ccc",
    name: "CCC",
    phone: "333-444-555",
    address: {
      id: "bucharest",
      city: "Bucharest",
      zipcode: "183761",
    },
  },
};
