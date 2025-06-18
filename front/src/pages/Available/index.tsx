import { CustomInput } from "../../components/CustomInput";
import { DateTimePicker } from "@mantine/dates";
import { useContext, useState } from "react";
import styles from "./styles.module.css";
import { CustomButton } from "../../components/CustomButton";
import axios from "axios";
import { GlobalContext } from "../../store/GlobalContext";

type result = {
  name: string;
  time: Date;
};

type resultList = result | result;

export function Available() {
  const [search, setSearch] = useState("");
  const [result, setResult] = useState<resultList>();
  const { authorization } = useContext(GlobalContext);

  function enviarFormulario(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();
    axios
      .post(
        "http://localhost:5184/api/v1/available/list",
        {
          Name: "",
          Initial: "2025-06-18T08:00:00.00Z",
          Final: "2025-06-18T18:00:00.00Z",
          Skip: 0,
          Take: 1000,
        },
        {
          headers: {
            Authorization: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlNpc3RlbWEuYWRtaW4iLCJVc2VySWQiOiI3NjIwN2U1Yi0zZmM1LTRhZDYtYTdjMC1jN2JiN2QxY2ZjYWUiLCJBY2Nlc3NJZCI6IjhkMjJiOGIzLTRjMTItNDBmYS05YjdhLTczZjZjZTJhMDhhOSIsInJvbGUiOiJBZG1pbiIsIm5iZiI6MTc1MDI0NzAzNCwiZXhwIjoxNzUwMjY4NjM0LCJpYXQiOjE3NTAyNDcwMzR9.vomJC79fruOGxM1ETJ56j30YElmCe_ANZxuG1PJYXUY`,
          },
        },
      )
      .then((response) => console.log(response.data))
      .catch((error) => console.error(error));
  }

  function handleClick(e: React.MouseEvent<HTMLButtonElement>) {
    e.preventDefault();
  }

  return (
    <>
      <div>
        <form className={styles.actionBar} onSubmit={enviarFormulario}>
          <CustomInput value={search} onChange={setSearch} id="Name" />
          <DateTimePicker />
          <DateTimePicker />
          <CustomButton type="submit">Consultar</CustomButton>
        </form>
      </div>
      <div className={styles.queryView}>
        <p>
          Lorem ipsum dolor sit amet consectetur adipisicing elit. Vitae modi,
          mollitia accusamus molestiae tempore natus incidunt facere soluta?
          Asperiores saepe voluptatibus incidunt impedit error, debitis quaerat
          nihil quia recusandae iste omnis ex vel veritatis earum? Ipsa, eius a.
          Sit architecto, nam dolor beatae modi animi. Itaque nihil voluptate,
          corrupti ad dolor vitae nam minima, recusandae dolorum unde odit vero
          nesciunt eos. Neque maiores sed placeat consequuntur eligendi, quis
          adipisci, est voluptatibus illo hic officia maxime, exercitationem
          laboriosam? Laboriosam reiciendis molestiae, labore iste, veniam minus
          adipisci ipsa possimus delectus excepturi quisquam quod aliquam?
          Eligendi animi voluptatibus voluptate enim alias at ut?
        </p>
        <p>
          Lorem ipsum dolor sit amet consectetur adipisicing elit. Vitae modi,
          mollitia accusamus molestiae tempore natus incidunt facere soluta?
          Asperiores saepe voluptatibus incidunt impedit error, debitis quaerat
          nihil quia recusandae iste omnis ex vel veritatis earum? Ipsa, eius a.
          Sit architecto, nam dolor beatae modi animi. Itaque nihil voluptate,
          corrupti ad dolor vitae nam minima, recusandae dolorum unde odit vero
          nesciunt eos. Neque maiores sed placeat consequuntur eligendi, quis
          adipisci, est voluptatibus illo hic officia maxime, exercitationem
          laboriosam? Laboriosam reiciendis molestiae, labore iste, veniam minus
          adipisci ipsa possimus delectus excepturi quisquam quod aliquam?
          Eligendi animi voluptatibus voluptate enim alias at ut?
        </p>
        <p>
          Lorem ipsum dolor sit amet consectetur adipisicing elit. Vitae modi,
          mollitia accusamus molestiae tempore natus incidunt facere soluta?
          Asperiores saepe voluptatibus incidunt impedit error, debitis quaerat
          nihil quia recusandae iste omnis ex vel veritatis earum? Ipsa, eius a.
          Sit architecto, nam dolor beatae modi animi. Itaque nihil voluptate,
          corrupti ad dolor vitae nam minima, recusandae dolorum unde odit vero
          nesciunt eos. Neque maiores sed placeat consequuntur eligendi, quis
          adipisci, est voluptatibus illo hic officia maxime, exercitationem
          laboriosam? Laboriosam reiciendis molestiae, labore iste, veniam minus
          adipisci ipsa possimus delectus excepturi quisquam quod aliquam?
          Eligendi animi voluptatibus voluptate enim alias at ut?
        </p>
      </div>
    </>
  );
}
