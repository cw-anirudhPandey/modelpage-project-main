import React from "react";
import "../css/styles.css";

const Popup = (props) => {
  return (
    <div className="popup-box">
      <div className="box">
        <h3 className="popup-title">{props.title}</h3>
        {props.children}
        <button
          onClick={() => {
            console.log('hi');
            props.changeIsOpen(props.type, false);
          }}
        >
          Close
        </button>
      </div>
    </div>
  );
};

export default Popup;
