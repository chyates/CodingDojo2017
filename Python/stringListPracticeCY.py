Python 2.7.10 (default, May 23 2015, 09:44:00) [MSC v.1500 64 bit (AMD64)] on win32
Type "copyright", "credits" or "license()" for more information.
>>> words = "It's thanksgiving day. It's my birthday, too!"
>>> print words
It's thanksgiving day. It's my birthday, too!
>>> words.find("day)
	   
SyntaxError: EOL while scanning string literal
>>> print words.find("day)
		 
SyntaxError: EOL while scanning string literal
>>> print words.find("day")
18
>>> print words.replace ("day", "month")
It's thanksgiving month. It's my birthmonth, too!
>>> y = [2,5,8,-12,99]
>>> print max(y)
99
>>> print min(y)
-12
>>> z = [1, "praying", 2, "woman", "let go", 3]
>>> print z[0], z[len(z)-1]
1 3
>>> x = [19,2,54,-2,7,12,98,32,10,-3,6]
>>> x.sort()
>>> print x
[-3, -2, 2, 6, 7, 10, 12, 19, 32, 54, 98]
>>> first_list = x[:len(x)/2]
>>> second_list = x[leng(x)/2:]

Traceback (most recent call last):
  File "<pyshell#15>", line 1, in <module>
    second_list = x[leng(x)/2:]
NameError: name 'leng' is not defined
>>> second_list = x[len(x)/2:]
>>> print "first list", first_list
first list [-3, -2, 2, 6, 7]
>>> print "second list", second_list
second list [10, 12, 19, 32, 54, 98]
>>> second_list.insert(0, first_list)
>>> print second_list
[[-3, -2, 2, 6, 7], 10, 12, 19, 32, 54, 98]
>>> 
