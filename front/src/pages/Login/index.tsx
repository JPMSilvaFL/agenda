import styles from "./styles.module.css";
import { CustomInput } from "../../components/CustomInput";
import { useContext, useEffect, useState } from "react";
import { CustomButton } from "../../components/CustomButton";
import { useDisclosure } from "@mantine/hooks";
import { CustomModal } from "../../components/CustomModal";
import { GlobalContext } from "../../store/GlobalContext";
import axios from "axios";
import { useNavigate } from "react-router-dom";

export function Login() {
  const [opened, { open, close }] = useDisclosure(false);
  const [openedRegister, { open: openRegister, close: closeRegister }] =
    useDisclosure(false);
  const navigate = useNavigate();

  const [user, setUser] = useState("");
  const [password, setPassword] = useState("");

  const [userForgot, setUserForgot] = useState("");
  const [newPassword, setNewPassword] = useState("");
  const [confirmNewPassword, setConfirmNewPassword] = useState("");

  const context = useContext(GlobalContext);

  if (!context) throw new Error("Context outside of provider");
  const { authorization, setAuthorization } = context;

  function handleLogin(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();

    axios
      .post("http://localhost:5184/api/v1/login", {
        Username: user.toString(),
        Password: password.toString(),
      })
      .then((response) => setAuthorization(response.data.authorization))
      .then(() => {
        if (authorization != null && authorization != undefined) navigate("/");
      });
  }

  useEffect(() => {
    console.log(authorization);
  }, [authorization]);

  return (
    <>
      <div className={styles.container}>
        <div className={styles.formLogin}>
          <form method="post" className={styles.login} onSubmit={handleLogin}>
            <CustomInput
              variant="filled"
              size="1rem"
              id="user"
              type="text"
              value={user}
              onChange={setUser}
              className={styles.inputLogin}
              styles={{
                input: {
                  padding: "1rem",
                },
              }}
            />
            <CustomInput
              variant="filled"
              size="1rem"
              id="password"
              type="password"
              value={password}
              onChange={setPassword}
              className={styles.inputLogin}
              styles={{
                input: {
                  padding: "1rem",
                },
              }}
            />
            <CustomButton type="submit">Login</CustomButton>
          </form>

          <CustomModal
            opened={opened}
            onClose={close}
            centered={true}
            withCloseButton={false}
          >
            <form method="post" className={styles.login}>
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
              />
              <CustomInput
                label="Confirm New Password"
                value={confirmNewPassword}
                onChange={setConfirmNewPassword}
                id="confirmNewPassword"
              />
              <CustomButton>Send</CustomButton>
            </form>
          </CustomModal>
          <p>
            Forgot your password?<a onClick={open}> Recover here</a>
          </p>

          <CustomModal
            opened={openedRegister}
            onClose={closeRegister}
            centered={true}
            withCloseButton={false}
            title="Register"
          ></CustomModal>
          <p>
            Has a account? <a onClick={openRegister}> Sign in here</a>
          </p>
        </div>
      </div>
    </>
  );
}
