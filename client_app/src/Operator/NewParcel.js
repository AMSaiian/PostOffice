import { useEffect, useState, useRef } from "react";
import React from "react";
import Select from 'react-select';
import '../style/newParcelMain.css';

export const NewParcel = () => {
  const [categoryDropDownOptions, setCategoryDropDownOptions] = useState([]); 
  const [postOfficesDropDownOptions, setPostOfficeDropDownOptions] = useState([]); 

  const [senderName, setSenderName] = useState("");
  const [senderSurname, setSenderSurname] = useState("");
  const [senderPhone, setSenderPhone] = useState("+380");

  const [receiverName, setReceiverName] = useState("");
  const [receiverSurname, setReceiverSurname] = useState("");
  const [receiverPhone, setReceiverPhone] = useState("+380");

  const [receiverZip, setReceiverZip] = useState("");

  const [description, setDescription] = useState("");
  const [itemCategoryId, setItemCategoryId] = useState(null);

  const [width, setWidth] = useState();
  const [height, setHeight] = useState();
  const [depth, setDepth] = useState();
  const [weight, setWeight] = useState();

  const [output, setOutput] = useState([]);

  useEffect(() => {
    const getCategories = 'https://localhost:7167/api/ItemCategory';
    fetch(getCategories, {
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
        setCategoryDropDownOptions(data.value.map(element => {
          return {value: element.id, label: element.name}
        }))
      })
      .catch((err) => {
        console.log(err);
      });

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
        console.log(data);
        setPostOfficeDropDownOptions(data.value
          .filter(element => element.zip !== JSON.parse(localStorage.getItem("token")).postOfficeZip)
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
    const createNewParcel = 'https://localhost:7167/api/ParcelManagement';
    fetch(createNewParcel, {
      method: "POST",
      headers: {
        Accept: "application/json, text/plain, */*",
        "Content-Type": "application/json",
        Authorization: "Bearer " + JSON.parse(localStorage.getItem("token")).jwtToken
      },
      body: JSON.stringify({
        sender: {
          id: null,
          name: senderName,
          surname: senderSurname,
          phoneNumber: senderPhone
        },
        receiver: {
          id: null,
          name: receiverName,
          surname: receiverSurname,
          phoneNumber: receiverPhone
        },
        officeFrom: {
          id: null,
          zip: JSON.parse(localStorage.getItem("token")).postOfficeZip,
          location: null
        },
        officeTo: {
          id: null,
          zip: receiverZip,
          location: null
        },
        items: [
          {
            id: null,
            description: description,
            characteristics: {
              width: width === "" ? undefined : width,
              height: height === "" ? undefined : height,
              depth: depth === "" ? undefined : depth,
              weight: weight === "" ? undefined : weight / 1000,
            },
            itemCategoryId: itemCategoryId
          }
        ]
      }),
    })
      .then((response) => response.json())
      .then((data) => {
        if (data.isSuccess) {
          window.alert("Parcel created!");
          window.location.reload(false);
          // setSenderName("");
          // setSenderSurname("");
          // setSenderPhone("+380");

          // setReceiverName("");
          // setReceiverSurname("");
          // setReceiverPhone("+380");

          // setDescription("");

          // setWidth(0);
          // setHeight(0);
          // setDepth(0);
          // setWeight(0);
          
        } else {
          setOutput(data.errors);
        }
      })
      .catch((err) => {
        console.log(err);
      });
  }

  return (        
    <main className="new-parcel-main">
      <form className="new-parcel-form" onSubmit={handleSubmit}>
        
        <div className="sender-part-wrapper">
          <h1>Sender</h1>
          <div className="new-parcel-form-control-wrappers" id="sender-name-wrapper">
            <label htmlFor="sender-name">Name</label>
            <input type="fname" className="sender-form-control" id="sender-name" value={senderName} onChange={(e) => setSenderName(e.target.value)} placeholder="Name" />
          </div>
          <div className="new-parcel-form-control-wrappers" id="sender-surname-wrapper">
            <label htmlFor="sender-surname">Surname</label>
            <input type="lname" className="sender-form-control" id="sender-surname" value={senderSurname} onChange={(e) => setSenderSurname(e.target.value)} placeholder="Surname" />
          </div>
          <div className="new-parcel-form-control-wrappers" id="sender-phone-wrapper">
            <label htmlFor="sender-phone">Phone number</label>
            <input type="tel" className="sender-form-control" id="sender-phone" value={senderPhone} onChange={(e) => setSenderPhone(e.target.value)} placeholder="Phone number" />
          </div>
        </div>
        
        <div className="parcel-item-wrapper">
          <h1>Item</h1>
          <div className="new-parcel-form-control-wrappers" id="item-category-wrapper">
            <label htmlFor="item-category">Category</label>
            <Select
              className="parcel-item-form-control-1"
              name="item-category"
              defaultValue={itemCategoryId}
              onChange={item => setItemCategoryId(item.value)}
              options={categoryDropDownOptions}
            />
          </div>
          <div className="new-parcel-form-control-wrappers" id="description-wrapper">
            <label htmlFor="description">Description</label>
            <input type="text" className="parcel-item-form-control" id="description" value={description} onChange={(e) => setDescription(e.target.value)} placeholder="Description" />
          </div>
        </div>
        <div className="parcel-char-wrapper">
          <h1>Characteristics</h1>
          <div className="new-parcel-form-control-wrappers" id="width-wrapper">
            <label htmlFor="width">Width</label>
            <input type="number" className="parcel-item-form-control" id="width" value={width} onChange={(e) => setWidth(e.target.value)} placeholder="mm" />
          </div>
          <div className="new-parcel-form-control-wrappers" id="height-wrapper">
            <label htmlFor="height">Height</label>
            <input type="number" className="parcel-item-form-control" id="height" value={height} onChange={(e) => setHeight(e.target.value)} placeholder="mm" />
          </div>
          <div className="new-parcel-form-control-wrappers" id="depth-wrapper">
            <label htmlFor="depth">Depth</label>
            <input type="number" className="parcel-item-form-control" id="depth" value={depth} onChange={(e) => setDepth(e.target.value)} placeholder="mm" />
          </div>
          <div className="new-parcel-form-control-wrappers" id="weight-wrapper">
            <label htmlFor="weight">Weight</label>
            <input type="number" className="parcel-item-form-control" id="weight" value={weight} onChange={(e) => setWeight(e.target.value)} placeholder="g" />
          </div>
        </div>
        <div className="receiver-part-wrapper">
          <h1>Receiver</h1>
          <div className="new-parcel-form-control-wrappers" id="receiver-name-wrapper">
            <label htmlFor="receiver-name">Name</label>
            <input type="fname" className="receiver-form-control" id="receiver-name" value={receiverName} onChange={(e) => setReceiverName(e.target.value)} placeholder="Name" />
          </div>
          <div className="new-parcel-form-control-wrappers" id="receiver-surname-wrapper">
            <label htmlFor="receiver-surname">Surname</label>
            <input type="lname" className="receiver-form-control" id="receiver-surname" value={receiverSurname} onChange={(e) => setReceiverSurname(e.target.value)} placeholder="Surname" />
          </div>
          <div className="new-parcel-form-control-wrappers" id="receiver-phone-wrapper">
            <label htmlFor="receiver-phone">Phone number</label>
            <input type="tel" className="receiver-form-control" id="receiver-phone" value={receiverPhone} onChange={(e) => setReceiverPhone(e.target.value)} placeholder="Phone number" />
          </div>
          <div className="new-parcel-form-control-wrappers" id="receiver-zip-wrapper">
            <label htmlFor="receiver-zip">Receiver zip</label>
            <Select
              className="parcel-item-form-control-1"
              name="receiver-zip"
              defaultValue={receiverZip}
              onChange={item => setReceiverZip(item.value)}
              options={postOfficesDropDownOptions}
            />
          </div>
          <div className="new-parcel-button-wrapper">
            <button type="submit" className="buttons" id="submit-new-parcel" onSubmit={(e) => handleSubmit(e)}>Accept</button>
          </div>
        </div>

      </form>
      <div className="new-parcel-output-wraper">
        {
          output.map((element, idx) => {
            return <p key={"new-parcel-output-" + idx} className="new-parcel-output">{element}</p>
          })
        }
      </div>
    </main>
  )
}