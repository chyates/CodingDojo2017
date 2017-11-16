function chanceGame (quarters) {
  while (quarters > 0) {
    var myPlay = Math.floor(Math.random() * 100) + 1;
    var machinePlay = Math.floor(Math.random() * 100) + 1;
    if (myPlay === machinePlay) {
        var winOutput = Math.floor(Math.random() * 51) + 50;
        quarters += winOutput;
        console.log("You won! You have ", quarters+winOutput, "quarters!");
    }
    quarters--;
  }
  return 0;
}
chanceGame(25);