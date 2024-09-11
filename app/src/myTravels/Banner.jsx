import React from "react";
import styles from "./banner.module.css";

const Banner = ({ children }) => {
    return (
        <header className="row align-items-center mb-4">
            <div className="col-2">
                <img src="images/myTravelsLogo.jpg" alt="logo" className={styles.logo} />
            </div>
            <div className="col-1"></div>
            <h1 className="col-9">{children}</h1>
        </header>
    );
};

export default Banner;