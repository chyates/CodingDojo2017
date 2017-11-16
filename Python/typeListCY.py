l1 = [3, 'bananas', 'are', 5, 9, 'dying']
l2 = [5,17,-3,8,99] #sum is 126
l3 = ['song', 'ice', 'fire']
sum = 0
list_str = ''

test_list = l1
for item in test_list:
  if type(item) is int:
    sum += item
  else:
    list_str += item + ' '
print sum
print 'String: ' + list_str
if all(isinstance(item, int) for item in test_list):
  print 'The list you entered is of integer type'
elif all(isinstance (item, str) for item in test_list):
  print 'The list you entered is of string type'
else:
  print 'The list you entered is mixed'