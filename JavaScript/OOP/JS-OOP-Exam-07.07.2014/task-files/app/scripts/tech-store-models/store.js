define(['tech-store-models/item'], function (Item) {
    var Store;
    Store = (function () {
        function Store(name) {
            this.name = name;
            validateName.call(this);
            this._items = [];
        }

        function validateName() {
            if (!(this.name.length > 5 && this.name.length < 41)) {
                throw new Error('The name of the store must be between 6 and 40 characters');
            }
        }

        Store.prototype.addItem = function (item) {
            if (!(item instanceof Item)) {
                throw {
                    message: 'Cannot add item different from type Item'
                };
            }
            this._items.push(item);
            return this;
        };

        Store.prototype.getAll = function () {
            //slice() returns a copy of the array
            return sortItemsAlphabetically(this._items).slice();
        };

        Store.prototype.getSmartPhones = function () {
            //filterItems() returns a copy of the array
            return filterItems(this._items, ['smart-phone']);
        };

        Store.prototype.getMobiles = function () {
            //filterItems() returns a copy of the array
            return filterItems(this._items, ['smart-phone', 'tablet']);
        };

        Store.prototype.getComputers = function () {
            //filterItems() returns a copy of the array
            return filterItems(this._items, ['pc', 'notebook'])
        };

        Store.prototype.filterItemsByType = function (filterType) {
            //filterItems() returns a copy of the array
            return filterItems(this._items, [filterType]);
        };

        Store.prototype.filterItemsByPrice = function (options) {
            if (!options) {
                options = {
                    min: 0,
                    max: Infinity
                }
            }
            var minPrice = options.min || 0;
            var maxPrice = options.max || +Infinity;

            var itemsToReturn = [];
            this._items.forEach(function (item) {
                if (item.price >= minPrice && item.price <= maxPrice) {
                    itemsToReturn.push(item);
                }
            });

            return itemsToReturn.sort(function (first, second) {
                return first.price - second.price;
            })
        };

        Store.prototype.countItemsByType = function () {
            var associativeArray = {};

            for (var i = 0; i < this._items.length; i += 1) {
                var currentType = this._items[i].type;
                if (associativeArray[currentType]) {
                    associativeArray[currentType]++;
                }
                else {
                    associativeArray[currentType] = 1;
                }
            }

            return associativeArray;
        };

        Store.prototype.filterItemsByName = function (partOfName) {
            var collectionToReturn = [];

            this._items.forEach(function(item) {
                var itemName = item.name.toLowerCase();

                if(itemName.indexOf(partOfName) >= 0) {
                    collectionToReturn.push(item);
                }
            });

            return sortItemsAlphabetically(collectionToReturn);
        };

        //private functions

        function filterItems(arrayOfItems, types) {
            var itemsToReturn = [];

            arrayOfItems.forEach(function (item) {
                for (var i = 0; i < types.length; i += 1) {
                    if (item.type === types[i]) {
                        itemsToReturn.push(item);
                    }
                }
            });

            return sortItemsAlphabetically(itemsToReturn);
        }

        function sortItemsAlphabetically(array) {
            return array.sort(function (first, second) {
                if (first.name < second.name)
                    return -1;
                if (first.name > second.name)
                    return 1;
                return 0;
            });
        }

        return Store;
    }());

    return Store;
});