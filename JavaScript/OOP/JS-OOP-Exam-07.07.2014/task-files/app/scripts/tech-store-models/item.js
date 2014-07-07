define(function () {
    'use strict';
    var Item;
    Item = (function () {
        function Item(type, name, price) {
            this.type = type;
            validateType.call(this);
            this.name = name;
            validateName.call(this);
            this.price = price;
            validatePrice.call(this);
        }

        function validateType() {
            if (!(this.type === 'accessory' || this.type === 'smart-phone' || this.type === 'notebook' || this.type === 'pc' || this.type === 'tablet')) {
                throw new Error('Type can have only the following values: "accessory", "smart-phone", "notebook", "pc" or "tablet".');
            }
        }

        function validateName() {
            if (!(this.name.length > 5 && this.name.length < 41)) {
                throw new Error('The name of the item must be between 6 and 40 characters');
            }
        }

        function validatePrice() {
            if(!(typeof this.price === 'number' && this.price >= 0)) {
                throw new Error('The price of the item must be decimal floating-point number bigger than 0');
            }
        }

        return Item;
    }());

    return Item;
});