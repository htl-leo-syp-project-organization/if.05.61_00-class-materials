import { getData } from './rest.mjs'
import { renderBlogEntries } from './html-renderer.mjs'

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

// Script to open and close sidebar
function showSidebar() {
        document.querySelector("#my-sidebar").style.display = "block"
}
    
function hideSidebar() {
    document.querySelector("#my-sidebar").style.display = "none"
}
