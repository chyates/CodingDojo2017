students = [ 
    {'first_name':  'Michael', 'last_name' : 'Jordan'},
    {'first_name' : 'John', 'last_name' : 'Rosales'},
    {'first_name' : 'Mark', 'last_name' : 'Guillen'},
    {'first_name' : 'KB', 'last_name' : 'Tonel'}
]

users = {
 'Students': [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'},
     {'first_name' : 'Mark', 'last_name' : 'Guillen'},
     {'first_name' : 'KB', 'last_name' : 'Tonel'}
  ],
 'Instructors': [
     {'first_name' : 'Michael', 'last_name' : 'Choi'},
     {'first_name' : 'Martin', 'last_name' : 'Puryear'}
  ]
 }

#print student names, part I
def print_students(arr):
    for student in students:
        print student['first_name'], student['last_name']

#print student + instructor names, plus a count and the length of their names, part II
def printStudentsInstructors(users):
    for role in users: #for each role in the dictionary users (ie. 'students' or 'instructors')
        count = 0 #start the count variable at 0
        print role #print the role (either students or instructors)
        for person in users[role]: #for each key/value pair in the designated role...
            count += 1 #increase the count variable by 1...
            firstName = person['first_name'].upper() #...create a variable called 'firstName' which takes the value of the first name at key person, formatted in upper case...
            lastName = person['last_name'].upper() #...and create a variable called 'lastName' which takes the value of last name at key person, formatted in upper case...
            length = len(firstName) + len(lastName) #...and create a variable called 'length' which is equal to the length of firstName plus the length of lastName
            print "{} - {} {} - {}".format(count, firstName, lastName, length) #...finally print all of this formatted with dashes in between

print_students(students)
printStudentsInstructors(users)
