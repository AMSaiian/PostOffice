import React from 'react';
import { Navigate } from 'react-router-dom';

const PrivateRoute = ({ allowedRole, children }) => {
  const token = JSON.parse(localStorage.getItem("token"));
  const currentTime = new Date();
  let userRole;
  if (token == null) {
    userRole = "Unknown";
  }
  else if (new Date(token.expireTime) <= currentTime) {
    localStorage.removeItem("token");
    userRole = "Unknown";
  }
  else {
    userRole = token.role;
  }

  if (allowedRole === userRole) {
    return children;
  } else {
    if (userRole === "Admin") {
      return <Navigate to="/admin" />;
    } else if (userRole === "Manager") {
      return <Navigate to="/manager" />;
    } else if (userRole === "Operator") {
      return <Navigate to="/operator" />;
    } else
      return <Navigate to="/login" />;
  }
};

export default PrivateRoute;