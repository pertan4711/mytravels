import axios from "axios";
import React, { useState } from "react";

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

const Travels = async () => {
  const resp = await axios.get('https://localhost:4711/api/v0.1/Travels'); 
  return (
    <div>
      <TravelList {...resp.data} />
    </div>
  )
}

const TravelList = (props) => {
  console.log(props);
  debugger;
  return(
    <div>
      {props.travels.map((travel) => <TravelInfo key={travel.id} {...travel} />)}
    </div>
  );
}

const TravelInfo = (travel) => {
  return (
      <div className="github-profile">
        {/* <img src={travel.media} /> */}
        <div className="info">
          <div key={'name' + travel.id} className="name">{travel.name}</div>
          <div key={'desc' + travel.id} className="description">{travel.description}</div>
          {travel.start && <div key={'start' + travel.id}>start: {travel.start}</div>}
          {travel.end &&<div key={'end' + travel.id}>end  : {travel.end}</div>}
          {travel.media.map(media => (
            <div key={'media' + travel.id + ':' + media.id}>
                media : {media.name}
            </div>
          ))}
          {travel.subTravels && 
            <ul>
              {travel.subTravels.map(sub => (
                <li key={'sub' + travel.id + ':' + sub.id}>{sub.name}</li>
              ))}
            </ul>
          }
        </div>
      </div>
  )
};

class Form extends React.Component {
  state = { travelId: '' };
  handleSubmit = async (event) => {
    event.preventDefault();
    const resp = await axios.get(
      `https://localhost:4711/api/v0.1/Travels/${this.state.travelId}?includeSubTravels=true`
    ); 
    //console.log(resp.data);
    this.props.onSubmit(resp.data);
    this.setState({travelId:''});
  }
  render() {
    return(
      <form onSubmit={this.handleSubmit}>
        <input 
          type="text" 
          value={this.state.travelId}
          onChange={event => this.setState({ travelId: event.target.value })}
          placeholder="Enter Travel ID" 
        />
        <button>Travel ID</button>
      </form>
    )
  };
}

class MyTravels extends React.Component {
  state = {
    travels: [],
  };
  addNewTravel = (travelData) => {
     this.setState((prevState) => ({
      travels: [...prevState.travels, travelData],
    }));
  };
  render() {
    return (
      <div>
        <div className="header">Denna app visar info om resor.</div>
        <Travels />
        <Form onSubmit={this.addNewTravel} />
        <TravelList travels={this.state.travels} />
      </div>
      );
  }
}

export default MyTravels;
