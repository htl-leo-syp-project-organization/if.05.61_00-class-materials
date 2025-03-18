import { getDataFrom, patchDataFor } from './rest.mjs' // dependency to rest.mjs; bad bad bad; don't try this at home

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
  const newDiv=createContainerDiv(blogEntry.id)
  const newImg=createBlogImage(blogEntry)
  const likeSymbol=createLikeSymbol(blogEntry)
  const newH3=createBlogTitle(blogEntry)
  const newP=createBlogText(blogEntry)
  putGridCellTogether(newDiv, newImg, likeSymbol, newH3, newP)
  return newDiv
}

function createContainerDiv(id) {
  const newDiv=document.createElement('div')
  newDiv.id=id // id is used to identify the blog entry; bad bad bad; don't try this at home
  newDiv.classList.add('w3-quarter')
  return newDiv
}

function createBlogImage(blogEntry) {
  const newImg=document.createElement('img')
  newImg.src=blogEntry.imagePath
  newImg.alt='food image'
  newImg.style.width='100%'
  return newImg
}

function createLikeSymbol(blogEntry) {
  const likeSymbol=document.createElement('img')
  if (blogEntry.likes > 0) {
    likeSymbol.src='images/heart-red.png'
  } else {
    likeSymbol.src='images/heart-empty.png'
  }
  likeSymbol.alt='like symbol'
  likeSymbol.style.width='20px'
  likeSymbol.style.height='20px'
  likeSymbol.style.position='relative'
  likeSymbol.style.left='46.5%'
  likeSymbol.style.top='0px'
  likeSymbol.style.zIndex='1'
  likeSymbol.style.cursor='pointer'
  likeSymbol.addEventListener('click', () => {
    const patchObject = {
      id: likeSymbol.parentElement.id,
      likes: blogEntry.likes
    }
    if (blogEntry.likes > 0) {
      likeSymbol.src='images/heart-empty.png'
      blogEntry.likes = 0
      patchObject.likes = 0
    } else {
      likeSymbol.src='images/heart-red.png'
      blogEntry.likes = 1
      patchObject.likes = 1
    }
    patchPostFor(likeSymbol.parentElement.id, patchObject)
  })
  return likeSymbol
}

function patchPostFor(id, data) {
  patchDataFor(`/posts/${id}`, data)
}

function createBlogTitle(blogEntry) {
  const newH3=document.createElement('h3')
  newH3.textContent=blogEntry.title
  return newH3
}

function createBlogText(blogEntry) {
  const newP=document.createElement('p')
  newP.textContent=blogEntry.text
  return newP
}

function putGridCellTogether(newDiv, newImg, likeSymbol, newH3, newP) {
  newDiv.appendChild(newImg)
  newDiv.appendChild(likeSymbol)
  newDiv.appendChild(newH3)
  newDiv.appendChild(newP)
}

