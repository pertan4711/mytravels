import React, { useEffect, useState } from "react";
import axios from "./axios";

const Travel = (travel) => {
  const [medias, setMedias] = useState([]); // multiple pics

  // Fetching one image at a time as a blob
  useEffect(() => {
    const getTravelMedia = async (t) => {
      if (t.travel.media) {
        for (const m of t.travel.media) {
          const fetchUrl = "file/" + m.id;
          try {
            const response = await axios.get(fetchUrl, {
              responseType: "blob",
            });
            setMedias([
              ...medias,
              {
                id: m.id,
                url: m.url,
                description: m.description,
                image: response.data,
              },
            ]);
          } catch (error) {
            console.log(error);
          }
        }
        return true;
      }
    };
    if (travel !== null) {
      getTravelMedia(travel);
    }
  }, [travel]);

  return (
    <div className="row-md-4 mb-3">
      <h4>
        {travel.travel.name} (id:{travel.travel.id})
      </h4>
      <div>{travel.travel.description}</div>
      <div className="mt-3">
        {travel.travel.start && (
          <>
            <b>period:</b> {travel.travel.start?.split("T")[0]}
          </>
        )}{" "}
        - {travel.travel.end && <>{travel.travel.end?.split("T")[0]}</>}
      </div>

      <h4 className="mt-3">Medias</h4>
      <div className="row">
        {medias.map((m) => {
          <div
            id={m.id}
            style={{ width: "18rem", height: "18rem" }}
            key={"m" + m.id}
            className="col-lg-2 col-md-3 col-sm-4 m-1 p-2 card h-100 shadow"
          >
            {/* <img
              //src={`data:image/jpeg;base64, ${m.fileContents}`}
              id={m.id}
              src={URL.createObjectURL(m.image)}
              className="card-img-top"
              style={{
                maxWidth: "17rem",
                maxHeight: "15rem",
                height: "auto",
                width: "auto",
              }}
            /> */}
            <div className="card-footer">
              <div className="small text-muted">
                m{m.id}: {m.url}
              </div>
            </div>
          </div>;
        })}
      </div>

      {travel.travel.subTravels && (
        <>
          <div className="">Inneh&aring;ller delresor:</div>
          <ul>
            {travel.travel.subTravels.map((sub) => (
              <li key={"sub" + travel.travel.id + ":" + sub.id}>{sub.name}</li>
            ))}
          </ul>
        </>
      )}
    </div>
  );
};

export default Travel;
