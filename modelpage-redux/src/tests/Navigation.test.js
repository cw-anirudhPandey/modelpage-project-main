import React from "react";
import { shallow } from "enzyme";
import { Navigation } from "../Components/Navigation";

describe("test Navigation Component", () => {
  let props;
  beforeEach(() => {
    props = {
      city: "Mumbai",
      version: "Vdi",
      cityList: ["Mumbai", "Chennai", "Delhi", "Pune"],
      type: "City",
    };
  });

  it("Should not render Popup Component", () => {
    const component = shallow(<Navigation {...props} />);
    expect(component.find("Popup")).toHaveLength(0);
  });
});
