import { useEffect, useState } from "react";
import React from "react";
import "../style/allPostOfficesMain.css"

export const AllPostOffices = () => {
    const [postOffices, setPostOffices] = useState([]);

    useEffect(() => {
        const getPostOffices = 'https://localhost:7167/api/PostOffice';

        fetch(getPostOffices, {
            method: "GET",
            headers: {
                Accept: "application/json, text/plain, */*",
                "Content-Type": "application/json",
                Authorization: "Bearer " + JSON.parse(localStorage.getItem("token")).jwtToken,
            }
        })
            .then((response) => response.json())
            .then((data) => {
                setPostOffices(data.value);
            })
            .catch((err) => {
                console.log(err);
            });
    }, [])

    return (
        <main className="all-post-offices-main">
            <table>
                <thead>
                    <tr>
                        <th>Zip</th>
                        <th>City</th>
                        <th>Street</th>
                        <th>Building №</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        postOffices.map((element, idx) => (
                            <tr key={"post-office-row-" + idx}>
                                <td>{element.zip}</td>
                                <td>{element.location.city}</td>
                                <td>{element.location.street}</td>
                                <td>{element.location.buildingNumber}</td>
                            </tr>
                        ))
                    }
                </tbody>
            </table>
        </main>
    )
}