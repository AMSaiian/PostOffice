import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import signOut from "../SignOut";

export const Header = ({names, paths}) => {
    const navigate = useNavigate();
    return (
        <header>
            <div className="header-tabs-part">
            {
                names.map((element, idx) => {
                    return <button className="headers-tabs" key={"tab-" + idx} onClick={(e) => {
                        e.preventDefault();
                        navigate(paths[idx]);
                    }} >{element}</button>
                })
            }
            </div>
            <div className="header-signOut=part">
                <button className="header-signout" onClick={(e) => signOut(e, navigate)}>Sign out</button>
            </div>
        </header>
    )
}