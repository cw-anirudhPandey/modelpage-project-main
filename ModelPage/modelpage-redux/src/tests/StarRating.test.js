import React from "react";
import { shallow } from "enzyme";
import StarRating from "../Components/StarRating";

describe("Test Star Rating Component", () => {
  it("Should Render nothing with no rating", () => {
    const component = shallow(<StarRating />);
    expect(component.find("Image")).toHaveLength(0);
  });
  it("Should Render Nothing with improper rating", () => {
    const component = shallow(<StarRating rating={10} />);
    expect(component.find("Image")).toHaveLength(0);
  });
  it("Should Render 3 Filled Stars with rating as 3", () => {
    const component = shallow(<StarRating rating={3} />);
    expect(component.find("Image").at(2).prop("alt")).toEqual("Filled Star");
    expect(component.find("Image").at(3).prop("alt")).toEqual("Empty Star");
    expect(component.find("Image").at(4).prop("alt")).toEqual("Empty Star");
  });
});
