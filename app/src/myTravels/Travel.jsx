import React, { useEffect, useState } from "react";
import axios from "./axios";

const Travel = (t) => {
  const [media, setMedia] = useState(); // one pic
  const [medias, setMedias] = useState([]); // multiple pics

  // Fetching one image as a blob
  useEffect(() => {
    const getTravelMedia = async (mediaid) => {
      const fetchUrl = "file/" + mediaid;
      try {
        const response = await axios.get(fetchUrl, { responseType: "blob" });
        setMedia(response.data);
        return response;
      } catch (error) {
        console.log(error);
      }
    };
    if (t.travel.media !== null) {
      getTravelMedia(t.travel.media[0].id);
    }
  }, [t]);

  // Fetching multiple images as array or base64
  useEffect(() => {
    const getTravelMedias = async (travelid) => {
      const fetchUrl =
        "file/travels/" + travelid + "/medias?pagenumber=1&pagesize=10";
      try {
        const response = await axios.get(fetchUrl, {responseType: "arraybuffer"});
        setMedias(response.data);
        return response;
      } catch (error) {
        console.log(error);
      }
    };
    if (t.travel !== null) {
      getTravelMedias(t.travel.id);
    }
  }, [t]);

  return (
    <div className="row-md-4 mb-3">
      <h4>
        {t.travel.name} (id:{t.travel.id})
      </h4>
      <div>{t.travel.description}</div>
      <div className="mt-3">
        {t.travel.start && (
          <>
            <b>period:</b> {t.travel.start?.split("T")[0]}
          </>
        )}{" "}
        - {t.travel.end && <>{t.travel.end?.split("T")[0]}</>}
      </div>

      <h4 className="mt-3">Medias</h4>
      <div className="row">
        {medias &&
          medias.map((m, index) => (
            <div
              style={{ width: "18rem", height: "18rem" }}
              key={"m" + index}
              className="col-lg-2 col-md-3 col-sm-4 m-1 p-2 card h-100 shadow"
            >
              <img
                //src={`data:image/jpeg;base64, ${m.fileContents}`}
                src={URL.createObjectURL(m)}
                className="card-img-top"
                style={{
                  maxWidth: "17rem",
                  maxHeight: "15rem",
                  height: "auto",
                  width: "auto",
                }}
              />
              <div className="card-footer">
                <div className="small text-muted">
                  {index + 1}. {m.fileDownloadName}
                </div>
              </div>
            </div>
          ))}
      </div>

      <h4>Media</h4>
      {media && <img src={URL.createObjectURL(media)} />}

      {t.travel.subTravels && (
        <>
          <div className="">Inneh&aring;ller delresor:</div>
          <ul>
            {t.travel.subTravels.map((sub) => (
              <li key={"sub" + t.travel.id + ":" + sub.id}>{sub.name}</li>
            ))}
          </ul>
        </>
      )}
    </div>
  );
};

export default Travel;
