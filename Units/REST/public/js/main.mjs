import { getData } from './rest.mjs'
import { renderOneGridLine } from './htmlRenderer.mjs'

document.body.onload = function() {
  // const sideBar = document.querySelector('#mySidebar')
  // sideBar.addEventListener('click', hideSidebar)
    loadDataFromServer()
}

async function loadDataFromServer() {
    const blogEntries = await getData("http://localhost:3000/posts")
    const grid = document.querySelector('#food-grid')
    for (let i = 0; i < blogEntries.length; i+=4) {
        const oneGridLine = renderOneGridLine(blogEntries.slice(i, i+4))
        grid.appendChild(oneGridLine)
    }
    // renderOneGridLine(blogEntries.slice(0, 4))
    console.log(blogEntries)
}
