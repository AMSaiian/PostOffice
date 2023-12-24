import React, { useState } from "react"

export const Login = () => {
    const [phone, setPhone] = useState("");
    const [password, setPassword] = useState("");

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
            .then((data) => console.log(data))
            .catch((err) => {
              console.log(err);
             });
    }

    return (
        <form onSubmit={handleSubmit}> 
            <label for="phone">Phone number</label>
            <input value={phone} onChange={(e) => setPhone(e.target.value)} type="tel" placeholder="Your phone number" name="phone"/>
            <label for="password">Password</label>
            <input value={password} onChange={(e) => setPassword(e.target.value)} type="password" placeholder="Your password" name="password"/>
            <button type="submit">Login</button>
        </form>
    )
}