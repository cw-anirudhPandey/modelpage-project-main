import React from "react";
import { shallow } from "enzyme";
import LinkList from "../Components/LinkList";

const listOfLinks = [
  {
    title: "Colors",
    href: "colors",
    imgUrl:
      "https://cdn.zeplin.io/5f489c7913d2623062e791d1/assets/4E6F07CF-813B-4F3C-8798-0283BD8E9B04.svg",
  },
  {
    title: "Images",
    href: "images",
    imgUrl:
      "https://cdn.zeplin.io/5f489c7913d2623062e791d1/assets/E778A3F2-4C9A-44A3-9591-91551C68B3C3.svg",
  },
  {
    title: "Videos",
    href: "videos",
    imgUrl:
      "https://cdn.zeplin.io/5f489c7913d2623062e791d1/assets/83BBF4DC-B856-47FA-B8B1-92AAB991711C.svg",
  },
];

describe("Test LinkList Component", () => {
  it("Should render Zero Links - No Props Passed", () => {
    const component = shallow(<LinkList />);
    expect(component.find("Link")).toHaveLength(0);
  })
  it("Should render Zero Links - Empty Array Passed", () => {
    const component = shallow(<LinkList listOfLinks={[]} />);
    expect(component.find("Link")).toHaveLength(0);
  })
  it("Should render Three Links", () => {
    const component = shallow(<LinkList listOfLinks={listOfLinks} />);
    expect(component.find("Link")).toHaveLength(3);
  })
});