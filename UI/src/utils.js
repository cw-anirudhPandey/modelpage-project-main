import axios from 'axios';

export const handleChange = (props, selectedText, changeToolTipStatus) => {
  if (props.type === "City") {
    props.changeSelectedCity(selectedText);
    changeToolTipStatus(props);
    cityApiCall(props.city?.id, props);
  } else if (props.type === "Version") {
    props.changeSelectedVersion(selectedText);
  }
  props.changeSelectedPrice();
  props.changePopupStatus(props.type, false);
};

export const changeToolTipStatus = (props) => {
  props.changeShowToolTip(true);
  setTimeout(() => {
    props.changeShowToolTip(false);
  }, 5000);
};

const cityApiCall = async (cityId, props) => {
  try {
    const response = await axios.get("http://localhost:5000/api/price/"+cityId);
    if (response.data) {
      props.changePriceDetailList(response.data);
      props.changeSelectedPrice();
    }
  } catch (error) {
    console.error(error);
  }
}

export const isDataObjectEmpty = (data) => {
  return (Object.keys(data).length === 0 && data.constructor === Object);
}  

export const formatPrice = (price) => {
  if(price && price.length === 0)
    return "";
  else if(price && price.length >= 3) {
    return price.slice(0, 1) + "." + price.slice(1, 3); 
  }
}

export const modelDetailsApiCall = async (modelId, setData, setShowContent, setMessage) => {
  try {
    const response = await axios.get(
      "http://localhost:5000/api/model/" + modelId
    )
    if(response.data) {
      setData(response.data);
    }
  } catch (error) {
    setShowContent(false);
    setMessage("Some problem occured " + error);
  }
}


