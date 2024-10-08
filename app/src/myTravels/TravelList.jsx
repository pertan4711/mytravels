import React from "react";

const TravelList = ({
  travels,
  listStyle,
  includeSubTravels,
  selectTravel,
}) => {
  const countMedia = (travel) => {
    let mediaCount = travel.media != null ? travel.media.length : 0;
    travel.subTravels?.forEach((subTravel) => {
      mediaCount = mediaCount + subTravel.media.length;
    });
    return mediaCount;
  };

  return (
    <div className="container-fluid row">
      {travels &&
        listStyle &&
        travels.map((travel) => <TravelText key={travel.id} {...travel} />)}

      {travels && !listStyle && includeSubTravels && (
        <div>
          <table className="table table-hover">
            <thead>
              <tr>
                <th>ID</th>
                <th>Resa</th>
                <th>Beskrivning</th>
                <th>Start</th>
                <th>Slut</th>
                <th>Delresor</th>
                <th>Tillhör</th>
                <th>Bilder</th>
              </tr>
            </thead>
            <tbody>
              {travels.map((t) => (
                <tr key={t.id} onClick={() => selectTravel(t)}>
                  <td>{t.id}</td>
                  <td>{t.name}</td>
                  <td>{t.description?.substring(0, 30)}</td>
                  <td>{t.start?.split("T")[0]}</td>
                  <td>{t.end?.split("T")[0]}</td>
                  <td>{t.subTravels?.length > 0 ? "Ja" : "Nej"}</td>
                  <td>{t.travelId}</td>
                  <td>{countMedia(t)}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}

      {travels && !listStyle && !includeSubTravels && (
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
                  <td>{t.description?.substring(0, 30)}</td>
                  <td>{t.start?.split("T")[0]}</td>
                  <td>{t.end?.split("T")[0]}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
      {!travels && <p>Loading...</p>}
    </div>
  );
};

const TravelText = (travel) => {
  return (
    <div className="col-md-4 mb-5">
      <h4>
        {travel.name} (id:{travel.id})
      </h4>
      <div>{travel.description}</div>
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
          <div className="">Inneh&aring;ller delresor:</div>
          <ul>
            {travel.subTravels.map((sub) => (
              <li key={"sub" + travel.id + ":" + sub.id}>{sub.name}</li>
            ))}
          </ul>
        </>
      )}
    </div>
  );
};

export default TravelList;
