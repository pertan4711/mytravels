import axios from "./axios";
import React, { useState, useEffect } from "react";
import Banner from "./Banner";
import TravelList from "./TravelList";
import InputTravelForm from "./InputTravelForm";

const ShowTravels = () => {
  const [travels, setTravels] = useState([]);
  const [incSubs, setIncSubs] = useState(false);

  useEffect(() => {
    async function fetchData() {
      const fetchUrl = "travels?includeSubTravels=" + incSubs + "&pageSize=50";
      const resp = await axios.get(fetchUrl);
      setTravels(resp.data);
      return resp;
    }
    fetchData();
  }, [incSubs]);

  return (
    <div>
      <Banner>Bilder tillsammans med resor</Banner>

      <InputTravelForm props={setTravels} />

      <div>
        <input
          id="cbIncludeSubs"
          type="checkbox"
          className="form-check-input"
          onChange={(e) => {
            setIncSubs(e.target.checked);
          }}
        />
        <label className="form-check-label" htmlFor="cbIncludeSubs">
          Inkludera delresor
        </label>
      </div>

      <TravelList travels={travels} listStyle={incSubs} />

    </div>
  );
};

export default ShowTravels;
