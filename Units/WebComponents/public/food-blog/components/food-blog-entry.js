import { attachStylesheetTo } from '../utilities.mjs'

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
        attachStylesheetTo(this)
        this.cloneAndAppendTemplate()
        const data = this.getDataFromElement()
        this.populateChildElementsWith(data)
    }

    getDataFromElement() {
        const jsonData = this.querySelector('script')
        let element = {}
        if (jsonData) {
            element = JSON.parse(jsonData.childNodes[0].nodeValue)
        }
        return element
    }

    cloneAndAppendTemplate() {
        const clone=document.importNode(template.content, true)
        this.shadowRoot.appendChild(clone)
    }

    populateChildElementsWith(data) {
        this.shadowRoot.querySelector('img').src=data.imageUrl
        this.shadowRoot.querySelector('h2').textContent=data.title
        this.shadowRoot.querySelector('p').textContent=data.text
        const button = this.shadowRoot.querySelector('button')
        button.addEventListener('click', () => {
            button.classList.toggle('liked')
        })
    }
}

customElements.define('food-blog-entry', FoodBlogEntry);
