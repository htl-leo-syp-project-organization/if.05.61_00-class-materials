import { getData } from './rest.mjs'
import { renderOneGridLine } from './htmlRenderer.mjs'

document.body.onload = function() {
    loadDataFromServer()
}

async function loadDataFromServer() {
    const blogEntries = await getData("http://localhost:3000/posts")
    renderOneGridLine(blogEntries.slice(0, 4))
    console.log(blogEntries)
}

// Script to open and close sidebar
function showSidebar() {
    document.getElementById("mySidebar").style.display = "block"
}
   
function hideSidebar() {
  document.getElementById("mySidebar").style.display = "none"
}
