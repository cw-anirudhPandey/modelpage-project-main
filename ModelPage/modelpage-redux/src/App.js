import React from "react";
import Header from "./Components/Header";
import Content from "./Components/Content";
import { BrowserRouter as Router } from "react-router-dom";
import { Route } from "react-router-dom";

const Comp = ({ match }) => {
  return (
    <React.Fragment>
      <Header />
      <Content match={match} />
    </React.Fragment>
  );
};

const App = () => {
  return (
    <Router>
      <div>
        <Route path="/model/:modelId" component={Comp} />
      </div>
    </Router>
  );
};

export default App;
