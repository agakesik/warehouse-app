import React, { useEffect, useState } from "react";
import Car from "./Car";

function Cars() {
  const [cars, setCars] = useState([]);
  const [messageForUser, setMessageForUser] = useState("Loading information");

  useEffect(() => getCars(), []);

  const apiUrl = "https://localhost:7124/api/Cars";
  const getCars = () => {
    fetch(apiUrl, {
      method: "GET",
    })
      .then((response) => {
        if (response.ok) {
          response.json().then((json) => {
            setCars(json);
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
  );
}

export default Cars;
