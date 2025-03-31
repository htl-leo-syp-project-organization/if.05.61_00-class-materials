import { FoodBlogEntry } from "../components/food-blog-entry.mjs"
window.onload = function() {
    const foodBlogEntry = new FoodBlogEntry({
        "title": "The Croissant",
        "text": "Warm, crispy, simply delicious.",
        "imageUrl": "images/croissant.jpg",
        "liked": false
    })

    const view = document.querySelector('food-blog-entry')
    view.foodBlogEntry = foodBlogEntry

    const updateButton = document.querySelector('#update-button')
    updateButton.addEventListener('click', () => {
        foodBlogEntry.toggleLike()
    })
}
