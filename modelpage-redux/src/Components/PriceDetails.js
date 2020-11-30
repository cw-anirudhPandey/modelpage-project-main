import React from "react";
import { connect } from "react-redux";

import { formatPrice } from '../utils';

function mapStateToProps(store) {
  return {
    price: store.selected.price,
  };
}

const PriceDetails = (props) => {
  return (
    <div>
      <h2 className="center-container">₹ {formatPrice(props?.price)} Lakh</h2>
      <h5 className="center-container">On Road Type</h5>
    </div>
  );
};

export default connect(mapStateToProps)(PriceDetails);
