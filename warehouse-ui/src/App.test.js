import { render, screen } from "@testing-library/react";
import App from "./App";
import { shallow } from "enzyme";

describe("Test App component", () => {
  test("App contains title", () => {
    const wrapper = shallow(<App />);
    // console.log(wrapper.find("<h1>").length);
    expect(wrapper.find("h1")).toHaveLength(1);
  });

  test("App contains Cars component", () => {
    const wrapper = shallow(<App />);
    expect(wrapper.find("Cars")).toHaveLength(1);
  });
});
