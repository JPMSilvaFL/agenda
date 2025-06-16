import {CustomInput} from "../../components/CustomInput";
import React from "react";

export function Available() {
    const [search, setSearch] = React.useState("");

    return (
        <>
            <div className="actionBar">
                <CustomInput value={search} onChange={setSearch} id="Name"/>
            </div>
            <div>

            </div>
        </>
    );
}
