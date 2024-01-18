import axios from "axios";
import React from "react";

const testTravels = [
  {
    id: 1, 
    name: "Maldiverna_2021", 
    description: "Dykning och Amari Havodda i Maldiverna 2021",
    media: [],
    subTravels: [
      {
        id: 2,
        name: "Amari Havodda",
        description: "Hotellö i Maldiverna med ett fint husrev",
        start: "2021-02-10",
        end: "2021-02-17",
        media: [
          {
            id: 1,
            type: "jpeg",
            name: "IMG-20210215-WA0017",
            url: "\\\\pertanqnap\\Multimedia\\eget\\2021\\01 Maldiverna\\Daniellas mobil\\IMG-20210215-WA0017.jpg"
          }
        ],
        subTravels: []
      },
      {
        id: 3,
        name: "Maldives Current Dives",
        description: "Dykning i södra Maldiverna ofta i strömstarka kanaler",
        start: "2021-02-17",
        end: "2021-02-22",
        media: [
          {
            id: 2,
            type: "jpeg",
            name: "IMG-20210215-WA0018",
            url: "\\\\pertanqnap\\Multimedia\\eget\\2021\\01 Maldiverna\\Daniellas mobil\\IMG-20210215-WA0018.jpg"
          }
        ],
        subTravels: []
      },
    ]
  },
  {
    id: 10,
    name: "Rom_2021",
    description: "Höstresa till Rom",
    start: "2021-09-16",
    end: "2021-09-20",
    media: [],
    subTravels: []
  }
]

const Travel = (props) => {
  const travels = props.travels;
  return (
    <div>
      {travels.map((travel) => (
        <>
          <h3>{travel.name}</h3>
          {travel.name}<br />
          {travel.description}<br />
          Består av dessa delresor:
          <ul>
            {travel.subTravels.map(subtravel => (
              <li>
                {subtravel.name}<br />
              </li>
            ))}
          </ul>
          {travel.subTravels.map(subtravel => <TravelInfo {...subtravel} />
          )}
        </>
      ))}
    </div>
  )
}

const TravelInfo = (props) => {
  const travel = props;
  return (
      <div className="github-profile">
        {/* <img src={travel.media} /> */}
        <div className="info">
          <div className="name">{travel.name}</div>
          <div className="description">{travel.description}</div>
          <div>start: {travel.start}</div>
          <div>end  : {travel.end}</div>
          {travel.media.map(media => (
            <div>
              {media.name}
            </div>
          ))}
        </div>
      </div>
  )
};


const MyTravels = () => {
  const apiMyTravel = async () => await axios.get('https://localhost:4711/api/v0.1/Travels');
  const resp = apiMyTravel();
  console.log('Starting frontend');
  return (
    <div>
      Denna app visar info om resor.<br />
      {resp && <p><div style={{color: 'green', fontWeight: 'bold'}}>Uppkopplingen till API lyckades!</div></p>}
      <Travel travels={testTravels} />
    </div>
    );
};

export default MyTravels;
