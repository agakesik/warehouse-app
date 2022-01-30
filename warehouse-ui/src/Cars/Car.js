import "./style.css";

function Car(props) {
  const activeClass = props.car.licensed ? "car__active" : "";
  const onClick = () => {
    if (props.car.licensed) {
      getDetails();
      props.openModal();
    }
  };

  const apiUrl =
    process.env.REACT_APP_API_URL + "/api/Cars/getDetails?id=" + props.car.id;
  const getDetails = () => {
    fetch(apiUrl, {
      method: "GET",
    })
      .then((response) => {
        if (response.ok) {
          response.json().then((json) => {
            props.setModalContent(json);
          });
        } else {
          console.log(
            "There was problem with getting information. Please try again later."
          );
        }
      })
      .catch((error) => console.log(error));
  };

  return (
    <div className={"car text__description " + activeClass} onClick={onClick}>
      <span>
        <p>Make: </p>
        <p className="text__information">{props.car.make}</p>
      </span>
      <span>
        <p>Model:</p>
        <p className="text__information">{props.car.model}</p>
      </span>
      <span>
        <p>Price: </p>

        <p className="text__information">{props.car.price}</p>
      </span>
    </div>
  );
}

export default Car;
