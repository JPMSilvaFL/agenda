import { CustomInput } from "../../components/CustomInput";
import { DateTimePicker } from "@mantine/dates";
import { useContext, useState } from "react";
import "react-calendar/dist/Calendar.css";
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
  var { authentication } = useContext(GlobalContext);
  

  axios.post("http://localhost:5184", {
    headers: {
      authorization: "Bearer " + {context.authentication},
    },
  });

  return (
    <>
      <div>
        <form className={styles.actionBar}>
          <CustomInput value={search} onChange={setSearch} id="Name" />
          <DateTimePicker />
          <DateTimePicker />
          <CustomButton>Consultar</CustomButton>
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
