import { attachStylesheetTo } from '../js/general/utilities.mjs'

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
class FoodBlogEntryView extends HTMLElement {
    connectedCallback() {
        this.attachShadow({mode: 'open'})
        attachStylesheetTo(this)
        this.cloneAndAppendTemplate()
        this.queryAllElements()
        this.addClickHandlerToLikeButton()
        this.data = this.getDataFromElement()
    }

    addClickHandlerToLikeButton() {
        this.button.addEventListener('click', () => {
            this.data.liked=!this.data.liked
        })
    }

    cloneAndAppendTemplate() {
        const clone=document.importNode(template.content, true)
        this.shadowRoot.appendChild(clone)
    }

    queryAllElements() {
        this.image = this.shadowRoot.querySelector('img')
        this.headline = this.shadowRoot.querySelector('h2')
        this.text = this.shadowRoot.querySelector('p')
        this.button = this.shadowRoot.querySelector('button')
    }

   getDataFromElement() {
        const jsonData = this.querySelector('script')
        let element = {}
        if (jsonData) {
            element = JSON.parse(jsonData.childNodes[0].nodeValue)
        }
        return element
    }

    populateChildElements() {
        const actualData = this.data
        this.image.src=actualData.imageUrl
        this.headline.textContent=actualData.title
        this.text.textContent=actualData.text
        if (actualData.liked) {
            this.button.classList.add('liked')
        } else {
            this.button.classList.remove('liked')
        }
    }

    set data(newValue) {
        this._data = new Proxy(newValue, {
            set: (target, property, value) => {
                target[property] = value
                this.populateChildElements()
                return true
            }
        })
        this.populateChildElements()
    }

    get data() {
        return this._data
    }
}

customElements.define('food-blog-entry', FoodBlogEntryView);
