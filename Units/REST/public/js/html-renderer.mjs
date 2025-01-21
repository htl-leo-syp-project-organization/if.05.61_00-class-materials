export function renderOneGridLine(blogEntries) {
    const gridLine = document.createElement('div')
    gridLine.classList.add('w3-row-padding')
    gridLine.classList.add('w3-padding-16')
    gridLine.classList.add('w3-center')
    blogEntries.forEach(blogEntry => {
      const oneGridEntry = renderOneGrid(blogEntry)
      gridLine.appendChild(oneGridEntry)
    })
    return gridLine
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
  

//   <!-- First Photo Grid-->
//   <div class="w3-row-padding w3-padding-16 w3-center" id="food">
//   </div>
  
//   <!-- Second Photo Grid-->
//   <div class="w3-row-padding w3-padding-16 w3-center">
//     <div class="w3-quarter">
//       <img src="/images/popsicle.jpg" alt="Popsicle" style="width:100%">
//       <h3>All I Need Is a Popsicle</h3>
//       <p>Lorem ipsum text praesent tincidunt ipsum lipsum.</p>
//     </div>
//     <div class="w3-quarter">
//       <img src="/images/salmon.jpg" alt="Salmon" style="width:100%">
//       <h3>Salmon For Your Skin</h3>
//       <p>Once again, some random text to lorem lorem lorem lorem ipsum text praesent tincidunt ipsum lipsum.</p>
//     </div>
//     <div class="w3-quarter">
//       <img src="/images/sandwich.jpg" alt="Sandwich" style="width:100%">
//       <h3>The Perfect Sandwich, A Real Classic</h3>
//       <p>Just some random text, lorem ipsum text praesent tincidunt ipsum lipsum.</p>
//     </div>
//     <div class="w3-quarter">
//       <img src="/images/croissant.jpg" alt="Croissant" style="width:100%">
//       <h3>Le French</h3>
//       <p>Lorem lorem lorem lorem ipsum text praesent tincidunt ipsum lipsum.</p>
//     </div>
