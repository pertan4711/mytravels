import React, { useEffect, useState } from "react";
import axios from "./axios";

const Travel = (t) => {
  const [media, setMedia] = useState();
  const [medias, setMedias] = useState([]);

  // Fetching one image
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

  // Fetching multiple images
  useEffect(() => {
    const getTravelMedias = async (travelid) => {
      const fetchUrl = "file/travels/" + travelid + "/medias";
      try {
        const response = await axios.get(fetchUrl);
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
    <div className="col-md-4 mb-5">
      <h4>
        {t.travel.name} (id:{t.travel.id})
      </h4>
      <div>{t.travel.description}</div>
      {t.travel.start && <div>start: {t.travel.start}</div>}
      {t.travel.end && <div>end : {t.travel.end}</div>}
      <h4>Medias</h4>
      {medias &&
        medias.map((m) => (
          <div key={"media" + t.travel.id + ":" + m.id}>
            <p>media : {m.fileDownloadName}</p>
            <p>contentType : {m.contentType}</p>
            <img src={`data:image/jpeg;base64, ${m.fileContents}`} />
          </div>
        ))}

      <h4>Media</h4>
      {media && <img src={URL.createObjectURL(media)} />}

      {t.travel.subTravels && (
        <>
          <div className="">InnehÃ¥ller delresor:</div>
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
