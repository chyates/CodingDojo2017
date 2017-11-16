#create class Bike with properties: price, max_speed, miles
#THEN, create 3 instances of Bike
#THEN, use __init__ function to specify price & max_speed of each instance, & write code to reset miles to 0 whenever a new instance is created
#THEN, add functions to class:
    #1: displayInfo(): shows properties we created of specific instance
    #2: ride(): display "Riding..." on the screen and increase total miles ridden by 10
    #3: reverse(): display "Reversing..." on the screen and decrease total miles ridden by 5
#FOR INSTANCES:
    #INSTANCE 1: ride 3x, reverse 1x, displayInfo
    #INSTANCE 2: ride 2x, reverse 2x, displayInfo
    #INSTANCE 3: reverse 3x, displayInfo

#create class Bike:
class Bike(object):
    def __init__(self, price, max_speed):
        self.price = price
        self.max_speed = max_speed
        self.miles = 0

    def displayInfo(self):
        print 'Price is $'+str(self.price)
        print 'Max speed is '+ str(self.max_speed)+' mph'
        print 'Total miles ridden are '+str(self.miles)+' miles'
    def ride(self):
        print 'Riding...'
        self.miles += 10
    def reverse(self):
        print 'Reversing...'
        self.miles -= 5

#create 3 instances of Bike class

#instance 1 functions
bike1 = Bike(800, 50)
bike1.ride()
bike1.ride()
bike1.ride()
bike1.reverse()
bike1.displayInfo()

#instance 2 functions
bike2 = Bike(100, 15)
bike2.ride()
bike2.ride()
bike2.reverse()
bike2.reverse()
bike2.displayInfo()

#instance 3 functions
bike3 = Bike(450, 30)
bike3.reverse()
bike3.reverse()
bike3.reverse()
bike3.displayInfo()