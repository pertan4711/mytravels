import React from "react";
import ShowButtons from "./incrementCounter/ShowButtons";
import GithubCards from "./githubCards/GithubCards";
import ConditionalStyle from "./conditionalStyle/ConditionalStyle";

const GettingStarted = () => {
    return (
        <div>
            <h1>Getting started - Samer Buna</h1>
            <h3>GithubCards</h3>
            <GithubCards />
            <hr />
            <h3>ShowButtons</h3>
            <ShowButtons buttonNumbers={[1, 2, 5, 10, 20]} />
            <hr />
            <h3>ConditionalStyle</h3>
            <ConditionalStyle />
        </div>
    );
}

export default GettingStarted;