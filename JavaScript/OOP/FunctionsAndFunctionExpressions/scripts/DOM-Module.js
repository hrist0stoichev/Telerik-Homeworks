var dom = function () {
    var buffer = {};

    function addElement(element, selector) {
        var parentElement = getElementsByCSSSelector(selector);
        parentElement.append(element);
    }

    function removeElements(element, selector) {
        var elementsToRemove = getElementsByCSSSelector(selector).find(element);
        elementsToRemove.remove();
    }

    function attachEvent(event, selector, func) {
        var selectedElement = getElementsByCSSSelector(selector);
        if (selectedElement.length > 1) {
            var parentElement = selectedElement.parent();
            parentElement.on(event, selector, func);
        }
        else {
            selectedElement.on(event, func);
        }
    }

    function appendToBuffer (element, selector) {
        for (var obj in buffer) {
            if (obj == selector) {
                buffer[obj].push(element);
                if (buffer[obj].length == 100) {
                    $(selector).append(buffer[obj]);
                    buffer[obj] = [];
                }

                return;
            }
        }

        buffer[selector] = [element];
    }

    function getElementsByCSSSelector(selector) {
        return $(selector);
    }

    return {
        addElement: addElement,
        removeElements: removeElements,
        attachEvent: attachEvent,
        getElementsByCSSSelectors: getElementsByCSSSelector,
        appendToBuffer: appendToBuffer
    }
}();

dom.addElement($('<ul>'), '#container');
dom.addElement($('<li>'), 'ul');
dom.addElement($('<li>'), 'ul');
dom.addElement($('<li>'), 'ul');
dom.addElement($('<li>'), 'ul');

dom.removeElements('li:first-child', 'ul');

dom.attachEvent('click', 'li', function () {
    $currentLi = $(this);
    $currentLi.parent().find('li').empty();
    $currentLi.text('success');
});

var elementsGettedByCSSSelector = dom.getElementsByCSSSelectors('li');
console.log(elementsGettedByCSSSelector);

dom.appendToBuffer($('<li>'), 'ul');
dom.appendToBuffer($('<li>'), 'ul');
dom.appendToBuffer($('<p>'), '#container');
dom.appendToBuffer($('<p>'), '#container');