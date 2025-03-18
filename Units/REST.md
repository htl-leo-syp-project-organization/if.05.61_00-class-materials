# REST

## Backend
### What to install
- [node.js](https://nodejs.org/)
- `npm install json-server` [Github page of json-server](https://github.com/typicode/json-server)
- If you use Visual Studio Code: REST Client

### Experiment with the json-server
- Create a directory for your experiments, start Visual Studio Code and create a file named `db.json` (as an example).
- Go to the console and fire up the json-server by `npx json-server db.json`.

Some ideas for experimenting could be:
1. Get all posts
2. Get a specific post
3. Add a post
4. Delete a post
5. Put a post
6. Patch a post
7. Get all comments
8. Embed comments in all posts

For more follow the instructions and suggestions on the [Github page of json-server](https://github.com/typicode/json-server)

## Frontend
### Prepare your frontend
- Download the source of the Food Blog Template from [w3schools](https://www.w3schools.com/w3css/w3css_templates.asp).
- Create a folder named `public` in your directory and store `index.html` there.
- Download the images from [the repo](REST/public/images.zip) and add them to the image directory. Figure out in the source code how to name the directory or rename the path in the source code to name the directory as you want.
- Test whether you can see a working template in your browser

### Some Very Basic Cleanup
1. Set a proper title
2. Rename the image folder to a proper name if not already done
3. Rename the event triggers properly
4. Put a nice photo from you as `chef.jpg`
5. ...

### A Bit Advanced Cleanup
Since we plan to add more JavaScript to our little project we want to get rid off the JS code in our index.html. Of course we are doing professional JS we use modules.

1. Create a directory `js` in your directory
2. Create a file `main.mjs` there
3. Remove the inline event triggers
4. Move the functions to show and hide the side bar into the module and name it properly
5. Add a `document.body.onload` trigger to the module where you add the `onclick` event listeners to the burger menu button and the side bar items.
6. Add a script tag `<script type="module" src="/js/main.mjs"></script>` at the end of the body.

### JavaScript Fetch API to Get Data from Backend
We begin this part by fixing our playground db we used at the very beginning of this lesson. So lets replace the content of the file `db.json` by some nice food data we need for our project here.

```json
{
  "posts": [
    {
      "id": "1",
      "title": "The Perfect Sandwich, A Real NYC Classic",
      "text": "Just some random text, lorem ipsum text praesent tincidunt ipsum lipsum.",
      "imagePath": "images/sandwich.jpg",
      "views": 100
    },
    {
      "id": "2",
      "title": "Cherries, interrupted",
      "text": "Just some random text, lorem ipsum text praesent tincidunt ipsum lipsum.",
      "imagePath": "images/cherries.jpg",
      "views": 200
    },
    {
      "id": "9d75",
      "title": "Le French",
      "text": "Just some random text, lorem ipsum text praesent tincidunt ipsum lipsum.",
      "imagePath": "images/croissant.jpg",
      "views": 0
    },
    {
      "id": "bc7d",
      "title": "All I Need Is a Popsicle",
      "text": "Just some random text, lorem ipsum text praesent tincidunt ipsum lipsum.",
      "imagePath": "images/popsicle.jpg",
      "views": 0
    },
    {
      "id": "62ef",
      "title": "Salmon For Your Skin",
      "text": "Just some random text, lorem ipsum text praesent tincidunt ipsum lipsum.",
      "imagePath": "images/salmon.jpg",
      "views": 0
    },
    {
      "id": "0a9f",
      "title": "Let Me Tell You About This Steak",
      "text": "Just some random text, lorem ipsum text praesent tincidunt ipsum lipsum.",
      "imagePath": "images/steak.jpg",
      "views": 0
    },
    {
      "id": "ab6f",
      "title": "Once Again, Robust Wine and Vegetable Pasta",
      "text": "Just some random text, lorem ipsum text praesent tincidunt ipsum lipsum.",
      "imagePath": "images/wine.jpg",
      "views": 0
    },
    {
      "title": "Post # 8",
      "views": 0,
      "text": "Just some random text, lorem ipsum text praesent tincidunt ipsum lipsum.",
      "imagePath": "images/cherries.jpg",
      "id": "c855"
    },
    {
      "id": "f332",
      "title": "Post # 9",
      "text": "Just some random text, lorem ipsum text praesent tincidunt ipsum lipsum.",
      "imagePath": "images/cherries.jpg",
      "views": 0
    },
    {
      "id": "406d",
      "title": "Post # 10",
      "text": "Just some random text, lorem ipsum text praesent tincidunt ipsum lipsum.",
      "imagePath": "images/cherries.jpg",
      "views": 0
    }
  ],
  "comments": [
    {
      "id": "1",
      "text": "a comment about post 1",
      "postId": "1"
    },
    {
      "id": "2",
      "text": "another comment about post 1",
      "postId": "1"
    }
  ],
  "profile": {
    "name": "typicode"
  }
}
```
Now we are ready to fetch data from our json-server.

1. Create a module `rest.mjs`
2. Export an async function `getDataFrom(url)`
   
```JavaScript
export async function getDataFrom(url) {
    try {
      const response = await fetch(url);
      if (!response.ok) {
        throw new Error(`Response status: ${response.status}`);
      }
  
      const json = await response.json();
      return json
    } catch (error) {
      console.error(error.message);
    }
  }
```
There is not too much magic happening here. Lets check the details:

1. All code is surrounded by a `try`-`catch` block to catch possible errors like malformed headers, cors problems, etc. If such an error occurs we log it into the console. A pretty fair first approach since most of these errors are developer errors and should not occur when the website finally is in production.
2. The standard `fetch` method (defined in the web standard) is called. Note that `fetch` is async (no big surprise since we get something from an external source) and we have to `await` the response.
3. The response contains all necessary data, meta (diagnostic) data as well as the actual payload (the data we eventually want to display in our website). We check the response whether its ok or not. If not ok we throw an error.
4. At the end we get our actual payload in form of an array of JavaScript objects and return this to our caller.

Now we can call this function in the `onload` trigger and check whether data is properly loaded.
```JavaScript
import { getData } from "./rest.mjs"
...
const entries = await getDataFrom('http://localhost:3000/posts')
console.log(entries)
```

### DOM Manipulation to Get Data Rendered
Finally we want to render the loaded data into our website. We start by analyzing the structure of the blog display part in `index.html`. We see that all blog entries are placed in a `div` container (the one after the comment line `<!-- !PAGE CONTENT! -->`).

The two rows are again represented by a `div` which itself contains four cells (one for every blog entry) again represented by a `div`.

The top container is a good anchor to place our blog entries dynamically with JavaScript. In order to be able to address it we give it an id, say `food-grid`. All other stuff inside this container will be generated dynamically, therefore we can remove it. Do not deleted it entirely in a first step since we need the structure to reconstruct everything now via JavaScript.

Now lets prepare the rendering functionality. For this we add a new file called `html-renderer.mjs` to our project. This module exports a function `renderBlogEntries` accepting the previously loaded blog entries from our REST server. It queries the `div`-container and then takes slices of 4 to render one grid line (function `renderOneGridLine`).

The function `renderOneGridLine` accepts a parameter `blogEntries` (having a slice of 4 entries). It constructs the proper `div`-structure (as previously seen in the html file), renders one grid cell (function `renderOneGridCell`) and appends it to the before created `div`.

Finally, `renderOneGridCell` accepts a parameter holding one blog entry, creates the proper html structure for one grid cell and puts the whole grid cell together.

We do not explain to many details here since we want to concentrate on the REST part of the project. The rendering code finally looks like as follows.

```JavaScript
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
```

### JavaScript Fetch API to Change Data in Backend
Now we want to add the functionality that one can like a blog entry. So we have to add
- an icon suggesting that we can like an entry
- the functionality to react on a click on this icon
- the REST call to store our click on the server

### Add an Icon
 First we put the usual like images (an [empty](./REST/public/images/heart-empty.png) and a [filled heart](./REST/public/images/heart-red.png)) into our image folder. Now we are ready to add the code to generate the html for showing the like symbol. Since there is already some complexity in it we extract it in a separate function. The function accepts a `blogEntry` as parameter. Based on this it can implement the logic to display a filled or empty heart symbol. The remainder of the function is straight forward CSS fiddling to place the like symbol properly.

 ```Javascript
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
  return likeSymbol
}
 ```

### React on a Click on the Like Icon

 ```Javascript #14-20
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
    if (blogEntry.likes > 0) {
      likeSymbol.src='images/heart-empty.png'
      blogEntry.likes = 0
    } else {
      likeSymbol.src='images/heart-red.png'
      blogEntry.likes = 1
    }
  })
  return likeSymbol
}
 ```

[Complete Documentation](https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API/Using_Fetch)