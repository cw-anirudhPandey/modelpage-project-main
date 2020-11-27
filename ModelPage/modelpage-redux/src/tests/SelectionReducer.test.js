import SelectionReducer from "../Reducers/SelectionReducer";

describe("Test Selection Reducer with default states", () => {
  it("should change showToolTip status", () => {
    expect(
      SelectionReducer(undefined, {
        type: "CHANGE_SHOW_TOOLTIP",
        data: true,
      }).showToolTip
    ).toEqual(true);
  });

  it("should change the selected City", () => {
    const newCity = "Mumbai";
    expect(
      SelectionReducer(undefined, {
        type: "CHANGE_SELECTED_CITY",
        data: newCity,
      }).selected.city
    ).toEqual(newCity);
  });

  it("should change the selected Version", () => {
    const newVersion = "Vdi";
    expect(
      SelectionReducer(undefined, {
        type: "CHANGE_SELECTED_VERSION",
        data: newVersion,
      }).selected.version
    ).toEqual(newVersion);
  });

  it("should change the PriceDetails List", () => {
    const priceDetailsList = [
      {
        price: 50000,
        city: "Mumbai",
        version: "Vxi",
      },
      {
        price: 10000,
        city: "Chennai",
        version: "Vdi",
      },
    ];
    expect(
      SelectionReducer(undefined, {
        type: "CHANGE_PRICE_VERSION_CITY_LIST",
        data: priceDetailsList,
      }).priceVersionCityList
    ).toEqual(priceDetailsList);
  });
});

const defaultState = {
  selected: {
    city: "",
    version: "",
    price: "",
  },
  list: {
    city: [],
    version: [],
  },
  showToolTip: false,
  priceVersionCityList: [
    {
      price: 50000,
      city: "Mumbai",
      version: "Vxi",
    },
    {
      price: 10000,
      city: "Chennai",
      version: "Vdi",
    },
  ],
};

describe("Test Reducer with default state also containing PriceVersionCityList", () => {

  it("should change the selected price - with invalid city and version", () => {
    const city = "Bangalore",
      version = "Vdi";
    expect(
      SelectionReducer(defaultState, {
        type: "CHANGE_SELECTED_PRICE",
        selectedVersion: version,
        selectedCity: city,
      }).selected.price
    ).toEqual('');
  });

  it("should change the selected price - with valid city and version", () => {
    const city = "Mumbai",
      version = "Vxi";
    expect(
      SelectionReducer(defaultState, {
        type: "CHANGE_SELECTED_PRICE",
        selectedVersion: version,
        selectedCity: city,
      }).selected.price
    ).toEqual(50000);
  });

});
