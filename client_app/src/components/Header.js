import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

export const Header = ({names, paths, handler}) => {
    const navigate = useNavigate();
    return (
        <header>
            {
                names.map((element, idx) => {
                    return <span key={element} onClick={() => navigate(paths[idx])}>{element}</span>
                })
            }
        </header>
    )
}