"use strict"

document.body.onload = function() {
    loadDataFromServer()
}

async function loadDataFromServer() {
    const blogEntries = await getData("http://localhost:3000/posts");
    console.log(blogEntries);
}

// Script to open and close sidebar
function showSidebar() {
    document.getElementById("mySidebar").style.display = "block";
  }
   
  function hideSidebar() {
    document.getElementById("mySidebar").style.display = "none";
  }
  
  async function getData(fromUrl) {
    try {
      const response = await fetch(fromUrl);
      if (!response.ok) {
        throw new Error(`Response status: ${response.status}`);
      }
  
      const json = await response.json();
      return json
    } catch (error) {
      console.error(error.message);
    }
  }