word_coll = ['Tomorrow', 'is', 'a', 'different', 'day']
char = 'd'
new_coll = []

for item in word_coll:
  if char in item:
    new_coll.append(item)
  else:
    pass
  
print new_coll