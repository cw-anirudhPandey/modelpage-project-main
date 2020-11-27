import React from "react";
import { shallow } from "enzyme";
import Link from "../Components/Link";

const defaultProps = {
  title: "Colors",
  href: "colors",
  imgUrl: "https://cdn.zeplin.io/5f489c7913d2623062e791d1/assets/4E6F07CF-813B-4F3C-8798-0283BD8E9B04.svg",
  height: 15,
  width: 15
};

describe("Test Link Component", () => {
  let props = {...defaultProps};
  it("Should render correct with all the props - Default case", () => {
    const component = shallow(<Link {...props} />);
    expect(component).toMatchSnapshot();
  });
  it("Should render correct with no props", () => {
    const component = shallow(<Link />);
    expect(component).toMatchSnapshot();
  });
});
