import React from "react";
import Image from "./Image";

const StarRating = (props) => {
  if(!props.rating)
  return null;
  const detail = {
    filled: {
      url: "https://www.flaticon.com/svg/static/icons/svg/2164/2164323.svg",
      alt: "Filled Star"
    },
    empty: {
      url: "https://www.flaticon.com/svg/static/icons/svg/2164/2164197.svg",
      alt: "Empty Star"
    },
  }
  const { rating } = props;
  const toRender = rating && (rating >= 0 && rating <= 5);
  return (
    toRender &&
    Array(5)
      .fill()
      .map((el, index) => {
        return (
          <span key={index}>
            <Image
              url={detail[Math.floor(rating) <= index ? "filled" : "empty"]["url"]
              }
              alt={detail[Math.floor(rating) <= index ? "filled" : "empty"]["alt"]}
              height={17}
              width={17}
            />
          </span>
        );
      })
  );
};

export default StarRating;
