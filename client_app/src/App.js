import './App.css';
import React from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import { Login } from "./Login";

function App() {
  return (
    <div className="App">
      <Login />
    </div>
  );
}

export default App;
