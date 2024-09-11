import React from "react";

const TravelList = ({ travels, listStyle }) => {
  return (
    <div>
      {travels &&
        listStyle &&
        travels.map((travel) => <TravelInfo key={travel.id} {...travel} />)}
      {travels &&
        !listStyle &&
          <div>
            <table className="table table-hover">
              <thead>
                <tr>
                  <th>ID</th>
                  <th>Resa</th>
                  <th>Beskrivning</th>
                  <th>Start</th>
                  <th>Slut</th>
                </tr>
              </thead>
              <tbody>
                {travels.map((t) => (
                    <tr key={t.id}>
                        <td>{t.id}</td>
                        <td>{t.name}</td>
                        <td>{t.description}</td>
                        <td>{t.start?.split('T')[0]}</td>
                        <td>{t.end?.split('T')[0]}</td>
                    </tr>
                ))}
              </tbody>
            </table>
          </div>
        }
      {!travels && <p>Loading...</p>}
    </div>
  );
};

const TravelInfo = (travel) => {
  return (
    <div className="github-profile">
      {/* <img src={travel.media} /> */}
      <div className="info">
        <div className="name">{travel.id}. {travel.name}</div>
        <div className="description">{travel.description}</div>
        {travel.start && <div>start: {travel.start}</div>}
        {travel.end && <div>end : {travel.end}</div>}
        {travel.media &&
          travel.media.map((media) => (
            <div key={"media" + travel.id + ":" + media.id}>
              media : {media.name}
            </div>
          ))}
        {travel.subTravels && (
          <>
            <div className="">Innehåller delresor:</div>
            <ul>
              {travel.subTravels.map((sub) => (
                <li key={"sub" + travel.id + ":" + sub.id}>{sub.name}</li>
              ))}
            </ul>
          </>
        )}
      </div>
    </div>
  );
};

export default TravelList;
