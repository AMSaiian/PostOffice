import { useState } from "react"

export const NewParcel = () => {
    const [senderName, setSenderName] = useState("");
    const [senderSurname, setSenderSurname] = useState("");
    const [senderPhone, setSenderPhone] = useState("+380");

    const [receiverName, setReceiverName] = useState("");
    const [receiverSurname, setReceiverSurname] = useState("");
    const [receiverPhone, setReceiverPhone] = useState("+380");

    return (        
        <main className="new-parcel-main">
          <div className="sender-part-wrapper">
            <form className="sender-credits-form">
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
            </form>
          </div>
          <div className="receiver-part-wrapper">
            <form className="receiver-credits-form">
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
            </form>
          </div>
        </main>
    )
}