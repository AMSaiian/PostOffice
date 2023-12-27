import './style/app.css';
import React, { useEffect } from "react";
import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";
import { Login } from "./components/Login";
import { OperatorPage } from './Operator/OperatorPage';
import { ManagerPage } from './Manager/ManagerPage';
import { AdminPage } from './Admin/AdminPage';
import PrivateRoute from './PrivateRoute';

function App() {
  
  return (
    <div className='app-wrapper'>
      <Router>
        <Routes>
          <Route path="/" element={<PrivateRoute allowedRole={"Unknown"}><Login/></PrivateRoute>} />
          <Route path="/login" element={<PrivateRoute allowedRole={"Unknown"}><Login/></PrivateRoute>} />
          <Route path="/operator/*" element={<PrivateRoute allowedRole={"Operator"}><OperatorPage/></PrivateRoute>} />
          <Route path="/manager/*" element={<PrivateRoute allowedRole={"Manager"}><ManagerPage/></PrivateRoute>} />
          <Route path="/admin/*" element={<PrivateRoute allowedRole={"Admin"}><AdminPage/></PrivateRoute>} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;