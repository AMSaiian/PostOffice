import { useEffect, useState } from "react";
import React from "react";
import "../style/allManagersMain.css"

export const AllManagers = () => {
    const [officeManagers, setOfficeManagers] = useState([]);

    useEffect(() => {
        const getManagers = 'https://localhost:7167/api/Staff?' + new URLSearchParams({
            role: 1,
        });
        fetch(getManagers, {
            method: "GET",
            headers: {
                Accept: "application/json, text/plain, */*",
                "Content-Type": "application/json",
                Authorization: "Bearer " + JSON.parse(localStorage.getItem("token")).jwtToken,
            }
        })
            .then((response) => response.json())
            .then((data) => {
                setOfficeManagers(data.value);
            })
            .catch((err) => {
                console.log(err);
            });
    }, [])

    const handleDelete = (e, idx) => {
        e.preventDefault();
        const manager = officeManagers[idx];
        const deleteManager = 'https://localhost:7167/api/Staff/' + manager.id;

        fetch(deleteManager, {
            method: "DELETE",
            headers: {
                Accept: "application/json, text/plain, */*",
                "Content-Type": "application/json",
                Authorization: "Bearer " + JSON.parse(localStorage.getItem("token")).jwtToken,
            },
        })
            .then((response) => response.json())
            .then((data) => {
                if (data.isSuccess) {
                    setOfficeManagers((prev) => prev.filter((_, index) => index !== idx));
                    window.alert("Manager deleted!")
                }
            })
            .catch((err) => {
                console.log(err);
            });
    }

    return (
        <main className="all-Managers-main">
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Surname</th>
                        <th>Phone number</th>
                        <th>Post office zip</th>
                        <th>Delete manager</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        officeManagers.map((element, idx) => (
                            <tr key={"manager-row-" + idx}>
                                <td>{element.name}</td>
                                <td>{element.surname}</td>
                                <td>{element.phoneNumber}</td>
                                <td>{element.zip}</td>
                                <td>
                                    <button className="delete-manager-buttons" onClick={(e) => handleDelete(e, idx)}>
                                        ✖
                                    </button>
                                </td>
                            </tr>
                        ))
                    }
                </tbody>
            </table>
        </main>
    )
}

export default AllManagers;