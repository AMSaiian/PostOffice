import { useState, useEffect } from "react";
import React from "react";
import Select from 'react-select';
import "../style/newManagerMain.css"

export const NewPostOfficeManager = () => {
    const [managerName, setmanagerName] = useState("");
    const [managerSurname, setmanagerSurname] = useState("");
    const [managerPhone, setmanagerPhone] = useState("+380");
    const [managerPassword, setmanagerPassword] = useState("");
    const [managerConfirmPassword, setmanagerConfirmPassword] = useState("");
    const [managerZip, setManagerZip] = useState("");

    const [postOfficesDropDownOptions, setPostOfficeDropDownOptions] = useState([]); 

    const [errors, setErrors] = useState([]);

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
                setPostOfficeDropDownOptions(data.value
                    .map(element => {
                        return { value: element.zip, label: element.zip }
                    }))
            })
            .catch((err) => {
                console.log(err);
            });
    }, []) 
    
    const handleSubmit = (e) => {
        e.preventDefault();
        const createNewmanager = 'https://localhost:7167/api/Auth/register';
        fetch(createNewmanager, {
            method: "POST",
            headers: {
                Accept: "application/json, text/plain, */*",
                "Content-Type": "application/json",
                Authorization: "Bearer " + JSON.parse(localStorage.getItem("token")).jwtToken
            },
            body: JSON.stringify({
                id: null,
                name: managerName,
                surname: managerSurname,
                phoneNumber: managerPhone,
                password: managerPassword,
                confirmPassword: managerConfirmPassword,
                role: 1,
                postOfficeZip: managerZip
            }),
        })
            .then((response) => response.json())
            .then((data) => {
                if (data.isSuccess) {
                    window.alert("New manager created!");
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
        <main className="new-manager-main">
            <form className="new-manager-form" onSubmit={handleSubmit}>
                <h1>New manager credits</h1>
                <div className="new-manager-form-control-wrappers" id="manager-name-wrapper">
                    <label htmlFor="manager-name">Name</label>
                    <input type="fname" className="manager-form-control" id="manager-name" value={managerName} onChange={(e) => setmanagerName(e.target.value)} placeholder="Name" />
                </div>
                <div className="new-manager-form-control-wrappers" id="manager-surname-wrapper">
                    <label htmlFor="manager-surname">Surname</label>
                    <input type="lname" className="manager-form-control" id="manager-surname" value={managerSurname} onChange={(e) => setmanagerSurname(e.target.value)} placeholder="Surname" />
                </div>
                <div className="new-manager-form-control-wrappers" id="manager-phone-wrapper">
                    <label htmlFor="manager-phone">Phone number</label>
                    <input type="tel" className="manager-form-control" id="manager-phone" value={managerPhone} onChange={(e) => setmanagerPhone(e.target.value)} placeholder="Phone number" />
                </div>
                <div className="new-manager-form-control-wrappers" id="manager-zip-wrapper">
                    <label htmlFor="manager-zip">Post office zip</label>
                    <Select
                        className="manager-form-control-1"
                        name="manager-zip"
                        defaultValue={managerZip}
                        onChange={item => setManagerZip(item.value)}
                        options={postOfficesDropDownOptions}
                    />
                </div>
                <div className="new-manager-form-control-wrappers" id="manager-password-wrapper">
                    <label htmlFor="manager-password">Password</label>
                    <input type="password" className="manager-form-control" id="manager-password" value={managerPassword} onChange={(e) => setmanagerPassword(e.target.value)} placeholder="Password" />
                </div>
                <div className="new-manager-form-control-wrappers" id="manager-confirm-password-wrapper">
                    <label htmlFor="manager-confirm-password">Confirm password</label>
                    <input type="password" className="manager-form-control" id="manager-confirm-password" value={managerConfirmPassword} onChange={(e) => setmanagerConfirmPassword(e.target.value)} placeholder="Confirm password" />
                </div>
                <div className="submit-new-manager-button-wrapper">
                    <button type="submit" className="buttons" id="submit-new-manager" onSubmit={(e) => handleSubmit(e)}>Create</button>
                </div>
            </form>
            <div className="new-manager-error-wraper">
                {
                    errors.map((element, idx) => {
                        return <p key={"new-manager-error-" + idx} className="new-manager-error">{element}</p>
                    })
                }
            </div>
        </main>
    )
}

export default NewPostOfficeManager;