export function renderOneGridLine(blogEntries) {
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
  }
  