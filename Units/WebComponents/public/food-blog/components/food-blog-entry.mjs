import { ViewModel } from "../js/general/view-model.mjs";

export class FoodBlogEntry extends ViewModel {
    constructor(initialData) {
        super()
        this._data = new Proxy(initialData, {
            set: (target, property, value) => {
                target[property] = value
                this.notify()
                return true;
            }
        })
    }

    get data() {
        return this._data
    }

    toggleLike() {
        this._data.liked = !this._data.liked
    }
}
