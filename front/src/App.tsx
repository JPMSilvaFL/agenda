import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Login } from "./pages/Login";
import "@mantine/core/styles.css";
import { MantineProvider } from "@mantine/core";
import {MainLayout} from "./templates/MainLayout";
import {Home} from "./pages/Home";
import {Available} from "./pages/Available";
import {NotFound} from "./pages/NotFound";

export function App() {

  return (
    <MantineProvider>
      <BrowserRouter>
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route path="/" element={<MainLayout />}>
            <Route index element={<Home />} />
            <Route path="available" element={<Available /> } />
            <Route path="*" element={<NotFound />}/>
          </Route>
        </Routes>
      </BrowserRouter>
    </MantineProvider>
  );
}
