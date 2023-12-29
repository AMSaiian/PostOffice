import { useEffect, useState } from "react";
import React from "react";
import "../style/newPostOfficeMain.css"

export const NewPostOffice = () => {
    const [postOfficeZip, setPostOfficeZip] = useState("");
    const [postOfficeCity, setPostOfficeCity] = useState("");
    const [postOfficeStreet, setPostOfficeStreet] = useState("");
    const [postOfficeBuilding, setPostOfficeBuilding] = useState("");

    const [errors, setErrors] = useState([]);

    const handleSubmit = (e) => {
        e.preventDefault();
        const createNewPostOffice = 'https://localhost:7167/api/PostOffice';
        fetch(createNewPostOffice, {
            method: "POST",
            headers: {
                Accept: "application/json, text/plain, */*",
                "Content-Type": "application/json",
                Authorization: "Bearer " + JSON.parse(localStorage.getItem("token")).jwtToken
            },
            body: JSON.stringify({
                id: null,
                zip: postOfficeZip,
                location: {
                    city: postOfficeCity,
                    street: postOfficeStreet,
                    buildingNumber: postOfficeBuilding
                }
            }),
        })
            .then((response) => response.json())
            .then((data) => {
                if (data.isSuccess) {
                    window.alert("New post office created!");
                    window.location.reload(false);
                } else {
                    setErrors(data.errors);
                }
            })
            .catch((err) => {
                console.log(err);
            });
    }

    return (        
        <main className="new-post-office-main">
            <form className="new-post-office-form" onSubmit={handleSubmit}>
                <h1>New post office credits</h1>
                <div className="new-post-office-form-control-wrappers" id="post-office-zip-wrapper">
                    <label htmlFor="post-office-zip">Post office zip</label>
                    <input type="text" className="post-office-form-control" id="post-office-zip" value={postOfficeZip} onChange={(e) => setPostOfficeZip(e.target.value)} placeholder="Zip" />
                </div>
                <div className="new-post-office-form-control-wrappers" id="post-office-city-wrapper">
                    <label htmlFor="post-office-city">City</label>
                    <input type="text" className="post-office-form-control" id="post-office-city" value={postOfficeCity} onChange={(e) => setPostOfficeCity(e.target.value)} placeholder="City" />
                </div>
                <div className="new-post-office-form-control-wrappers" id="post-office-street-wrapper">
                    <label htmlFor="post-office-street">Street</label>
                    <input type="text" className="post-office-form-control" id="post-office-street" value={postOfficeStreet} onChange={(e) => setPostOfficeStreet(e.target.value)} placeholder="Street" />
                </div>
                <div className="new-post-office-form-control-wrappers" id="post-office-building-wrapper">
                    <label htmlFor="post-office-building">Building number</label>
                    <input type="text" className="post-office-form-control" id="post-office-building" value={postOfficeBuilding} onChange={(e) => setPostOfficeBuilding(e.target.value)} placeholder="Building №" />
                </div>
                <div className="submit-new-post-office-button-wrapper">
                    <button type="submit" className="buttons" id="submit-new-post-office" onSubmit={(e) => handleSubmit(e)}>Create</button>
                </div>
            </form>
            <div className="new-post-office-error-wraper">
                {
                    errors.map((element, idx) => {
                        return <p key={"new-post-office-error-" + idx} className="new-post-office-error">{element}</p>
                    })
                }
            </div>
        </main>
    )
}