for count in range(1,1000,2):
    print count
#prints all numbers within a range from 1 to 1000 with a skip-value of 2

for count in range(1,10000001,5):
    print count
#prints all numbers within a range from 5 to 10000001 (to include 1 million) with a skip-value of 5

x = [1, 2, 5, 10, 255, 3]
sum = 0
for i in x:
  sum += i
print sum
#sets a variable x equal to a list of values
#sets a variable sum equal to 0
#create a for loop to iterate through each index in variable x
#every time the loop iterates, it increases the value of sum by the value of i
#prints the final value of sum

a = [1, 2, 5, 10, 255, 3]
sum = 0
avg = 0
for i in a:
  sum += i
  avg = sum/len(a)
print avg
#sets a variable a equal to a list of values
#sets a variable sum equal to 0
#sets a variable avg equal to 0
#create a for loop to iterate through each index in variable a
#every time the loop iterates, it increases the value of sum by the value of i
#every time the loop iterates, it resets the value of avg to be sum divided by the length of a
#prints the final value of avg