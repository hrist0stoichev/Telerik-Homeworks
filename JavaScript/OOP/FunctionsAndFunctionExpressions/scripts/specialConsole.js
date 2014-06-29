var specialConsole = function () {
    function formatString(args) {
        if (args[1]) {
            for (var i = 1; i < args.length; i++) {
                args[0] = args[0].replace('{' + (i - 1) + '}', args[i]);
            }
        }

        return args[0];
    }

    function writeLine() {
        console.log(formatString(arguments).toString());
    }

    function writeWarning() {
        console.warn(formatString(arguments).toString());
    }

    function writeError() {
        console.error(formatString(arguments).toString());
    }

    return {
        writeLine: writeLine,
        writeWarning: writeWarning,
        writeError: writeError
    }
}();

specialConsole.writeLine('Message: hello');
specialConsole.writeLine('Message: {0}', 'hello');
specialConsole.writeError('Error: {0}', 'Something happened');
specialConsole.writeWarning('Warning: {0}', 'A warning');
