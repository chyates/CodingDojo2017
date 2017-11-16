#odd or even function
def odd_even():
  for x in range(1, 2001):
    if (x % 2 == 0):
      print "Number is", x, ". This is an even number."
    else:
      print "Number is", x, ". This is an odd number."
      
odd_even()

#multiply list function
def multiply(arr, num):
  for i in range(0, len(arr)):
    arr[i] *= num
  return arr

my_list = [3,7,1,12,9]
print multiply(my_list, 4)

#hacker function (nested multiply)
def hacker(arr): #defines function, w/ parameter of an array
    arrToo = [] #creates new variable arrToo as an empty list
    for x in arr: #for each value in the original list...
        arrVal = [] #create a new variable called arrVal, which is an empty list...
        for i in range(0,x): #...and for each index of that arrVal, which should run as long as the amount of indices in the original list...
            arrVal.append(1) #...insert the value of 1 to each index in arrVal
        arrToo.append(arrVal) #...and insert all values (aka new lists for each value in original array) in arrVal to arrToo
    return arrToo #return final result of arrToo

y = hacker(multiply([5,8,7],2)) #calls the function with argument of the multiply function, which takes arguments of an array and a number to multiply it by
print y #will execute multiply function and get an array of [10, 16, 14], which then becomes the new array (arrToo) that runs through the hacker function