import { handleChange, changeToolTipStatus } from "../utils";

describe("test handleChange function", () => {
  let changeToolTipStatus, props;
  beforeEach(() => {
    changeToolTipStatus = jest.fn();
    props = {
      type: "City",
      version: "v1",
      city: "mumbai",
      cityList: ["Mumbai", "Chennai", "Delhi", "Pune"],
      changeSelectedCity: jest.fn(),
      changeSelectedVersion: jest.fn(),
      changeSelectedPrice: jest.fn(),
      changePopupStatus: jest.fn()
    };
  });

  afterEach(() => {
    jest.clearAllMocks();
  });

  it("should call all the proper functions when type as City", () => {
    handleChange(props, "selectedText", changeToolTipStatus);
    // functions given valid arguments.
    expect(props.changeSelectedCity.mock.calls[0][0]).toBe("selectedText");
    expect(props.changeSelectedPrice.mock.calls[0][0]).toBe(props.version);
    expect(props.changeSelectedPrice.mock.calls[0][1]).toBe(props.city);
    expect(props.changePopupStatus.mock.calls[0][0]).toBe(props.type);
    expect(props.changePopupStatus.mock.calls[0][1]).toBe(false);
    expect(changeToolTipStatus.mock.calls[0][0]).toBe(props);
    // check functions called.
    expect(props.changeSelectedCity.mock.calls.length).toBe(1);
    expect(props.changeSelectedPrice.mock.calls.length).toBe(1);
    expect(props.changePopupStatus.mock.calls.length).toBe(1);
    expect(changeToolTipStatus.mock.calls.length).toBe(1);
    expect(props.changeSelectedVersion.mock.calls.length).toBe(0);
  });

  it("should call all the proper functions when type as Version", () => {
    props.type = "Version";
    handleChange(props, "selectedText", changeToolTipStatus);
    // functions given valid arguments.
    expect(props.changeSelectedVersion.mock.calls[0][0]).toBe("selectedText");
    expect(props.changeSelectedPrice.mock.calls[0][0]).toBe(props.version);
    expect(props.changeSelectedPrice.mock.calls[0][1]).toBe(props.city);
    expect(props.changePopupStatus.mock.calls[0][0]).toBe(props.type);
    expect(props.changePopupStatus.mock.calls[0][1]).toBe(false);
    // check functions called.
    expect(props.changeSelectedVersion.mock.calls.length).toBe(1);
    expect(props.changeSelectedPrice.mock.calls.length).toBe(1);
    expect(props.changePopupStatus.mock.calls.length).toBe(1);
    expect(changeToolTipStatus.mock.calls.length).toBe(0);
    expect(props.changeSelectedCity.mock.calls.length).toBe(0);
  });
});

describe("Test changeToolTipStatus Function", () => {
  it("should call changeShowToolTip twice, once after 5 seconds.", () => {
    const props = {
      changeShowToolTip: jest.fn(),
    };
    jest.useFakeTimers();
    changeToolTipStatus(props);
    // functions called 1 times.
    expect(props.changeShowToolTip).toHaveBeenCalledTimes(1);
    expect(setTimeout).toHaveBeenCalledTimes(1);
    expect(setTimeout).toHaveBeenLastCalledWith(expect.any(Function), 5000);
  });
});
