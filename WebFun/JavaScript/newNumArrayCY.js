function newNumArray (arr) {
  var arrnew = [];
  for (var i=0; i<arr.length; i++) {
    if (typeof(arr[i]) === "number"){
      arrnew.push(arr[i]);
      }
    }
  return arrnew;
}

newNumArray ([1,4,"tree", "smoke", 7]);