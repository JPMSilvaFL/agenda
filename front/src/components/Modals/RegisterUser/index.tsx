import { useEffect, useState } from "react";
import { CustomButton } from "../../CustomButton";
import { CustomInput } from "../../CustomInput";
import styles from "./styles.module.css";
import { RegisterUser as RegisterUserRequest } from "../../../requests/Users/user";

export function RegisterUser() {
  const [user, setUser] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [errorConfirmPass, setErrorConfirmPass] = useState("");

  const [address, setAddress] = useState("");
  const [email, setEmail] = useState("");
  const [phone, setPhone] = useState("");
  const [document, setDocument] = useState("");
  const [fullName, setFullName] = useState("");

  const [message, setMessage] = useState("");
  const [colorMessage, setColorMessage] = useState("green");

  useEffect(() => {
    if (password != confirmPassword)
      setErrorConfirmPass("Must be the same to the password!");
    if (password == confirmPassword || confirmPassword.length <= 0)
      setErrorConfirmPass("");
  }, [confirmPassword]);

  useEffect(() => {});

  async function HandleSubmit(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();
    var response = await RegisterUserRequest(
      user,
      password,
      address,
      email,
      phone,
      document,
      fullName,
    );
    if (response.status === 200) {
      setMessage("User registered successfully!");
      setUser("");
      setPassword("");
      setConfirmPassword("");
      setAddress("");
      setEmail("");
      setPhone("");
      setDocument("");
      setFullName("");
    } else if (response.status === 409) {
      setColorMessage("red");
      setMessage(response.data.errors);
    } else {
      setColorMessage("red");
      setMessage("An error occurred while registering the user.");
    }
  }

  return (
    <form method="post" className={styles.login} onSubmit={HandleSubmit}>
      <CustomInput
        label="Full Name"
        value={fullName}
        onChange={setFullName}
        id="fullName"
        type="text"
        placeholder="Your Full Name"
      />
      <CustomInput
        label="Email"
        value={email}
        onChange={setEmail}
        id="email"
        type="email"
        placeholder="example@example.com"
      />
      <CustomInput
        label="Address"
        value={address}
        onChange={setAddress}
        id="address"
        type="text"
        placeholder="123 Main St, City, State, Zip"
      />
      <CustomInput
        label="Phone"
        value={phone}
        onChange={setPhone}
        id="phone"
        type="tel"
        placeholder="(xx) xxxxx-xxxx"
      />
      <CustomInput
        label="CPF"
        value={document}
        onChange={setDocument}
        id="document"
        placeholder="123.456.789-00"
      />
      <CustomInput
        label="User"
        value={user}
        onChange={setUser}
        id="user"
        type="text"
        placeholder="example.username"
      />
      <CustomInput
        label="Password"
        value={password}
        onChange={setPassword}
        id="Password"
      />
      <CustomInput
        label="Confirm Password"
        value={confirmPassword}
        onChange={setConfirmPassword}
        id="confirmPassword"
        error={errorConfirmPass}
      />
      {message && <p style={{ color: "{colorMessage}" }}>{message}</p>}
      <CustomButton type="submit">Send</CustomButton>
    </form>
  );
}
