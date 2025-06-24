import axios from "axios";

export async function RegisterUser(
  user: string,
  password: string,
  address: string,
  email: string,
  phone: string,
  document: string,
  fullName: string,
) {
  return await axios.post("http://localhost:5184/api/v1/users", {
    Password: password,
    Username: user,
    Person: {
      Address: address,
      Document: document,
      Email: email,
      FullName: fullName,
      Phone: phone,
      Type: "F",
    },
    idAccess: "8D22B8B3-4C12-40FA-9B7A-73F6CE2A08A9",
  });
}
