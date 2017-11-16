#create class Animal with following attributes: name and health
    #Animal methods:
        #1: walk: decreases health -1
        #2: run: decreases health -5
        #3: displayHealth: print animal's health to terminal
    #**create instance of Animal class that: walks x3, runs x2, displays health**

#create subclasses Dog, Dragon
    #Dog attributes: initial health of 150
    #Dog methods:
        #pet: health increases +5
    
    #Dragon attributes: initial health of 170
    #Dragon methods: 
        #fly: decreases health -10
        #displayHealth: calls parent method, and prints 'I am a dragon'

#confirmations for subclasses:
    #Dragons cannot pet; Dogs cannot fly or display 'I am a dragon'


# -----------------------
# - ANIMAL CLASS CREATE -
# -----------------------

class Animal(object):
    def __init__(self, name):
        self.name = name
        self.health = 100

    def walk(self):
        self.health -= 1
        return self
    
    def run(self):
        self.health -= 5
        return self

    def displayHealth (self):
        print 'My name is ' + self.name
        print 'I have ' +str(self.health)+ ' health'

#-----------------------
#- DOG SUBCLASS CREATE -
#-----------------------

class Dog(Animal):
    def __init__(self, name):
        super(Dog,self).__init__(name)
        self.health = 150

    def pet(self):
        self.health += 5
        return self

#--------------------------
#- DRAGON SUBCLASS CREATE -
#--------------------------

class Dragon(Animal):
    def __init__(self, name):
        super(Dragon, self).__init__(name)
        self.health = 170

    def fly(self):
        self.health -= 10
        return self
    
    def displayHealth(self):
        print 'I am a dragon'
        super(Dragon, self).displayHealth()

#--------------------------
#- INSTANCE CREATION/TEST -
#--------------------------

dog = Dog('Clifford')
dog.walk().walk().run().pet().pet().walk().displayHealth() #should be 152

dragon = Dragon('Hiccup')
dragon.walk().run().fly().fly().fly().displayHealth() #should be 134