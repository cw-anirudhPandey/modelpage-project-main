const applicationData = {
  selected: {
    city: {},
    version: {},
    price: "",
  },
  list: {
    city: [],
    version: [],
  },
  showToolTip: false,
  priceDetailsList: [],
  popup: {
    type: "",
    isOpen: false,
  },
};

// const applicationData = {
//   selected: {
//     city: "",
//     version: "",
//     price: "",
//   },
//   list: {
//     city: ["Mumbai", "Chennai", "Bangalore", "Delhi"],
//     version: ["v1", "v2", "v3", "v4"],
//   },
//   showToolTip: false,
//   popup: {
//     type: "",
//     isOpen: false,
//   },
//   priceVersionCityList: [
//     {
//       price: 40000,
//       city: "Mumbai",
//       version: "v1",
//     },
//     {
//       price: 200,
//       city: "Bangalore",
//       version: "v4",
//     },
//     {
//       price: 50,
//       city: "Chennai",
//       version: "v2",
//     },
//     {
//       price: 402030,
//       city: "Delhi",
//       version: "v1",
//     },
//     {
//       price: 10000,
//       city: "Chennai",
//       version: "v3",
//     },
//   ],
// };

function SelectionReducer(state = applicationData, action) {
  const newState = {
    ...state,
  };
  switch (action.type) {
    case "CHANGE_SELECTED_CITY":
      newState.selected.city = action.data;
      return newState;
    case "CHANGE_SELECTED_VERSION":
      newState.selected.version = action.data;
      return newState;
    case "CHANGE_SELECTED_PRICE":
      if (newState.priceDetailsList) {
        newState.priceDetailsList.forEach((element) => {
          if (element.versionId === newState.selected.version?.id) {
            newState.selected.price = element.value;
            return newState;
          }
        });
      }
      return newState;
    case "CHANGE_SHOW_TOOLTIP":
      newState.showToolTip = action.data;
      return newState;
    case "CHANGE_POPUP_STATUS":
      newState.popup = action.data;
      return newState;
    case "CHANGE_CITY_LIST":
      newState.list.city = action.data;
      return newState;
    case "CHANGE_VERSION_LIST":
      newState.list.version = action.data;
      return newState;
    case "CHANGE_PRICE_DETAIL_LIST":
      newState.priceDetailsList = action.data;
      return newState;

    default:
      return state;
  }
}

export default SelectionReducer;
