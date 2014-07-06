define(function () {
    var Student;
    Student = (function () {
        function Student(info) {
            this.name = info.name;
            this.exam = info.exam;
            this.homework = info.homework;
            this.attendance = info.attendance;
            this.teamwork = info.teamwork;
            this.bonus = info.bonus;
        }

        return Student;
    }());

    return Student;
});