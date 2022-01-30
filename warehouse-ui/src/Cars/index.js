import React, { useEffect, useState } from "react";
import Car from "./Car";
import Modal from "./Modal";

function Cars() {
  const [cars, setCars] = React.useState([]);
  const [messageForUser, setMessageForUser] = React.useState(
    "Loading information"
  );
  const [modalVisible, toggleModalVisible] = React.useState(false);
  const [modalContent, setModalContent] = React.useState({});

  useEffect(() => getCars(), []);

  const apiUrl = process.env.REACT_APP_API_URL + "/api/Cars";
  const getCars = () => {
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
    <Car
      car={car}
      key={car.id}
      openModal={() => toggleModalVisible(true)}
      setModalContent={(carDetails) => setModalContent(carDetails)}
    />
  ));

  return (
    <div>
      <div className="cars">
        {cars.length ? carsComponents : messageForUser}
      </div>
      <Modal
        modalVisible={modalVisible}
        modalContent={modalContent}
        closeModal={() => toggleModalVisible(false)}
      />
    </div>
  );
}

export default Cars;
