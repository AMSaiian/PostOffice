import { useState } from "react"
import Select from 'react-select';

export const NewParcel = () => {
  const dropDownOptions = [
    { value: 'Canned food', label: 'Canned food' },
    { value: 'Electronics', label: 'Electronics' },
    { value: 'Other', label: 'Other' },
  ];

  const [senderName, setSenderName] = useState("");
  const [senderSurname, setSenderSurname] = useState("");
  const [senderPhone, setSenderPhone] = useState("+380");

  const [receiverName, setReceiverName] = useState("");
  const [receiverSurname, setReceiverSurname] = useState("");
  const [receiverPhone, setReceiverPhone] = useState("+380");

  const [description, setDescription] = useState("");
  const [itemCategory, setItemCategory] = useState("");

  const [width, setWidth] = useState();
  const [height, setHeight] = useState();
  const [depth, setDepth] = useState();
  const [weight, setWeight] = useState();

  return (        
    <main className="new-parcel-main">
      <form className="new-parcel-form">
        
        <div className="sender-part-wrapper">
          <h1>Sender</h1>
          <div className="sender-name-wrapper">
            <label htmlFor="sender-name">Name</label>
            <input type="fname" className="sender-form-control" id="sender-name" value={senderName} onChange={(e) => setSenderName(e.target.value)} placeholder="Name" />
          </div>
          <div className="sender-surname-wrapper">
            <label htmlFor="sender-surname">Surname</label>
            <input type="lname" className="sender-form-control" id="sender-surname" value={senderSurname} onChange={(e) => setSenderSurname(e.target.value)} placeholder="Surname" />
          </div>
          <div className="sender-phone-wrapper">
            <label htmlFor="sender-phone">Phone number</label>
            <input type="tel" className="sender-form-control" id="sender-phone" value={senderPhone} onChange={(e) => setSenderPhone(e.target.value)} placeholder="Phone number" />
          </div>
        </div>

        <div className="parcel-item-wrapper">
          <div className="item-category-wrapper">
            <Select
              defaultValue={itemCategory}
              onChange={setItemCategory}
              options={dropDownOptions}
            />
          </div>
          <div className="description-wrapper">
            <label htmlFor="description">Description</label>
            <input type="text" className="parcel-item-form-control" id="description" value={description} onChange={(e) => setDescription(e.target.value)} placeholder="Description" />
          </div>
          <div className="width-wrapper">
            <label htmlFor="width">Width</label>
            <input type="number" className="parcel-item-form-control" id="width" value={width} onChange={(e) => setWidth(e.target.value)} placeholder="mm" />
          </div>
          <div className="height-wrapper">
            <label htmlFor="height">Height</label>
            <input type="number" className="parcel-item-form-control" id="height" value={height} onChange={(e) => setHeight(e.target.value)} placeholder="mm" />
          </div>
          <div className="depth-wrapper">
            <label htmlFor="depth">Depth</label>
            <input type="number" className="parcel-item-form-control" id="depth" value={depth} onChange={(e) => setDepth(e.target.value)} placeholder="mm" />
          </div>
          <div className="weight-wrapper">
            <label htmlFor="weight">Weight</label>
            <input type="number" className="parcel-item-form-control" id="weight" value={weight} onChange={(e) => setWeight(e.target.value)} placeholder="g" />
          </div>
        </div>
        
        <div className="receiver-part-wrapper">
          <h1>Receiver</h1>
          <div className="receiver-name-wrapper">
            <label htmlFor="receiver-name">Name</label>
            <input type="fname" className="receiver-form-control" id="receiver-name" value={receiverName} onChange={(e) => setReceiverName(e.target.value)} placeholder="Name" />
          </div>
          <div className="receiver-surname-wrapper">
            <label htmlFor="receiver-surname">Surname</label>
            <input type="lname" className="receiver-form-control" id="receiver-surname" value={receiverSurname} onChange={(e) => setReceiverSurname(e.target.value)} placeholder="Surname" />
          </div>
          <div className="receiver-phone-wrapper">
            <label htmlFor="receiver-phone">Phone number</label>
            <input type="tel" className="receiver-form-control" id="receiver-phone" value={receiverPhone} onChange={(e) => setReceiverPhone(e.target.value)} placeholder="Phone number" />
          </div>
        </div>

      </form>
    </main>
  )
}