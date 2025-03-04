export function renderBlogEntries(blogEntries) {
  const grid = document.querySelector('#food-grid')
  for (let i = 0; i < blogEntries.length; i+=4) {
      const oneGridLine = renderOneGridLine(blogEntries.slice(i, i+4))
      grid.appendChild(oneGridLine)
  }
}

function renderOneGridLine(blogEntries) {
  const gridLine = document.createElement('div')
  gridLine.classList.add('w3-row-padding')
  gridLine.classList.add('w3-padding-16')
  gridLine.classList.add('w3-center')
  blogEntries.forEach(blogEntry => {
    const oneGridEntry = renderOneGridCell(blogEntry)
    gridLine.appendChild(oneGridEntry)
  })
  return gridLine
}
  
function renderOneGridCell(blogEntry) {
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
}
