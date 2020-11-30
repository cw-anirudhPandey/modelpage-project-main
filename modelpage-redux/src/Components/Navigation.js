import React from "react";
import Image from "./Image";
import { connect } from "react-redux";

import {
  changeSelectedCity,
  changeShowToolTip,
  changeSelectedPrice,
  changePopupStatus,
} from "../actions/Actions";

import {
  getSelectedCity,
  getSelectedVersion,
  getCityList,
  getShowToolTipStatus,
  getPopupStatus,
} from "../Selectors/Selector";

export const Navigation = (props) => {
  return (
    <React.Fragment>
      <span
        onClick={() => props.changePopupStatus(props.type, true)}
        className="tooltip nav-icon"
      >
        <Image
          width={"20"}
          height={"20"}
          url={"https://www.flaticon.com/svg/static/icons/svg/67/67347.svg"}
        />
        {props.showToolTip ? (
          <span className="tooltiptext">{props.city?.name}</span>
        ) : null}
      </span>
    </React.Fragment>
  );
};

export default connect(
  (store) => ({
    city: getSelectedCity(store),
    cityList: getCityList(store),
    version: getSelectedVersion(store),
    showToolTip: getShowToolTipStatus(store),
    popupStatus: getPopupStatus(store),
  }),
  {
    changeSelectedCity,
    changeShowToolTip,
    changeSelectedPrice,
    changePopupStatus,
  }
)(Navigation);
