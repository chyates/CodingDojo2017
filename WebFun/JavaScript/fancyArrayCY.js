function fancyArray() {
    var arr = ["James", "Jill", "Jane", "Jack"];
    var sym = '->';
    for (var i=0; i<arr.length; i++) {
        console.log(i + sym + arr[i]);
    }
}

fancyArray();