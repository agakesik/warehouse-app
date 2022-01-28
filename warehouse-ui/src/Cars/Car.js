import "./style.css";

function Car(props) {
  return (
    <div className="car">
      <p>Make: {props.make}</p>
      <p>Model: {props.model}</p>
      <p>Price: {props.price}</p>
    </div>
  );
}

export default Car;
