import React from "react";
import axios from "axios";

// Reading through DOM
class FormRef extends React.Component {
  userNameInput = React.createRef();
  handleSubmit = (event) => {
    event.preventDefault();
    console.log(this.userNameInput.current.value);
  };
  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <input
          type="text"
          placeholder="GitHub username"
          ref={this.userNameInput}
          required
        />
        <button>Add card</button>
      </form>
    );
  }
}

// React controlled
class FormState extends React.Component {
  state = { userName: "" };
  handleSubmit = async (event) => {
    event.preventDefault();
    const resp = await axios.get(
      `https://api.github.com/users/${this.state.userName}`
    );
    this.props.onSubmit(resp.data);
    this.setState({ userName: "" });
  };
  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <input
          type="text"
          value={this.state.userName}
          onChange={(event) => this.setState({ userName: event.target.value })}
          placeholder="GitHub username"
          required
        />
        <button>Add card</button>
      </form>
    );
  }
}

export default FormState;
