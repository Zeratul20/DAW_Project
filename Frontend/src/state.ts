export type State = {
  designers: Designers;
  clients: Clients;
  collections: Collections;
  dashboard: {
    registration: {
      usernameInput: string;
      passwordInput: string;
      submitted: boolean;
    };
    login: { usernameInput: string; passwordInput: string; submitted: boolean };
    selectedMenu: string;
    desginerInput: Designer;
    clientInput: Client;
  };
};

export type Address = {
  id: string;
  city: string;
  zipcode: string;
};

export type Designer = {
  id: string;
  name: string;
  age: number;
  gender: string;
  address: Address;
};

export type Client = {
  id: string;
  name: string;
  phone: string;
  address: Address;
};

export type Collection = {
  id: string;
  collectionName: string;
  numberOfItems: number;
  releaseDate: Date;
};

export type Designers = Record<string, Designer>;

export type Clients = Record<string, Client>;

export type Collections = Record<string, Collection>;
