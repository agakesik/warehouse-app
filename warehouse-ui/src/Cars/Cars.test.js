import { shallow } from "enzyme";
import React from "react";

import Cars from "./index";

const fakeCars = [
  {
    make: "testMake1",
    model: "testModel1",
    price: "5",
  },
  {
    make: "testMake2",
    model: "testModel2",
    price: "10",
  },
];

describe("Test Car component", () => {
  test("render Car components based on state data", () => {
    React.useState = jest.fn().mockReturnValue([fakeCars, {}]);

    const wrapper = shallow(<Cars />);
    expect(wrapper.find("Car")).toHaveLength(2);
  });
});
