import "./style.css";

function Car(props) {
  return (
    <div className="car">
      <span>
        <p>Make: </p>
        <p className="car__information">{props.make}</p>
      </span>
      <span>
        <p>Model:</p>
        <p className="car__information">{props.model}</p>
      </span>
      <span>
        <p>Price: </p>

        <p className="car__information">{props.price}</p>
      </span>
    </div>
  );
}

export default Car;
