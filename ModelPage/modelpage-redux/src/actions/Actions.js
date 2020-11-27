function changeSelectedCity(selectedText) {
  return {
    type: "CHANGE_SELECTED_CITY",
    data: selectedText,
  };
}

function changeSelectedVersion(selectedText) {
  return {
    type: "CHANGE_SELECTED_VERSION",
    data: selectedText,
  };
}

function setSelectedPrice(selectedPrice) {
  return {
    type: "SET_SELECTED_PRICE",
    data: selectedPrice
  };
}

function changeSelectedPrice(selectedVersion, selectedCity) {
  return {
    type: "CHANGE_SELECTED_PRICE",
    selectedVersion,
    selectedCity
  };
}

function changeShowToolTip(showToolTip) {
  return {
    type: "CHANGE_SHOW_TOOLTIP",
    data: showToolTip,
  };
}

function changePopupStatus(type, isOpen) {
  return {
    type: "CHANGE_POPUP_STATUS",
    data: {
      type,
      isOpen
    }
  };
}

function changeCityList(cityList) {
  return {
    type: "CHANGE_CITY_LIST",
    data: cityList,
  };
}

function changeVersionList(versionList) {
  return {
    type: "CHANGE_VERSION_LIST",
    data: versionList,
  };
}

function changePriceVersionCityList(priceVersionCityList) {
  return {
    type: "CHANGE_PRICE_VERSION_CITY_LIST",
    data: priceVersionCityList,
  };
}

export {
  changeCityList,
  changeVersionList,
  changeSelectedCity,
  changeSelectedVersion,
  changeSelectedPrice,
  changeShowToolTip,
  changePopupStatus,
  changePriceVersionCityList,
};
