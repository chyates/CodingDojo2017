class MathDojo(object):
    def __init__(self):
        self.total = 0

    def add(self, num1, num2):
        self.total += num1+num2
        return self

    def subtract(self, num1, num2):
        self.total -= num1+num2
        return self

md = MathDojo()
md.add(2,4)
