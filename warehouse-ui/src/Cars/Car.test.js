import { render, screen } from "@testing-library/react";
import { shallow } from "enzyme";

import Car from "./Car";

describe("Test Car component", () => {
  test("renders all 3 informations", () => {
    const fakeCar = {
      id: 1,
      make: "testMake",
      model: "testModel",
      price: "5",
      licensed: false,
    };
    render(<Car car={fakeCar} />);
    const makeInformation = screen.getByText(/testMake/i);
    const modelInformation = screen.getByText(/testModel/i);
    const priceInformation = screen.getByText(/5/i);

    expect(makeInformation).toBeInTheDocument();
    expect(modelInformation).toBeInTheDocument();
    expect(priceInformation).toBeInTheDocument();
  });

  test("click on licensed car should open modal and change modal's content", () => {
    const fakeCar = {
      id: 1,
      make: "testMake",
      model: "testModel",
      price: "5",
      licensed: true,
    };
    const mockSetModalContent = jest.fn();
    const mockOpenModal = jest.fn();

    const wrapper = shallow(
      <Car
        car={fakeCar}
        setModalContent={mockSetModalContent}
        openModal={mockOpenModal}
      />
    );

    wrapper.find(".car").simulate("click");

    expect(mockSetModalContent).toHaveBeenCalled();
    expect(mockOpenModal).toHaveBeenCalled();
  });
});
