import ReactDOM from "react-dom/client";
import ShowButtons from "./incrementCounter/ShowButtons";
import GithubCards from "./githubCards/GithubCards";
import ConditionalStyle from "./conditionalStyle/ConditionalStyle";
import MyTravels from "./myTravels/MyTravels";

const root = ReactDOM.createRoot(document.getElementById("root"));

root.render(
  <>
    <h1>Getting started - Samer Buna</h1>
    <h3>GithubCards</h3>
    <GithubCards />
    <hr />
    <h3>ShowButtons</h3>
    <ShowButtons buttonNumbers={[1, 2, 5, 10, 20]} />
    <hr />
    <h3>ConditionalStyle</h3>
    <ConditionalStyle />
    <hr />
    <h1>MyTravels</h1>
    <MyTravels />
  </>
);
