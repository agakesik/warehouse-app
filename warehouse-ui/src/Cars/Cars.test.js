import { shallow } from "enzyme";
import React from "react";

import Cars from "./index";

const fakeCars = [
  {
    id: 1,
    make: "testMake1",
    model: "testModel1",
    price: "5",
    licensed: false,
  },
  {
    id: 2,
    make: "testMake2",
    model: "testModel2",
    price: "10",
    licensed: false,
  },
];

describe("Test Cars component", () => {
  test("render Car components based on state data", () => {
    React.useState = jest.fn().mockReturnValue([fakeCars, {}]);

    const wrapper = shallow(<Cars />);
    expect(wrapper.find("Car")).toHaveLength(2);
  });

  test("contains modal element", () => {
    React.useState = jest.fn().mockReturnValue([fakeCars, {}]);

    const wrapper = shallow(<Cars />);
    expect(wrapper.find("Modal")).toHaveLength(1);
  });
});
