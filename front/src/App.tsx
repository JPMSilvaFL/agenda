import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Login } from "./pages/Login";
import { NotFound } from "./pages/NotFound";
import { Navbar } from "./components/Menu";
import { useDisclosure } from "@mantine/hooks";
import { AppShell, Burger, MantineProvider } from "@mantine/core";
import "@mantine/core/styles.css";
import { UserTray } from "./components/UserTray";
import styles from "./App.module.css";
import { Home } from "./pages/Home";

export function App() {
  const [opened, { toggle }] = useDisclosure();
  return (
    <MantineProvider>
      <BrowserRouter>
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route
            path=""
            element={
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
                <AppShell.Navbar p="md">
                  <Navbar />
                </AppShell.Navbar>
                <AppShell.Main className={styles.mainContainer}>
                  <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="*" element={<NotFound />} />
                  </Routes>
                </AppShell.Main>
              </AppShell>
            }
          />
        </Routes>
      </BrowserRouter>
    </MantineProvider>
  );
}
