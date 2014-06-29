var Canvas = (function () {
    function Canvas(selector) {
        this._selector = selector;
        this._canvas = document.querySelector(this._selector);
        this._ctx = this._canvas.getContext('2d');
    }

    Canvas.prototype = {
        drawRect: function(x, y, width, height) {
            this._ctx.beginPath();
            this._ctx.rect(x, y, width, height);
            this._ctx.closePath();
            this._ctx.stroke();
        },
        drawCircle: function(x, y, r) {
            this._ctx.beginPath();
            this._ctx.arc(x, y, r, 0, 2 * Math.PI);
            this._ctx.closePath();
            this._ctx.stroke();
        },
        drawLine: function(x1, y1, x2, y2) {
            this._ctx.beginPath();
            this._ctx.moveTo(x1, y1);
            this._ctx.lineTo(x2, y2);
            this._ctx.closePath();
            this._ctx.stroke();
        }
    };

    return Canvas;
}());

var testCanvas = new Canvas('#the-canvas');

testCanvas.drawRect(50, 50, 50, 50);
testCanvas.drawCircle(250, 150, 50);
testCanvas.drawLine(50, 250, 400, 250);