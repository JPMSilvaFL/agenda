import { useEffect, useState } from "react";
import { CustomButton } from "../../CustomButton";
import { CustomInput } from "../../CustomInput";
import styles from "./styles.module.css";
import axios from "axios";

export function ForgotPassword() {
  const [userForgot, setUserForgot] = useState("");
  const [newPassword, setNewPassword] = useState("");
  const [confirmNewPassword, setConfirmNewPassword] = useState("");
  const [errorConfirmPass, setErrorConfirmPass] = useState("");

  useEffect(() => {
    if (newPassword != confirmNewPassword)
      setErrorConfirmPass("Must be the same to the password!");
    if (newPassword == confirmNewPassword || confirmNewPassword.length <= 0)
      setErrorConfirmPass("");
  }, [confirmNewPassword]);

  function HandleSubmit(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();
    axios
      .post("http://localhost:5184/api/v1/user/changepassword", {
        Username: userForgot,
        Password: confirmNewPassword,
      })
      .then((resp) => {
        if (resp.data.error <= 0) alert("Password changed succesfully");
      })
      .catch(() => {
        alert("Password not changed!");
      });
  }

  return (
    <form method="post" className={styles.login} onSubmit={HandleSubmit}>
      <CustomInput
        label="User"
        value={userForgot}
        onChange={setUserForgot}
        id="userForgot"
      />
      <CustomInput
        label="New Password"
        value={newPassword}
        onChange={setNewPassword}
        id="newPassword"
        type="password"
      />
      <CustomInput
        label="Confirm New Password"
        value={confirmNewPassword}
        onChange={setConfirmNewPassword}
        id="confirmNewPassword"
        error={errorConfirmPass}
        type="password"
      />
      <CustomButton type="submit">Send</CustomButton>
    </form>
  );
}
