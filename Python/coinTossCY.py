import random

def coinToss(reps):
  attemptCount = 1
  headCount = 0
  tailsCount = 0
  result = ""
  
  for x in range(1, reps):
    toss = random.randint(0, 1)
    if (toss == 1):
      headCount += 1
      result = "heads"
      print "Attempt #", attemptCount, ": Throwing a coin....It's", result, "...Got", headCount, "head(s) so far and", tailsCount, "tail(s) so far"
    else:
      tailsCount += 1
      result = "tails"
      print "Attempt #", attemptCount, ": Throwing a coin....It's", result, "...Got", headCount, "head(s) so far and", tailsCount, "tail(s) so far"
    attemptCount += 1

coinToss(11)