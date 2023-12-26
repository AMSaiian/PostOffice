import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

export const Login = () => {
    const [phone, setPhone] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();
    const [errors, setErrors] = useState([]);

    const handleSubmit = (e) => {
        e.preventDefault();
        const login = 'https://localhost:7167/api/Auth';
        fetch(login, {
            method: "POST",
            headers: {
              Accept: "application/json, text/plain, */*",
              "Content-Type": "application/json",
            },
            body: JSON.stringify({
              phoneNumber: phone,
              password: password,
            }),
          })
            .then((response) => response.json())
            .then((data) => { 
              setPhone("");
              setPassword("");
      
              if (data.isSuccess) {
                const token = data.value;
                localStorage.setItem("token", JSON.stringify(token));

                if (data.value.role === "Operator") {
                    navigate("/operator");
                } else if (data.value.role === "Manager") {
                    navigate("/manager");
                } else if (data.value.role === "Admin") {
                    navigate("/admin");
                }
              } else {
                setErrors(data.errors);
              }
            })
            .catch((err) => {
              console.log(err);
             });
    }

    return (
        <main className="login-main">
          <div className="login-form-wraper">
            <form onSubmit={handleSubmit}>
                <h1>Login</h1>
                <div className="login-form-group">
                  <label htmlFor="phone-input">Phone number</label>
                  <input type="tel" className="login-form-control" id="phone-input" value={phone} onChange={(e) => setPhone(e.target.value)} placeholder="Your phone number" />
                </div>
                <div className="form-group"> 
                  <label htmlFor="password-input">Password</label>
                  <input type="password" className="login-form-control" id="password-input" value={password} onChange={(e) => setPassword(e.target.value)} placeholder="Your password" />
                </div>
                <button type="submit" onSubmit={(e) => handleSubmit(e)} className="buttons" id="login-buttons">Login</button>
            </form>
          </div>
          <div className="loginErrorWraper">
            {
              errors.map((element, idx) => {
                return <p key={"login-error-" + idx} className="login-error">{element}</p>
              })
            }
          </div>
        </main>
    )
}