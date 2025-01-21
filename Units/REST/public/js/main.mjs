import { getData } from './rest.mjs';
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
