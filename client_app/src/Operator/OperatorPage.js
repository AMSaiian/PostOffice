import React, { useState } from "react";
import PrivateRoute from '../PrivateRoute';
import { Header } from "../components/Header";
import { Footer } from "../components/Footer"
import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";
import { NewParcel } from "./NewParcel";
import { AcceptParcels } from "./AcceptParcels";
import { GiveParcel } from "./GiveParcel";

export const OperatorPage = () => {
    return (        
      <>
        <Header names={["New parcel", 'Accept parcels', 'Give parcels']} paths={["newParcel", "acceptParcels", "giveParcel"]} />
        <Routes>
          <Route path="newParcel" element={<PrivateRoute allowedRole={"Operator"}><NewParcel/></PrivateRoute>} />
          <Route path="acceptParcels" element={<PrivateRoute allowedRole={"Operator"}><AcceptParcels/></PrivateRoute>} />
          <Route path="giveParcel" element={<PrivateRoute allowedRole={"Operator"}><GiveParcel/></PrivateRoute>} />
        </Routes>
        <h1>This is OperatorPage</h1>
        <Footer/>
      </>
      )
}