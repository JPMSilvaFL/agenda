import styles from "./styles.module.css";
import { CustomInput } from "../../components/CustomInput";
import { useContext, useEffect, useState } from "react";
import { CustomButton } from "../../components/CustomButton";
import { useDisclosure } from "@mantine/hooks";
import { CustomModal } from "../../components/CustomModal";
import { GlobalContext } from "../../store/GlobalContext";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { ForgotPassword } from "../../components/Modals/ForgotPassword";
import { RegisterUser } from "../../components/Modals/RegisterUser";

export function Login() {
  const [opened, { open, close }] = useDisclosure(false);
  const [openedRegister, { open: openRegister, close: closeRegister }] =
    useDisclosure(false);
  const navigate = useNavigate();

  const [user, setUser] = useState("");
  const [password, setPassword] = useState("");
  const [errorLogin, setErrorLogin] = useState("");

  const context = useContext(GlobalContext);

  if (!context) throw new Error("Context outside of provider");
  const { setAuthorization } = context;

  function handleLogin(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();

    axios
      .post("http://localhost:5184/api/v1/login", {
        Username: user.toString(),
        Password: password.toString(),
      })
      .then((response) => setAuthorization(response.data.authorization))
      .then(() => {
        navigate("/");
      })
      .catch(() => {
        setErrorLogin("Invalid username or password");
      });
  }
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
            {errorLogin && <p className={styles.errorLogin}>{errorLogin}</p>}
            <CustomButton type="submit">Login</CustomButton>
          </form>

          <CustomModal
            opened={opened}
            onClose={close}
            centered={true}
            withCloseButton={false}
          >
            <ForgotPassword />
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
          >
            <RegisterUser />
          </CustomModal>
          <p>
            Has a account? <a onClick={openRegister}> Sign in here</a>
          </p>
        </div>
      </div>
    </>
  );
}
