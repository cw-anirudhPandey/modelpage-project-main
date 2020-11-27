export const handleChange = (props, selectedText, changeToolTipStatus) => {
  if (props.type === "City") {
    props.changeSelectedCity(selectedText);
    changeToolTipStatus(props);
  } else if (props.type === "Version") {
    props.changeSelectedVersion(selectedText);
  }
  props.changeSelectedPrice(props.version, props.city);
  props.changePopupStatus(props.type, false);
};

export const changeToolTipStatus = (props) => {
  props.changeShowToolTip(true);
  let timerId = setTimeout(() => {
    props.changeShowToolTip(false);
  }, 5000);
};
