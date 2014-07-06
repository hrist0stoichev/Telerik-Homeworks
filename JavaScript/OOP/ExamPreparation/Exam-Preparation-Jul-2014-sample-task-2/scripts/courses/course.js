define(function () {
    var Course;
    Course = (function () {
        function Course(title, scoreFormula) {
            this._title = title;
            this._scoreFormula = scoreFormula;
            this._students = [];
        }

        Course.prototype.addStudent = function (student) {
            this._students.push(student);
        };

        Course.prototype.calculateResults = function () {
            var self = this;

            this._students.forEach(function (student) {
                student.totalResult = self._scoreFormula(student);
            });
        };

        Course.prototype.getTopStudentsByExam = function (count) {
            return sortStudentsBy(this._students, 'exam', count)
        };

        Course.prototype.getTopStudentsByTotalScore = function (count) {
            return sortStudentsBy(this._students, 'totalResult', count);
        };

        function sortStudentsBy(students, valueToSortBy, count) {
            students.sort(function (first, second) {
                return second[valueToSortBy] - first[valueToSortBy]
            });

            return students.slice(0, count);
        }

        return Course;
    }());

    return Course;
});