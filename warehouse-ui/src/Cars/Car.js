import "./style.css";

function Car(props) {
  const activeClass = props.car.licensed ? "car__active" : "";
  const onClick = () => {
    if (props.car.licensed) {
      props.setModalContent(props.car);
      props.openModal();
    }
  };
  return (
    <div className={"car " + activeClass} onClick={onClick}>
      <span>
        <p>Make: </p>
        <p className="car__information">{props.car.make}</p>
      </span>
      <span>
        <p>Model:</p>
        <p className="car__information">{props.car.model}</p>
      </span>
      <span>
        <p>Price: </p>

        <p className="car__information">{props.car.price}</p>
      </span>
    </div>
  );
}

export default Car;
