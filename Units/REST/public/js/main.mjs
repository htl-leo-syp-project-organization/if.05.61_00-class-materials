import { getData } from './rest.mjs'
import { renderOneGridLine } from './html-renderer.mjs'

document.body.onload = async function() {
    const burgerMenuButton = document.querySelector('#burger-menu-button')
    burgerMenuButton.addEventListener('click', showSidebar)

    const closeSidebarItems = document.querySelector('#my-sidebar').childNodes
    closeSidebarItems.forEach(item => item.addEventListener('click', hideSidebar))
    const entries = await loadDataFromServer()
    renderBlogEntries(entries)
}

async function loadDataFromServer() {
    const blogEntries = await getData("http://localhost:3000/posts")
    return blogEntries
}

function renderBlogEntries(blogEntries) {
    const grid = document.querySelector('#food-grid')
    for (let i = 0; i < blogEntries.length; i+=4) {
        const oneGridLine = renderOneGridLine(blogEntries.slice(i, i+4))
        grid.appendChild(oneGridLine)
    }
}

    // Script to open and close sidebar
function showSidebar() {
        document.querySelector("#my-sidebar").style.display = "block"
}
    
function hideSidebar() {
    document.querySelector("#my-sidebar").style.display = "none"
}
