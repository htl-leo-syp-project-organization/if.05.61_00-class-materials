export function attachStylesheetTo(element) {
    const link=document.createElement('link')
    link.setAttribute('rel', 'stylesheet')
    link.setAttribute('href', 'https://www.w3schools.com/w3css/4/w3.css')
    element.shadowRoot.appendChild(link)
}
