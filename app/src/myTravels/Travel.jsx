import React, { useEffect, useState } from "react";
import axios from "./axios";

const Travel = (t) => {
  const [media, setMedia] = useState();

  useEffect(() => {
    const getTravelMedia = async (mediaid) => {
      const fetchUrl = "file/" + mediaid;
      try {
        const resp = await axios.get(fetchUrl, { responseType: "blob" });
        setMedia(resp.data);
        return resp;
      } catch (error) {
        console.log(error);
      }
    };
    getTravelMedia(t.travel.id);
  }, [t]);

  return (
    <div className="col-md-4 mb-5">
      <h4>
        {t.travel.name} (id:{t.travel.id})
      </h4>
      <div>{t.travel.description}</div>
      {t.travel.start && <div>start: {t.travel.start}</div>}
      {t.travel.end && <div>end : {t.travel.end}</div>}
      {/* {media &&
        media.map((media) => (
          <div key={"media" + t.travel.id + ":" + media.id}>
            media : {media.name}
          </div>
          <Image image={}
        ))} */}

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
