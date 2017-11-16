import random

def scores_grades(reps):
    print "Scores and Grades"
    for x in range (0, reps):
        score = random.randint(60, 100)
        if score >= 60 and score <= 69:
            print "Score:", score, "Your grade is a D."
        elif score >= 70 and score <= 79:
            print "Score:", score, "Your grade is a C."
        elif score >= 80 and score <= 89:
            print "Score:", score, "Your grade is a B."
        else:
            print "Score:", score, "Your grade is an A."
    print "End of the program. Bye!"

print scores_grades(10)

#session['result'] == 'You got it! ' +str(num_guess)+ ' was the number!'