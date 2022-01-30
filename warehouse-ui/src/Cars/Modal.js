import React from "react";
import Car from "./Car";

function Modal(props) {
  const isVisible = props.modalVisible ? "cars__modal__visible" : "";
  const car = props.modalContent;

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
        <p>this is a test modal</p>
        <p>make: {car ? car.make : ""} </p>
      </div>
    </div>
  );
}

export default Modal;
