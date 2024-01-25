let table = document.getElementById("table")
let name = document.getElementById("name")
let surname = document.getElementById("surname")
let age = document.getElementById("age")


function insertIntoTable() {
    let personName = name.value;
    let personSurname = surname.value;
    let personAge = parseFloat(age.value);
    let person = new Person(personName, personSurname, personAge);
    let index = person.length;
    personSurname.push(person);
    let row = table.insertRow();
    let cell = row.insertCell();
    cell.innerText = personName;
    cell = row.insertCell();
    cell.innerText = personSurname;
    cell = row.insertCell();
    cell.innerText = person.age;
    cell = row.insertCell();
    let button = document.createElement("input");
    button.type = "button";
    button.value = "Zobrazit"
    button.onclick = function(){
        popup.show(person);
    }
    cell.appendChild(button)
    console.log(person.toString)
}


class Person {
    constructor(name, surname, age) {
        this.name = name;
        this.surname = surname;
        this.age = age;
        this.isAdult = age >= 18;
    }
    toString(){
        return "Name: " + this.name + " , Surname " + this.surname + " , Age " + this.age;
    }
}