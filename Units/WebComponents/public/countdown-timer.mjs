class CountdownTimer extends HTMLElement {
    connectedCallback() {
        this.endDate = new Date(this.getAttribute('end-date'))
        this.prefixText = this.innerHTML.trim()
        this.update()
        this.timer = setInterval(() => this.update(), 1000)
    }
    update() {
        const now = new Date()
        const remaining = this.endDate - now
        if (remaining <= 0) {
            clearInterval(this.timer)
            this.innerHTML = 'Countdown expired'
        } else {
            const seconds = Math.floor(remaining / 1000) % 60
            const minutes = Math.floor(remaining / 1000 / 60) % 60
            const hours = Math.floor(remaining / 1000 / 60 / 60) % 24
            const days = Math.floor(remaining / 1000 / 60 / 60 / 24)
            this.innerHTML = `${this.prefixText} ${days} days, ${hours} hours, ${minutes} minutes, ${seconds} seconds`
        }
    }

    disconnectedCallback() {
        clearInterval(this.timer)
    }
}

customElements.define('countdown-timer', CountdownTimer)
