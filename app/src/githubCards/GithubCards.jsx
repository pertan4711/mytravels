import React from "react";
import CardList from "./CardList";
import FormState from "./FormState";

// const testData = [
//   {
//     name: "Dan Abramov",
//     avatar_url: "https://avatars0.githubusercontent.com/u/810438?v=4",
//     company: "@facebook",
//   },
//   {
//     name: "Sophie Alpert",
//     avatar_url: "https://avatars2.githubusercontent.com/u/6820?v=4",
//     company: "Humu",
//   },
//   {
//     name: "Sebastian Markbåge",
//     avatar_url: "https://avatars2.githubusercontent.com/u/63648?v=4",
//     company: "Facebook",
//   },
// ];

class GithubCards extends React.Component {
  state = {
    profiles: [],
  };
  addNewProfile = (profileData) => {
    this.setState((prevState) => ({
      profiles: [...prevState.profiles, profileData],
    }));
  };
  render() {
    return (
      <div>
        <div className="header">{this.props.title}</div>
        <FormState onSubmit={this.addNewProfile} />
        <CardList profiles={this.state.profiles} />
      </div>
    );
  }
}

export default GithubCards;
