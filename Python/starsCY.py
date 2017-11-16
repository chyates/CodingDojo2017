#draw stars function (part 1)
def drawStars (array):
  for x in array:
    print x *"*"

arrTest = [3,7,2,4]
drawStars(arrTest)

#draw stars for integers/strings function (part II)
def drawStarsString (array):
  for x in array:
    if isinstance(x, int):
      print x * "*"
    elif isinstance (x,str):
      length = len(x)
      letter = x[0].lower()
      print letter * length

arrTest2 = [3, "Jill", 9, "Apple", "Bottle", 7]
drawStarsString(arrTest2)