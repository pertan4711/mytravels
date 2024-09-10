import React from "react";
import { Link } from "react-router-dom";

const Home = () => {
  return (
    <>
      <h1>Home</h1>
      <ul>
        <li><Link to="/gettingStarted">Getting Started</Link></li>
        <li><Link to="/mathML">MathML</Link></li>
        <li><Link to="/myTravels">My Travels</Link></li>
      </ul>
    </>
  );
};

export default Home;
