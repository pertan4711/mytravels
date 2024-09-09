import useAxios from "./useAxios";
import axios from '../api/accessMyTravels';

import React from "react";

const MyTravels = () => {
  const [travels, error, loading] = useAxios({
    axiosInstance: axios,
    method: 'GET',
    url: '/',
    requestConfig: {
      headers: {
        'Content-Language': 'en-US'
      }
    }
  });
  
  return (
    <div>
      <h2>Travels</h2>
      {loading && <p>Loading...</p>}
      {!loading && error && <p className="errMsg">{error}</p>}
      {!loading && !error && travels && <p>{travels.toString()}</p>}
      {!loading && !error && !travels && <p>Inga resor att visa</p>}
    </div>
  );
}

export default MyTravels;
