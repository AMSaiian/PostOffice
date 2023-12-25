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

                if (data.value.role === 2) {
                    navigate("/operator");
                } else if (data.value.role === 1) {
                    navigate("/manager");
                } else if (data.value.role === 0) {
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
        <form onSubmit={handleSubmit}>
            <h1>Login</h1>
            <div className="form-group">
              <label htmlFor="phone-input">Phone number</label>
              <input type="tel" className="form-control" id="phone-input" value={phone} onChange={(e) => setPhone(e.target.value)} placeholder="Your phone number" />
            </div>
            <div className="form-group"> 
              <label htmlFor="password-input">Password</label>
              <input type="password" className="form-control" id="password-input" value={password} onChange={(e) => setPassword(e.target.value)} placeholder="Your password" />
            </div>
            <button type="submit" className="btn btn-primary">Login</button>
            <div>
              {
              errors.map((element, idx) => {
                return <p key={idx}>{element}</p>
              })
              }
            </div>
        </form>
    )
}