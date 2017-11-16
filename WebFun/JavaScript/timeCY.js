{
  var HOUR = 6;
  var MINUTE = 10;
  var PERIOD = "AM";
  
  if (PERIOD == 'AM') {
    if (MINUTE < 30) {
      console.log('just after', HOUR, 'in the morning');
      }
    else if (MINUTE > 30) {
      console.log ('almost ', HOUR+1, 'in the morning');
      }
  }
  
  else if (PERIOD == 'PM'){
    if (MINUTE < 30) {
      console.log('just after ', HOUR, 'in the evening');
    }
  else if (MINUTE > 30) {
      console.log ('almost ', HOUR+1, 'in the evening');
    }
  }
}