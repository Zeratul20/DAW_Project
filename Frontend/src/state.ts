export type State = {
  designers: { items: Designers; triggers: number };
  clients: { items: Clients; triggers: number };
  collections: { items: Collections; triggers: number };
  dashboard: {
    registration: {
      usernameInput: string;
      passwordInput: string;
      submitted: boolean;
    };
    login: { usernameInput: string; passwordInput: string; submitted: boolean };
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
