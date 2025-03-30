export class ViewModel extends EventTarget {
    notify() {
      this.dispatchEvent(new Event('change'));
    }
  
    subscribe(callback) {
      this.addEventListener('change', callback);
    }
  
    unsubscribe(callback) {
      this.removeEventListener('change', callback);
    }
  }
  