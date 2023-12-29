import { useState } from "react";
import React from "react";
import "../style/newOperatorMain.css"

export const NewOperator = () => {
  const [operatorName, setOperatorName] = useState("");
  const [operatorSurname, setOperatorSurname] = useState("");
  const [operatorPhone, setOperatorPhone] = useState("+380");
  const [operatorPassword, setOperatorPassword] = useState("");
  const [operatorConfirmPassword, setOperatorConfirmPassword] = useState("");

  const [errors, setErrors] = useState([]);

  const handleSubmit = (e) => {
    e.preventDefault();
    const createNewOperator = 'https://localhost:7167/api/Auth/register';
    fetch(createNewOperator, {
      method: "POST",
      headers: {
        Accept: "application/json, text/plain, */*",
        "Content-Type": "application/json",
        Authorization: "Bearer " + JSON.parse(localStorage.getItem("token")).jwtToken
      },
      body: JSON.stringify({
        id: null,
        name: operatorName,
        surname: operatorSurname,
        phoneNumber: operatorPhone,
        password: operatorPassword,
        confirmPassword: operatorConfirmPassword,
        role: 2,
        postOfficeZip: JSON.parse(localStorage.getItem("token")).postOfficeZip
      }),
    })
      .then((response) => response.json())
      .then((data) => {
        if (data.isSuccess) {
          window.alert("New operator created!");
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
    <main className="new-operator-main">
      <form className="new-operator-form" onSubmit={handleSubmit}>
          <h1>New operator credits</h1>
          <div className="new-operator-form-control-wrappers" id="operator-name-wrapper">
            <label htmlFor="operator-name">Name</label>
            <input type="fname" className="operator-form-control" id="operator-name" value={operatorName} onChange={(e) => setOperatorName(e.target.value)} placeholder="Name" />
          </div>
          <div className="new-operator-form-control-wrappers" id="operator-surname-wrapper">
            <label htmlFor="operator-surname">Surname</label>
            <input type="lname" className="operator-form-control" id="operator-surname" value={operatorSurname} onChange={(e) => setOperatorSurname(e.target.value)} placeholder="Surname" />
          </div>
          <div className="new-operator-form-control-wrappers" id="operator-phone-wrapper">
            <label htmlFor="operator-phone">Phone number</label>
            <input type="tel" className="operator-form-control" id="operator-phone" value={operatorPhone} onChange={(e) => setOperatorPhone(e.target.value)} placeholder="Phone number" />
          </div>
        <div className="new-operator-form-control-wrappers" id="operator-password-wrapper">
          <label htmlFor="operator-password">Password</label>
          <input type="password" className="operator-form-control" id="operator-password" value={operatorPassword} onChange={(e) => setOperatorPassword(e.target.value)} placeholder="Password" />
        </div>
        <div className="new-operator-form-control-wrappers" id="operator-confirm-password-wrapper">
          <label htmlFor="operator-confirm-password">Confirm password</label>
          <input type="password" className="operator-form-control" id="operator-confirm-password" value={operatorConfirmPassword} onChange={(e) => setOperatorConfirmPassword(e.target.value)} placeholder="Confirm password" />
        </div>
          <div className="submit-new-operator-button-wrapper">
            <button type="submit" className="buttons" id="submit-new-operator" onSubmit={(e) => handleSubmit(e)}>Create</button>
          </div>
      </form>
      <div className="new-operator-error-wraper">
        {
          errors.map((element, idx) => {
            return <p key={"new-operator-error-" + idx} className="new-operator-error">{element}</p>
          })
        }
      </div>
    </main>
  )
}

export default NewOperator;