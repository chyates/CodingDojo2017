import turtle
def drawDoDec(size):
  angle = 30
  for side in range (12):
    turtle.forward(size)
    turtle.right(angle)
  return
drawDoDec (80)