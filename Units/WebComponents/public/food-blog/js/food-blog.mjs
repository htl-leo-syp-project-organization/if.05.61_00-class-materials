window.onload = function() {
    const updateButton = document.querySelector('#update-button')
    updateButton.addEventListener('click', () => {
        const foodBlogEntry = document.querySelector('food-blog-entry')
        foodBlogEntry.data.liked = true
    })
}
