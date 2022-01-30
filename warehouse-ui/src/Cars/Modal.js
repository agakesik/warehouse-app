import React from "react";

function Modal(props) {
  const isVisible = props.modalVisible ? "cars__modal__visible" : "";
  const modalCar = props.modalContent;

  return (
    <div className={"cars__modal " + isVisible}>
      <div
        className="cars__modal__background"
        onClick={() => props.closeModal()}
      ></div>
      <div className="cars__modal__content">
        <div
          className="cars__modal__close-button"
          onClick={() => props.closeModal()}
        >
          close X
        </div>
        <div className="text__description">
          <p>
            make:{" "}
            <span className="text__information">
              {modalCar ? modalCar.make : ""}
            </span>
          </p>
          <p>
            model:{" "}
            <span className="text__information">
              {modalCar ? modalCar.model : ""}
            </span>
          </p>
          <p>
            year:{" "}
            <span className="text__information">
              {modalCar ? modalCar.yearModel : ""}
            </span>
          </p>
          <p>
            price:{" "}
            <span className="text__information">
              {modalCar ? modalCar.price : ""}
            </span>{" "}
          </p>
          <p>
            warehouse:{" "}
            <span className="text__information">
              {modalCar ? modalCar.warehouseName : ""}
            </span>
          </p>
          <p>
            warehouse location:{" "}
            <span className="text__information">
              {modalCar
                ? `lon: ${modalCar.warehouseLongitude}, lat: ${modalCar.warehouseLatitude}`
                : ""}
            </span>
          </p>
        </div>
      </div>
    </div>
  );
}

export default Modal;
