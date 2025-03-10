import { setServerUrl, getDataFrom } from './rest.mjs'
import { renderBlogEntries } from './html-renderer.mjs'

document.body.onload = async function() {
    const burgerMenuButton = document.querySelector('#burger-menu-button')
    burgerMenuButton.addEventListener('click', showSidebar)

    const closeSidebarItems = document.querySelector('#my-sidebar').childNodes
    closeSidebarItems.forEach(item => item.addEventListener('click', hideSidebar))

    setServerUrl('http://localhost:3000')
    const entries = await loadPostsFromServer()
    renderBlogEntries(entries)
}

async function loadPostsFromServer() {
    const blogEntries = await getDataFrom('/posts')
    return blogEntries
}

// Script to open and close sidebar
function showSidebar() {
        document.querySelector("#my-sidebar").style.display = "block"
}
    
function hideSidebar() {
    document.querySelector("#my-sidebar").style.display = "none"
}
