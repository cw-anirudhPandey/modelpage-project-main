import React from "react";
import Image from "./Image";

const Link = (props) => {
  const { title, href, imgUrl, height, width } = props.link;

  return (
    <span className="link">
      <Image
        url={imgUrl}
        alt={title}
        height={height || 20}
        width={width || 20}
      />
      <a href={href} className="link-title">
        {title}
      </a>
    </span>
  );
};

export default Link;
