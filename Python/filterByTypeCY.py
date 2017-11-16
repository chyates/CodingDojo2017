sI = 45
mI = 100
bI = 455
eI = 0
spI = -23
sS = "Rubber baby buggy bumpers"
mS = "Experience is simply the name we give our mistakes"
bS = "Tell me and I forget. Teach me and I remember. Involve me and I learn."
eS = ""
aL = [1, 7, 4, 21]
mL = [3, 5, 7, 34, 3, 2, 113, 65, 8, 89]
lL = [4, 34, 22, 68, 9, 13, 3, 5, 7, 9, 2, 12, 45, 923]
eL = []
spL = ['name', 'address', 'phone number', 'social security number']

now_test = sS  # creates new variable to plug in one from list
# creates new variable equal to the type of the variable contained w/in now_test
now_type = type(now_test)
if now_type is int:  # if the type of now_type is an integer...
    if now_test >= 100:  # ...and if it's greater than 100....
        print "That's a big number!"  # print this message
    else: #if the type of now_type is an integer and it's less than 100...
        print "That's a small number!" #print this message
elif now_type is str: #if the type of now_type is a string...
    if len(now_test) >= 50: #...and if the length of that string is greather than or equal to 50 characters...
        print "Long sentence." #print this message
    else: #if the length is less than 50 characters...
        print "Short sentence." #print this message
elif isinstance(now_test, list): #if now_test is a list...
    if len(now_test) >= 10: #...and the length of the list is greather than or equal to 10 values...
        print "Big list!" #print this message
    else: #if the length is less than 10 values...
        print "Short list!" #print this message
