import { render, screen } from "@testing-library/react";

import Car from "./Car";

describe("Test Car component", () => {
  test("renders all 3 informations", () => {
    render(<Car make="testMake" model="testModel" price="5" />);
    const makeInformation = screen.getByText(/testMake/i);
    const modelInformation = screen.getByText(/testModel/i);
    const priceInformation = screen.getByText(/5/i);

    expect(makeInformation).toBeInTheDocument();
    expect(modelInformation).toBeInTheDocument();
    expect(priceInformation).toBeInTheDocument();
  });
});
