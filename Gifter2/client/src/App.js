import React from "react";
import "./App.css";
import PostForm from "./components/PostForm";
import PostList from "./components/PostList";
import PostSearch from "./components/PostSearch"

function App() {
  return (
    <div className="App">
      <PostForm />
      <PostList />
      <PostSearch />
    </div>
  );
}

export default App;
