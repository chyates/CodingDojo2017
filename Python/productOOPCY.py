#create Class 'product' with attributes: price, name, weight, brand, sell status (default is 'for sale')
#methods: 
    #1: displayInfo: display all product details
    #2: sell: change sell status to 'sold'
    #3: addTax: takes tax as decimal amount and outputs price of item including tax
    #4: itemReturn: takes reason for return as parameter and changes sell status accordingly
        #if item being returned bc defective, change price to 0
        #if returned in box (unopened), mark 'for sale'
        #if returned in box (opened), mark 'used' and apply 20% discount (ie. 80% of price)

class Product(object):
    def __init__(self, price, name, weight, brand, sell_status):
        self.price = price
        self. name = name
        self.weight = weight
        self.brand = brand
        self.sell_status = sell_status

    def  displayInfo(self):
        print 'Price: $'+str(self.price)
        print 'Item Name: '+self.name
        print 'Weight: '+str(self.weight)+ ' lbs'
        print 'Brand: '+self.brand
        print 'Status: '+self.sell_status

    def sell(self):
        print 'Selling...'
        sell_status = 'Sold'
        print sell_status
    
    def addTax(self,tax):
        print 'Adding tax...'
        price = self.price*(1-tax)
        print 'Price: $' + str(price)
    
    def itemReturn(self,reason):
        print 'Returning...'
        if reason == 'Defective':
            sell_status = 'Defective'
            price = 0
        elif reason == 'Opened':
            sell_status = 'Used'
            price = self.price*0.80
        else:
            pass
        print 'Status: '+ sell_status
        print 'Price: $'+ str(price)

item1 = Product(1.50, 'Banana', 0.5, 'Dole', 'For Sale')
item1.displayInfo()
item1.addTax(0.1)
item1.sell()
item1.itemReturn('Defective')
