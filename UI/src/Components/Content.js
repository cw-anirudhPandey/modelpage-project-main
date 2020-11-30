import React, { useEffect, useState } from "react";
import { connect } from "react-redux";

// Utils
import { isDataObjectEmpty, modelDetailsApiCall } from "../utils";

// Components
import Image from "./Image";
import LinkList from "./LinkList";
import ModelDetails from "./ModelDetails";
import SelectionPopup from "./SelectionPopup";
import PriceDetails from "./PriceDetails";
import EmiWidget from "./EmiWidget";
import Message from "./Message";

// actions
import {
  changeSelectedCity,
  changeSelectedVersion,
  changeSelectedPrice,
  changeCityList,
  changeVersionList,
  changePriceDetailList,
} from "../actions/Actions";

// constants
import { defaultMsg, emiDetails, listOfLinks } from "../constants";

const Content = (props) => {
  const [data, setData] = useState({});
  const [carName, setCarName] = useState("");
  const [carImage, setCarImage] = useState("");
  const [msg, setMessage] = useState(defaultMsg);
  const [showContent, setShowContent] = useState(false);
  const [reviewDetails, setReviewDetails] = useState({});
  const modelId = props?.match?.params?.modelId;

  useEffect(() => {
    modelDetailsApiCall(modelId, setData, setShowContent, setMessage);
  }, []);

  useEffect(() => {
    if (!isDataObjectEmpty(data) && data.carPriceDetails?.length > 0) {
      // setting data in store.
      props.changeCityList(data?.citySet);
      props.changeVersionList(data?.versionSet);
      props.changeSelectedVersion(data?.versionSet[0]);
      props.changePriceDetailList(data?.carPriceDetails);
      props.changeSelectedPrice();
      // change state data.
      setShowContent(true);
      setReviewDetails({
        rating: data.carReview.rating,
        totalReviewCount: data.carReview.count,
      });
      setCarName(`${data.carMake.makeName} ${data.carModel.modelName}`);
      setCarImage(data.carImage.imageUrl);
    } else if(data.carPriceDetails) {
      setShowContent(false);
      setMessage("Some problem occured");
    }
  }, [data]);

  return (
    <div>
      {showContent ? (
        <React.Fragment>
          <Image url={carImage} alt={"Car"} height={202} width={340} />
          <LinkList listOfLinks={listOfLinks} />
          <ModelDetails name={carName} reviewDetails={reviewDetails} />
          <SelectionPopup type={"Version"} />
          <SelectionPopup type={"City"} />
          <PriceDetails />
          <EmiWidget details={emiDetails} />
        </React.Fragment>
      ) : (
        <Message message={msg} />
      )}
    </div>
  );
};

export default connect(null, {
  changeSelectedCity,
  changeSelectedVersion,
  changeSelectedPrice,
  changeCityList,
  changeVersionList,
  changePriceDetailList,
})(Content);
