import React, { useState } from "react";

type value = {
  authorization: JsonWebKey | null;
  setAuthorization: React.Dispatch<React.SetStateAction<JsonWebKey | null>>;
};

type GlobalStorageProps = {
  children: React.ReactNode;
};

export const GlobalContext = React.createContext<value | null>(null);

export const GlobalStorage = ({ children }: GlobalStorageProps) => {
  const [authorization, setAuthorization] = useState<JsonWebKey | null>(null);

  return (
    <GlobalContext.Provider value={{ authorization, setAuthorization }}>
      {children}
    </GlobalContext.Provider>
  );
};
