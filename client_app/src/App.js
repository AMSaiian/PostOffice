import './App.css';
import React, { useEffect } from "react";
import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";
import { Login } from "./components/Login";
import { OperatorPage } from './components/OperatorPage';
import { ManagerPage } from './components/ManagerPage';
import { AdminPage } from './components/AdminPage';
import { Header } from './components/Header';
import PrivateRoute from './PrivateRoute';

function App() {
  
  return (
    <div>
      <Router>
        <Header names={["1",'2','3']} />
        <Routes>
          <Route path="/" element={<PrivateRoute allowedRole={-1}><Login/></PrivateRoute>} />
          <Route path="/login" element={<PrivateRoute allowedRole={-1}><Login/></PrivateRoute>} />
          <Route path="/operator" element={<PrivateRoute allowedRole={2}><OperatorPage/></PrivateRoute>} />
          <Route path="/manager" element={<PrivateRoute allowedRole={1}><ManagerPage/></PrivateRoute>} />
          <Route path="/admin" element={<PrivateRoute allowedRole={0}><AdminPage/></PrivateRoute>} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;