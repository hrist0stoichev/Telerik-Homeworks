var movingShapes = function () {
    var DEFAULT_SIZE = 30 + 'px',
        SPEED = 1,
        RECTX = 400,
        RECTY = 250,
        TOP = 50,
        LEFT = 50,
        INTERVAL = 1,
        ELLX = 100,
        ELLY = 50,
        ELLR = 150;

    function addShape (movementType) {
        var div = appendStyles($('<div>'));

        if (movementType == 'rect') moveRect(div);
        else if (movementType == 'ellipse') moveEllipse(div)
    }

    function appendStyles (element) {
        return element.css({
            width: DEFAULT_SIZE,
            height: DEFAULT_SIZE,
            border: getRandomNumber(0, 10) + 'px solid ' + getRandomColor(),
            background: getRandomColor(),
            position: 'absolute',
            left: LEFT + 'px',
            top: TOP + 'px',
        });
    }

    function getRandomNumber (start, end) {
        return Math.floor(Math.random() * (end - start) + start);
    }

    function getRandomColor() {
        return '#' + ('00000' + (Math.random() * 16777216 << 0).toString(16)).substr(-6);
    }

    function moveRect(div) {
        div.appendTo('body');
        var isMovingRight  = true,
            isMovingDown = true;

        function move() {
            if(isMovingRight && isMovingDown) {
                if (parseInt(div.css('left')) + SPEED <= RECTX) {
                    div.css('left', parseInt(div.css('left')) + SPEED);
                }
                else {
                    isMovingRight = !isMovingRight;
                }
            }
            else if (!isMovingRight && isMovingDown) {
                if (parseInt(div.css('top')) + SPEED <= RECTY) {
                    div.css('top', parseInt(div.css('top')) + SPEED);
                }
                else {
                    isMovingDown = !isMovingDown;
                }
            }
            else if (!isMovingRight && !isMovingRight) {
                if (parseInt(div.css('left')) - SPEED >= LEFT) {
                    div.css('left', parseInt(div.css('left')) - SPEED);
                }
                else {
                    isMovingRight = !isMovingRight;
                }
            }
            else if (isMovingRight && !isMovingDown) {
                if (parseInt(div.css('top')) - SPEED >= TOP) {
                    div.css('top', parseInt(div.css('top')) - SPEED);
                }
                else {
                    isMovingDown = !isMovingDown;
                }
            }
        }

        setInterval(move, INTERVAL);
    }

    function moveEllipse (div) {
        div.appendTo('body');
        var totalMove = 0;

        function move() {
            totalMove ++;
            if (totalMove == 360) {
                totalMove = 0;
            }

            var left = (ELLX + Math.cos(Math.PI / 90 * totalMove)) * ELLR;
            var top = 2 * (ELLY + Math.sin(Math.PI / 90 * totalMove) * ELLR);
            div.css({
                left: left + 'px',
                top: top + 'px'
            });
        }

        setInterval(move, INTERVAL + 10);
    }

    return{
        add: addShape
    }
}();

movingShapes.add('rect');
movingShapes.add('ellipse');