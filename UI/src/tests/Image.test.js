import React from 'react';
import { shallow } from 'enzyme';
import Image from '../Components/Image';


const defaultProps = {
  url: "https://images.unsplash.com/photo-1502877338535-766e1452684a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=751&q=80",
  alt: "Car",
  height: "200",
  width: "200"
}

describe("Test Image Component", () => {
  it("Should render correct with props - Default Case", () => {
    const component = shallow(<Image {...defaultProps}/>);
    expect(component).toMatchSnapshot();
  });
  it("Should render correct with no props", () => {
    const component = shallow(<Image />);
    expect(component).toMatchSnapshot();
  });
})