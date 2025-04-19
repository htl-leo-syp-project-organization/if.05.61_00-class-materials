import { attachStylesheetTo } from "../js/general/utilities.mjs"

const template = document.createElement('template')
template.innerHTML = `
    <style>
    </style>
    <div class="w3-row-padding w3-padding-16 w3-center">
    </div>
`
class HStack extends HTMLElement {
    set viewModel(newValue) {
        this._viewModel = newValue
        this.addChildElements()
    }

    addChildElements() {
        const actualData = this._viewModel
        const childTemplate = this._childTemplateNode

        actualData.forEach((child) => {
            const childTemplateClone = document.importNode(childTemplate, true)
            childTemplateClone.foodBlogEntry = child
            this.shadowRoot.appendChild(childTemplateClone)    
        })
    }

    connectedCallback() {
        this.attachShadow({mode: 'open'})
        attachStylesheetTo(this)
        this.cloneAndAppendTemplate()
        this.prepareChildTemplate()
    }

    cloneAndAppendTemplate() {
        const clone=document.importNode(template.content, true)
        this.shadowRoot.appendChild(clone)
    }

    prepareChildTemplate() {
        const childTemplate = this.querySelector('*')
        this._childTemplateNode = childTemplate.cloneNode(true)
        childTemplate.remove()
    }
}

customElements.define('h-stack', HStack)
