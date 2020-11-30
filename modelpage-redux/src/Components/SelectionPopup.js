import React from "react";
import { connect } from "react-redux";
import Popup from "./Popup";

import { handleChange, changeToolTipStatus } from "../utils";

// actions
import {
  changeSelectedCity,
  changeSelectedVersion,
  changeShowToolTip,
  changeSelectedPrice,
  changePopupStatus,
  changePriceDetailList,
} from "../actions/Actions";

import {
  getSelectedCity,
  getSelectedVersion,
  getCityList,
  getVersionList,
  getPopupStatus,
} from "../Selectors/Selector";

export const SelectionPopup = (props) => {
  const list = props.type === "City" ? props.cityList : props.versionList;
  const title = `Select ${props.type ? props.type : "City"}`;
  const selectedText =
    props.type === "City" ? props.city?.name : props.version?.name;

  const renderList = list.map((element, index) => {
    return (
      <p
        className="popup-elements"
        key={index}
        value={element.name}
        onClick={() => handleChange(props, element, changeToolTipStatus)}
      >
        {element.name}
      </p>
    );
  });

  return (
    <React.Fragment>
      <div
        className="selection-popup"
        onClick={() => props.changePopupStatus(props.type, true)}
      >
        <span className="selection-popup-type">{props.type}: </span>
        <p className="selection-popup-text">
          {selectedText ?? "Select Nearby City"}
        </p>
      </div>
      {props.popupStatus.type === props.type && props.popupStatus.isOpen ? (
        <Popup
          changeIsOpen={props.changePopupStatus}
          type={props.type}
          title={title}
        >
          <div>{renderList}</div>
        </Popup>
      ) : null}
    </React.Fragment>
  );
};

export default connect(
  (store) => ({
    city: getSelectedCity(store),
    version: getSelectedVersion(store),
    cityList: getCityList(store),
    versionList: getVersionList(store),
    popupStatus: getPopupStatus(store),
  }),
  {
    changeSelectedCity,
    changeSelectedVersion,
    changeShowToolTip,
    changeSelectedPrice,
    changePopupStatus,
    changePriceDetailList,
  }
)(SelectionPopup);
