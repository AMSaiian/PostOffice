import { useEffect, useState } from "react";
import React from "react";
import "../style/allOperatorsMain.css"

export const AllOperators = () => {
  const [officeOperators, setOfficeOperators] = useState([]);

  useEffect(() => {
    const postOfficeZip = JSON.parse(localStorage.getItem("token")).postOfficeZip;
    const getOperators = 'https://localhost:7167/api/Staff?' + new URLSearchParams({
      role: 2,
      zip: postOfficeZip,
    });
    fetch(getOperators, {
      method: "GET",
      headers: {
        Accept: "application/json, text/plain, */*",
        "Content-Type": "application/json",
        Authorization: "Bearer " + JSON.parse(localStorage.getItem("token")).jwtToken,
      }
    })
      .then((response) => response.json())
      .then((data) => {
        setOfficeOperators(data.value);
      })
      .catch((err) => {
        console.log(err);
      });
  }, [])

  const handleDelete = (e, idx) => {
    e.preventDefault();
    const operator = officeOperators[idx];
    const deleteOperator = 'https://localhost:7167/api/Staff/' + operator.id;

    fetch(deleteOperator, {
      method: "DELETE",
      headers: {
        Accept: "application/json, text/plain, */*",
        "Content-Type": "application/json",
        Authorization: "Bearer " + JSON.parse(localStorage.getItem("token")).jwtToken,
      },
    })
      .then((response) => response.json())
      .then((data) => {
        if (data.isSuccess) {
          setOfficeOperators((prev) => prev.filter((_, index) => index !== idx));
          window.alert("Operator deleted!")
        }
      })
      .catch((err) => {
        console.log(err);
      });
  }

  return (
    <main className="all-operators-main">
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Surname</th>
            <th>Phone number</th>
            <th>Delete operator</th>
          </tr>
        </thead>
        <tbody>
          {
            officeOperators.map((element, idx) => (
              <tr key={"operator-row-" + idx}>
                <td>{element.name}</td>
                <td>{element.surname}</td>
                <td>{element.phoneNumber}</td>
                <td>
                  <button className="delete-operator-buttons" onClick={(e) => handleDelete(e, idx)}>
                    ✖
                  </button>
                </td>
              </tr>
            ))
          }
        </tbody>
      </table>
    </main>
  )
}

export default AllOperators;