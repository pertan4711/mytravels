import React, { useState } from "react";

const InputTravelForm = ({ addTravel }) => {
  const [travel, setTravel] = useState({
    name: "",
    description: "",
    start: "",
    end: "",
  });

  // computed property name
  const change = (e) =>
    setTravel({ ...travel, [e.target.name]: e.target.value });

  const saveTravel = (e) => {
    e.preventDefault();
    addTravel(travel);
  };

  return (
    <div className="container">
      <form className="" onSubmit={saveTravel}>
        <div className="form-group">
          <label htmlFor="name" className="form-label">
            Namn p&aring; resa:
          </label>
          <input
            id="name"
            type="text"
            className="form-control"
            placeholder="Resenamn"
            aria-label="Resenamn"
            aria-describedby="addon-wrapping"
            name="name"
            value={travel.name}
            onChange={change}
          />
        </div>

        <div className="form-group">
          <label htmlFor="description" className="form-label">
            Beskrivning:
          </label>
          <input
            id="description"
            type="text"
            className="form-control"
            name="description"
            value={travel.description}
            onChange={change}
          />
        </div>

        <div className="form-group">
          <label htmlFor="start">Start datum:</label>
          <input
            id="start"
            type="text"
            className="form-control"
            name="start"
            value={travel.start}
            onChange={change}
          />
        </div>

        <div className="form-group">
          <label htmlFor="end">Slut datum:</label>
          <input
            id="end"
            type="text"
            className="form-control"
            name="end"
            value={travel.end}
            onChange={change}
          />
        </div>
        <button type="submit" className="btn btn-primary">
          OK
        </button>
      </form>
    </div>
  );
};

export default InputTravelForm;
