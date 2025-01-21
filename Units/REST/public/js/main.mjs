import { getData } from './rest.mjs'
import { renderOneGridLine } from './html-renderer.mjs'

document.body.onload = function() {
    const burgerMenuButton = document.querySelector('#burger-menu-button')
    burgerMenuButton.addEventListener('click', showSidebar)

    const closeSidebarItems = document.querySelectorAll('.sidebar-item')
    closeSidebarItems.forEach(item => item.addEventListener('click', hideSidebar))
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

    // Script to open and close sidebar
export function showSidebar() {
        document.getElementById("my-sidebar").style.display = "block"
}
    
export function hideSidebar() {
    document.getElementById("my-sidebar").style.display = "none"
}
