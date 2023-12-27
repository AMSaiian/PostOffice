import React, { useState } from "react";
import { Header } from "../components/Header";
import { Footer } from "../components/Footer"
import { NewPostOffice } from "./NewPostOffice";
import { NewPostOfficeManager } from "./NewPostOfficeManager";
import { AllPostOffices } from "./AllPostOffices";
import PrivateRoute from '../PrivateRoute';
import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";

export const AdminPage = () => {
    return (        
    <>
      <Header names={["New post office", 'New post office manager', 'All post offices']} paths={["newPostOffice", "newPostOfficeManager", "allPostOffices"]} />
      <Routes>
        <Route path="newPostOffice" element={<PrivateRoute allowedRole={"Admin"}><NewPostOffice/></PrivateRoute>} />
        <Route path="newPostOfficeManager" element={<PrivateRoute allowedRole={"Admin"}><NewPostOfficeManager/></PrivateRoute>} />
        <Route path="allPostOffices" element={<PrivateRoute allowedRole={"Admin"}><AllPostOffices/></PrivateRoute>} />
      </Routes>
      <Footer />
    </>
    )
}