function getChange (cents) {
  var quarters = (cents - (cents % 25))/25;
  cents %= 25;
  var dimes = (cents - (cents % 10))/10;
  cents %= 10;
  var nickels = (cents - (cents % 5))/5;
  cents %= 5;
  return quarters + " quarters, " + dimes + " dimes, " + nickels + " nickels, " + cents + " pennies."
}

getChange (42);

// to step through equation for 42:
//   var quarters = (42 - (42 % 25))/25;
//     var quarters = (42 - (17))/25;
//     var quarters = (25/25)
//     var quarters = 1;
//   cents %= 25;
//     cents = cents % 25
//     cents = 17;
//   var dimes = (17 - (17 % 10))/10;
//     var dimes = (17-(7)) / 10;
//     var dimes = (7) / 10;
//     var dimes = 1;
//   cents %= 10;
//     cents = cents % 10
//     cents = 17 % 10;
//     cents = 7;
//   var nickels = (cents - (cents % 5))/5;
//     var nickels = (7 - (7 % 5))/5;
//     var nickels = (7 - 2)/5
//     var nickels = 5/5;
//   var nickels = 1;
//   cents %= 5;
//     cents = cents % 5;
//     cents = 7 % 5;
//     cents(aka pennies) = 2;
//   return quarters + "quarters", dimes + "dimes", nickels + "nickels", cents + "pennies"
//   return 1 quarter, 1 dime, 1 nickel, 2 pennies YEP