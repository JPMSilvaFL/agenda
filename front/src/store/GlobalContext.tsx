import React, { useState } from "react";

type value = {
  authentication: JsonWebKey | null;
  setAuthentication: React.Dispatch<React.SetStateAction<JsonWebKey | null>>;
};

type GlobalStorageProps = {
  children: React.ReactNode;
};

export const GlobalContext = React.createContext<value | null>(null);

export const GlobalStorage = ({ children }: GlobalStorageProps) => {
  const [authentication, setAuthentication] = useState<JsonWebKey | null>(null);

  return (
    <GlobalContext.Provider value={{ authentication, setAuthentication }}>
      {children}
    </GlobalContext.Provider>
  );
};
