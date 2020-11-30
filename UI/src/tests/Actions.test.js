
// actions
import {
  changeCityList,
  changeVersionList,
  changeSelectedCity,
  changeSelectedVersion,
  changeSelectedPrice,
  changeShowToolTip,
  changePriceDetailList,
} from "../actions/Actions";

describe("Action Creators", () => {
  let expectedAction;
  beforeEach(() => {
    expectedAction = {};
  });

  test("changeSelectedCity action creator, returns expected action", () => {
    expectedAction.type = "CHANGE_SELECTED_CITY";
    expectedAction.data = "Mumbai";

    expect(changeSelectedCity("Mumbai")).toEqual(expectedAction);
  });
  test("changeSelectedVersion action creator, returns expected action", () => {
    expectedAction.type = "CHANGE_SELECTED_VERSION";
    expectedAction.data = "Vdi";

    expect(changeSelectedVersion("Vdi")).toEqual(expectedAction);
  });
  test("changeSelectedPrice action creator, returns expected action", () => {
    const city = "Mumbai",
      version = "Vdi";
    expectedAction.type = "CHANGE_SELECTED_PRICE";
    expectedAction.selectedCity = city;
    expectedAction.selectedVersion = version;

    expect(changeSelectedPrice(version, city)).toEqual(expectedAction);
  });
  test("changeCityList action creator, returns expected action", () => {
    const cityList = ["Mumbai", "Pune", "Delhi"];
    expectedAction.type = "CHANGE_CITY_LIST";
    expectedAction.data = cityList;

    expect(changeCityList(cityList)).toEqual(expectedAction);
  });
  test("changeVersionList action creator, returns expected action", () => {
    const versionList = ["Vdi", "Vxi"];
    expectedAction.type = "CHANGE_VERSION_LIST";
    expectedAction.data = versionList;

    expect(changeVersionList(versionList)).toEqual(expectedAction);
  });
  test("changeShowToolTip action creator, returns expected action", () => {
    expectedAction.type = "CHANGE_SHOW_TOOLTIP";
    expectedAction.data = true;

    expect(changeShowToolTip(true)).toEqual(expectedAction);
  });
  test("changePriceDetailList action creator, returns expected action", () => {
    const priceDetailsList = [
      {
        price: 40000,
        version: "Vdi",
        city: "Mumbai"
      }
    ];
    expectedAction.type = "CHANGE_PRICE_DETAIL_LIST";
    expectedAction.data = priceDetailsList;

    expect(changePriceDetailList(priceDetailsList)).toEqual(expectedAction);
  });
});
