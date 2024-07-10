let salaries = {
    John: 100,
    Ann: 160,
    Pete: 130
};

let sum = 0;

for (let key in salaries) {
    if (salaries.hasOwnProperty(key)) {
        sum += salaries[key];
    }
}

console.log(sum); // Output should be 390


function multiplyNumeric(obj) {
    for (let key in obj) {
        if (typeof obj[key] === 'number') {
            obj[key] *= 2;
        }
    }
}

let menu = {
    width: 200,
    height: 300,
    title: "My menu"
};

console.log("Before:", menu);

multiplyNumeric(menu);

console.log("After:", menu);

function checkEmailId(str) {
    str = str.toLowerCase();
    let atIndex = str.indexOf('@');
    let dotIndex = str.indexOf('.');
   
    if (atIndex > 0 && dotIndex > atIndex + 1) {
        return true;
    } else {
        return false;
    }
}

console.log(checkEmailId("example@example.com"));
console.log(checkEmailId("example.com@example"));
console.log(checkEmailId("example@.com"));
console.log(checkEmailId("example@examplecom"));
console.log(checkEmailId("example@exa.mple.com"));


function truncate(str, maxlength) {
    if (str.length > maxlength) {
        return str.slice(0, maxlength - 3) + '...';
    } else {
        return str;
    }
}

console.log(truncate("What I'd like to tell on this topic is:", 20));
console.log(truncate("Hi everyone!", 20));

let styles = ["James", "Brennie"];
console.log(styles);

styles.push("Robert");
console.log(styles); 

let middleIndex = Math.floor(styles.length / 2);
styles[middleIndex] = "Calvin";
console.log(styles);


let firstElement = styles.shift();
console.log(firstElement); 
console.log(styles); 

styles.unshift("Rose", "Regal");
console.log(styles); 