import React from "react";
import Car from "./Car";

function Cars() {
  const cars = [
    {
      id: 1,
      make: "Maserati",
      model: "Coupe",
      yearModel: 2005,
      price: 199572.71,
      licensed: false,
    },
    {
      id: 2,
      make: "Isuzu",
      model: "Rodeo",
      yearModel: 1998,
      price: 6303.99,
      licensed: false,
    },
  ];

  const carsComponents = cars.map((car) => (
    <Car make={car.make} model={car.model} price={car.price} />
  ));

  return <div className="cars">{carsComponents}</div>;
}

export default Cars;
