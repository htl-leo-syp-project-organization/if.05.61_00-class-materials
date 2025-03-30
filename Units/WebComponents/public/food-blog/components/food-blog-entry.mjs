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
        this.queryAllElements()
        this.button.addEventListener('click', () => {
            console.log('button clicked')
            this.data.liked = !this.data.liked
        })
        this.data = this.getDataFromElement()
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

    populateChildElementsWith(data) {
        this.shadowRoot.querySelector('img').src=data.imageUrl
        this.shadowRoot.querySelector('h2').textContent=data.title
        this.shadowRoot.querySelector('p').textContent=data.text
        const button = this.shadowRoot.querySelector('button')
        if (data.liked) {
            button.classList.add('liked')
        } else {
            button.classList.remove('liked')
        }
        console.log('data.liked:', data.liked)
    }

    set data(newValue) {
        this._data = new Proxy(newValue, {
            set: (target, property, value) => {
                target[property] = value
                this.populateChildElementsWith(this.data)
                return true
            }
        })
        this.populateChildElementsWith(this.data)
    }

    get data() {
        return this._data
    }
}

customElements.define('food-blog-entry', FoodBlogEntry);
