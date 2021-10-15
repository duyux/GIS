
define(["dojo/_base/declare"], function (declare) {
    return declare("namespace.Person", null, {
        name: null,
        age: null,
        constructor: function (name, age) {
            this.name = name;
            this.age = age;
        }
    })
})