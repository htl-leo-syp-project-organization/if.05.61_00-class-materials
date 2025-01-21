import { getData } from './rest.mjs'

document.body.onload = function() {
    loadDataFromServer()
}

async function loadDataFromServer() {
    const blogEntries = await getData("http://localhost:3000/posts")
    renderOneGridLine(blogEntries.slice(0, 4))
    console.log(blogEntries)
}

function renderOneGridLine(blogEntries) {
  const grid = document.querySelector('#food')
  blogEntries.forEach(blogEntry => {
    const oneGridEntry = renderOneGrid(blogEntry)
    grid.appendChild(oneGridEntry)
  })
}

function renderOneGrid(blogEntry) {
  const newDiv = document.createElement('div')
  newDiv.classList.add('w3-quarter')

  const newImg = document.createElement('img')
  newImg.src = blogEntry.imagePath
  newImg.alt = 'food image'
  newImg.style.width = '100%'

  const newH3 = document.createElement('h3')
  newH3.textContent = blogEntry.title

  const newP = document.createElement('p')
  newP.textContent = blogEntry.text

  newDiv.appendChild(newImg)
  newDiv.appendChild(newH3)
  newDiv.appendChild(newP)

  return newDiv
  //   return `
  //     <div class="w3-quarter">
  //       <img src=${blogEntry.imagePath} alt="food image" style="width:100%">
  //       <h3>${blogEntry.title}</h3>
  //       <p>${blogEntry.text}</p>
  //     </div>
}

// Script to open and close sidebar
function showSidebar() {
    document.getElementById("mySidebar").style.display = "block"
}
   
function hideSidebar() {
  document.getElementById("mySidebar").style.display = "none"
}
