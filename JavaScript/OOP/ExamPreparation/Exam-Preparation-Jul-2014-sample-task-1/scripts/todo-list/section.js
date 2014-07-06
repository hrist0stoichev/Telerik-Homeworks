define(function () {
    'use strict';
    var Section;
    Section = (function () {
        function Section(title) {
            this._title = title;
            this._items = [];
        }

        Section.prototype.add = function(item) {
            this._items.push(item);
        };

        Section.prototype.getData = function() {
            return {
                title: this._title,
                items: this._items.map(function (item) {
                    return item.getData()
                })
            };
        };

        return Section;
    }());
    return Section;
});