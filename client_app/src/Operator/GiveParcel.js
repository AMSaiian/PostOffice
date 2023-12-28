import { useEffect, useState } from "react";
import React from "react";
import Select from 'react-select';
import '../style/giveParcelMain.css';

export const GiveParcel = () => {
    const [receiverName, setReceiverName] = useState("");
    const [receiverSurname, setReceiverSurname] = useState("");
    const [receiverPhone, setReceiverPhone] = useState("+380");

    const [gotParcelsDropDownOptions, setGotParcelsDropDownOptions] = useState([]);

    const defaultParcelState = {
        id: null,
        name: "",
        surname: "",
        phoneNumber: "",
        gabarites: {
            width: 0,
            height: 0,
            weight: 0,
            depth: 0
        }
    }

    const [chosenParcel, setChosenParcel] = useState(defaultParcelState);

    const [category, setCategory] = useState("");
    const [description, setDescription] = useState("");
    const [width, setWidth] = useState();
    const [height, setHeight] = useState();
    const [depth, setDepth] = useState();
    const [weight, setWeight] = useState();

    const [output, setOutput] = useState([]);

    const [showParcelPart, setShowParcelPart] = useState(false);

    const handleGetParcels = (e) => {
        e.preventDefault();
        const getClientParcels = 'https://localhost:7167/api/ParcelManagement/clientArrivedParcels/' + JSON.parse(localStorage.getItem("token")).postOfficeZip;
        fetch(getClientParcels, {
            method: "POST",
            headers: {
                Accept: "application/json, text/plain, */*",
                "Content-Type": "application/json",
                Authorization: "Bearer " + JSON.parse(localStorage.getItem("token")).jwtToken,
            },
            body: JSON.stringify({
                id: null,
                name: receiverName,
                surname: receiverSurname,
                phoneNumber: receiverPhone
            }),
        })
            .then((response) => response.json())
            .then((data) => {
                if (data.isSuccess) {
                    setGotParcelsDropDownOptions(data.value.map((element) => {
                        return { value: element, label: element.id }
                    }))
                    setShowParcelPart(true);
                    setOutput([]);
                } else {
                    setShowParcelPart(false);
                    handleChoseParcel({value: defaultParcelState});
                    setOutput(data.errors);
                }
            })
            .catch((err) => {
                console.log(err);
            });
    }

    const handleChoseParcel = (item) => {
        setChosenParcel(item.value);
        setDescription(item.value.itemDescription);
        setCategory(item.value.itemCategory);
        setWidth(item.value.gabarites.width);
        setHeight(item.value.gabarites.height);
        setDepth(item.value.gabarites.depth);
        setWeight(item.value.gabarites.weight * 1000);
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        const status = 6;
        const changeParcelStatus = 'https://localhost:7167/api/ParcelManagement/changeStatus';
        const body = {
            id: null,
            status: status,
            changesTime: new Date().toISOString(),
            parcelId: chosenParcel.id,
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
                    window.alert("Parcel granted!")
                    window.location.reload(false);
                } else {
                    setOutput(data.errors);
                }
            })
            .catch((err) => {
                console.log(err);
            });
        
    }
    
    return (
        <main className="give-parcel-main">
            <form className="give-parcel-form" onSubmit={handleSubmit}>        
                <div className="receiver-part-wrapper">
                    <h1>Receiver</h1>
                    <div className="give-parcel-form-control-wrappers" id="receiver-name-wrapper">
                        <label htmlFor="receiver-name">Name</label>
                        <input type="fname" className="receiver-form-control" id="receiver-name" value={receiverName} onChange={(e) => setReceiverName(e.target.value)} placeholder="Name" />
                    </div>
                    <div className="give-parcel-form-control-wrappers" id="receiver-surname-wrapper">
                        <label htmlFor="receiver-surname">Surname</label>
                        <input type="lname" className="receiver-form-control" id="receiver-surname" value={receiverSurname} onChange={(e) => setReceiverSurname(e.target.value)} placeholder="Surname" />
                    </div>
                    <div className="give-parcel-form-control-wrappers" id="receiver-phone-wrapper">
                        <label htmlFor="receiver-phone">Phone number</label>
                        <input type="tel" className="receiver-form-control" id="receiver-phone" value={receiverPhone} onChange={(e) => setReceiverPhone(e.target.value)} placeholder="Phone number" />
                    </div>
                    <div className="get-parcels-button-wrapper">
                        <button type="submit" className="buttons" id="submit-get-parcels" onClick={(e) => handleGetParcels(e)}>Get parcels</button>
                    </div>
                </div>

                <div className="grant-parcels-wrapper">
                    { showParcelPart ? 
                    <><div className="parcel-wrapper">
                            <h1>Item</h1>
                            <div className="give-parcel-form-control-wrappers" id="parcel-id-wrapper">
                                <label htmlFor="parcel-id">Parcel number</label>
                                <Select
                                    className="parcel-item-form-control-1"
                                    name="parcel-id"
                                    onChange={item => handleChoseParcel(item)}
                                    options={gotParcelsDropDownOptions} />
                            </div>
                            <div className="give-parcel-form-control-wrappers" id="category-wrapper">
                                <label htmlFor="category">Category</label>
                                <input type="text" className="parcel-item-form-control" id="category" value={category} readOnly placeholder="Category" />
                            </div>
                            <div className="give-parcel-form-control-wrappers" id="description-wrapper">
                                <label htmlFor="description">Description</label>
                                <input type="text" className="parcel-item-form-control" id="description" value={description} readOnly placeholder="Description" />
                            </div>
                        </div><div className="parcel-char-wrapper">
                                <h1>Characteristics</h1>
                                <div className="give-parcel-form-control-wrappers" id="width-wrapper">
                                    <label htmlFor="width">Width</label>
                                    <input type="number" className="parcel-item-form-control" id="width" value={width} readOnly placeholder="mm" />
                                </div>
                                <div className="give-parcel-form-control-wrappers" id="height-wrapper">
                                    <label htmlFor="height">Height</label>
                                    <input type="number" className="parcel-item-form-control" id="height" value={height} readOnly placeholder="mm" />
                                </div>
                                <div className="give-parcel-form-control-wrappers" id="depth-wrapper">
                                    <label htmlFor="depth">Depth</label>
                                    <input type="number" className="parcel-item-form-control" id="depth" value={depth} readOnly placeholder="mm" />
                                </div>
                                <div className="give-parcel-form-control-wrappers" id="weight-wrapper">
                                    <label htmlFor="weight">Weight</label>
                                    <input type="number" className="parcel-item-form-control" id="weight" value={weight} readOnly placeholder="g" />
                                </div>
                                <div className="give-parcel-button-wrapper">
                                    <button type="submit" className="buttons" id="submit-give-parcel" onSubmit={(e) => handleSubmit(e)}>Accept</button>
                                </div>
                            </div></>
                    : null }
                </div>
            </form >
            <div className="get-parcel-output-wraper">
                {
                    output.map((element, idx) => {
                        return <p key={"give-parcel-output-" + idx} className="give-parcel-output">{element}</p>
                    })
                }
            </div>
        </main>
    )
}