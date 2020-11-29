import React, { useEffect, useState } from "react";
import axios from "axios";
import { connect } from "react-redux";

// Components
import Image from "./Image";
import LinkList from "./LinkList";
import ModelDetails from "./ModelDetails";
import SelectionPopup from "./SelectionPopup";
import PriceDetails from "./PriceDetails";
import EmiWidget from "./EmiWidget";

// actions
import {
  changeSelectedCity,
  changeSelectedVersion,
  changeSelectedPrice,
  changeCityList,
  changeVersionList,
  changePriceDetailList,
} from "../actions/Actions";

// Props data
const listOfLinks = [
  {
    title: "Colors",
    href: "colors",
    imgUrl:
      "https://cdn.zeplin.io/5f489c7913d2623062e791d1/assets/4E6F07CF-813B-4F3C-8798-0283BD8E9B04.svg",
  },
  {
    title: "Images",
    href: "images",
    imgUrl:
      "https://cdn.zeplin.io/5f489c7913d2623062e791d1/assets/E778A3F2-4C9A-44A3-9591-91551C68B3C3.svg",
  },
  {
    title: "Videos",
    href: "videos",
    imgUrl:
      "https://cdn.zeplin.io/5f489c7913d2623062e791d1/assets/83BBF4DC-B856-47FA-B8B1-92AAB991711C.svg",
  },
  {
    title: "360 view",
    href: "view",
    imgUrl:
      "https://cdn.zeplin.io/5f489c7913d2623062e791d1/assets/197D5552-0F5E-4ED5-B14B-DADE28E826EF.svg",
  },
];

const emiDetails = {
  cost: "10,716",
  duration: "5 years",
}

const Content = (props) => {
  const [data, setData] = useState({});
  const [carName, setCarName] = useState("");
  const [carImage, setCarImage] = useState("");
  const [reviewDetails, setReviewDetails] = useState({});
  const modelId = props?.match?.params?.modelId;

  useEffect(() => {
    (async () => {
      try {
        const response = await axios.get("http://localhost:5000/api/model/" +modelId);
        console.log(response.data);
        if (response.data) {
          setData(response.data);
        }
      } catch (error) {
        console.error(error);
      }
    })();
  }, []);

  useEffect(() => {
    if (!(Object.keys(data).length === 0 && data.constructor === Object)) {
      
      // setting data in store.
      props.changeCityList(data?.citySet);
      props.changeVersionList(data?.versionSet);
      // props.changeSelectedCity(data?.citySet[0]); -----------------
      props.changeSelectedVersion(data?.versionSet[0]);
      props.changePriceDetailList(data?.priceDetailList);
      props.changeSelectedPrice();
      // change state data.
      setReviewDetails({
        rating: data.reviewDetail.rating,
        totalReviewCount: data.reviewDetail.count
      });
      setCarName(`${data.makeDetail.makeName} ${data.modelDetail.modelName}`);
      setCarImage(data.imageDetail.imageUrl);
    }
  }, [data]);

  return (
    <React.Fragment>
      <Image url={carImage} alt={"Car"} height={202} width={340} />
      <LinkList listOfLinks={listOfLinks} />
      <ModelDetails name={carName} reviewDetails={reviewDetails} />
      <SelectionPopup type={"Version"} />
      <SelectionPopup type={"City"} />

      <PriceDetails />
      <EmiWidget details={emiDetails} />
    </React.Fragment>
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
