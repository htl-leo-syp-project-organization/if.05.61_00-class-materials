class TimeFormatted extends HTMLElement {
    connectedCallback() {
        let date = new Date(this.getAttribute('datetime') || Date.now())
        this.innerHTML = `On ${date.toDateString()} at ${date.toTimeString()}`
    }

    static get observedAttributes() {
        return ['datetime']
    }

    attributeChangedCallback(name, oldValue, newValue) {
        let date = new Date(newValue)
        this.innerHTML = `On ${date.toDateString()} at ${date.toTimeString()}`
    }
}

customElements.define('time-formatted', TimeFormatted)

