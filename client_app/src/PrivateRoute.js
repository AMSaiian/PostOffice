import React from 'react';
import { Navigate } from 'react-router-dom';

const PrivateRoute = ({ allowedRole, children }) => {
  const token = JSON.parse(localStorage.getItem("token"));
  const currentTime = new Date();
  let userRole;
  if (token == null) {
    userRole = -1;
  }
  else if (new Date(token.expireTime) <= currentTime) {
    localStorage.removeItem("token");
    userRole = -1;
  }
  else {
    userRole = token.role;
  }

  if (allowedRole === userRole) {
    return children;
  } else {
    if (userRole === 0) {
      return <Navigate to="/admin" />;
    } else if (userRole === 1) {
      return <Navigate to="/manager" />;
    } else if (userRole === 2) {
      return <Navigate to="/operator" />;
    } else
      return <Navigate to="/login" />;
  }
};

export default PrivateRoute;