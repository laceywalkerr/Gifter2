import React from "react";
import { BrowserRouter as Router } from "react-router-dom";
import "./App.css";
// import PostForm from "./components/PostForm";
// import PostList from "./components/PostList";
// import PostSearch from "./components/PostSearch"
import ApplicationViews from "./components/ApplicationViews";

function App() {
  return (
    <div className="App">
      <Router>
        <ApplicationViews />
      </Router>
      {/* <PostForm />
      <PostList />
      <PostSearch /> */}
    </div>
  );
}

export default App;

