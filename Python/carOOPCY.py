#create Class 'car' with attributes: price, speed, fuel, mileage
    #if price > 10000, tax = 15% of price
    #else, tax = 12%
#methods:
    #displayAll(): shows properties of each instance

#instances: create 6

class Car(object):
    def __init__(self, price, speed, fuel, mileage):
        self.price = price
        self.speed = speed
        self.fuel = fuel
        self.mileage = mileage
        if price > 10000:
            self.tax = 0.15
        else:
            self.tax = 0.12
        self.displayAll()
    
    def displayAll(self):
        print 'Price: ' + str(self.price)
        print 'Speed: ' + str(self.speed) + ' mph'
        print 'Fuel: ' + self.fuel
        print 'Mileage: ' +str(self.mileage) + ' mpg'
        print 'Tax: ' + str(self.tax)

#six instances of Car class
car1 = Car(7500, 90, 'Half Full', 45)
car2 = Car(12500, 120, 'Full', 65)
car3 = Car(9000, 75, 'Quarter Full', 30)
car4 = Car(6200, 100, 'Mostly Full', 25)
car5 = Car(13000, 85, 'Full', 40)
car6 = Car(1200, 60, 'Empty', 15)
