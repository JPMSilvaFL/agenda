import { AppShell, Burger } from "@mantine/core";
import styles from "../../App.module.css";
import { UserTray } from "../../components/UserTray";
import { Navbar } from "../../components/Menu";
import { Outlet, useNavigate } from "react-router-dom";
import { useDisclosure } from "@mantine/hooks";
import { useContext, useEffect } from "react";
import { GlobalContext } from "../../store/GlobalContext";
import axios from "axios";

export function MainLayout() {
  const [opened, { toggle }] = useDisclosure();
  const navigate = useNavigate();

  const context = useContext(GlobalContext);
  if (!context) throw new Error("Context outside of provider");
  const { authorization } = context;
  useEffect(() => {
    axios
      .post("http://localhost:5184/api/v1/login/validatetoken", {
        token: authorization,
      })
      .then((resp) => {
        var confirm = resp.data;
        if (confirm == false) navigate("login");
      });
  });
  return (
    <AppShell
      padding={{ base: 10, sm: 15, lg: "xl" }}
      header={{ height: { base: 48, sm: 60, lg: 76 } }}
      navbar={{
        width: 120,
        breakpoint: "sm",
        collapsed: { mobile: !opened },
      }}
    >
      <AppShell.Header className={styles.headerContainer}>
        <Burger
          lineSize={5}
          onClick={toggle}
          opened={opened}
          hiddenFrom="sm"
          size="lg"
        />
        <div className={styles.userTray}>
          <UserTray />
        </div>
      </AppShell.Header>
      <AppShell.Navbar className={styles.navBar}>
        <Navbar />
      </AppShell.Navbar>
      <AppShell.Main className={styles.mainContainer}>
        <Outlet />
      </AppShell.Main>
    </AppShell>
  );
}
