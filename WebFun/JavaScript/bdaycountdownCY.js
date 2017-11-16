{
  var bday = 252;
  while (bday > 0) {
    if (bday > 30) {
      console.log(bday + " days until my birthday. Too long!");
    }
    
    else if (bday < 5) {
      console.log(bday+ ' days until my birthday. AHHH!')
    }
    
    else if (bday <= 30) {
      console.log(bday +' days until my birthday. So soon!');
    }
    
  bday -= 1;
  }
  console.log('ITS MY BIRTHDAY!!');
}