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

function changeSelectedPrice() {
  return {
    type: "CHANGE_SELECTED_PRICE"
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

function changePriceDetailList(priceVersionCityList) {
  return {
    type: "CHANGE_PRICE_DETAIL_LIST",
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
  changePriceDetailList,
};
