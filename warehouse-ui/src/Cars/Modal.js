import React from "react";

function Modal(props) {
  const isVisible = props.modalVisible ? "cars__modal__visible" : "";
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
      </div>
    </div>
  );
}

export default Modal;
