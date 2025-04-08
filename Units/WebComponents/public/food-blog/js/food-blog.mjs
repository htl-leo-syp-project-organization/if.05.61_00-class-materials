import { FoodBlogEntry } from "../components/food-blog-entry.mjs"
window.onload = function() {
    const foodBlogEntries = [new FoodBlogEntry({
        "title": "The Croissant",
        "text": "Warm, crispy, simply delicious.",
        "imageUrl": "images/croissant.jpg",
        "liked": false
    }),
    new FoodBlogEntry({
        "title": "The Cherries",
        "text": "Red and juicy.",
        "imageUrl": "images/cherries.jpg",
        "liked": false
    }),
    new FoodBlogEntry({
        "title": "The Popsicle",
        "text": "A refreshing summer treat.",
        "imageUrl": "images/popsicle.jpg",
        "liked": false
    }),
    new FoodBlogEntry({
        "title": "A Salmon A Day",
        "text": "... keeps the doctor away.",
        "imageUrl": "images/salmon.jpg",
        "liked": false
    })
]

    const view = document.querySelector('h-stack')
    view.viewModel = foodBlogEntries

    const updateButton = document.querySelector('#update-button')
    updateButton.addEventListener('click', () => {
        foodBlogEntry.toggleLike()
    })
}
