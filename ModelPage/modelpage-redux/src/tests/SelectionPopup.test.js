import React from "react";
import { shallow } from "enzyme";
import { SelectionPopup } from "../Components/SelectionPopup";
import { handleChange, changeToolTipStatus } from "../Components/Navigation";

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
    const component = shallow(<SelectionPopup {...props} />);
    expect(component.find("Popup")).toHaveLength(0);
    // expect(component.find("li")).toHaveLength(4);
  });
});