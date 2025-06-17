import styles from "./styles.module.css";
import {CustomInput} from "../../components/CustomInput";
import {useState} from "react";
import {CustomButton} from "../../components/CustomButton";
import {useDisclosure} from "@mantine/hooks";
import {CustomModal} from "../../components/CustomModal";

export function Login() {
    const [opened, {open, close}] = useDisclosure(false);
    const [openedRegister, {open: openRegister, close: closeRegister}] =
        useDisclosure(false);

    const [user, setUser] = useState("");
    const [password, setPassword] = useState("");

    const [userForgot, setUserForgot] = useState("");
    const [newPassword, setNewPassword] = useState("");
    const [confirmNewPassword, setConfirmNewPassword] = useState("");

    return (
        <>
            <div className={styles.container}>
                <div className={styles.formLogin}>
                    <form method="post" className={styles.login}>
                        <CustomInput
                            variant="filled"
                            size="1rem"
                            id="user"
                            type="text"
                            value={user}
                            onChange={setUser}
                        />
                        <CustomInput
                            variant="filled"
                            size="1rem"
                            id="password"
                            type="password"
                            value={password}
                            onChange={setPassword}
                        />
                        <CustomButton>Login</CustomButton>
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
                        Has a account? <a onClick={openRegister}> Sign in
                        here</a>
                    </p>
                </div>
            </div>
        </>
    );
}
