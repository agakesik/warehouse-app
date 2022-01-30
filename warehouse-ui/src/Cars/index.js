import React, { useEffect, useState } from "react";
import Car from "./Car";

function Cars() {
  const [cars, setCars] = React.useState([]);
  const [messageForUser, setMessageForUser] = React.useState(
    "Loading information"
  );
  console.log("test");

  useEffect(() => getCars(), []);

  const apiUrl = process.env.REACT_APP_API_URL + "/api/Cars";
  const getCars = () => {
    console.log("go to fecth");
    fetch(apiUrl, {
      method: "GET",
    })
      .then((response) => {
        if (response.ok) {
          response.json().then((json) => {
            setCars(json);
            console.log("fetched data");
          });
        } else {
          setMessageForUser(
            "There was problem with getting information. Please try again later."
          );
        }
      })
      .catch((error) => console.log(error));
  };

  const carsComponents = cars.map((car) => (
    <Car make={car.make} model={car.model} price={car.price} key={car.id} />
  ));

  return (
    <div className="cars">{cars.length ? carsComponents : messageForUser}</div>
    // <div></div>
  );
}

export default Cars;
