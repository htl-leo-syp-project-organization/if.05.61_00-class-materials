const template = document.createElement('template')
template.innerHTML = `
    <style>
      article {
        border: 1px solid #ccc;
        padding: 1rem;
        border-radius: 0.5rem;
        font-family: sans-serif;
      }
      img {
        max-width: 100%;
      }
      button {
        cursor: pointer;
        border: none;
        background: none;
        font-size: 1.5rem;
        color: gray;
      }
      button.liked {
        color: red;
      }
    </style>
    <article class="w3-quarter w3-padding-16">
      <img part="image">
      <h2 part="title"></h2>
      <p part="text"></p>
      <button part="like">♥</button>
    </article>
`
class FoodBlogEntry extends HTMLElement {
    connectedCallback() {
        this.attachShadow({mode: 'open'})

        const link = document.createElement('link')
        link.setAttribute('rel', 'stylesheet')
        link.setAttribute('href', 'https://www.w3schools.com/w3css/4/w3.css')
        this.shadowRoot.appendChild(link)

        const clone = document.importNode(template.content, true)
        this.shadowRoot.appendChild(clone)
        const data = JSON.parse(this.querySelector('script').childNodes[0].nodeValue)
        this.shadowRoot.querySelector('img').src = data.imageUrl
        this.shadowRoot.querySelector('h2').textContent = data.title
        this.shadowRoot.querySelector('p').textContent = data.text
        this.shadowRoot.querySelector('button').addEventListener('click', () => {
            this.shadowRoot.querySelector('button').classList.toggle('liked')
        })
    }
}

customElements.define('food-blog-entry', FoodBlogEntry);
