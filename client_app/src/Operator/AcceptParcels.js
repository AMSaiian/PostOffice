import { useEffect, useState } from "react";
import React from "react";
import "../style/acceptParcelMain.css"

export const AcceptParcels = () => {
    const [receivedParcels, setReceivedParcels] = useState([]);

    useEffect(() => {
        const postOfficeZip = JSON.parse(localStorage.getItem("token")).postOfficeZip;
        const getReceivedParcels = 'https://localhost:7167/api/ParcelManagement/arrivedParcels/' + postOfficeZip;
        fetch(getReceivedParcels, {
            method: "GET",
            headers: {
                Accept: "application/json, text/plain, */*",
                "Content-Type": "application/json",
                Authorization: "Bearer " + JSON.parse(localStorage.getItem("token")).jwtToken,
            }
        })
            .then((response) => response.json())
            .then((data) => {
                console.log(data);
                setReceivedParcels(data.value);
            })
            .catch((err) => {
                console.log(err);
            });
    }, [])

    const handleAcceptReceiving = (e, idx) => {
        e.preventDefault();
        const status = 5;
        const parcel = receivedParcels[idx];
        const changeParcelStatus = 'https://localhost:7167/api/ParcelManagement/changeStatus';
        const body = {
            id: null,
            status: status,
            changesTime: new Date().toISOString(),
            parcelId: parcel.id,
        }

        fetch(changeParcelStatus, {
            method: "PUT",
            headers: {
                Accept: "application/json, text/plain, */*",
                "Content-Type": "application/json",
                Authorization: "Bearer " + JSON.parse(localStorage.getItem("token")).jwtToken,
            },
            body: JSON.stringify(body),
        })
            .then((response) => response.json())
            .then((data) => {
                if (data.isSuccess) {
                    setReceivedParcels((prev) => prev.filter((_, index) => index !== idx));
                    window.alert("Parcel arrivement accepted!")
                }
            })
            .catch((err) => {
                console.log(err);
            });
    }
    
    return (
        <main className="accept-parcels-main">
            <table>
                <thead>
                    <tr>
                        <th>Shipping №</th>
                        <th>City from</th>
                        <th>Post zip from</th>
                        <th>Accept receiving</th>
                    </tr>
                </thead>
                <tbody>
                    {
                    receivedParcels.map((element, idx) => (
                        <tr key={"received-parcel-row-" + idx}>
                            <td>{element.id}</td>
                            <td>{element.cityFrom}</td>
                            <td>{element.zipFrom}</td>
                            <td>
                                <button className="accept-receiving-buttons" onClick={(e) => handleAcceptReceiving(e, idx)}>
                                    ✔
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