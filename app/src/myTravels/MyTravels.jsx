import axios from "./axios";
import React, { useState, useEffect } from "react";
import Banner from "./Banner";
import TravelList from "./TravelList";
//import InputTravelForm from "./InputTravelForm";
import Travel from "./Travel";

const ShowTravels = () => {
  const [travels, setTravels] = useState([]);
  const [viewTravelStyle, setViewTravelStyle] = useState(false); // false = table; true = text
  const [includeSubTravels, setIncludeSubTravels] = useState(false);
  const [selectedTravel, setSelectedTravel] = useState();

  useEffect(() => {
    const getTravels = async () => {
      const fetchUrl =
        "travels?includeSubTravels=" + includeSubTravels + "&pageSize=50";
      const resp = await axios.get(fetchUrl);
      setTravels(resp.data);
      return resp;
    };
    getTravels();
  }, [includeSubTravels]);

  const addTravel = async (newTravel) => {
    const postUrl = "travels";

    try {
      const resp = await axios.post(postUrl, newTravel);
      console.log(resp);
    } catch (error) {
      console.log(error);
    }

    setTravels([...travels, newTravel]);
  };

  return (
    <div>
      <Banner>Bilder tillsammans med resor</Banner>

      <div className="row mb-3">
        <div className="col">
          <button className="btn btn-primary me-2" onClick={addTravel}>
            Skapa ny
          </button>
          <button className="btn btn-primary">Ta bort</button>
        </div>
      </div>

      {/* <div className="row">
        <InputTravelForm props={setTravels} />
      </div> */}

      <div className="row mb-5 border col-4 p-2">
        <div className="form-check">
          <input
            id="cbViewStyle"
            type="checkbox"
            className="form-check-input"
            onChange={(e) => {
              setViewTravelStyle(e.target.checked);
            }}
          />
          <label className="form-check-label" htmlFor="cbViewStyle">
            Se all information om resa
          </label>
        </div>

        <div className="form-check">
          <input
            id="cbIncludeSubs"
            type="checkbox"
            className="form-check-input"
            onChange={(e) => {
              setIncludeSubTravels(e.target.checked);
            }}
          />
          <label className="form-check-label" htmlFor="cbIncludeSubs">
            Inkludera delresor
          </label>
        </div>
      </div>

      {selectedTravel ? (
        <Travel travel={selectedTravel} />
      ) : (
        <TravelList
          travels={travels}
          listStyle={viewTravelStyle}
          includeSubTravels={includeSubTravels}
          selectTravel={setSelectedTravel}
        />
      )}
    </div>
  );
};

export default ShowTravels;
