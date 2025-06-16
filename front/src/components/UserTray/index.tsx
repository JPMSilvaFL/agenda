import {Popover, Avatar} from "@mantine/core";
import styles from "./styles.module.css";

export function UserTray() {
    return (
        <Popover width="fit-content" position="right" withArrow shadow="md">
            <Popover.Target>
                <Avatar radius="xl"/>
            </Popover.Target>
            <Popover.Dropdown className={styles.userContainer}>
                <div className={styles.userInfoHeader}>
                    <Avatar radius="xl"/>
                    <p className={styles.userInfoName}>Joao Pedro Mota</p>
                    <p className={styles.userInfoEmail}>joao.pedro.69461@gmail.com</p>
                </div>
                <div className={styles.userRows}>
                    <p>Tema</p>
                    <p>Configurações</p>
                    <p>Logout</p>
                    <p>Sair</p>
                </div>
            </Popover.Dropdown>
        </Popover>
    );
}
