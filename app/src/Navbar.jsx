import React from "react";
import { Outlet, Link } from "react-router-dom";

const Navbar = () => {
  return (
    <>
      <nav className="mb-5">
        <ul className="breadcrumb">
          <li className="breadcrumb-item">
            <Link to="/">Home</Link>
          </li>
          <li className="breadcrumb-item">
            <Link to="/gettingStarted">Getting Started</Link>
          </li>
          <li className="breadcrumb-item">
            <Link to="/myTravels">My Travels</Link>
          </li>
        </ul>
      </nav>
      <Outlet />
    </>
  );
};

export default Navbar;
