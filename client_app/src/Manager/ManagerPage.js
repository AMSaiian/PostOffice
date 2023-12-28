import React, { useState } from "react";
import PrivateRoute from '../PrivateRoute';
import { Header } from "../components/Header";
import { Footer } from "../components/Footer"
import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";
import { NewOperator } from "./NewOperator";
import { AllOperators } from "./AllOperators";

export const ManagerPage = () => {
    return (
        <>
            <Header names={["New operator", 'All operators']} paths={["newOperator", "allOperators"]} />
            <Routes>
                <Route path="newOperator" element={<PrivateRoute allowedRole={"Manager"}><NewOperator /></PrivateRoute>} />
                <Route path="allOperators" element={<PrivateRoute allowedRole={"Manager"}><AllOperators /></PrivateRoute>} />
            </Routes>
            <Footer />
        </>
    )
}