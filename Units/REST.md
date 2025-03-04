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

### JavaScript Fetch API to Get Data from Server
Now we are ready to fetch data from our json-server.

1. Create a module `rest.mjs`
2. Export an async function `getData(fromUrl)`
   
```JavaScript
export async function getData(fromUrl) {
    try {
      const response = await fetch(fromUrl);
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
[Complete Documentation](https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API/Using_Fetch)