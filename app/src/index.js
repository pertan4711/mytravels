import React from "react";
import ReactDOM from "react-dom/client";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import GettingStarted from "./gettingStarted/GettingStarted";
import MyTravels from "./myTravels/MyTravels";
import NoPage from "./NoPage";
import Navbar from "./Navbar";
import Home from "./Home";

export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Navbar />}>
          <Route index element={<Home />} />
          <Route path="gettingstarted" element={<GettingStarted />} />
          <Route path="myTravels" element={<MyTravels />} />
          <Route path="*" element={<NoPage />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<App />);
