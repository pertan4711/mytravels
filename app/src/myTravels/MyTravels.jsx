import axios from "./axios";
import React, { useState, useEffect } from "react";

const TravelList = ({ travels }) => {
  return (
    <div>
      {travels && travels.map((travel) => <TravelInfo key={travel.id} {...travel} />)}
      {!travels && <p>Loading...</p>}
    </div>
  );
}

const TravelInfo = (travel) => {
  return (
    <div className="github-profile">
      {/* <img src={travel.media} /> */}
      <div className="info">
        <div className="name">{travel.name}</div>
        <div className="description">{travel.description}</div>
        {travel.start && <div>start: {travel.start}</div>}
        {travel.end && <div>end  : {travel.end}</div>}
        {travel.media && travel.media.map(media => (
          <div key={'media' + travel.id + ':' + media.id}>
            media : {media.name}
          </div>
        ))}
        {travel.subTravels &&
          <>
            <div className="">Innehåller delresor:</div>
            <ul>
              {travel.subTravels.map(sub => (
                <li key={'sub' + travel.id + ':' + sub.id}>{sub.name}</li>
              ))}
            </ul>
          </>
        }
      </div>
    </div>
  )
};

const MyTravels = () => {
  const [travels, setTravels] = useState([]);
  const [fetchUrl, setFetchUrl] = useState('travels?includeSubTravels=false');

  useEffect(() => {
    async function fetchData() {
      const resp = await axios.get(fetchUrl);
      setTravels(resp.data);
      return resp;
    }
    fetchData();
  }, [fetchUrl]);

  // const addNewTravel = (newTravelData) => {
  //   setTravels([...travels, newTravelData]);
  // }

  return (
    <div>
      <div className="header">Denna app visar info om resor.</div>
      <div className="form-check">
        <input id="cbIncludeSubs" type="checkbox" className="form-check-input" onChange={(e) => {
          setFetchUrl('travels?includeSubTravels=' + e.target.checked);
        }} />
        <label className="form-check-label" htmlFor="cbIncludeSubs">Inkludera delresor</label>
      </div>
      <TravelList travels={travels} />
      {/* <TravelForm onSubmit={addNewTravel} /> */}
    </div>
  );
}

export default MyTravels;
