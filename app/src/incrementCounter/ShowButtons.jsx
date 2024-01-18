import React from "react";
import { useState } from "react";

// Vanlig funktionsdeklaration med default props-funktion som skickas från ShowButtons()
function Button(props) {
  const handleClick = () => props.onClickFunction(props.increment);
  return <button onClick={handleClick}>+{props.increment}</button>;
}

// Mer modern funktionsdeklaration - anropas oxå från ShowButtons()
const Display = (props) => {
  return <div>{props.message}</div>;
};

// Anropa githubs API med asynkront anrop
const hamta = async () => {
  const resp = await fetch("https://api.github.com");
  const data = await resp.json();
  console.log(data);
};

function ShowButtons({ buttonNumbers }) {
  const [counter, setCounter] = useState(42);
  hamta();
  const incrementCounter = (incr) => setCounter(counter + incr);
  return (
    <div>
      {buttonNumbers.map(number => 
          <Button onClickFunction={number} increment={number} />
          )
      }

      <Display message={counter} />
    </div>
  );
}

export default ShowButtons;
