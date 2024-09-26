import React, { useEffect, useState } from "react";
import axios from "./axios";
import FileDropZone from "./FileDropZone";

const Travel = ({ travel, setSelectedCallback }) => {
  const [medias, setMedias] = useState([]); // multiple pics

  const onMyFileUpload = (files) => {
    console.log("fileupload" + files);
    let fileCount = 0;
    let rows = [];

    // Add visual confirmation of added files
    for (const file of files) {
      const filerow = `<tr>
          <td class="small">
            ${file.name}
          </td>
          <td class="small">
            ${file.comment}
          </td>
          <td class="small">
            ${file.size}
          </td>
        <tr>`;

      rows.append(filerow);
      fileCount++;
    }

    return fileCount, rows;
  };

  // Fetching one image at a time as a blob
  useEffect(() => {
    const getTravelMedia = async (t) => {
      if (t.media) {
        for (const m of t.media) {
          const fetchUrl = "file/" + m.id;
          try {
            const response = await axios.get(fetchUrl, {
              responseType: "blob",
            });
            setMedias((medias) => [
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
  }, []);

  return (
    <div className="row-md-4 mb-3">
      <h4>
        {travel.name} (id:{travel.id})
      </h4>
      <div>{travel.description}</div>
      <div className="mt-3">
        {travel.start && (
          <>
            <b>period:</b> {travel.start?.split("T")[0]}
          </>
        )}{" "}
        - {travel.end && <>{travel.end?.split("T")[0]}</>}
      </div>

      <h4 className="mt-3">Medias</h4>
      <div className="row">
        {medias.map((m) => (
          <div
            style={{ width: "18rem", height: "18rem" }}
            key={"m" + m.id}
            className="col-lg-2 col-md-3 col-sm-4 m-1 p-2 card h-100 shadow"
          >
            <img
              id={m.id}
              src={URL.createObjectURL(m.image)}
              className="card-img-top"
              style={{
                maxWidth: "17rem",
                maxHeight: "15rem",
                height: "auto",
                width: "auto",
              }}
            />
            <div className="card-footer">
              <div className="small text-muted">{m.url.split("\\").pop()}</div>
            </div>
          </div>
        ))}
      </div>

      {travel.subTravels && (
        <>
          <div className="row mt-5">
            <h4>Inneh&aring;ller delresor:</h4>
          </div>
          <ul>
            {travel.subTravels.map((sub) => (
              <li
                key={"sub" + travel.id + ":" + sub.id}
                onClick={setSelectedCallback}
              >
                {sub.name}
              </li>
            ))}
          </ul>
        </>
      )}

      <FileDropZone onFileUpload={onMyFileUpload} />
    </div>
  );
};

export default Travel;
