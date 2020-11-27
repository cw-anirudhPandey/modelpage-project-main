import React, { useEffect, useState } from "react";
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
  const [selectedCitystate, setSelectedCitystate] = useState(props.city);
  // const [selectedVersionstate, setSelectedVersionstate] = useState(props.version);

  useEffect(() => {
    console.log("[selectedCitystate] updated");
  }, [selectedCitystate])

  const renderList = list.map((element, index) => {
    return (
      <li
        style={{ cursor: "pointer" }}
        key={index}
        value={element.name}
        onClick={() => handleChange(props, element.name, changeToolTipStatus)}
      >
        {element.name}
      </li>
    );
  });

  return (
    <div className="selection-popup">
      <h4>
        {props.type}:{" "}
        <span>{props.type === "City" ? props.city : props.version}</span>
      </h4>
      <button onClick={() => props.changePopupStatus(props.type, true)}>
        Select {props.type}
      </button>
      {props.popupStatus.type === props.type && props.popupStatus.isOpen ? (
        <Popup
          changeIsOpen={props.changePopupStatus}
          type={props.type}
          title={title}
        >
          <ul>{renderList}</ul>
        </Popup>
      ) : null}
    </div>
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
  }
)(SelectionPopup);
