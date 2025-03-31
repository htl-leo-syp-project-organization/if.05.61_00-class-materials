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
    constructor() {
        super()
    }

    set foodBlogEntry(newValue) {
        this._viewModel = newValue
        this._viewModel.subscribe(() => {
            this.populateChildElements()
        })
        this.populateChildElements()
    }

    connectedCallback() {
        this.attachShadow({mode: 'open'})
        attachStylesheetTo(this)
        this.cloneAndAppendTemplate()
        this.queryAllElements()
        this.addClickHandlerToLikeButton()
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

    addClickHandlerToLikeButton() {
        this.button.addEventListener('click', () => {
            this._viewModel.toggleLike()
        })
    }
    
    populateChildElements() {
        const actualData = this._viewModel.data
        this.image.src=actualData.imageUrl
        this.headline.textContent=actualData.title
        this.text.textContent=actualData.text
        if (actualData.liked) {
            this.button.classList.add('liked')
        } else {
            this.button.classList.remove('liked')
        }
    }
}

customElements.define('food-blog-entry', FoodBlogEntryView);
